using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace util
{
    // use: [TypeConverter(typeof(ArrayFormat<int>))]
    public class ArrayFormat<T> : ArrayConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type dstType)
        {
            if (dstType == typeof(string))
                return value == null ? "" : format(value);

            return base.ConvertTo(context, culture, value, dstType);
        }

        public string format(object value)
        {
            if (value is Array)
                return string.Join(",", value as T[]);

            return value.ToString();
        }
    }
}
