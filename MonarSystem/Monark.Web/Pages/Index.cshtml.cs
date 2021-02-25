using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Monark.Data;
using Monark.Data.Conversao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monark.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private MonarkContext context;

        public IndexModel(ILogger<IndexModel> logger, MonarkContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public void OnGet()
        {
           // NovoDatabase novo = new NovoDatabase(context);
           // novo.GetData();
        }
    }
}
