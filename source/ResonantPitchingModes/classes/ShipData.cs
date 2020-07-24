using System;

namespace ResonantPitchingModes
{
    public class ShipData
    {
        double m_shipWidth;
        double m_shipDraft;
        double m_metacentricHeight;
        double m_shipSpeed;
        int m_headingAngle;

        public double shipSpeed { get; set; }

        public ShipData(double shipWidth, double shipDraft, double metacentricHeight, double shipSpeed, int headingAngle)
        {
            m_shipWidth = shipWidth;
            m_shipDraft = shipDraft;
            m_metacentricHeight = metacentricHeight;
            m_shipSpeed = shipSpeed;
            m_headingAngle = headingAngle;
        }

        public ShipData()
        {

        }

        public double GetShipSpeed()
        {
            return m_shipSpeed;
        }

        public double GetHeadingAngle()
        {
            return m_headingAngle;
        }

        public double GetOwnRollingPeriod()
        {
            return 0.8 * m_shipWidth / Math.Sqrt(m_metacentricHeight);
        }

        public double GetPitchingPeriod()
        {
            return 2.5 * Math.Sqrt(m_shipDraft);
        }
    }
}
