using System;
using UnitsNet;
using System.Numerics;
using UnitsNet.Units;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anten.Controllers
{
    public class CoaxialCableController : Controller
    {   
        public double[][] CalculateCoaxialCable(
            double DoutValue,
            double DinValue,
            double Er
            )

    

    // Tiếp tục với các tính toán cần thiết ở đây và trả về một mảng double[][] hoặc giá trị phù hợp.

        {
            double pi = Math.PI;
            Length Dout = Length.FromMillimeters(DoutValue);
            Length Din = Length.FromMillimeters(DinValue);
            Speed Vo = Speed.FromKilometersPerSecond(300000);
            double Co = Vo.MetersPerSecond;
            ElectricResistance Zo = ElectricResistance.FromOhms(138*Math.Log(Dout.Meters/Din.Meters,10)/Math.Sqrt(Er));
            Frequency Fcutoff = Frequency.FromHertz(Vo.MetersPerSecond/(pi*(Dout.Meters+Din.Meters)/2*Math.Sqrt(Er)));
            Capacitance Cft = Capacitance.FromFarads(7.354*Er/(Math.Log(Dout.Meters/Din.Meters,10)));
            ElectricInductance Ift = ElectricInductance.FromHenries(140.4*Math.Log(Dout.Meters/Din.Meters,10));
            return new double[][] {
                new double[] { Zo.Ohms },
                new double[] { Fcutoff.Hertz },
                new double[] { Cft.Nanofarads }
            };



            // Invalid matching type or unknown case
            return new double[0][];
        }

        



    }
}