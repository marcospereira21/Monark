using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class Evento
    {
        public int Id { get; set; }
        [Required]
        public DateTime DtEvento { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }
        [MaxLength(300)]
        public String Comentaio { get; set; }
        public EventoTipo EventoTipo { get; set; }
       
    }
}