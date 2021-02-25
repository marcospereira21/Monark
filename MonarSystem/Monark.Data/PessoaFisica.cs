using Monark.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sexo { get; set; }
        [Required]
        public Tratamento Tratamento { get; set; }
        [MaxLength(50)]
        public string EstadoCivil { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Sobrenome { get; set; }
        [MaxLength(200)]
        public string NomeCompleto { get; set; }
        [MaxLength(17)]
        public string CPF { get; set; }
        public int DiaAniversario { get; set; }
        public int MesAniversario { get; set; }
        public int AnoAniversario { get; set; }
        [MaxLength(50)]
        public string Profissao { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        public PessoaFisica Conjuge { get; set; }

        public IList<Telefone> Telefones { get; set; } = new List<Telefone>();
        public Endereco Endereco { get; set; }

    }
}