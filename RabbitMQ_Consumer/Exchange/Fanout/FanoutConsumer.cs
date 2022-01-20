using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_Consumer
{
    public class FanoutConsumer
    {
        public static void Fanout() {

            var exchaneName = "fanout-exchange";
            var connection = RabbitMQHelper.GetConnection();
            var channel = connection.CreateModel();
            //声明交换机
            channel.ExchangeDeclare(exchaneName, "fanout");
            //定义队列
            string queueName1 = "fanout-queue1";
            channel.QueueDeclare(queueName1, false, false, false, null);
            string queueName2 = "fanout-queue2";
            channel.QueueDeclare(queueName2, false, false, false, null);
            string queueName3 = "fanout-queue3";
            channel.QueueDeclare(queueName3, false, false, false, null);

            //绑定交换机
            channel.QueueBind(queueName1, exchaneName, "", null);
            channel.QueueBind(queueName2, exchaneName, "", null);
            channel.QueueBind(queueName3, exchaneName, "", null);
            //队列执行好了，不用等待其他队列完（机器强的多执行）
            channel.BasicQos(0, 1, false);
            //创建一个对象进行消费
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                //消费完后需要手动签收消息，如果不写改代码容易造成重复消费问题
                channel.BasicAck(ea.DeliveryTag, true);//可以降低每次签收性能消耗
                Console.WriteLine($"[x] {message} ");
            };

            /*
             * autoAck 消费签收模式
             * False=手动签收：保证正确消费，不会丢消息（基于客户端而已）
             * True=自动签收：容易丢消息
             * 签收：意味着消息从队列中删除
            */
            //autoAck=False:消费完之后需要手动
            channel.BasicConsume(queueName3, autoAck:false, consumer);
            Console.WriteLine("结束");
        }
    }
}
