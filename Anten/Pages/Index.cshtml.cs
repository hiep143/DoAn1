using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anten.Pages
{
    public class MicrostripPatch : PageModel
    {
        private readonly ILogger<MicrostripPatch> _logger;

        public MicrostripPatch(ILogger<MicrostripPatch> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
