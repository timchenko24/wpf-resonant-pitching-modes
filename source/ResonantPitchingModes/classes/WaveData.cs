using System;

namespace ResonantPitchingModes
{
    public class WaveData
    {
        int m_waveLength;
        ShipData ship;

        public WaveData(int waveLength, ShipData ship)
        {
            m_waveLength = waveLength;
            this.ship = ship;
        }

        public double GetWaveSpeed()
        {
            return 1.25 * Math.Sqrt(m_waveLength);
        }

        public double GetApparentWavePeriod(int angle)
        {
            return m_waveLength / (GetWaveSpeed() - ship.GetShipSpeed() * Math.Cos(angle * (Math.PI / 180.0)));
        }

        public double GetApparentWavePeriod()
        {
            return m_waveLength / (GetWaveSpeed() - ship.GetShipSpeed() * Math.Cos(ship.GetHeadingAngle() * (Math.PI / 180.0)));
        }
    }
}
