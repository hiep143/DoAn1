﻿using System;
using UnitsNet;
using System.Numerics;
using UnitsNet.Units;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anten.Controllers
{
    public class MicrostripPatchController : Controller
    {
        public static double[][] CalculateMicrostripPatch(
            double Er,
            double HValue,
            double FrequencyValue
            )

    

    // Tiếp tục với các tính toán cần thiết ở đây và trả về một mảng double[][] hoặc giá trị phù hợp.

        {
            Length H = Length.FromMillimeters(HValue);
            Frequency F = Frequency.FromGigahertz(FrequencyValue);
            Speed Vo = Speed.FromKilometersPerSecond(300000);
            double Co = Vo.MetersPerSecond;
            Length W = Length.FromMeters(Vo.MetersPerSecond/(2*F.Hertz) * (Math.Sqrt(2/(Er+1))));
            double Ereff = (Er+1)/2 + ((Er-1)/2)/Math.Sqrt(1+12*H.Meters/W.Meters);
            Length delta_L = Length.FromMeters(H.Meters*0.412 * ((Ereff+0.3)*(W.Meters/H.Meters+0.264)) / ((Ereff-0.258)*(W.Meters/H.Meters+0.8)));
            Length L = Length.FromMeters(Vo.MetersPerSecond/(2*F.Hertz*Math.Sqrt(Ereff)) - 2*delta_L.Meters);
            return new double[][] { new double[] { L.Millimeters }, new double[] { W.Millimeters } };


            // Invalid matching type or unknown case
            return new double[0][];
        }
    }
}