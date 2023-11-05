using System;
using System.Collections.Generic;
using System.Text;

namespace TraVeL.Core.Models
{
    public class AccountDetails
    {
        private int _id;
        private string _username;
        private string _password;
        private int _type;

        public AccountDetails() { }

        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
