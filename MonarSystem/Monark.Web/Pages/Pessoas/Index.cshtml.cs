using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Monark.Data;
using Microsoft.AspNetCore.Http;

namespace Monark.Web.Pages.Pessoas
{
    public class IndexModel : PageModel
    {
        private readonly Monark.Data.MonarkContext _context;

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 15;
        public int RowCount { get; set; }
        public int PageCount { get; set; }


        [BindProperty]
        public string FilterNome { get; set; }
        [BindProperty]
        public string FilterCidade { get; set; }

        public IndexModel(Monark.Data.MonarkContext context)
        {
            _context = context;
        }

        public IList<Pessoa> Pessoa { get; set; }
        public string SessionFilterNome { get; private set; }

        public const string SessionKeyNome = "_Name";
        public const string SessionKeyCidade = "_Cidade";

        public async Task OnGetAsync()
        {
            GetSessions();
            await GetData();
        }


        public async Task OnPostAsync()
        {

            await GetData();
        }

        private void GetSessions()
        {
            FilterNome = HttpContext.Session.GetString(SessionKeyNome);
            FilterCidade = HttpContext.Session.GetString(SessionKeyCidade);
        }

        private async Task GetData()
        {
            var skip = (PageNum - 1) * PageSize;
            if (FilterNome == null)
                HttpContext.Session.SetString(SessionKeyNome, string.Empty);
            else
                HttpContext.Session.SetString(SessionKeyNome, FilterNome);

            if (FilterCidade == null)
                HttpContext.Session.SetString(SessionKeyCidade, string.Empty);
            else
                HttpContext.Session.SetString(SessionKeyCidade, FilterCidade);

            IQueryable<Pessoa> query = _context.Pessoas
                .Include(a => a.PessoaFisica).ThenInclude(f => f.Endereco)
                .Include(b => b.PessoaJuridica).ThenInclude(f => f.Endereco)
                .Include(c => c.Notas);

            if (!string.IsNullOrEmpty(FilterNome))
            {
                query = query.Where(x => EF.Functions.Like(x.PessoaFisica.NomeCompleto, "%" + FilterNome + "%"));
            }

            if (!string.IsNullOrEmpty(FilterCidade))
            {
                query = query.Where(x => EF.Functions.Like(x.PessoaFisica.Endereco.Cidade, "%" + FilterCidade + "%")
                        || EF.Functions.Like(x.PessoaJuridica.Endereco.Cidade, "%" + FilterCidade + "%"));
            }

            query = query.OrderBy(x => x.PessoaFisica.NomeCompleto);

            RowCount = query.Count();
            query = query.Skip(skip).Take(PageSize);
            Pessoa = await query.ToListAsync();
            PageCount = (int)Math.Ceiling(decimal.Divide(RowCount, PageSize));

        }


    }
}
