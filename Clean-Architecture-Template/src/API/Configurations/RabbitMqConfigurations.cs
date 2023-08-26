using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Configurations
{
    public class RabbitMqConfigurations
    {
        public string AMQPHOSTNAME { get; set; }
        public string AMQPUSERNAME { get; set; }
        public string AMQPPASSWORD { get; set; }
        public string AMQPVIRTUALHOST { get; set; }
        public string AMQPEXCHANGENAME { get; set; }
        public string AMQPEXCHANGETYPE { get; set; }
    }
}