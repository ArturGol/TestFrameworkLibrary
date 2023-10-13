using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkLibrary.Models
{
    public class ContactsUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public List<string> categories { get; set; }
    }
}
