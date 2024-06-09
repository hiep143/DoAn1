using System;
using Anten.Controllers;

namespace Anten.Models
{
    public class CoaxialCable
    {
        public CoaxialCable(double er, double doutValue, double dinValue)
        {
            Er = er;
            Dout = doutValue;
            Din = dinValue;
        }

        public double[][]? CCResults { get; set; }
        public double Er { get; set; }
        public double Dout { get; set; }
        public double Din { get; set; }

        public void Calculate()
        {
            // Tạo một đối tượng CoaxialCableController để gọi phương thức tính toán
            var controller = new CoaxialCableController();

            // Gọi phương thức tính toán từ đối tượng controller
            CCResults = controller.CalculateCoaxialCable(Er, Dout, Din);
        }
    }
}
