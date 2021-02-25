using Monark.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Monark.Data
{
    public class Pessoa
    {
        public int Id { get; set; }
        private string _NomeCompleto;
        [NotMapped]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string NomeCompleto
        {
            get
            {
                _NomeCompleto = PessoaFisica?.NomeCompleto ?? PessoaJuridica?.RazaoSocial;
                return _NomeCompleto;
            }

        }

        private string _cidade;

        public string Cidade
        {
            get {
                _cidade = PessoaFisica?.Endereco?.Cidade ?? PessoaJuridica?.Endereco?.Cidade;
                return _cidade; }
        }


        [Required]
        public int Codigo { get; set; }
        [MaxLength(50)]
        public string Origem { get; set; }
        [Required]
        [DisplayName("Dt Atualização")]
        public DateTime DtAtualizacao { get; set; }
        [Required]
        public bool Ativo { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public ICollection<Nota> Notas { get; set; }
        public IList<Evento> Eventos { get; set; } = new List<Evento>();

       
    }
}