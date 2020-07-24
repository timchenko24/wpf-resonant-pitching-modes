using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResonantPitchingModes
{
    public class Coordinates
    {
        double m_angle;
        double m_radius;

        public Coordinates(double angle)
        {
            m_angle = angle;
        }

        public Coordinates(double angle, double radius)
        {
            m_angle = angle;
            m_radius = radius;
        }

        public double GetXForLimit()
        {
            return Math.Cos(m_angle) * m_radius + 180;
        }

        public double GetXForPoint()
        {
            return Math.Cos(m_angle) * m_radius + 177;
        }

        public double GetYForPoint()
        {
            return Math.Sin(m_angle) * m_radius - 3;
        }
    }
}
