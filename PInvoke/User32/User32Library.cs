using System;
using System.Runtime.InteropServices;

namespace System95.PInvoke.User32
{
    public static partial class User32Library
    {
        private const string User32 = "user32.dll";
        [LibraryImport(User32, EntryPoint = "FindWindowExW", SetLastError = false, StringMarshalling = StringMarshalling.Utf16)]
        internal static partial IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);
    }
}
