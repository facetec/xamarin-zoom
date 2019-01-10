**Limited Support Notice**
--------------------------
This plugin, bindings, and sample code are meant for example purposes.  This example is not guaranteed to run out of the box as it may be utilizing an older version of ZoOm than we officially support for development purposes.

For experienced Xamarin developers, this plugin and the sample provided should be enough to port ZoOm into your own application.  There may be some work required to update the bindings to the versy latest released Native iOS and Android ZoOm libraries (7.0.0)+, which can be downloaded here - https://dev.zoomlogin.com/zoomsdk/#/downloads.

Hopefully this is enough to get you going!

If you have any more technical questions or need assistance upgrading this library to the latest version of ZoOm, please feel free to contact us at support@zoomlogin.com
------------------------------
**End Limited Support Notice**

ZoOm SDK for Xamarin
------------
To get started with ZoOm, you must be registered.  If you don't have an app token, register for [developer access](https://dev.zoomlogin.com/).

Getting Started - Android
---------
To install the library for Android, simply open your project and install our NuGet package named `Xamarin.Zoom.AndroidLibrary`.  For more details on how to install a NuGet package, [see here](https://blog.xamarin.com/xamarin-studio-and-nuget/).

Once the library is installed, see our [Android Sample App](https://github.com/facetec/xamarin-zoom/tree/master/Samples/iOS) for an example of how to use it.  For a more in-depth explanation of the ZoOm SDK and its capabilities, see the [Android documentation](https://dev.zoomlogin.com/zoomsdk/#/android-guide) for the native library.

Getting Started - iOS
---------
To install the library for iOS, simply open your project and install our NuGet package named `Xamarin.Zoom.iOSLibrary`.  For more details on how to install a NuGet package, [see here](https://blog.xamarin.com/xamarin-studio-and-nuget/).

Once the library is installed, see our [iOS Sample App](https://github.com/facetec/xamarin-zoom/tree/master/Samples/iOS) for an example of how to use it.  For a more in-depth explanation of the ZoOm SDK and its capabilities, see the [iOS documentation](https://dev.zoomlogin.com/zoomsdk/#/ios-guide) for the native library.

Limitations
------
Most functionality of the native Android and iOS libraries is available through these libraries with some exceptions.  Most notably, there is currently no support for UI customization.  It will likely be added in the future.
