using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class Endereco
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Logradouro { get; set; }
        [MaxLength(20)]
        public string Numero { get; set; }
        [MaxLength(100)]
        public string Complemento { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(50)]
        public string Estado { get; set; }
        [MaxLength(50)]
        public string Cidade { get; set; }
        [MaxLength(50)]
        public string CEP { get; set; }
        [MaxLength(50)]
        public string Pais { get; set; }
        public TipoEnderecoEnum Tipo { get; set; }
        
    }
}