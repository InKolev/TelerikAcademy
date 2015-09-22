using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Employee
    {
        public Employee(string name, Manager manager)
        {
            this.Name = name;
            this.Manager = manager;
            this.Mailbox = new List<Message>();
        }

        private List<Message> Mailbox { get; set; }

        public Manager Manager { get; set; }

        public string Name { get; set; }

        public void Send(Message message)
        {
            this.Manager.Send(message);
        }

        public void SendToAll(Message message)
        {
            this.Manager.SendToAll(message);
        }

        public void ReceiveMessage(Message message)
        {
            this.Mailbox.Add(message);

            Console.WriteLine("A message from {0} was received in the mailbox of {1}.", message.Sender, this.Name);
        }
    }
}