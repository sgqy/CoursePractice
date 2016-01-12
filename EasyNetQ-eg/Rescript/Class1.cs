using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescript
{
    public class Message
    {
        public int order { get; private set; }
        public string content { get; private set; }
        public Message(int order, string content)
        {
            this.order = order;
            this.content = content;
        }
    }
}
