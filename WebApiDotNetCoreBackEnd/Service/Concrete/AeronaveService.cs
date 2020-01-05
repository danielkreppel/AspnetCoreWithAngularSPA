using Common.AeronaveViewModels;
using Common.Extensions;
using AutoMapper;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Log.Contract;
using Repository.Contract;

namespace Service.Concrete
{
    public class AeronaveService : IAeronaveService
    {
        //private IAeronavesRepository _aeronaveRepo;
        //private ITiposAeronavesRepository _tipoAeronaveRepo;   
        private IMapper _mapper;
        private ILog _log;
        private IUnitOfWork _unitOfWork;

        public AeronaveService(
            IMapper mapper, 
            //IAeronavesRepository aeronaveRepo,
            //ITiposAeronavesRepository tipoAeronaveRepo,
            ILog log,
            IUnitOfWork unitOfWork
            )
        {
            _mapper = mapper;
            //_aeronaveRepo = aeronaveRepo;
            //_tipoAeronaveRepo = tipoAeronaveRepo;
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MatriculasAeronavesViewModel>> BuscarMatriculas()
        {
            try
            {
                var aeronaves = await _unitOfWork.AeronavesRepository.GetAsync();//_aeronaveRepo.BuscarTodosAsync();
                var tiposAeronaves = await _unitOfWork.TiposAeronavesRepository.GetAsync();//_tipoAeronaveRepo.BuscarTodosAsync();
                var model = aeronaves.MapToViewModel<MatriculasAeronavesViewModel>(_mapper);

                foreach(var m in model)
                {
                    m.TipoAeronave = tiposAeronaves.Where(t => t.Idtipoaeronave == m.IdAeronave).FirstOrDefault()?.Descricao;
                }

                return model;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }
    }
}
