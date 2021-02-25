using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class Telefone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public int CodigoPais { get; set; }
        [Required]
        [MaxLength(50)]
        public string Numero { get; set; }
        public int Ramal { get; set; }
        public bool Principal { get; set; }
        public bool WhatsApp { get; set; }
        public TelefoneTipoEnum Tipo { get; set; }
    }
}