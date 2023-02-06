using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        protected long sin;
        protected string birthdate;
        protected string department;

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            /* OR
             * get => name;
             */
        }
        public Employee()
        {

        }

        public Employee(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
