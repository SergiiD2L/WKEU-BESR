using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WKEU_BESR.Common;
using WKEU_BESR.Droid;
using WKEU_BESR.Droid.Renderers;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace WKEU_BESR.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        private GradientDrawable _normal, _pressed;
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var btn = this.Control;
            btn.SetAllCaps(false);

            btn.TextAlignment = Android.Views.TextAlignment.Center;

            //if (Control != null)
            //{
            //    var button = (CustomButton)e.NewElement;


            //    button.SizeChanged += (s, args) =>
            //    {
            //        var radius = 110;

            //        // Create a drawable for the button's normal state
            //        _normal = new Android.Graphics.Drawables.GradientDrawable();

            //        //if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
            //        //    _normal.SetColor(Android.Graphics.Color.ParseColor("#ff2c2e2f"));
            //        //else
            //        //    _normal.SetColor(button.BackgroundColor.ToAndroid());

            //        _normal.SetCornerRadius(radius);

            //        //// Create a drawable for the button's pressed state
            //        //_pressed = new Android.Graphics.Drawables.GradientDrawable();
            //        //var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.Gray);
            //        //_pressed.SetColor(highlight);
            //        //_pressed.SetCornerRadius(radius);

            //        // Add the drawables to a state list and assign the state list to the button
            //        //var sld = new StateListDrawable();
            //        //sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
            //        //sld.AddState(new int[] { }, _normal);
            //        Control.SetBackground(_normal);
            //    };
            //}
        }

    }
    
}