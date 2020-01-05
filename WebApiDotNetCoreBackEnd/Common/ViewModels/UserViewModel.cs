using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Common.ViewModels
{
    public class UserViewModel
    {
        public long IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string RolesList { get; set; }
        public bool UpdatePassword { get; set; }

        public List<RoleViewModel> Roles { get; set; }

    }
}
