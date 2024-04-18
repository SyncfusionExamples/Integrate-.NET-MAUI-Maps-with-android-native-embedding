# How to integrate .NET MAUI Maps with android native embedding application?
In this article, you will learn how to create a [.NET MAUI Maps](https://www.syncfusion.com/maui-controls/maui-maps) native embedded Android application by following the step by step process explained below.

**Step 1:**
Create a .NET Android application and install the [Syncfusion.Maui.Maps](https://www.nuget.org/packages/Syncfusion.Maui.Maps) nuget package using the [nuget.org](https://www.nuget.org/).

**Step 2:**
In the project file of the native application, add the tag `<UseMaui>true</UseMaui>` to enable the .NET MAUI support as demonstrated below.

**[XML]:** 
 ```xml
<PropertyGroup>
	<Nullable>enable</Nullable>
	<ImplicitUsings>enable</ImplicitUsings>
	<UseMaui>true</UseMaui>
</PropertyGroup>
 ```
 
**Step 3:**
Initialize .NET MAUI in the native app project by creating a **MauiAppBuilder** object and using the **UseMauiEmbedding** function. Then, use the **Build()** method on the **MauiAppBuilder** object to build a **MauiApp** object. Finally, create a **MauiContext** object from the MauiApp object to convert .NET MAUI controls to native types.

**[C#]:** 
 ```csharp
MauiContext? _mauiContext;
protected override void OnCreate(Bundle? savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    MauiAppBuilder builder = MauiApp.CreateBuilder();
    builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
    builder.ConfigureSyncfusionCore();
    MauiApp mauiApp = builder.Build();
    _mauiContext = new MauiContext(mauiApp.Services, this);
}
 ```
 
**Step 4:**
Create a new instance for the SfMaps control, add a shape layer to it, and set the source of the map shapes using the [ShapesSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Maps.MapShapeLayer.html#Syncfusion_Maui_Maps_MapShapeLayer_ShapesSource) property of the [MapShapeLayer](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Maps.MapShapeLayer.html).
 
**[C#]:** 
 ```csharp
protected override void OnCreate(Bundle? savedInstanceState)
{
   ...
   SfMaps map = new SfMaps();
   MapShapeLayer layer = new MapShapeLayer();
   layer.ShapesSource = MapSource.FromUri(new Uri("https://cdn.syncfusion.com/maps/map-data/world-map.json"));
   map.Layer = layer;
   ...
}
 ```
 
**Step 5:**
Convert the Maps control to a platform-specific view for the .NET MAUI framework and set this view as the content view for the current Android activity.

**[C#]:** 
 ```csharp
protected override void OnCreate(Bundle? savedInstanceState)
{
   Android.Views.View view = map.ToPlatform(_mauiContext);

   // Set our view from the "main" layout resource
   SetContentView(view);
}
 ```

**Output:**

 ![Map-Android-Native-Embedding.png](https://syncfusion.bolddesk.com/kb/agent/attachment/article/15039/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIxMjk0Iiwib3JnaWQiOiIzIiwiaXNzIjoic3luY2Z1c2lvbi5ib2xkZGVzay5jb20ifQ.5YoUPaX9jHRLmWuSFDPlCFQ4sTUypypplfOckfjzq5Y)
