using AutoMapper;
using Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<TVM> MapToViewModel<TVM>(this IEnumerable<IDomainEntity> domainEntitiesList, IMapper mapper) {

            List<TVM> model = new List<TVM>();

            foreach (var a in domainEntitiesList)
            {
                model.Add(mapper.Map<TVM>(a));
            }

            return model;
        }

    }
}
