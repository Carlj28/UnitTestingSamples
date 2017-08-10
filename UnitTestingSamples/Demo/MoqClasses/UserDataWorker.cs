using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.MoqClasses
{
    public class UserDataWorker
    {
        public string UpdateUser(IUserData data)
        {
            var response = data.GetUserData();

            if (String.IsNullOrEmpty(response))
                throw new ArgumentException();

            DoSomething(response);

            return response;
        }

        public string UpdateUser(IUserData data, string param)
        {
            var response = data.GetUserData(param);

            if (String.IsNullOrEmpty(response))
                throw new ArgumentException();

            DoSomething(response);

            return response;
        }

        private void DoSomething(string userData)
        {
            if(String.IsNullOrEmpty(userData))
                throw new ArgumentException();

            //
        }

        public void InsertData(IUserData data, SomeUserData sd)
        {
            data.InsertUserData(sd);
        }

        public void InsertData(IUserData data, IEnumerable<SomeUserData> sd)
        {
            foreach (var value in sd)
            {
                data.InsertUserData(value);
            }
        }
    }
}
