using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Service.Contract;
using Common.AeronaveViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeronaveController : ControllerBase
    {
        private IAeronaveService _aeronaveService;

        public AeronaveController(IAeronaveService repo) 
        {
            _aeronaveService = repo;
        }

        [HttpGet, Route("Matriculas")]
        public async Task<IEnumerable<MatriculasAeronavesViewModel>> BuscarMatriculasAeronaves()
        {
            return await _aeronaveService.BuscarMatriculas();
        }
    }
}
