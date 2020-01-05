using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Aeronave : IDomainEntity
    {
        public int IDAERONAVE { get; set; }

        public string MATRICULA { get; set; }

        public int IDTIPOAERONAVE { get; set; }

    }
 
}
