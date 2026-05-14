using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    public class User
    {
        public string Name { get; }
        public int UserId { get; }

        public User(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }
    }

}
