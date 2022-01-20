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
    public class DirectConsumer
    {
        public static void Direct() {
            var connection = RabbitMQHelper.GetConnection();
            var channel = connection.CreateModel();
            var exchangeName = "direct-exchange";
            //声明一个交换机
            channel.ExchangeDeclare(exchangeName, "direct");
            //定义一个队列
            var queueName1 = "direct-queue1";
            channel.QueueDeclare(queueName1, false, false, false, null);
            var queueName2 = "direct-queue2";
            channel.QueueDeclare(queueName2, false, false, false, null);
            var queueName3 = "direct-queue3";
            channel.QueueDeclare(queueName3, false, false, false, null);
            //绑定交换机（没有意义）
            channel.QueueBind(queueName1, exchangeName, "red", null);
            channel.QueueBind(queueName2, exchangeName, "yellow", null);
            channel.QueueBind(queueName3, exchangeName, "green", null);
            //队列执行好了，不用等待其他队列完（机器强的多执行）
            channel.BasicQos(0,1,false);
            //声明一个消费事件
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                var message = ea.Body;
                var body = Encoding.UTF8.GetString(message.ToArray());
                var routingKey = ea.RoutingKey;
                channel.BasicAck(ea.DeliveryTag, true);
                Console.WriteLine($"[direct] body:{body} routingKey:{routingKey}");
            };
            channel.BasicConsume(queueName3, false, consumer);
        }
    }
}
