using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WKEU_BESR.Views
{
    public class BindableMasterDetailPage : MasterDetailPage
    {
        public static readonly BindableProperty MasterPageProperty =
            BindableProperty.Create("MasterPage",
                typeof(Page),
                typeof(BindableMasterDetailPage),
                new Page(),
                BindingMode.Default,
                propertyChanged: OnMasterChanged);

        public static readonly BindableProperty DetailPageProperty =
            BindableProperty.Create("DetailPage",
                typeof(Page),
                typeof(BindableMasterDetailPage),
                new Page(),
                propertyChanged: OnDetailChanged);

        public Page DetailPage
        {
            get
            {
                Detail = (Page)GetValue(DetailPageProperty);
                return Detail;
            }
            set
            {
                SetValue(DetailPageProperty, value);
                Detail = value;
            }
        }

        public Page MasterPage
        {
            get
            {
                Master = (Page)GetValue(MasterPageProperty);
                return Master;
            }
            set
            {
                SetValue(MasterPageProperty, value);
                Master = value;
            }
        }

        private static void OnMasterChanged(BindableObject bindable, object oldValue, object newValue)
        {            
            ((BindableMasterDetailPage)bindable).MasterPage = (Page)newValue;
        }

        private static void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BindableMasterDetailPage)bindable).DetailPage = (Page)newValue;
        }
    }
}
