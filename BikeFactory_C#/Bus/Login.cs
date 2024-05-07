using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Factory.Bus
{
    public class Login
    {
        private string user;
        private string password;
        public string User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public Login()
        {
            this.user = "Undefined";
            this.password = "Undefined";
        }
        public Login(string user, string password)
        {
            this.user = user;
            this.password = password;
        }
        public override string ToString()
        {
            return this.user + ", " + this.password;
        }
    }
}
