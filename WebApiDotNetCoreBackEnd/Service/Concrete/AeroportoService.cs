using Common.AeroportoViewModels;
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

namespace Service.Concrete
{
    public class AeroportoService : IAeroportoService
    {
        //private IAeroportosRepository _aeroportoRepo;
        private IMapper _mapper;
        private ILog _log;
        private IUnitOfWork _unitOfWork;

        public AeroportoService(
            IMapper mapper, 
            //IAeroportosRepository aeroportoRepo,
            ILog log,
            IUnitOfWork unitOfWork
            )
        {
            _mapper = mapper;
            //_aeroportoRepo = aeroportoRepo;
            _log = log;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<AeroportosViewModel>> BuscarAeroportos()
        {
            try
            {
                var aeroportos = await _unitOfWork.AeroportosRepository.GetAsync();//_aeroportoRepo.BuscarTodosAsync();

                return aeroportos.MapToViewModel<AeroportosViewModel>(_mapper);
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }   
        }
    }
}
