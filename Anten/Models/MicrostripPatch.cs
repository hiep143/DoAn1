using System;
using UnitsNet;

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
            // Kiểm tra các điều kiện đầu vào
            if (Er <= 0 || this.H <= 0 || this.F <= 0)
            {
                throw new ArgumentException("Các giá trị đầu vào phải lớn hơn 0");
            }

            Length H = Length.FromMillimeters(this.H);
            Frequency Freq = Frequency.FromGigahertz(this.F);
            Speed Vo = Speed.FromKilometersPerSecond(300000);
            double Co = Vo.MetersPerSecond;
            Length W = Length.FromMeters(Vo.MetersPerSecond / (2 * Freq.Hertz) * (Math.Sqrt(2 / (Er + 1))));
            double Ereff = (Er + 1) / 2 + ((Er - 1) / 2) / Math.Sqrt(1 + 12 * H.Meters / W.Meters);
            Length delta_L = Length.FromMeters(H.Meters * 0.412 * ((Ereff + 0.3) * (W.Meters / H.Meters + 0.264)) / ((Ereff - 0.258) * (W.Meters / H.Meters + 0.8)));
            Length L = Length.FromMeters(Vo.MetersPerSecond / (2 * Freq.Hertz * Math.Sqrt(Ereff)) - 2 * delta_L.Meters);
            MPResults = new double[][] { new double[] { L.Millimeters }, new double[] { W.Millimeters } };
        }
    }
}
