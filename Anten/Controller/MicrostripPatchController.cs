﻿using Microsoft.AspNetCore.Mvc;
using Anten.Models;
using System;

namespace Anten.Controllers
{
    public class MicrostripPatchController : Controller
    {
        // Đảm bảo rằng chỉ có một định nghĩa của CalculateMicrostripPatch
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
            catch (ArgumentException ex)
            {
                // Trả về thông báo lỗi nếu các giá trị đầu vào không hợp lệ
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Trả về view "Error" nếu có lỗi khác xảy ra
                return View("Error", ex);
            }
        }
    }
}
