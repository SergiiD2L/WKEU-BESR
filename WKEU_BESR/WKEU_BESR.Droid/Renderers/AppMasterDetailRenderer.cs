using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using WKEU_BESR.Droid.Renderers;
using WKEU_BESR.Views;

[assembly: ExportRenderer(typeof(BindableMasterDetailPage), typeof(AppMasterDetailRenderer))]
namespace WKEU_BESR.Droid.Renderers
{
    public class AppMasterDetailRenderer : MasterDetailPageRenderer
    {
        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            if (newElement == null)
            {
                return;
            }

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                var drawer = GetChildAt(1);
                var detail = GetChildAt(0);

                var padding = detail.GetType().GetRuntimeProperty("TopPadding");
                //int value = (int)padding.GetValue(detail);

                padding.SetValue(drawer, 0);
                padding.SetValue(detail, 0);
            }
        }
    }
}