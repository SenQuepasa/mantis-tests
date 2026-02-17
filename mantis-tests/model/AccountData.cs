using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mantis_tests
{
    public class AccountData 
    {
        //public AccountData(string name, string email, string password)
        //{
        //    Name = name;
        //    Email = email;
        //    Password = password;
        //}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public bool Equals(AccountData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (Name == other.Name)
            {
                    return true;
            }
            return Name == other.Name;

        }
        public int CompareTo(AccountData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int nameComparison = Name.CompareTo(other.Name);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
            return Name.CompareTo(other.Name);
        }
      
    }

}
