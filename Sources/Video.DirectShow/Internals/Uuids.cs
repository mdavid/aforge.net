// AForge Direct Show Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2007
// andrew.kirillov@gmail.com
//

namespace AForge.Video.DirectShow.Internals
{
    using System;
    using System.Runtime.InteropServices;

	/// <summary>
	/// DirectShow class IDs.
	/// </summary>
    [ComVisible( false )]
    public class Clsid
    {
        /// <summary>
        /// System device enumerator.
        /// </summary>
        /// 
        /// <remarks>Equals to CLSID_SystemDeviceEnum.</remarks>
        /// 
        public static readonly Guid SystemDeviceEnum =
            new Guid( 0x62BE5D10, 0x60EB, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86 );

    }
}
