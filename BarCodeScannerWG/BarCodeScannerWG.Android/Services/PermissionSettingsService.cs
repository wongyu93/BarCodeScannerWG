using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCodeScannerWG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(BarCodeScannerWG.Droid.Services.PermissionSettingsService))]
namespace BarCodeScannerWG.Droid.Services
{
    public class PermissionSettingsService : IPermissionSettingsService
    {
        public void OpenAppSettings()
        {
            var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
            intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.SingleTop | ActivityFlags.ClearTop);
            var uri = Android.Net.Uri.FromParts("package", Application.Context.PackageName, null);
            intent.SetData(uri);
            Application.Context.StartActivity(intent);

        }
    }
}