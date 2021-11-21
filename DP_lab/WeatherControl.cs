using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DP_lab
{
    /// Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку –
    /// температуру (целое число в диапазоне от -50 до +50),
    /// направление ветра (строка),
    /// скорость ветра (целое число),
    /// наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег.
    /// Можно использовать целочисленное значение, либо создать перечисление enum).
    /// Свойство «температура» преобразовать в свойство зависимости.
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public string WindDirection { get; set; }
        public int WindSpeer { get; set; }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public Precipitation Precipitation { get; set; }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }
    }
    public enum Precipitation
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    }
}
