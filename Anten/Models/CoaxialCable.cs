using System;
using UnitsNet;

namespace Anten.Models
{
    public class CoaxialCable
    {
        public double Er { get; set; } // Hằng số điện môi
        public double DoutValue { get; set; } // Đường kính ngoài
        public double DinValue { get; set; } // Đường kính trong
        public double[][]? CCResults { get; set; } // Kết quả tính toán

        public CoaxialCable(double er, double dout, double din)
        {
            Er = er;
            DoutValue = dout;
            DinValue = din;
        }

        public void CalculateCoaxialCable()
        {
            // Kiểm tra điều kiện đầu vào
            if (Er <= 0 || DoutValue <= 0 || DinValue <= 0)
            {
                throw new ArgumentException("Các giá trị đầu vào phải lớn hơn 0");
            }

            double pi = Math.PI;
            Length Dout = Length.FromMillimeters(DoutValue);
            Length Din = Length.FromMillimeters(DinValue);
            Speed Vo = Speed.FromKilometersPerSecond(300000);
            double Co = Vo.MetersPerSecond;
            ElectricResistance Zo = ElectricResistance.FromOhms(138 * Math.Log(Dout.Meters / Din.Meters, 10) / Math.Sqrt(Er));
            Frequency Fcutoff = Frequency.FromHertz(Vo.MetersPerSecond / (pi * (Dout.Meters + Din.Meters) / 2 * Math.Sqrt(Er)));
            Capacitance Cft = Capacitance.FromFarads(7.354 * Er / (Math.Log(Dout.Meters / Din.Meters, 10)));
            ElectricInductance Ift = ElectricInductance.FromHenries(140.4 * Math.Log(Dout.Meters / Din.Meters, 10));
            CCResults = new double[][]
            {
                new double[] { Zo.Ohms },
                new double[] { Fcutoff.Gigahertz },
                new double[] { Cft.Farads },
                new double[] { Ift.Henries }
            };
        }
    }
}
