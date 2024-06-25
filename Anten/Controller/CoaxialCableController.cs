using Microsoft.AspNetCore.Mvc;
using Anten.Models;
using System;

namespace Anten.Controllers
{
    public class CoaxialCableController : Controller
    {
        [HttpPost]
        public IActionResult CalculateCoaxialCable(double Er, double Dout, double Din)
        {
            try
            {
                var coaxial = new CoaxialCable(Er, Dout, Din);
                coaxial.CalculateCoaxialCable();
                return Json(coaxial.CCResults);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
