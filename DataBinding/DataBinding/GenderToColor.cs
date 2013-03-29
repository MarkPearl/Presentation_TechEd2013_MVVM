using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace DataBinding
{
    public class GenderToColor : MarkupExtension, IValueConverter
    {
        private GenderToColor _genderToColor;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Gender) value)
            {
                case Gender.Male: return Brushes.LightBlue;
                case Gender.Female : return Brushes.Pink;
                default: return Brushes.Red;
            }
        }       

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_genderToColor == null){_genderToColor = new GenderToColor();}
            return _genderToColor;
        }

        #region ...

        public GenderToColor()
        {
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}