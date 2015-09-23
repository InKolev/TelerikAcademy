using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Manager : AbstractManager
    {
        public Manager(string name)
        {
            this.Name = name;
            this.Employees = new List<Employee>();
        }

        public string Name { get; set; }

        public override void Add(Employee employee)
        {
            this.Employees.Add(employee);
        }

        public override void Remove(Employee employee)
        {
            this.Employees.Remove(employee);
        }

        public override void Send(Message message)
        {
            if(message.HasManyReceivers)
            {
                var receivers = this.Employees
                    .Where(employee => message.Receivers.Contains(employee.Name))
                    .Select(employee => employee);

                foreach(var receiver in receivers)
                {
                    Console.WriteLine("{0} sent a message to {1}, through the manager.", message.Sender, receiver.Name);
                    receiver.ReceiveMessage(message);
                }
            }
            else
            {
                Console.WriteLine("{0} sent a message to {1}, through the manager.", message.Sender, message.Receiver);

                this.Employees
                    .Where(employee => employee.Name.Equals(message.Receiver))
                    .Select(employee => employee)
                    .First()
                    .ReceiveMessage(message);
            }
        }

        public override void SendToAll(Message message)
        {
            foreach (var employee in this.Employees)
            {
                if (!employee.Name.Equals(message.Sender))
                {
                    message.Receivers.Add(employee.Name);
                }
            }
            foreach (var employee in this.Employees)
            {
                if (!employee.Name.Equals(message.Sender))
                {
                    Console.WriteLine("{0} sent a message to {1}, through the manager.", message.Sender, employee.Name);
                    employee.ReceiveMessage(message);
                }
               
            }
        }
    }
}
