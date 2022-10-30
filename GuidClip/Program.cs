using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using GuidClip;

const int CF_UNICODETEXT = 0x0D;

unsafe
{
    var buffer = (byte*)NativeMemory.Alloc(32 * 2 + 2);

    var bytesWritten = Encoding.Unicode.GetBytes(
        chars: Guid.NewGuid().ToString(),
        bytes: new Span<byte>(buffer, 36 * 2));

    Debug.Assert(bytesWritten is 36 * 2);

    buffer[72] = 0; // Null Terminator
    buffer[73] = 0; // Null Terminator

    var result = SafeNativeMethods.OpenClipboard(IntPtr.Zero);
    Debug.Assert(result);

    result = SafeNativeMethods.EmptyClipboard();
    Debug.Assert(result);

    SafeNativeMethods.SetClipboardData(CF_UNICODETEXT, buffer);

    result = SafeNativeMethods.CloseClipboard();
    Debug.Assert(result);

    NativeMemory.Free(buffer);
}