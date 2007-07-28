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
    /// The interface provides methods for building a filter graph. An application can use it to add filters to
    /// the graph, connect or disconnect filters, remove filters, and perform other basic operations. 
    /// </summary>
    /// 
    [ComImport,
    Guid( "56A8689F-0AD4-11CE-B03A-0020AF0BA770" ),
    InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IFilterGraph
    {
        /// <summary>
        /// Adds a filter to the graph and gives it a name.
        /// </summary>
        /// 
        /// <param name="pFilter">Filter to add to the graph.</param>
        /// <param name="pName">Name of the filter.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int AddFilter( [In] IBaseFilter pFilter, [In, MarshalAs( UnmanagedType.LPWStr )] string pName );

        /// <summary>
        /// Removes a filter from the graph.
        /// </summary>
        /// 
        /// <param name="pFilter">Filter to be removed from the graph.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int RemoveFilter( [In] IBaseFilter pFilter );

        /// <summary>
        /// Provides an enumerator for all filters in the graph.
        /// </summary>
        /// 
        /// <param name="ppEnum">Filter enumerator.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int EnumFilters( [Out] out IntPtr ppEnum );

        /// <summary>
        /// Finds a filter that was added with a specified name.
        /// </summary>
        /// 
        /// <param name="pName">Name of filter to search for.</param>
        /// <param name="ppFilter">Interface of found filter.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int FindFilterByName( [In, MarshalAs( UnmanagedType.LPWStr )] string pName, [Out] out IBaseFilter ppFilter );

        /// <summary>
        /// Connects two pins directly (without intervening filters).
        /// </summary>
        /// 
        /// <param name="ppinOut">Output pin.</param>
        /// <param name="ppinIn">Input pin.</param>
        /// <param name="pmt">Media type to use for the connection.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int ConnectDirect( [In] IPin ppinOut, [In] IPin ppinIn, [In, MarshalAs( UnmanagedType.LPStruct )] AMMediaType pmt );

        /// <summary>
        /// Breaks the existing pin connection and reconnects it to the same pin.
        /// </summary>
        /// 
        /// <param name="ppin">Pin to disconnect and reconnect.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int Reconnect( [In] IPin ppin );

        /// <summary>
        /// Disconnects a specified pin.
        /// </summary>
        /// 
        /// <param name="ppin">Pin to disconnect.</param>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int Disconnect( [In] IPin ppin );

        /// <summary>
        /// Sets the reference clock to the default clock.
        /// </summary>
        /// 
        /// <returns>Return's <b>HRESULT</b> error code.</returns>
        /// 
        [PreserveSig]
        int SetDefaultSyncSource( );
    }
}
