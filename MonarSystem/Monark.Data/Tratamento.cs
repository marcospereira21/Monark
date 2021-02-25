using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class Tratamento
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}