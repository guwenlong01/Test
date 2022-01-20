using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_Common
{
    public class RabbitMQHelper
    {
        public static IConnection GetConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "192.168.202.128",
                Port = 5672,
                UserName = "gwl",
                Password = "gwl",
                VirtualHost = "/"
            };
            return factory.CreateConnection();
        }
    }


}
