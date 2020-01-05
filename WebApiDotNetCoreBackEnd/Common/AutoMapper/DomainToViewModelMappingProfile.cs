using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Common.PlanoDeVooViewModels;
using Common.AeronaveViewModels;
using Common.AeroportoViewModels;
using Model;
using Common.ViewModels;

namespace Common.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //CreateMap<PlanoVoo, PlanoVooViewModel>()
            //.ForMember(dest => dest.IdPlanoVoo, opts => opts.MapFrom(src => src.IDPLANOVOO))
            //.ForMember(dest => dest.NumeroVoo, opts => opts.MapFrom(src => src.NUMEROVOO))
            //.ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.DATA))
            //.ForMember(dest => dest.IdAeronave, opts => opts.MapFrom(src => src.IDAERONAVE))
            //.ForMember(dest => dest.IdAeroportoOrigem, opts => opts.MapFrom(src => src.IDAEROPORTOORIGEM))
            //.ForMember(dest => dest.IdAeroportoDestino, opts => opts.MapFrom(src => src.IDAEROPORTODESTINO))
            //.ForMember(dest => dest.Matricula, opts => opts.MapFrom(src => src.MATRICULA))
            //.ForMember(dest => dest.TipoAeronave, opts => opts.MapFrom(src => src.TIPOAERONAVE))
            //.ForMember(dest => dest.Origem, opts => opts.MapFrom(src => src.ORIGEM))
            //.ForMember(dest => dest.Destino, opts => opts.MapFrom(src => src.DESTINO));

            //CreateMap<Aeronave, MatriculasAeronavesViewModel>()
            //.ForMember(dest => dest.IdAeronave, opts => opts.MapFrom(src => src.IDAERONAVE))
            //.ForMember(dest => dest.Matricula, opts => opts.MapFrom(src => src.MATRICULA))
            //.ForMember(dest => dest.IdTipoAeronave, opts => opts.MapFrom(src => src.IDTIPOAERONAVE));

            //CreateMap<Aeroporto, AeroportosViewModel>()
            //.ForMember(dest => dest.IdAeroporto, opts => opts.MapFrom(src => src.IDAEROPORTO))
            //.ForMember(dest => dest.Sigla, opts => opts.MapFrom(src => src.SIGLA));

            CreateMap<PlanoVoo, PlanoVooViewModel>()
            .ForMember(dest => dest.IdPlanoVoo, opts => opts.MapFrom(src => src.Idplanovoo))
            .ForMember(dest => dest.NumeroVoo, opts => opts.MapFrom(src => src.Numerovoo))
            .ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.Data))
            .ForMember(dest => dest.IdAeronave, opts => opts.MapFrom(src => src.Idaeronave))
            .ForMember(dest => dest.IdAeroportoOrigem, opts => opts.MapFrom(src => src.Idaeroportoorigem))
            .ForMember(dest => dest.IdAeroportoDestino, opts => opts.MapFrom(src => src.Idaeroportodestino))
            .ForMember(dest => dest.Matricula, opts => opts.MapFrom(src => src.Aeronave.Matricula))
            .ForMember(dest => dest.TipoAeronave, opts => opts.MapFrom(src => src.Aeronave.TipoAeronave.Descricao))
            .ForMember(dest => dest.Origem, opts => opts.MapFrom(src => src.AeroportoOrigem.Sigla))
            .ForMember(dest => dest.Destino, opts => opts.MapFrom(src => src.AeroportoDestino.Sigla));

            CreateMap<Aeronaves, MatriculasAeronavesViewModel>()
            .ForMember(dest => dest.IdAeronave, opts => opts.MapFrom(src => src.Idaeronave))
            .ForMember(dest => dest.Matricula, opts => opts.MapFrom(src => src.Matricula))
            .ForMember(dest => dest.IdTipoAeronave, opts => opts.MapFrom(src => src.Idtipoaeronave));

            CreateMap<Aeroportos, AeroportosViewModel>()
            .ForMember(dest => dest.IdAeroporto, opts => opts.MapFrom(src => src.Idaeroporto))
            .ForMember(dest => dest.Sigla, opts => opts.MapFrom(src => src.Sigla));

            CreateMap<User, UserViewModel>()
           .ForMember(dest => dest.IdUser, opts => opts.MapFrom(src => src.IdUser))
           .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
           .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
           .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
           .ForMember(dest => dest.RolesList, opts => opts.MapFrom(src => string.Join(", ", src.UserRoles.Select(u => u.Role.Description))));

            CreateMap<Role, RoleViewModel>()
            .ForMember(dest => dest.IdRole, opts => opts.MapFrom(src => src.IdRole))
            .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));
        }
    }
}
