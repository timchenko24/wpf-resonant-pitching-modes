using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ResonantPitchingModes
{
    public class PitchingDiagram
    {
        Dictionary<String, Coordinates> m_points;
        Canvas m_cnv;

        public PitchingDiagram(Canvas cnv, Dictionary<String, Coordinates> points)
        {
            m_points = points;
            m_cnv = cnv;
        }
        public void Draw()
        {
            DrawShipPoint();
            DrawPeriods();
        }

        private void DrawShipPoint()
        {
            Ellipse shipPoint = new Ellipse()
            {
                Width = 7,
                Height = 7,
                Stroke = Brushes.Blue,
                StrokeThickness = 4
            };

            Canvas.SetLeft(shipPoint, m_points["ship"].GetXForPoint());
            Canvas.SetBottom(shipPoint, m_points["ship"].GetYForPoint());

            m_cnv.Children.Add(shipPoint);
        }

        private void DrawPeriods()
        {
            Path rollRectPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Opacity = 0.5,
                Fill = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            RectangleGeometry rollRect = new RectangleGeometry();
            rollRect.Rect = new Rect(m_points["rollLimitMax"].GetXForLimit(), 0, m_points["rollLimitMin"].GetXForLimit() - m_points["rollLimitMax"].GetXForLimit(), 180);

            Path pitchRectPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Opacity = 0.5,
                Fill = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            RectangleGeometry pitchRect = new RectangleGeometry();
            pitchRect.Rect = new Rect(m_points["pitchingLimitMax"].GetXForLimit(), 0, m_points["pitchingLimitMin"].GetXForLimit() - m_points["pitchingLimitMax"].GetXForLimit(), 180);

            rollRectPath.Data = rollRect;
            pitchRectPath.Data = pitchRect;
            m_cnv.Children.Add(rollRectPath);
            m_cnv.Children.Add(pitchRectPath);
        }

        public static void Clear(Canvas cnv)
        {
            cnv.Children.RemoveRange(1, 3);
        }
    }
}
