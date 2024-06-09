using System;
using Anten.Controllers;

namespace Anten.Models
{
    public class MicrostripPatch
    {
        public MicrostripPatch(double er, double h, double f)
        {
            Er = er;
            H = h;
            F = f;
        }

        public double[][]? MPResults { get; set; }
        public double Er { get; set; } // Hằng số điện môi
        public double H { get; set; } // Độ dày tấm sub
        public double F { get; set; } // Tần số

        
        public void CalculateMicrostripPatch()
        {
            MPResults = MicrostripPatchController.CalculateMicrostripPatch(Er,H,F);

            // Thực hiện tính toán độ kháng dựa trên các giá trị và loại mạch được cung cấp
            // (Đoạn mã tính toán đã được đưa vào trong phương thức này)
        }
    }
}
