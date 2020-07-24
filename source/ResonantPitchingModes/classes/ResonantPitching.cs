using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ResonantPitchingModes
{
    public class ResonantPitching
    {
        WaveData wave;
        ShipData ship;

        public ResonantPitching(WaveData wave, ShipData ship)
        {
            this.wave = wave;
            this.ship = ship;
        }

        private bool CheckRule(double apparentWavePeriod, double rollingPeriod, double limitMin, double limitMax)
        {
            return (apparentWavePeriod / rollingPeriod > limitMin) && (apparentWavePeriod / rollingPeriod < limitMax);
        }

        public string CheckRules()
        {
            string res = String.Empty;

            if (CheckRule(wave.GetApparentWavePeriod(), ship.GetOwnRollingPeriod(), 0.8, 1.2))
            {
                res += "Обнаружен основной резонанс бортовой качки\n";
            }

            if (CheckRule(wave.GetApparentWavePeriod(), ship.GetOwnRollingPeriod(), 1.85, 2.15))
            {
                res += "Обнаружен параметрический резонанс бортовой качки\n";
            }
            
            if (CheckRule(wave.GetApparentWavePeriod(), ship.GetPitchingPeriod(), 0.8, 1.2))
            {
                res += "Обнаружен основной резонанс килевой качки";
            }

            if (res == String.Empty)
            {
                res += "Резонансных периодов не обнаружено";
            }

            return res;
        }

        public double[] GetRollLimits()
        {
            List<double> temp = new List<double>();

            for (int i = 0; i <= 180; i++)
            {
                if (CheckRule(wave.GetApparentWavePeriod(i), ship.GetOwnRollingPeriod(), 0.8, 1.2))
                {
                    temp.Add(i);
                }
            }

            return new double[] { Accessories.DegreeToRad(temp.First()), Accessories.DegreeToRad(temp.Last()) };
        }

        public double[] GetPitchingLimits()
        {
            List<double> temp = new List<double>();

            for (int i = 0; i <= 180; i++)
            {
                if (CheckRule(wave.GetApparentWavePeriod(i), ship.GetPitchingPeriod(), 0.8, 1.2))
                {
                    temp.Add(i);
                }
            }

            return new double[] { Accessories.DegreeToRad(temp.First()), Accessories.DegreeToRad(temp.Last()) };
        }

        public void DisplayLimitsToLabel(Label lbl)
        {
            lbl.Content += string.Format($"\n\n{Accessories.RadToDegree(GetRollLimits()[0])}° - {Accessories.RadToDegree(GetRollLimits()[1])}° - основной резонанс бортовой качки" +
                $"\n{Accessories.RadToDegree(GetPitchingLimits()[0])}° - {Accessories.RadToDegree(GetPitchingLimits()[1])}° - основной резонанс килевой качки");
        }
    }
}
