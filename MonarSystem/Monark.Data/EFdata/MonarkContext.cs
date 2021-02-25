using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Monark.Data.Conversao;

namespace Monark.Data
{
    public class MonarkContext : DbContext
    {
        public MonarkContext(DbContextOptions<MonarkContext> options) : base(options)
        {

        }

        public DbSet<Pessoa>  Pessoas{ get; set; }
        public DbSet<PessoaTipo> PessoaTipos { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoTipo> EventoTipos { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Monarquia> Monarquia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}