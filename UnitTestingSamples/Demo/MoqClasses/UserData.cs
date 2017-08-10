using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.MoqClasses
{
    public class UserData : IUserData
    {
        public string Username { get; set; }
        public DateTime BornDate { get; set; }

        public string GetUserData() => $"{Username} {BornDate:MM/dd/yyyy}";
        public string GetUserData(string param) => $"{Username} {BornDate:MM/dd/yyyy} {param}";
        public string InsertUserData(SomeUserData param)
        {
            if(param == null)
                throw new ArgumentException();

            //Do something

            return string.Empty;
        }
    }
}
