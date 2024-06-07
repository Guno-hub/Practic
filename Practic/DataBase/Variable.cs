using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Zapis
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Order { get; set; }
        public string DateD { get; set; }
    }
}
