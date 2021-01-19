using Music.Models.froogh_asgari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Repository
{
    public class UserRepo : User
    {
        static List<User> users = new List<User>();


        public void Insert(User user)
        {

            if (!users.Any(x => x.EmailAddress == user.EmailAddress))
            {
                users.Add(user);
            }
            else
            {
                return;
            }

        }
    }
}
