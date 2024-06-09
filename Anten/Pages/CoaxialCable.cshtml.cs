using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anten.Pages
{
    public class CoaxialCable : PageModel
    {
        private readonly ILogger<CoaxialCable> _logger;

        public CoaxialCable(ILogger<CoaxialCable> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
