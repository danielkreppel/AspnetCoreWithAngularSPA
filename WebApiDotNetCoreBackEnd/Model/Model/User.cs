using Model.Contract;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class User : IDomainEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
