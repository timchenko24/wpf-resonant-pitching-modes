using System;
using System.ComponentModel;

namespace ResonantPitchingModes
{
    public class InputController : IDataErrorInfo
    {
        public int WaveLength { get; set; }
        public double ShipSpeed { get; set; }
        public int HeadingAngle { get; set; }
        public double ShipWidth { get; set; }
        public double ShipDraft { get; set; }
        public double MetacentricHeight { get; set; }

        public InputController() {}

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "WaveLength":
                        if ((WaveLength < 1) || (WaveLength > 90))
                        {
                            error = "Длина волны должна быть больше 1 и меньше 90";
                        }
                        break;
                    case "ShipWidth":
                        if ((ShipWidth < 1) || (ShipWidth > 90))
                        {
                            error = "Ширина должна быть больше 1 и меньше 90";
                        }
                        break;
                    case "ShipDraft":
                        if ((ShipDraft <= 0) || (ShipDraft > 24))
                        {
                            error = "Осадка должна быть больше 0 и меньше 24";
                        }
                        break;
                    case "MetacentricHeight":
                        if ((MetacentricHeight <= 0) || (MetacentricHeight > 5))
                        {
                            error = "Метаценрическая высота должна быть больше 0 и меньше 5";
                        }
                        break;
                    case "ShipSpeed":
                        if ((ShipSpeed <= 0) || (ShipSpeed > 50))
                        {
                            error = "Скорость судна должна быть больше 0 и меньше 50";
                        }
                        break;
                    case "HeadingAngle":
                        if ((HeadingAngle < 0) || (HeadingAngle > 180))
                        {
                            error = "Курсовой угол должен быть больше 0 и меньше 180";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { return String.Empty; }
        }
    }
}
