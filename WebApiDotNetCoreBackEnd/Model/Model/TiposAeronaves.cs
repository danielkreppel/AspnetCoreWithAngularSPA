using Model.Contract;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TiposAeronaves : IDomainEntity
    {
        public TiposAeronaves()
        {
            Aeronaves = new HashSet<Aeronaves>();
        }

        public int Idtipoaeronave { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Aeronaves> Aeronaves { get; set; }
    }
}
