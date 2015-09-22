using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Message
    {
        public Message(string content, string sender)
        {
            this.Content = content;
            this.Sender = sender;
            this.Receivers = new List<string>();
            this.HasManyReceivers = true;
        }

        public Message(string content, string sender, string receiver)
        {
            this.Content = content;
            this.Sender = sender;
            this.Receiver = receiver;
        }

        public Message(string content, string sender, ICollection<string> receivers)
        {
            this.Content = content;
            this.Sender = sender;
            this.Receivers = receivers;
            this.HasManyReceivers = true;
        }

        public ICollection<string> Receivers { get; set; }

        public string Receiver { get; set; }

        public string Sender { get; private set; }

        public string Content { get; private set; }

        /// <summary>
        /// Indicates if the message has one or more receivers. Default value is "false".
        /// </summary>
        public bool HasManyReceivers { get; set; } = false;
    }
}
