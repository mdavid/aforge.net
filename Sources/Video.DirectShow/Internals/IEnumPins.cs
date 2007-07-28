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
    /// Enumerates pins on a filter.
    /// </summary>
    /// 
    [ComImport,
    Guid( "56A86892-0AD4-11CE-B03A-0020AF0BA770" ),
    InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IEnumPins
    {
        /// <summary>
        /// Retrieves a specified number of pins.
        /// </summary>
        /// 
        /// <param name="cPins">Number of pins to retrieve.</param>
        /// <param name="ppPins">Array of size <b>cPins</b> that is filled with <b>IPin</b> pointers.</param>
        /// <param name="pcFetched">Pointer to a variable that receives the number of pins retrieved.
        /// Can be NULL if <b>cPins</b> is 1.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int Next( [In] int cPins,
            [Out, MarshalAs( UnmanagedType.LPArray, SizeParamIndex = 0 )] IPin[] ppPins,
            [Out] out int pcFetched );

        /// <summary>
        /// Skips over a specified number of pins.
        /// </summary>
        /// 
        /// <param name="cPins">Number of pins to skip.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int Skip( [In] int cPins );

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int Reset( );

        /// <summary>
        /// Makes a copy of the enumerator with the same enumeration state. 
        /// </summary>
        /// 
        /// <param name="ppEnum">Address of a variable that receives a pointer to the
        /// <b>IEnumPins</b> interface of the new enumerator.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int Clone( [Out] out IEnumPins ppEnum );
    }
}
