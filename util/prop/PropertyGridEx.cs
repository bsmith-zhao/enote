using System;
using System.Reflection;
using System.Windows.Forms;
using util.ext;

namespace util.prop
{
    public static class PropertyGridEx
    {
        public static void editAndLimit(this PropertyGrid ui, Action<PropertyValueChangedEventArgs> valueChanged)
        {
            ui.PropertyValueChanged += (s, e) => 
            {
                if (limitValue(e.ChangedItem))
                    ui.Refresh();

                valueChanged?.Invoke(e);
            };

            ui.MouseWheel += (s, e) =>
            {
                var item = ui.SelectedGridItem;
                if (item == null
                    || !item.attr<EditByWheel>(out var attr, out var prop)
                    || !attr.modify(item.Value, e.Delta > 0, out var dst))
                    return;

                var oldValue = item.Value;
                if (item.attr<ByteSize>())
                    prop.SetValue(item.Parent.Value, $"{dst}".byteSize().byteSize());
                else
                    prop.SetValue(item.Parent.Value, dst);
                limitValue(item);

                if ($"{oldValue}" == $"{item.Value}")
                    return;

                ui.Refresh();

                valueChanged?.Invoke(new PropertyValueChangedEventArgs(item, oldValue));
            };
        }

        static bool limitValue(GridItem item)
        {
            if (item.attr<RangeLimit>(out var rng, out var prop)
                && rng.limit(item.Value, out var dst))
            {
                prop.SetValue(item.Parent.Value, dst);
                return true;
            }
            return false;
        }

        public static bool attr<T>(this GridItem item)
            where T : Attribute
            => item.attr<T>(out var prop) != null;

        public static bool attr<T>(this GridItem item, out T att, out PropertyInfo prop)
            where T : Attribute
            => (att = item.attr<T>(out prop)) != null;

        public static T attr<T>(this GridItem item, out PropertyInfo prop)
            where T : Attribute
        {
            var type = item.Parent.Value.GetType();
            prop = type.GetProperty(item.Label);
            var attrs = prop.GetCustomAttributes(typeof(T), false);
            return attrs.item(0) as T;
        }
    }
}
