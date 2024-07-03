using Windows.ApplicationModel;

namespace System95.Helpers
{
    public static class InfoHelper
    {
        public static string AppInstalledLocation { get; } = Package.Current.InstalledLocation.Path;
    }
}
