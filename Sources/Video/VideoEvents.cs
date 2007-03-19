// AForge Video Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2007
// andrew.kirillov@gmail.com
//

namespace AForge.Video
{
    using System;

    /// <summary>
    /// Delegate for new event handler
    /// </summary>
    /// <param name="sender">Sender object</param>
    /// <param name="eventArgs">Event arguments</param>
    /// 
    public delegate void NewFrameEventHandler( object sender, NewFrameEventArgs eventArgs );

    /// <summary>
    /// Arguments for new frame evemt from video source
    /// </summary>
    /// 
    public class NewFrameEventArgs : EventArgs
    {
        private System.Drawing.Bitmap frame;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewFrameEventArgs"/> class
        /// </summary>
        /// 
        /// <param name="frame">New frame</param>
        /// 
        public NewFrameEventArgs( System.Drawing.Bitmap frame )
        {
            this.frame = frame;
        }

        /// <summary>
        /// New frame from video source
        /// </summary>
        /// 
        public System.Drawing.Bitmap Frame
        {
            get { return frame; }
        }
    }
}
