using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WKEU_BESR.Helper;

namespace WKEU_BESR.Controls
{
    public class CustomRadioButton : View
    {
        //public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(PickerControl), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(PickerControl.OnSelectedItemChanged), null, null, null);

        //public static readonly BindableProperty CheckedProperty = BindableProperty.Create<CustomRadioButton, bool>(p => p.Checked, false);
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create("Checked", typeof(bool), typeof(CustomRadioButton), default(bool), BindingMode.TwoWay, null, null, null, null);
        /// <summary>
        /// The default text property.
        /// </summary>
        //public static readonly BindableProperty TextProperty = BindableProperty.Create<CustomRadioButton, string>(p => p.Text, string.Empty);
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomRadioButton), default(string), BindingMode.TwoWay, null, null, null, null);
        /// <summary>
        /// The checked changed event.
        /// </summary>
        public EventHandler<EventArgs<bool>> CheckedChanged;


        /// <summary>
        /// Identifies the TextColor bindable property.
        /// </summary>
        /// 
        /// <remarks/>
        //public static readonly BindableProperty TextColorProperty = BindableProperty.Create<CustomRadioButton, Color>(p => p.TextColor, Color.Black);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(CustomRadioButton), default(Color), BindingMode.TwoWay, null, null, null, null);
        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return (bool)this.GetValue(CheckedProperty);
            }

            set
            {
                this.SetValue(CheckedProperty, value);
                var eventHandler = this.CheckedChanged;
                if (eventHandler != null)
                {
                   
                    eventHandler.Invoke(this, value);
                }
            }
        }

        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }

            set
            {
                this.SetValue(TextProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)this.GetValue(TextColorProperty);
            }

            set
            {
                this.SetValue(TextColorProperty, value);
            }
        }

        public int Id { get; set; }
   
        
       
    }

  
}
