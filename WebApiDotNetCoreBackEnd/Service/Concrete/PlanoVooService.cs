using Common.PlanoDeVooViewModels;
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

namespace Service.Concrete
{
    public class PlanoVooService : IPlanoVooService
    {
        //private IPlanoVooRepository _planoVooRepo;
        private IMapper _mapper;
        private ILog _log;
        private IUnitOfWork _unitOfWork;

        public PlanoVooService(
            IMapper mapper, 
            //IPlanoVooRepository planoVooRepo,
            ILog log,
            IUnitOfWork unitOfWork
            )
        {
            _mapper = mapper;
            //_planoVooRepo = planoVooRepo;
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PlanoVooViewModel>> BuscarPlanosVoos()
        {
            try
            {
                var planosVoo = await _unitOfWork.PlanoVooRepository.GetAsync(null, null, 
                    p => p.Aeronave,
                    p => p.Aeronave.TipoAeronave,
                    p => p.AeroportoDestino,
                    p => p.AeroportoOrigem );
                return planosVoo.MapToViewModel<PlanoVooViewModel>(_mapper);
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<bool> NumeroVooCadastradoAsync(string numero)
        {
            try
            {
                var planovoo = await _unitOfWork.PlanoVooRepository.GetAsync(p => p.Numerovoo == numero);
                return planovoo != null && planovoo.Count() > 0;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                throw;
            }
        }

        public async Task<bool> Salvar(PlanoVooViewModel model)
        {
            try
            {
                if (model.IdPlanoVoo == 0)
                {
                    await _unitOfWork.PlanoVooRepository.InsertAsync(_mapper.Map<PlanoVoo>(model));
                }
                else
                    _unitOfWork.PlanoVooRepository.Update(_mapper.Map<PlanoVoo>(model));
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }

        public async Task<bool> Excluir(PlanoVooViewModel model)
        {
            try
            {
                _unitOfWork.PlanoVooRepository.Delete(_mapper.Map<PlanoVoo>(model));
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }
    }
}
