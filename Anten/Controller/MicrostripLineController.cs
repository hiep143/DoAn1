﻿using Microsoft.AspNetCore.Mvc;
using Anten.Models;

namespace Anten.Controllers
{
    [Route("[controller]")]
    public class MicrostripLineController : Controller
    {
        [HttpPost("CalculateCase1")]
        public IActionResult CalculateCase1(double er, double h, double f, double zoValue, double El)
        {
            try
            {
                MicrostripLine line = new MicrostripLine(er, h, f);
                var result = line.CalculateCase1(zoValue, El);
                if (result == null || result.Length == 0)
                {
                    return BadRequest("No results calculated.");
                }
                return Json(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CalculateCase2")]
        public IActionResult CalculateCase2(double er, double h, double f, double wValue, double lValue)
        {
            try
            {
                MicrostripLine line = new MicrostripLine(er, h, f);
                var result = line.CalculateCase2(wValue, lValue);
                if (result == null || result.Length == 0)
                {
                    return BadRequest("No results calculated.");
                }
                return Json(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
