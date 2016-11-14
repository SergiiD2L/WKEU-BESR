using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WKEU_BESR.Helper;
using WKEU_BESR.Models;

namespace WKEU_BESR.Controls
{
    public class BindableRadioGroup : StackLayout
    {
       
        public List<CustomRadioButton> rads;

        public BindableRadioGroup()
        {

            rads = new List<CustomRadioButton>();
        }


        //public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(BindableRadioGroup), default(CityModel), BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindableRadioGroup.OnSelectedItemChanged), null, null, null);


        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(object), typeof(BindableRadioGroup), default(IList), BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindableRadioGroup.OnItemsSourceChanged), null, null, null);
        

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create("SelectedIndex", typeof(int), typeof(BindableRadioGroup), default(int), BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindableRadioGroup.OnSelectedIndexChanged), null, null, null);
        

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        //public object SelectedItem
        //{
        //    get
        //    {
        //        return base.GetValue(BindableRadioGroup.SelectedItemProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(BindableRadioGroup.SelectedItemProperty, value);
        //        if (ItemsSource != null && ItemsSource.Contains(SelectedItem))
        //        {
        //            SelectedIndex = ItemsSource.IndexOf(SelectedItem);
        //        }
        //        else
        //        {
        //            SelectedIndex = 0;
        //        }
        //    }
        //}

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {           
            //BindableRadioGroup picker = (BindableRadioGroup)bindable;
            //picker.SelectedItem = newValue;
            //if (picker.ItemsSource != null && picker.SelectedItem != null)
            //{
            //    int count = 0;
            //    foreach (object obj in picker.ItemsSource)
            //    {
            //        if (obj == picker.SelectedItem)
            //        {
            //            picker.SelectedIndex = count;
            //            picker.rads[count].Checked = true;
            //            break;
            //        }
            //        count++;
            //    }
            //}
        }

        public int SelectedIndex
        {
            get {
                return (int)GetValue(SelectedIndexProperty);
            }
            set {
                SetValue(SelectedIndexProperty, value);
            }
        }
      
        public event EventHandler<int> CheckedChanged;



        private static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var radButtons = bindable as BindableRadioGroup;
           
            radButtons.rads.Clear();
            radButtons.Children.Clear();
            if (newvalue != null)
            {
              
                int radIndex = 0;
                foreach (var item in (IEnumerable)newvalue)
                {
                    try
                    {
                        dynamic currentItem = null;

                        var rad = new CustomRadioButton();
                        //if(item.GetType() == typeof(CityModel))
                        //{
                        //    currentItem = (CityModel)item;
                        //    rad.Text = currentItem.CityName;
                        //}
                        //else if(item.GetType() == typeof(CurrencyModel))
                        //{
                        //    currentItem = (CurrencyModel)item;
                        //    rad.Text = currentItem.CurrencyName;
                        //}


                        rad.Id = radIndex;

                        rad.CheckedChanged += radButtons.OnCheckedChanged;

                        radButtons.rads.Add(rad);

                        radButtons.Children.Add(rad);
                        radIndex++;
                    }
                    catch(Exception ex)
                    {

                    }

                }
            }
        }

        private void OnCheckedChanged(object sender, EventArgs<bool> e)
        {
           
           if (e.Value == false) return;

            var selectedRad = sender as CustomRadioButton;

            foreach (var rad in rads)
            {
                if(!selectedRad.Id.Equals(rad.Id))
                {
                    rad.Checked = false;
                }
                else
                {
                    //SelectedItem = ItemsSource[rad.Id];
					if(CheckedChanged != null)
                    	CheckedChanged.Invoke(sender, rad.Id); 
                   
                }
                
            }

        }

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if ((int)newvalue == -1) return;

            var bindableRadioGroup = bindable as BindableRadioGroup;

            foreach (var rad in bindableRadioGroup.rads)
            {
                if (rad.Id == bindableRadioGroup.SelectedIndex)
                {
                    rad.Checked = true;
                }               
            }

        }
    
    }
}
