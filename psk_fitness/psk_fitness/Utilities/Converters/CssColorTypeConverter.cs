namespace psk_fitness;
using System.ComponentModel;

public class CssColorTypeConverter : TypeConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
            if (value is string strValue)
            {
                return CssColor.FromString(strValue);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

