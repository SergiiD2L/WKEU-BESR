using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WKEU_BESR.Controls
{
    public class PickerControl : Picker
    {
        public PickerControl()
        {
            base.SelectedIndexChanged += OnSelectedIndexChanged;            
        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(PickerControl), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(PickerControl.OnSelectedItemChanged), null, null, null);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(PickerControl), null, BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(PickerControl.OnItemsSourceChanged), null, null, null);
        public static readonly BindableProperty DisplayPropertyProperty = BindableProperty.Create("DisplayProperty", typeof(string), typeof(PickerControl), null, BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(PickerControl.OnDisplayPropertyChanged), null, null, null);
        //public static readonly BindableProperty MyTextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(PickerControl), null, BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(PickerControl.OnTextColorPropertyChanged), null, null, null);

        public IList ItemsSource
        {
            get { return (IList)base.GetValue(PickerControl.ItemsSourceProperty); }
            set { base.SetValue(PickerControl.ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get
            {
                return base.GetValue(PickerControl.SelectedItemProperty);
            }
            set
            {
                base.SetValue(PickerControl.SelectedItemProperty, value);
                if (ItemsSource != null && ItemsSource.Contains(SelectedItem))
                {
                    SelectedIndex = ItemsSource.IndexOf(SelectedItem);
                }
                else
                {
                    SelectedIndex = 0;
                }
            }
        }

        public string DisplayProperty
        {
            get { return (string)base.GetValue(PickerControl.DisplayPropertyProperty); }
            set { base.SetValue(PickerControl.DisplayPropertyProperty, value); }
        }

        //public Color MyTextColor
        //{
        //    get { return (Color)base.GetValue(PickerControl.MyTextColorProperty); }
        //    set { base.SetValue(PickerControl.MyTextColorProperty, value); }
        //}

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsSource != null)
            {
                this.SelectedItem = ItemsSource[SelectedIndex];
            }
            
        }


        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            PickerControl picker = (PickerControl)bindable;
            picker.SelectedItem = newValue;
            if (picker.ItemsSource != null && picker.SelectedItem != null)
            {
                int count = 0;
                foreach (object obj in picker.ItemsSource)
                {
                    if (obj == picker.SelectedItem)
                    {
                        picker.SelectedIndex = count;
                        break;
                    }
                    count++;
                }
            }
        }

        //private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    PickerControl picker = (PickerControl)bindable;
        //    picker.MyTextColor = Color.FromHex(newValue.ToString());
        //    loadItemsAndSetSelected(bindable);

        //}


        private static void OnDisplayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            PickerControl picker = (PickerControl)bindable;
            picker.DisplayProperty = (string)newValue;
            loadItemsAndSetSelected(bindable);

        }
        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            PickerControl picker = (PickerControl)bindable;
            picker.ItemsSource = (IList)newValue;
            loadItemsAndSetSelected(bindable);
        }

        static void loadItemsAndSetSelected(BindableObject bindable)
        {
            PickerControl picker = (PickerControl)bindable;
            if (picker.ItemsSource as IEnumerable != null)
            {
                int count = 0;
                foreach (object obj in (IEnumerable)picker.ItemsSource)
                {
                    string value = string.Empty;
                    if (picker.DisplayProperty != null)
                    {
                        var prop = obj.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));
                        if (prop != null)
                        {
                            value = prop.GetValue(obj).ToString();
                        }
                    }
                    else
                    {
                        value = obj.ToString();
                    }
                    picker.Items.Add(value);
                    if (picker.SelectedItem != null)
                    {
                        if (picker.SelectedItem == obj)
                        {
                            picker.SelectedIndex = count;
                        }
                    }
                    count++;
                }
            }
        }
    }
}