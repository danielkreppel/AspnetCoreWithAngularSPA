using Model.Contract;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Aeroportos : IDomainEntity
    {
        public Aeroportos()
        {
            PlanoVooIdaeroportodestinoNavigation = new HashSet<PlanoVoo>();
            PlanoVooIdaeroportoorigemNavigation = new HashSet<PlanoVoo>();
        }

        public int Idaeroporto { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<PlanoVoo> PlanoVooIdaeroportodestinoNavigation { get; set; }
        public virtual ICollection<PlanoVoo> PlanoVooIdaeroportoorigemNavigation { get; set; }
    }
}
