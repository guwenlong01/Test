using RabbitMQ_Consumer.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQ_Consumer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //普通队列模式
            //Receive.ReceiveMessage();
            //扇形消费
            //FanoutConsumer.Fanout();
            //完全匹配模式
            //DirectConsumer.Direct();
            //模糊匹配模式
            TopicConsumer.Topic();
            Console.WriteLine("消费启动");
            //Console.ReadKey();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
