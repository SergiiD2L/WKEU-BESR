using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using WKEU_BESR.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using WKEU_BESR.Controls;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(PickerControl), typeof(PickerControlRenderer))]
namespace WKEU_BESR.Droid.Renderers
{
    public class PickerControlRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                //Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.drop,0,0,0);
                Control.SetSingleLine(true);
                Control.SetPaddingRelative(0,2,0,0);
                
                nativeEditText.Ellipsize = TextUtils.TruncateAt.End;
                
                nativeEditText.SetBackground(null);
                nativeEditText.SetTextColor(Color.White);
            }
        }
    }
}