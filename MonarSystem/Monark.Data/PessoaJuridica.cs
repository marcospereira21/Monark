using Monark.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class PessoaJuridica
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string RazaoSocial { get; set; }
        [MaxLength(20)]
        public string CNPJ { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public IList<Telefone> Telefones { get; set; } = new List<Telefone>();
        public Endereco Endereco { get; set; }


    }
}