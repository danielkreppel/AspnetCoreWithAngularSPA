using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TipoAeronave : IDomainEntity
    {
        public int IDTIPOAERONAVE { get; set; }

        public string DESCRICAO { get; set; }

    }
}
