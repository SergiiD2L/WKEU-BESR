using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WKEU_BESR.Common;
using WKEU_BESR.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace WKEU_BESR.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                nativeEditText.SetBackground(null);
             
                //var shape = new ShapeDrawable();
                //shape.Paint.Color = Xamarin.Forms.Color.Red.ToAndroid();
                //shape.Paint.StrokeWidth = 5;
                //shape.Paint.SetStyle(Paint.Style.Stroke);
                //nativeEditText.Background = shape;
            }
        }
    }
}