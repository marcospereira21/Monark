using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monark.Data.Conversao
{

    public class NovoDatabase
    {
        MonarkContext context;
        private IList<Monarquia> MonarquiaDados = new List<Monarquia>();
        public NovoDatabase(MonarkContext context)
        {
            this.context = context;
        }


        public IList<Monarquia> GetData()
        {
            MonarquiaDados = context.Monarquia.ToList();

            AddPessoa();
            return MonarquiaDados;

        }


        private void AddPessoa()
        {
            var Trat = context.Tratamentos.ToList();


            foreach (var item in MonarquiaDados)
            {
                var pe = new Pessoa
                {
                    Origem = item.zblo,
                    Id = item.Id,
                    DtAtualizacao = DateTime.Now,
                    PessoaFisica = new PessoaFisica
                    {
                        
                        Tratamento = Trat.Where(x => x.Id == item.tratamId).FirstOrDefault(),
                        Nome = item.parte,
                        NomeCompleto = item.nome2,
                        CPF = item.cpf,
                        Email = item.email,
                        Sexo = item.sexo,
                        Endereco = new Endereco
                        {
                            Logradouro = item.endaux,
                            Bairro = item.baiaux,
                            Numero = null,
                            Complemento = null,
                            Cidade = item.cidade,
                            Estado = item.uf,
                            CEP = item.cepaux + item.c_par,
                            Pais = null
                        },
                        Telefones = new List<Telefone>()
                        { new Telefone
                            { Numero = item.telefr
                            } 
                        }
                    }
                };

                context.Pessoas.Add(pe);
                context.SaveChanges();
            }

           

        }



    }
}
