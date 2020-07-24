using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResonantPitchingModes
{
    public class CoordinatesFactory
    {
        ResonantPitching m_rp;
        ShipData m_ship;
        double m_radius;

        public CoordinatesFactory(ResonantPitching rp, ShipData ship, double radius)
        {
            m_rp = rp;
            m_ship = ship;
            m_radius = radius;
        }

        public Coordinates GetShipPointInstance()
        {
            return new Coordinates(Accessories.DegreeToRad(m_ship.GetHeadingAngle()), m_radius);
        }

        public Coordinates GetRollLimitMinPointInstance()
        {
            return new Coordinates(m_rp.GetRollLimits()[0], m_radius);
        }

        public Coordinates GetRollLimitMaxPointInstance()
        {
            return new Coordinates(m_rp.GetRollLimits()[1], m_radius);
        }

        public Coordinates GetPitchingLimitMinPointInstance()
        {
            return new Coordinates(m_rp.GetPitchingLimits()[0], m_radius);
        }

        public Coordinates GetPitchingLimitMaxPointInstance()
        {
            return new Coordinates(m_rp.GetPitchingLimits()[1], m_radius);
        }

        public Dictionary<string, Coordinates> GetDictionaryOfInstances()
        {
            Dictionary<string, Coordinates> temp = new Dictionary<string, Coordinates>();
            temp.Add("ship", GetShipPointInstance());
            temp.Add("rollLimitMin", GetRollLimitMinPointInstance());
            temp.Add("rollLimitMax", GetRollLimitMaxPointInstance());
            temp.Add("pitchingLimitMin", GetPitchingLimitMinPointInstance());
            temp.Add("pitchingLimitMax", GetPitchingLimitMaxPointInstance());

            return temp;
        }
    }
}
