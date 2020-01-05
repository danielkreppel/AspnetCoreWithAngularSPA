using Common.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUsersService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<IEnumerable<RoleViewModel>> GetRolesAsync();
        Task<User> GetUserByEmailAsync(string email);

        Task<bool> SaveAsync(UserViewModel model);

        Task<bool> RemoveAsync(UserViewModel model);

        Task<bool> UserAlreadyRegisteredAsync(string email);

    }
}
