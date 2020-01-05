using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Aeroporto : IDomainEntity
    {
        public int IDAEROPORTO { get; set; }

        public string SIGLA { get; set; }

    }
}
