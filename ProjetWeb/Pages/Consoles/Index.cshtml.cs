using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetWeb.API;

namespace ProjetWeb.Pages.Consoles
{
    public class IndexModel : PageModel
    {
        private readonly IConsoleJeus _console;

        public IndexModel(IConsoleJeus console)
        {
            _console = console;
        }

        public IList<ConsoleJeu> ConsoleJeu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ConsoleJeu = (await _console.ConsoleJeusAllAsync()).ToList();
        }
    }
}
