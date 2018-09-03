using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceTests.ControllerTests
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool AccountLocked { get; set; }
        //public virtual List<Role> Roles { get; set; }
    }

    public class UsersContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
    }

    public class UsersService
    {
        private readonly UsersContext usersContext;

        public UsersService(UsersContext usersContext)
        {
            this.usersContext = usersContext;
        }

        public User AddUser(string login, string name, string surname)
        {
            var newUser = this.usersContext.Users.Add(
                new User
                {
                    Login = login,
                    Name = name,
                    Surname = surname,
                    AccountLocked = false
                });

            this.usersContext.SaveChanges();
            return newUser;
        }

        public IList<User> GetLockedUsers()
        {
            return this.usersContext.Users.Where(x => x.AccountLocked).ToList();
        }
    }
}
