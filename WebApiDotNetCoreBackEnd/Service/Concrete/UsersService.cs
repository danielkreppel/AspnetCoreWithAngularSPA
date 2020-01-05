using Common.ViewModels;
using Common.Extensions;
using AutoMapper;
using Data.Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Log.Contract;
using Repository.Contract;
using Model;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Service.Helpers;

namespace Service.Concrete
{
    public class UsersService : IUsersService
    {
        private IMapper _mapper;
        private ILog _log;
        private IUnitOfWork _unitOfWork;

        public UsersService(
            IMapper mapper, 
            ILog log,
            IUnitOfWork unitOfWork
            )
        {
            _mapper = mapper;
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            try
            {
                var users = await _unitOfWork.UsersRepository.GetAsync(null, null, u => u.UserRoles);
                var usersViewModel = users.MapToViewModel<UserViewModel>(_mapper);

                foreach(var userVM in usersViewModel)
                {
                    userVM.Roles = new List<RoleViewModel>();
                    userVM.Roles.AddRange(users.First(u => u.IdUser == userVM.IdUser).UserRoles.Select(ur => new RoleViewModel { IdRole = ur.IdRole.Value, Description = ur.Role.Description}));
                }

                return usersViewModel;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<IEnumerable<RoleViewModel>> GetRolesAsync()
        {
            try
            {
                var roles = await _unitOfWork.RolesRepository.GetAsync(null, null);

                return roles.MapToViewModel<RoleViewModel>(_mapper);
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var usuario = await _unitOfWork.UsersRepository.GetAsync(u => u.Email == email, null, u => u.UserRoles);

                return usuario.FirstOrDefault();
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<bool> SaveAsync(UserViewModel model)
        {
            try
            {                
                if (model.IdUser == 0)
                {
                    PassInfo pass = new SimpleHash().HMACSHA1(model.Password);
                    var usuario = _mapper.Map<User>(model);
                    usuario.Salt = pass.Salt;
                    usuario.Password = pass.Password;
                    
                    await _unitOfWork.UsersRepository.InsertAsync(usuario);
                }
                else
                {
                    var usuario = await _unitOfWork.UsersRepository.GetByIDAsync((int)model.IdUser);
                    usuario.Name = model.Name;
                    usuario.Email = model.Email;
                    //Incluir userroles no uow repository, remover userroles e adicionar denovo
                    //foreach(var role in usuario.UserRoles)
                    //{
                    //    await _unitOfWork.UserRolesRepository.Delete(role.);
                    //}
                    
                    if (model.UpdatePassword)
                    {
                        PassInfo pass = new SimpleHash().HMACSHA1(model.Password);
                        usuario.Salt = pass.Salt;
                        usuario.Password = pass.Password;
                    }
                    _unitOfWork.UsersRepository.Update(usuario);
                }
                    
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }

        public async Task<bool> RemoveAsync(UserViewModel model)
        {
            try
            {
                var user = await _unitOfWork.UsersRepository.GetByIDAsync((int)model.IdUser);
                user.Active = false;

                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }

        public async Task<bool> UserAlreadyRegisteredAsync(string email)
        {
            try
            {
                var usuario = await _unitOfWork.UsersRepository.GetAsync(p => p.Email == email);
                return usuario != null && usuario.Count() > 0;
            }
            catch (Exception e)
            {
                _log.LogError(e);
                throw;
            }
        }
    }
}
