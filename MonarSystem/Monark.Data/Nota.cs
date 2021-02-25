using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class Nota
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Anotacao { get; set; }
        [Required]
        public DateTime DtAnotacao { get; set; }
    }
}