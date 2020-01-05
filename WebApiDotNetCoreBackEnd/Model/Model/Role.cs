using Model.Contract;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Role : IDomainEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int IdRole { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
