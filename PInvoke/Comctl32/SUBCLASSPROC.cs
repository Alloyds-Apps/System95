using System95.PInvoke.User32;
using System;

namespace System95.PInvoke.Comctl32
{
    public delegate IntPtr SUBCLASSPROC(IntPtr hWnd, WindowMessage uMsg, IntPtr wParam, IntPtr lParam, uint uIdSubclass, IntPtr dwRefData);
}
