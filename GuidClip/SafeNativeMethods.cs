namespace GuidClip;

using System.Runtime.InteropServices;

public static unsafe partial class SafeNativeMethods
{
    [return: MarshalAs(UnmanagedType.Bool)]
    [LibraryImport("user32.dll", SetLastError = true)]
    public static partial bool CloseClipboard();

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool EmptyClipboard();

    [return: MarshalAs(UnmanagedType.Bool)]
    [LibraryImport("user32.dll", SetLastError = true)]
    public static partial bool OpenClipboard(IntPtr hWndNewOwner);

    [LibraryImport("user32.dll")]
    public static partial IntPtr SetClipboardData(uint uFormat, byte* memory);
}