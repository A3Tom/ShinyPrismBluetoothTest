using System;

using Android.App;
using Android.Runtime;
using Shiny;

namespace ShinyPrismBLE_Trial.Droid
{
    [Application(Debuggable = true)]
    public class MainApplication : ShinyAndroidApplication<ShinyAppStartup>
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }
    }
}