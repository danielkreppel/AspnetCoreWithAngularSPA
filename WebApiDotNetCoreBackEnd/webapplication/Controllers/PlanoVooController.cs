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

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoVooController : ControllerBase
    {
        private IPlanoVooService _planoVooService;
        private ILog _log;

        public PlanoVooController(IPlanoVooService repo, ILog log) 
        {
            _planoVooService = repo;
            _log = log;
        }

        [HttpGet]
        [Route("PlanosDeVoo")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<IEnumerable<PlanoVooViewModel>> BuscarPlanosVoo()
        {
            return await _planoVooService.BuscarPlanosVoos();
        }

        [HttpPost]
        [Route("PlanoDeVoo/Salvar")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<JsonReturnViewModel> SalvarPlanoVoo([FromBody]PlanoVooViewModel model)
        {
            try
            {
                if (model.IdPlanoVoo == 0 && await _planoVooService.NumeroVooCadastradoAsync(model.NumeroVoo))
                {
                    return new JsonReturnViewModel { Error = true, Message = "Número do vôo digitado já existe." };
                }
                else if (!await _planoVooService.Salvar(model))
                {
                    return new JsonReturnViewModel{ Error = true };
                }

                return new JsonReturnViewModel { Error = false };
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return new JsonReturnViewModel { Error = true };
            }
            
        }

        [HttpPost]
        [Route("PlanoDeVoo/Excluir")]
        [Authorize(Roles = "Gerente,Funcionario")]
        public async Task<JsonReturnViewModel> ExcluirPlanoVoo([FromBody]PlanoVooViewModel model)
        {
            try
            {
                if (!await _planoVooService.Excluir(model))
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
