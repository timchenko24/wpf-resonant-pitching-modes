using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ResonantPitchingModes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InputController input;
        ShipData ship;
        WaveData wave;
        ResonantPitching rp;
        Dictionary<String, Coordinates> points;
        CoordinatesFactory coordsFactory;
        PitchingDiagram diag;

        public MainWindow()
        {
            InitializeComponent();

            input = new InputController();
            DataContext = input;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            ship = new ShipData(input.ShipWidth, input.ShipDraft, input.MetacentricHeight, input.ShipSpeed, input.HeadingAngle);
            wave = new WaveData(input.WaveLength, ship);
            rp = new ResonantPitching(wave, ship);

            double radius = input.ShipSpeed * 180 / 30;

            coordsFactory = new CoordinatesFactory(rp, ship, radius);

            points = coordsFactory.GetDictionaryOfInstances();

            diag = new PitchingDiagram(cnvDiagram, points);

            diag.Draw();

            gbInputData.IsEnabled = false;

            lblResult.Content += string.Format("\n{0}", rp.CheckRules());

            rp.DisplayLimitsToLabel(lblResult);

        }

        private void BtnResetInput_Click(object sender, RoutedEventArgs e)
        {
            tbHeadingAngle.Clear();
            gbInputData.IsEnabled = true;
            lblResult.Content = "Результат:";
            PitchingDiagram.Clear(cnvDiagram);
        }
    }
}
