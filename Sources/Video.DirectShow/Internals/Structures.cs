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

    // PIN_DIRECTION

    /// <summary>
    /// This enumeration indicates a pin's direction.
    /// </summary>
    /// 
    [ComVisible( false )]
    public enum PinDirection
    {
        /// <summary>
        /// Input pin.
        /// </summary>
        Input,

        /// <summary>
        /// Output pin.
        /// </summary>
        Output
    }

    // AM_MEDIA_TYPE

    /// <summary>
    /// The structure describes the format of a media sample.
    /// </summary>
    /// 
    [ComVisible( false ),
    StructLayout( LayoutKind.Sequential )]
    public class AMMediaType : IDisposable
    {
        /// <summary>
        /// Globally unique identifier (GUID) that specifies the major type of the media sample.
        /// </summary>
        public Guid majorType;

        /// <summary>
        /// GUID that specifies the subtype of the media sample.
        /// </summary>
        public Guid subType;

        /// <summary>
        /// If <b>true</b>, samples are of a fixed size.
        /// </summary>
        [MarshalAs( UnmanagedType.Bool )]
        public bool fixedSizeSamples = true;

        /// <summary>
        /// If <b>true</b>, samples are compressed using temporal (interframe) compression.
        /// </summary>
        [MarshalAs( UnmanagedType.Bool )]
        public bool temporalCompression;

        /// <summary>
        /// Size of the sample in bytes. For compressed data, the value can be zero.
        /// </summary>
        public int sampleSize = 1;

        /// <summary>
        /// GUID that specifies the structure used for the format block.
        /// </summary>
        public Guid formatType;

        /// <summary>
        /// Not used.
        /// </summary>
        public IntPtr unkPtr;

        /// <summary>
        /// Size of the format block, in bytes.
        /// </summary>
        public int formatSize;

        /// <summary>
        /// Pointer to the format block.
        /// </summary>
        public IntPtr formatPtr;

        /// <summary>
        /// Destroys the instance of the <see cref="AMMediaType"/> class.
        /// </summary>
        /// 
        ~AMMediaType( )
        {
            Dispose( false );
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        ///
        public void Dispose( )
        {
            Dispose( true );
            // remove me from the Finalization queue 
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        /// 
        /// <param name="disposing">Indicates if disposing was initiated manually.</param>
        /// 
        protected virtual void Dispose( bool disposing )
        {
            if ( formatSize != 0 )
                Marshal.FreeCoTaskMem( formatPtr );
            if ( unkPtr != IntPtr.Zero )
                Marshal.Release( unkPtr );
        }
    }


    // PIN_INFO

    /// <summary>
    /// The structure contains information about a pin.
    /// </summary>
    /// 
    [ComVisible( false ),
    StructLayout( LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode )]
    public class PinInfo
    {
        /// <summary>
        /// Owning filter.
        /// </summary>
        public IBaseFilter filter;

        /// <summary>
        /// Direction of the pin.
        /// </summary>
        public PinDirection dir;

        /// <summary>
        /// Name of the pin.
        /// </summary>
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 128 )]
        public string name;
    }
}
