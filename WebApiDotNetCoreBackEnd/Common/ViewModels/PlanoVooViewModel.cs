using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Common.PlanoDeVooViewModels
{
    public class PlanoVooViewModel
    {
        public int IdPlanoVoo { get; set; }

        [Display(Name = "Número")]
        public string NumeroVoo { get; set; }

        public DateTime Data { get; set; }

        public int? IdAeronave { get; set; }

        public int? IdAeroportoOrigem { get; set; }

        public int? IdAeroportoDestino { get; set; }

        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Display(Name = "Tipo Aeronave")]
        public string TipoAeronave { get; set; }
        
        public string Origem { get; set; }

        public string Destino { get; set; }

        public string DataFormatada
        {
            get
            {
                return this.Data.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }
    }
}
