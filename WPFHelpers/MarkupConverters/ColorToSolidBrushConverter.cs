namespace WPFHelpers.MarkupConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Windows.Media;

    public class ColorToSolidBrushConverter : MarkupExtension, IValueConverter
    {
        private static Color ConvertRGB(string rgbOrRgba)
        {
            rgbOrRgba = rgbOrRgba.Substring(rgbOrRgba.IndexOf('(') + 1).Replace(")", "");
            var values = rgbOrRgba.Split(',');
            var r = System.Convert.ToByte(values[0].Trim());
            var g = System.Convert.ToByte(values[1].Trim());
            var b = System.Convert.ToByte(values[2].Trim());
            if (values.Length == 4)
            {
                var a = System.Convert.ToByte(decimal.Parse(values[3].Trim()) * 255);
                return Color.FromArgb(a, r, g, b);
            }
            else
            {
                return Color.FromRgb(r, g, b);
            }
        }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if(value is string colourString)
                {
                    if (colourString.StartsWith("rgb"))
                    {
                        value = ConvertRGB(colourString);
                    }
                    else
                    {
                        // can do known color names, hex and more...
                        value = ColorConverter.ConvertFromString(colourString);
                    }
                }
                
                return new SolidColorBrush((Color)value);
                
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
