// AForge Core Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2008
// andrew.kirillov@gmail.com
//

namespace AForge
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Set of systems tools.
    /// </summary>
    /// 
    /// <remarks><para>The class is a container of different system tools, which are used
    /// across the framework. Some of these tools are platform specific, so their
    /// implementation is different on different platform, like .NET and Mono.</para>
    /// </remarks>
    /// 
    public class SystemTools
    {
        /// <summary>
        /// Copy block of unmanaged memory.
        /// </summary>
        /// 
        /// <param name="dst">Destination pointer.</param>
        /// <param name="src">Source pointer.</param>
        /// <param name="count">Memory block's length to copy.</param>
        /// 
        /// <returns>Return's the value of <b>dst</b> - pointer to destination.</returns>
        ///
        public static IntPtr CopyUnmanagedMemory( IntPtr dst, IntPtr src, int count )
        {
            unsafe
            {
                CopyUnmanagedMemory( (byte*) dst.ToPointer( ), (byte*) src.ToPointer( ), count );
            }
            return dst;
        }

        /// <summary>
        /// Copy block of unmanaged memory.
        /// </summary>
        /// 
        /// <param name="dst">Destination pointer.</param>
        /// <param name="src">Source pointer.</param>
        /// <param name="count">Memory block's length to copy.</param>
        /// 
        /// <returns>Return's the value of <b>dst</b> - pointer to destination.</returns>
        /// 
        public static unsafe byte* CopyUnmanagedMemory( byte* dst, byte* src, int count )
        {
#if !MONO
            return memcpy( dst, src, count );
#else
            int countUint = count >> 2;
            int countByte = count & 3;

            uint* dstUint = (uint*) dst;
            uint* srcUint = (uint*) src;

            while ( countUint-- != 0 )
            {
                *dstUint++ = *srcUint++;
            }

            byte* dstByte = (byte*) dstUint;
            byte* srcByte = (byte*) srcUint;

            while ( countByte-- != 0 )
            {
                *dstByte++ = *srcByte++;
            }
            return dst;
#endif
        }


#if !MONO
        // Win32 memory copy function
        [DllImport( "ntdll.dll" )]
        private static unsafe extern byte* memcpy(
            byte* dst,
            byte* src,
            int count );
#endif
    }
}
