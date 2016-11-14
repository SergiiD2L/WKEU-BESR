using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android;
using Android.Support.Design.Widget;
using Xamarin.Forms;

namespace WKEU_BESR.Droid
{

    [Activity(Label = "WKEU_BESR", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;
        string[] PermissionsLocation = {
                                Android.Manifest.Permission.AccessCoarseLocation,
                                Android.Manifest.Permission.AccessFineLocation
                                };

        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Forms.DependencyService.Register<INavigation>();
            LoadApplication(new App());

            GetLocationPermissionAsync();
        }

        void GetLocationPermissionAsync()
        {

            if ((int)Build.VERSION.SdkInt >= 23)
            {

                if (CheckSelfPermission(PermissionsLocation[0]) == (int)Permission.Granted)
                {
                    return;
                }
                if (CheckSelfPermission(PermissionsLocation[1]) == (int)Permission.Granted)
                {
                    return;
                }
                RequestPermissions(PermissionsLocation, RequestLocationId);
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                        }
                        else
                        {
                        }
                    }
                    break;
            }
        }        
    }
}

