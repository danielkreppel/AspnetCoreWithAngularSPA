using Model.Contract;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Aeronaves : IDomainEntity
    {
        public Aeronaves()
        {
            PlanosVoo = new HashSet<PlanoVoo>();
        }

        public int Idaeronave { get; set; }
        public string Matricula { get; set; }
        public int Idtipoaeronave { get; set; }
        public bool Ativo { get; set; }

        public virtual TiposAeronaves TipoAeronave { get; set; }
        public virtual ICollection<PlanoVoo> PlanosVoo { get; set; }
    }
}
