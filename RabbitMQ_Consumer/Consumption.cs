using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_Common;
using RabbitMQ_Consumer.Normal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQ_Consumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 一般消费（1对1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXF_Click(object sender, EventArgs e)
        {
            #region 注释-不用
            /*
            //消费者消费的是队列中的消息（和生产者的队列名称一致）
            string queueName = "Worker_Queue";
            
            var connection = RabbitMQHelper.GetConnection();
            //创建通信渠道
            var channel = connection.CreateModel();
            //定义一个队列：如果先启动的消费端，就会有异常（找不到这个队列）
            channel.QueueDeclare(queueName,false,false,false,null);
            //创建一个事件对象消费
            var consumer = new EventingBasicConsumer(channel);
            //绑定一个委托
            consumer.Received += (model, ea) => {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                var aa = message;
            };
            //消费的时候绑定consumer回调
            channel.BasicConsume(queueName, true, consumer);
            */
            #endregion
            Receive.ReceiveMessage();
        }

        /// <summary>
        /// 扇形（交换机）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFanout_Click(object sender, EventArgs e)
        {
            FanoutConsumer.Fanout();
        }
    }
}
