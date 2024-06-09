using System;
using Microsoft.AspNetCore.Mvc;
using Anten.Models;

namespace Anten.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult CalculateMicrostripPatch(double Er, double H, double F)
        {
            try
            {
                // Tạo một đối tượng MicrostripPatch và truyền các giá trị từ request
                var model = new MicrostripPatch(Er, H, F);

                // Gọi phương thức CalculateMicrostripPatch để tính toán
                model.CalculateMicrostripPatch();

                // Trả về kết quả tính toán dưới dạng JSON
                return Json(model.MPResults);
            }
            catch (Exception ex)
            {
                // Trả về view "Error" nếu có lỗi xảy ra
                return View("Error", ex);
            }
        }

        public IActionResult CalculateCoaxialCable(double Er, double Dout, double Din)
        {
            try
            {
                // Tạo một đối tượng CoaxialCable và truyền các giá trị từ request
                var coaxial = new CoaxialCable(Er, Dout, Din);

                // Gọi phương thức Calculate để tính toán
                coaxial.Calculate();

                // Trả về kết quả tính toán dưới dạng JSON
                return Json(coaxial.CCResults);
            }
            catch (Exception ex)
            {
                // Trả về view "Error" nếu có lỗi xảy ra
                return View("Error", ex);
            }
        }
    }
}
