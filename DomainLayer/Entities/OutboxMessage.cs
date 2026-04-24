using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class OutboxMessage
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string Payload { get; set; }
        public bool IsProcessed { get; set; } = false;
    }
}
