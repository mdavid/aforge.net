// AForge Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//
// Copyright © Frank Nagl, 2008-2009
// admin@franknagl.de
// www.franknagl.de
//
namespace AForge.Imaging
{
    using System.Drawing;

    /// <summary>
    /// Segment class keeps information (color and array of all pixel) about found segment. 
    /// The class is used with segmentation algorithms implementing <see cref="ISegmentsDetector"/>
    /// interface.
    /// </summary>
    public class Segment
    {
        //private color of segment
        private Color color;
        /// <summary>Color of segment.</summary>
        public Color Color
        {
            get { return color; }
        }
        //private array with coordinates of all pixel of segment
        private Point[] pixel;
        /// <summary>Array with coordinates of all pixel of segment.</summary>
        public Point[] Pixel
        {
            get { return pixel; }
            set { pixel = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> struct.
        /// </summary>
        /// <param name="color">The color of segment.</param>
        /// <param name="pixel">All pixel of segment.</param>
        public Segment(Color color, Point[] pixel)
        {
            this.color = color;
            this.pixel = pixel;
        }
    }
}
