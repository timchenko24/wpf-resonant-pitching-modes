using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResonantPitchingModes
{
    public static class Accessories
    {
        public static double DegreeToRad(double angle)
        {
            return angle * Math.PI / 180;
        }

        public static double RadToDegree(double angle)
        {
            return angle * 180 / Math.PI;
        }
    }
}
