using Model.Contract;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class UserRole : IDomainEntity
    {
        public int IdUserRole { get; set; }
        public int? IdUser { get; set; }
        public int? IdRole { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
