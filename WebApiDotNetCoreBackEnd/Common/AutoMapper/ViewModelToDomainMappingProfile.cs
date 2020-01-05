using Common.PlanoDeVooViewModels;
using Common.AeronaveViewModels;
using Common.AeroportoViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common.ViewModels;

namespace Common.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<PlanoVooViewModel, PlanoVoo>()
            //.ForMember(dest => dest.IDPLANOVOO, opts => opts.MapFrom(src => src.IdPlanoVoo))
            //.ForMember(dest => dest.NUMEROVOO, opts => opts.MapFrom(src => src.NumeroVoo))
            //.ForMember(dest => dest.DATA, opts => opts.MapFrom(src => src.Data))
            //.ForMember(dest => dest.IDAERONAVE, opts => opts.MapFrom(src => src.IdAeronave))
            //.ForMember(dest => dest.IDAEROPORTOORIGEM, opts => opts.MapFrom(src => src.IdAeroportoOrigem))
            //.ForMember(dest => dest.IDAEROPORTODESTINO, opts => opts.MapFrom(src => src.IdAeroportoDestino))
            //.ForMember(dest => dest.MATRICULA, opts => opts.MapFrom(src => src.Matricula))
            //.ForMember(dest => dest.TIPOAERONAVE, opts => opts.MapFrom(src => src.TipoAeronave))
            //.ForMember(dest => dest.ORIGEM, opts => opts.MapFrom(src => src.Origem))
            //.ForMember(dest => dest.DESTINO, opts => opts.MapFrom(src => src.Destino));

            CreateMap<PlanoVooViewModel, PlanoVoo>()
            .ForMember(dest => dest.Idplanovoo, opts => opts.MapFrom(src => src.IdPlanoVoo))
            .ForMember(dest => dest.Numerovoo, opts => opts.MapFrom(src => src.NumeroVoo))
            .ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.Data))
            .ForMember(dest => dest.Idaeronave, opts => opts.MapFrom(src => src.IdAeronave))
            .ForMember(dest => dest.Idaeroportoorigem, opts => opts.MapFrom(src => src.IdAeroportoOrigem))
            .ForMember(dest => dest.Idaeroportodestino, opts => opts.MapFrom(src => src.IdAeroportoDestino));
            //.ForMember(dest => dest.MATRICULA, opts => opts.MapFrom(src => src.Matricula))
            //.ForMember(dest => dest.TIPOAERONAVE, opts => opts.MapFrom(src => src.TipoAeronave))
            //.ForMember(dest => dest.ORIGEM, opts => opts.MapFrom(src => src.Origem))
            //.ForMember(dest => dest.DESTINO, opts => opts.MapFrom(src => src.Destino));

            CreateMap<UserViewModel, User>()
            .ForMember(dest => dest.IdUser, opts => opts.MapFrom(src => src.IdUser))
            .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
            //.ForMember(dest => dest.Senha, opts => opts.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Active, opts => opts.MapFrom(src => src.Active));
            //.ForMember(dest => dest.UsuarioPerfil, opts => opts.MapFrom(src => src.Perfis));
        }
    }
}
