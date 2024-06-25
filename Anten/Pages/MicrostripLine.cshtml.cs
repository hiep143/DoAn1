using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anten.Pages
{
    public class MicrostripLine : PageModel
    {
        private readonly ILogger<MicrostripLine> _logger;

        public MicrostripLine(ILogger<MicrostripLine> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
