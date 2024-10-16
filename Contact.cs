using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerT3.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Contact(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{Name} - {Address} - {Phone}"; // 在列表框中显示姓名、住址和电话
        }
    }
}

