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

        public static int IDCounter = 1;
        public void Insert(User user)
        {

            if (!users.Any(x => x.EmailAddress == user.EmailAddress))
            {
                user.Id = IDCounter;
                users.Add(user);
                IDCounter++;
            }
            else
            {
                return;
            }

        }
    }
}
