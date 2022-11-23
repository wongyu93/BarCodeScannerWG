
using Android.Content;
using Android.Gms.Ads;
using BarCodeScannerWG.AdMob;
using BarCodeScannerWG.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBannerRenderer))]
namespace BarCodeScannerWG.Droid
{
    public class AdBannerRenderer : ViewRenderer
    {
        AdView adView;
        Context context;
        public AdBannerRenderer(Context _context) : base(_context)
        {
            context = _context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (e.OldElement == null)
            {
                adView = new AdView(Context);
                switch ((Element as AdBanner).Size)
                {
                    case AdBanner.Sizes.Standardbanner:
                        adView.AdSize = AdSize.Banner;
                        break;
                    case AdBanner.Sizes.LargeBanner:
                        adView.AdSize = AdSize.LargeBanner;
                        break;
                    case AdBanner.Sizes.MediumRectangle:
                        adView.AdSize = AdSize.MediumRectangle;
                        break;
                    case AdBanner.Sizes.FullBanner:
                        adView.AdSize = AdSize.FullBanner;
                        break;
                    case AdBanner.Sizes.Leaderboard:
                        adView.AdSize = AdSize.Leaderboard;
                        break;
                    case AdBanner.Sizes.SmartBannerPortrait:
                        adView.AdSize = AdSize.SmartBanner;
                        break;
                    default:
                        adView.AdSize = AdSize.Banner;
                        break;
                }

#if DEBUG
                adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
#else
                adView.AdUnitId = "ca-app-pub-9093576399641909/3411579123";
#endif

                var requestbuilder = new AdRequest.Builder();
                adView.LoadAd(requestbuilder.Build());

                if (Control == null)
                {
                    SetNativeControl(adView);
                }
            }
        }

        //public void OnPause()
        //{
        //    adView?.Pause();
        //}

        //public void OnResume()
        //{
        //    adView?.Resume();
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    adView?.Destroy();
        //    base.Dispose(disposing);
        //}
    }
}