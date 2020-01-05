using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Service.Contract;
using Common.PlanoDeVooViewModels;
using System.Threading.Tasks;
using Common.ViewModels;
using Common.Log.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;
        private ILog _log;
        private readonly IStringLocalizer<UsersController> _localizer;

        public UsersController(IUsersService service, ILog log, IStringLocalizer<UsersController> localizer) 
        {
            _usersService = service;
            _log = log;
            _localizer = localizer;
        }

        [HttpGet]
        [Route("Get/AllUsers")]
        [Authorize(Roles = "Gerente")]
        public async Task<IEnumerable<UserViewModel>> AllUsers()
        {
            return await _usersService.GetUsersAsync();
        }

        [HttpGet]
        [Route("Get/AllRoles")]
        [Authorize(Roles = "Gerente")]
        public async Task<IEnumerable<RoleViewModel>> AllRoles()
        {
            return await _usersService.GetRolesAsync();
        }

        [HttpPost]
        [Route("Save")]
        [Authorize(Roles = "Gerente")]
        public async Task<JsonReturnViewModel> Save([FromBody]UserViewModel model)
        {
            try
            {
                if (model.IdUser == 0 && await _usersService.UserAlreadyRegisteredAsync(model.Email))
                {
                    return new JsonReturnViewModel { Error = true, Message = _localizer["UserSameEmail"] };
                }
                else if (!await _usersService.SaveAsync(model))
                {
                    return new JsonReturnViewModel{ Error = true, Message = _localizer["GenericError"] };
                }

                return new JsonReturnViewModel { Error = false };
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return new JsonReturnViewModel { Error = true, Message = _localizer["GenericError"] };
            }
            
        }

        [HttpPost]
        [Route("Remove")]
        [Authorize(Roles = "Gerente")]
        public async Task<JsonReturnViewModel> Remove([FromBody]UserViewModel model)
        {
            try
            {
                if (!await _usersService.RemoveAsync(model))
                {
                    return new JsonReturnViewModel { Error = true };
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return new JsonReturnViewModel { Error = true };
            }
            return new JsonReturnViewModel { Error = false };
        }
    }
}
