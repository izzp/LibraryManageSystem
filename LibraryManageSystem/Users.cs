using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class Users
    {
        string account;
        string password;
        string name;
        string mobile;
        string email;
        string type;
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
