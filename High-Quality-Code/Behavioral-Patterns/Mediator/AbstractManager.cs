using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal abstract class AbstractManager
    { 
        protected ICollection<Employee> Employees { get; set; }

        /// <summary>
        /// Adds a new employee to the current manager's list.
        /// </summary>
        /// <param name="employee">An employee to be managed.</param>
        public abstract void Add(Employee employee);

        /// <summary>
        /// Removes an employee from the current manager's list.
        /// </summary>
        /// <param name="employee">Employee to be removed.</param>
        public abstract void Remove(Employee employee);

        /// <summary>
        /// Send message to single or many employees.
        /// </summary>
        /// <param name="message">A message to be sent</param>
        public abstract void Send(Message message);

        /// <summary>
        /// Send message to all employees who are managed by the current Manager.
        /// </summary>
        /// <param name="message">A message to be sent.</param>
        public abstract void SendToAll(Message message);
    }
}
