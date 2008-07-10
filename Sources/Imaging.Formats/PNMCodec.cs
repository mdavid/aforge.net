// AForge Image Formats Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging.Formats
{
    using System;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Text;

    /// <summary>
    /// PNM image format decoder.
    /// </summary>
    /// 
    /// <remarks><para>The PNM (an acronym derived from "Portable Any Map") format is an
    /// abstraction of the PBM, PGM and PPM formats. I.e. the name "PNM" refers collectively
    /// to PBM (binary images), PGM (grayscale images) and PPM (color image) image formats.</para>
    /// 
    /// <para>Image in PNM format can be found in different scientific databases and laboratories,
    /// for example <i>Yale Face Database</i> and <i>AT&amp;T Face Database</i>.</para>
    /// 
    /// <para><note>Only PNM images of P5 (binary encoded PGM) and P6 (binary encoded PPM) formats
    /// are supported at this point.</note></para>
    /// 
    /// <para><note>The maximum supported pixel value is 255 at this point.</note></para>
    /// 
    /// <para><note>The class supports only one-frame PNM images. As it is specified in format
    /// specification, the multi-frame PNM images has appeared starting from 2000.</note></para>
    /// 
    /// </remarks>
    /// 
    public class PNMCodec : IImageDecoder
    {
        /// <summary>
        /// Decode first frame of PNM image.
        /// </summary>
        /// 
        /// <param name="stream">Source stream, which contains encoded image.</param>
        /// 
        /// <returns>Returns decoded image frame.</returns>
        /// 
        /// <exception cref="NotSupportedException">Format of the PNM image is not supported.</exception>
        /// <exception cref="ArgumentException">The stream contains invalid PNM image.</exception>
        /// 
        public Bitmap DecodeSingleFrame( Stream stream )
        {
            // read magic word
            byte magic1 = (byte) stream.ReadByte( );
            byte magic2 = (byte) stream.ReadByte( );

            // check if it is valid PNM image
            if ( ( magic1 != 'P' ) || ( magic2 < '1' ) || ( magic2 > '6' ) )
            {
                throw new ArgumentException( "The stream does not contain valid PNM image." );
            }

            // check if it is P5 or P6 format
            if ( ( magic2 != '5' ) && ( magic2 != '6' ) )
            {
                throw new NotSupportedException( "Format is not supported yet. Only P5 and P6 are supported for now." );
            }

            int width = 0, height = 0, maxValue = 0;

            try
            {
                // read image's width and height
                width  = ReadIntegerValue( stream );
                height = ReadIntegerValue( stream );
                // read pixel's highiest value
                maxValue = ReadIntegerValue( stream );
            }
            catch
            {
                throw new ArgumentException( "The stream does not contain valid PNM image." );
            }

            // check if all attributes are valid
            if ( ( width <= 0 ) || ( height <= 0 ) || ( maxValue <= 0 ) )
            {
                throw new ArgumentException( "The stream does not contain valid PNM image." );
            }

            // check maximum pixel's value
            if ( maxValue > 255 )
            {
                throw new NotSupportedException( "255 is the maximum pixel's value, which is supported for now." );
            }

            try
            {
                // decode PNM image depending on its format
                switch ( magic2 )
                {
                    case (byte) '5':
                        return ReadP5Image( stream, width, height, maxValue );
                    case (byte) '6':
                        return ReadP6Image( stream, width, height, maxValue );
                }
            }
            catch
            {
                throw new ArgumentException( "The stream does not contain valid PNM image." );
            }

            return null;
        }


        // Load P5 PGM image (grayscale PNM image with binary encoding)
        private unsafe Bitmap ReadP5Image( Stream stream, int width, int height, int maxValue )
        {
            double scalingFactor = (double) 255 / maxValue;

            // create new bitmap and lock it
            Bitmap image = Tools.CreateGrayscaleImage( width, height );
            BitmapData imageData = image.LockBits( new Rectangle( 0, 0, width, height ),
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed );

            int stride = imageData.Stride;
            byte* ptr = (byte*) imageData.Scan0.ToPointer( );

            // prepare a buffer for one line
            byte[] line = new byte[width];

            int totalBytesRead = 0, bytesRead = 0;

            // load all rows
            for ( int y = 0; y < height; y++ )
            {
                totalBytesRead = 0;
                bytesRead = 0;

                // load next line
                while ( totalBytesRead != width )
                {
                    bytesRead = stream.Read( line, totalBytesRead, width - totalBytesRead );

                    if ( bytesRead == 0 )
                    {
                        // if we've reached the end before complete image is loaded, then there should
                        // be something wrong
                        throw new Exception( );
                    }

                    totalBytesRead += bytesRead;
                }

                // fill next image row
                byte* row = ptr + stride * y;

                for ( int x = 0; x < width; x++, row++ )
                {
                    *row = (byte) ( scalingFactor * line[x] );
                }
            }

            // unlock image and return it
            image.UnlockBits( imageData );
            return image;
        }

        // Load P6 PPM image (color PNM image with binary encoding)
        private unsafe Bitmap ReadP6Image( Stream stream, int width, int height, int maxValue )
        {
            double scalingFactor = (double) 255 / maxValue;

            // create new bitmap and lock it
            Bitmap image = new Bitmap( width, height, PixelFormat.Format24bppRgb );
            BitmapData imageData = image.LockBits( new Rectangle( 0, 0, width, height ),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

            int stride = imageData.Stride;
            byte* ptr = (byte*) imageData.Scan0.ToPointer( );

            // prepare a buffer for one line
            int lineSize = width * 3;
            byte[] line = new byte[lineSize];

            int totalBytesRead = 0, bytesRead = 0;

            // load all rows
            for ( int y = 0; y < height; y++ )
            {
                totalBytesRead = 0;
                bytesRead = 0;

                // load next line
                while ( totalBytesRead != lineSize )
                {
                    bytesRead = stream.Read( line, totalBytesRead, lineSize - totalBytesRead );

                    if ( bytesRead == 0 )
                    {
                        // if we've reached the end before complete image is loaded, then there should
                        // be something wrong
                        throw new Exception( );
                    }

                    totalBytesRead += bytesRead;
                }

                // fill next image row
                byte* row = ptr + stride * y;

                for ( int x = 0, i = 0; x < width; x++, i += 3, row += 3 )
                {
                    row[2] = (byte) ( scalingFactor * line[i] );       // red
                    row[1] = (byte) ( scalingFactor * line[i + 1] );   // green
                    row[0] = (byte) ( scalingFactor * line[i + 2] );   // blue
                }
            }

            // unlock image and return it
            image.UnlockBits( imageData );
            return image;
        }

        // Read integer ASCII value from the source stream.
        private int ReadIntegerValue( Stream stream )
        {
            byte[] buffer = new byte[256];
            int bytesRead = 1;

            // locate something, what is not spacing
            buffer[0] = SkipSpaces( stream );
            // complete reading useful value
            bytesRead += ReadUntilSpace( stream, buffer, 1 );

            return int.Parse( Encoding.ASCII.GetString( buffer, 0, bytesRead ) );
        }

        // Skip spaces (spaces, new lines, tabs and comment lines) in the specified stream
        // and return the first non-space byte. Stream's position will point to the next
        // byte coming after the first found non-space byte.
        private byte SkipSpaces( Stream stream )
        {
            byte nextByte = (byte) stream.ReadByte( );

            while ( ( nextByte == ' ' ) || ( nextByte == '\n' ) || ( nextByte == '\r' ) || ( nextByte == '\t' ) )
            {
                nextByte = (byte) stream.ReadByte( );
            }

            if ( nextByte == '#' )
            {
                // read until new line
                while ( nextByte != '\n' )
                {
                    nextByte = (byte) stream.ReadByte( );
                }
                // skip pending spaces or another comment
                return SkipSpaces( stream );
            }

            return nextByte;
        }

        // Read stream until space is found (space, new line, tab or comment). Returns
        // number of bytes read. Stream's position will point to the next
        // byte coming after the first found space byte.
        private int ReadUntilSpace( Stream stream, byte[] buffer, int start )
        {
            byte nextByte = (byte) stream.ReadByte( );
            int bytesRead = 0;

            while ( ( nextByte != ' ' ) && ( nextByte != '\n' ) && ( nextByte != '\r' ) && ( nextByte != '\t' ) && ( nextByte != '#' ) )
            {
                buffer[start + bytesRead] = nextByte;
                bytesRead++;
                nextByte = (byte) stream.ReadByte( );
            }

            return bytesRead;
        }
    }
}
