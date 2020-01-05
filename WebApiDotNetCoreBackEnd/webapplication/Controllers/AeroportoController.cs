using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Service.Contract;
using Common.AeroportoViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportoController : ControllerBase
    {
        private IAeroportoService _aeroportoService;

        public AeroportoController(IAeroportoService repo) 
        {
            _aeroportoService = repo;
        }

        [HttpGet, Route("BuscarTodos")]
        public async Task<IEnumerable<AeroportosViewModel>> BuscarAeroportos()
        {
            return await _aeroportoService.BuscarAeroportos();
        }
    }
}
