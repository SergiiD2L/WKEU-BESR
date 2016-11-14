using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using WKEU_BESR.Common;
using WKEU_BESR.Droid.Renderers;

//[assembly: ExportRenderer(typeof(AnimationPage), typeof(PageAnimationRenderer))]
namespace WKEU_BESR.Droid.Renderers
{
    public class PageAnimationRenderer : NavigationPageRenderer
    {        
        protected override void SetupPageTransition(Android.Support.V4.App.FragmentTransaction transaction, bool isPush)
        {            
            //if (isPush)
            //    transaction.SetCustomAnimations(Resource.Animation.abc_popup_enter, Resource.Animation.abc_popup_exit);
            //else
            //    transaction.SetCustomAnimations(Resource.Animation.abc_popup_enter, Resource.Animation.abc_popup_exit);

            //if (isPush)
            //    transaction.SetCustomAnimations(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
            //else
            //    transaction.SetCustomAnimations(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
        }        
    }
}