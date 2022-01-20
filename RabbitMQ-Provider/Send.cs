using RabbitMQ.Client;
using RabbitMQ_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQ_Provider
{
    public partial class Send : Form
    {
        public static int FCount = 0;
        public Send()
        {
            InitializeComponent();
        }

        private void btnFS_Click(object sender, EventArgs e)
        {
            FCount++;
            string queueName = "Normal";
            using (var connection = RabbitMQHelper.GetConnection())
            {
                //创建信道
                using (var channel = connection.CreateModel())
                {
                    //创建队列
                    channel.QueueDeclare(queueName, false, false, false, null);
                    string message = "Hello RabbitMQ Message "+ FCount;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", queueName, null, body);
                }
            }
        }

        /// <summary>
        /// 扇形（交换机）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFanout_Click(object sender, EventArgs e)
        {
            using (var connection = RabbitMQHelper.GetConnection()) 
            {
                using (var channel = connection.CreateModel())
                {
                    //声明交换机对象
                    channel.ExchangeDeclare("fanout-exchange", "fanout");
                    //创建队列
                    string queueName1 = "fanout-queue1";
                    channel.QueueDeclare(queueName1, false, false, false, null);
                    string queueName2 = "fanout-queue2";
                    channel.QueueDeclare(queueName2, false, false, false, null);
                    string queueName3 = "fanout-queue3";
                    channel.QueueDeclare(queueName3, false, false, false, null);
                    //绑定交换机
                    //fanout-exchange 绑定三个队列
                    channel.QueueBind(queue: queueName1, exchange: "fanout-exchange", routingKey: "");
                    channel.QueueBind(queue: queueName2, exchange: "fanout-exchange", routingKey: "");
                    channel.QueueBind(queue: queueName3, exchange: "fanout-exchange", routingKey: "");

                    for (int i = 0; i < 10; i++)
                    {
                        string message = $"fanout  {i + 1} Message";
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("fanout-exchange", "", null, body);

                    }
                }
            }
        }

        /// <summary>
        /// direct消费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndirect_Click(object sender, EventArgs e)
        {
            var exchangeName = "direct-exchange";
            var connection = RabbitMQHelper.GetConnection();
            var channel = connection.CreateModel();
            //声明交换机对象
            channel.ExchangeDeclare(exchangeName, "direct");
            //定义交换机对象
            var queueName1 = "direct-queue1";
            channel.QueueDeclare(queueName1, false, false, false, null);
            var queueName2 = "direct-queue2";
            channel.QueueDeclare(queueName2, false, false, false, null);
            var queueName3 = "direct-queue3";
            channel.QueueDeclare(queueName3, false, false, false, null);

            //绑定交换机
            channel.QueueBind(queueName1, exchangeName, "red", null);
            channel.QueueBind(queueName2, exchangeName, "yellow", null);
            channel.QueueBind(queueName3, exchangeName, "green", null);

            for (int i = 0; i < 10; i++) {
                var message = $"direct {i+1} =>green";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchangeName, "green", null, body);
            }
        }

        /// <summary>
        /// 模糊匹配模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopic_Click(object sender, EventArgs e)
        {
            var exchangeName = "topic-exchange";
            var connection = RabbitMQHelper.GetConnection();
            var channel = connection.CreateModel();
            //声明交换机对象
            channel.ExchangeDeclare(exchangeName, "topic");
            //定义交换机对象
            var queueName1 = "topic-queue1";
            channel.QueueDeclare(queueName1, false, false, false, null);
            var queueName2 = "topic-queue2";
            channel.QueueDeclare(queueName2, false, false, false, null);
            var queueName3 = "topic-queue3";
            channel.QueueDeclare(queueName3, false, false, false, null);

            //绑定交换机
            channel.QueueBind(queueName1, exchangeName, "user.data.*", null);
            channel.QueueBind(queueName2, exchangeName, "user.data.update", null);
            channel.QueueBind(queueName3, exchangeName, "user.data.delete", null);

            for (int i = 0; i < 10; i++)
            {
                var message = $"direct {i + 1} =>user.data.update";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchangeName, "user.data.delete", null, body);
            }

        }
    }
}
