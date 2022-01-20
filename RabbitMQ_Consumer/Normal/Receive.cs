using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ_Consumer.Normal
{
    public class Receive
    {
        public static void ReceiveMessage()
        {

            //消费者消费的是队列中的消息（和生产者的队列名称一致）
            string queueName = "Normal";

            var connection = RabbitMQHelper.GetConnection();
            //创建信道
            var channel = connection.CreateModel();
            //定义一个队列：如果先启动的消费端，就会有异常（找不到这个队列）
            channel.QueueDeclare(queueName, false, false, false, null);
            //创建一个事件对象消费
            var consumer = new EventingBasicConsumer(channel);
            /*
             设置prefetchCount:1来告知RabbitMQ，在未收到消费端的消息确认时，
            不再分发消息,ss也确保了当前消费
            */
            channel.BasicQos(prefetchSize:0, prefetchCount:1, false);
            //绑定一个委托
            consumer.Received += (model, ea) => {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine($"消费：{message}");
                Thread.Sleep(1000);
            };
            //消费的时候绑定consumer回调
            channel.BasicConsume(queueName, true, consumer);
        }
    }
}
