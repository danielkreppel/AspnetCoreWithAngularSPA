using Model.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public partial class PlanoVoo : IDomainEntity
    {
        public int Idplanovoo { get; set; }
        public string Numerovoo { get; set; }
        public DateTime Data { get; set; }
        public int? Idaeronave { get; set; }
        public int? Idaeroportoorigem { get; set; }
        public int? Idaeroportodestino { get; set; }
        public bool Ativo { get; set; }

        //[ForeignKey("AERONAVES")]
        public virtual Aeronaves Aeronave { get; set; }

        //[ForeignKey("AEROPORTOS")]
        public virtual Aeroportos AeroportoDestino { get; set; }

        //[ForeignKey("AEROPORTOS")]
        public virtual Aeroportos AeroportoOrigem { get; set; }
    }
}
