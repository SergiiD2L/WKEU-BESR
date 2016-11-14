using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WKEU_BESR.Common;
using WKEU_BESR.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomTabPage), typeof(CustomTabPageRenderer))]

namespace WKEU_BESR.Droid.Renderers
{
    public class CustomTabPageRenderer : TabbedRenderer
    {
        public CustomTabPageRenderer()
        {

        }

    }
}