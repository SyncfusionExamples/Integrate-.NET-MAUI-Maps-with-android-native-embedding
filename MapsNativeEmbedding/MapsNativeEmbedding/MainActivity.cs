using Android.App;
using Android.OS;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Maps;

namespace MapsNativeEmbedding
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MauiContext? _mauiContext;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
            builder.ConfigureSyncfusionCore();
            MauiApp mauiApp = builder.Build();
            _mauiContext = new MauiContext(mauiApp.Services, this);

            SfMaps map = new SfMaps();
            MapShapeLayer layer = new MapShapeLayer();
            layer.ShapesSource = MapSource.FromUri(new Uri("https://cdn.syncfusion.com/maps/map-data/world-map.json"));
            map.Layer = layer;

            Android.Views.View view = map.ToPlatform(_mauiContext);

            // Set our view from the "main" layout resource
            SetContentView(view);
        }
    }
}