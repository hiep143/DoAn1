using System;
using UnitsNet;

namespace Anten.Models
{
    public class MicrostripLine
    {
        public MicrostripLine(double er, double h, double f)
        {
            Er = er;
            H = h;
            F = f;
        }

        public double[][]? MLResults { get; set; }
        public double Er { get; set; } // Dielectric constant
        public double H { get; set; } // Substrate thickness
        public double F { get; set; } // Frequency

        public double[] CalculateCase1(double zoValue, double El)
        {
            if (Er <= 0 || H <= 0 || F <= 0)
            {
                throw new ArgumentException("Input values must be greater than 0.");
            }

            double pi = Math.PI;
            double e = Math.E;
            Speed C = Speed.FromMetersPerSecond(300_000_000);
            Frequency frequency = Frequency.FromGigahertz(F);
            ElectricResistance Zo = ElectricResistance.FromOhms(zoValue);
            double A = (Zo.Ohms / 60) * Math.Sqrt((Er + 1) / 2) + ((Er - 1) / (Er + 1)) * (0.23 + 0.11 / Er);
            double B = 377 * pi / (2 * Zo.Ohms * Math.Sqrt(Er));
            Length hLength = Length.FromMillimeters(H);

            Length W1 = Length.FromMeters(hLength.Meters * 8 * Math.Pow(e, A) / (Math.Pow(e, 2 * A) - 2));
            Length W2 = Length.FromMeters((hLength.Meters * 2 / pi) * (B - 1 - Math.Log(2 * B - 1, e) + ((Er - 1) / (2 * Er)) * (Math.Log(B - 1, e) + 0.39 - 0.61 / Er)));

            if (W1.Meters < 2 * hLength.Meters)
            {
                double Ee1 = (Er + 1) / 2 + ((Er - 1) / 2) / Math.Sqrt(1 + 12 * hLength.Meters / W1.Meters);
                Length lamda = Length.FromMeters(C.MetersPerSecond / (Math.Sqrt(Ee1) * frequency.Hertz));
                Length L1 = Length.FromMeters(El * lamda.Meters / 360);
                return new double[] { W1.Millimeters, L1.Millimeters };
            }
            else
            {
                double Ee2 = (Er + 1) / 2 + ((Er - 1) / 2) / Math.Sqrt(1 + 12 * hLength.Meters / W2.Meters);
                Length lamda = Length.FromMeters(C.MetersPerSecond / (Math.Sqrt(Ee2) * frequency.Hertz));
                Length L2 = Length.FromMeters(El * lamda.Meters / 360);
                return new double[] { W2.Millimeters, L2.Millimeters };
            }
        }

        public double[] CalculateCase2(double wValue, double lValue)
        {
            if (Er <= 0 || H <= 0 || F <= 0)
            {
                throw new ArgumentException("Input values must be greater than 0.");
            }

            double pi = Math.PI;
            double e = Math.E;
            Speed C = Speed.FromMetersPerSecond(300_000_000);

            Length L = Length.FromMillimeters(lValue);
            Length W = Length.FromMillimeters(wValue);
            Frequency frequency = Frequency.FromGigahertz(F);
            Length hLength = Length.FromMillimeters(H);

            double Ee = (Er + 1) / 2 + ((Er - 1) / 2) / Math.Sqrt(1 + 12 * hLength.Meters / W.Meters);
            Length lamda = Length.FromMeters(C.MetersPerSecond / (Math.Sqrt(Ee) * frequency.Hertz));
            double El = L.Millimeters * 360 / lamda.Millimeters;

            if (W.Meters <= hLength.Meters)
            {
                ElectricResistance Zo1 = ElectricResistance.FromOhms((60 / Math.Sqrt(Ee)) * Math.Log(8 * hLength.Meters / W.Meters + W.Meters / (4 * hLength.Meters)));
                return new double[] { Zo1.Ohms, El };
            }
            else
            {
                ElectricResistance Zo2 = ElectricResistance.FromOhms(120 * pi / (Math.Sqrt(Ee) * (W.Meters / hLength.Meters + 1.393 + 0.667 * Math.Log(W.Meters / hLength.Meters + 1.444, e))));
                return new double[] { Zo2.Ohms, El };
            }
        }
    }
}
