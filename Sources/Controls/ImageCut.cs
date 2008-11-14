// AForge Controls Library
// AForge.NET framework
//
// Copyright © Frank Nagl, 2008
// admin@franknagl.de
// www.franknagl.de
//
namespace AForge.Controls
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// Declares the event handler for moving sliders 
    /// </summary>
    public delegate void OnSliderMovedEventHandler();

    /// <summary>
    /// The enum values represent the position of a slider as an id.
    /// </summary>
    public enum Sliders
    {
        /// <summary>
        /// The id for the left slider.
        /// </summary>
        Left,
        /// <summary>
        /// The id for the right slider.
        /// </summary>
        Right,
        /// <summary>
        /// The id for the up slider.
        /// </summary>
        Up,
        /// <summary>
        /// The id for the down slider.
        /// </summary>
        Down
    }

    /// <summary>
    /// The ImageCut control.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The ImageCut control allows to trim and cut a picture by moving
    /// sliders per mouse dragging. 
    /// Furthermore it provides interfaces to move a rollovered slider
    /// or a specified slider for a defined 
    /// value (e.g. moving the right slider for 3 pixel).
    /// </para>
    /// <para>Sample usage:</para>
    /// <code>
    /// //the picture, which will be trimmed and cut
    /// Bitmap myPicture = (Bitmap) Bitmap.FromFile("Path of picture");
    /// 
    /// //Maximal allowed width of the picture
    /// int maxWidth = 200;
    /// 
    /// //Maximal allowed height of the picture
    /// int maxHeight = 100;
    /// 
    /// //Initializes the ImageCut control
    /// ImageCut myImageCut = new ImageCut(myPicture, maxWidth, maxHeight);
    /// 
    /// //Optional: Only necessary, if you need to process a slider movement
    /// myImageCut.OnSliderMovedEvent += new OnSliderMovedHandler(OnSliderMoved);
    /// 
    /// //Optional: Setting some properties, otherwise it will be used the default values
    /// myImageCut.Location = new Point(5, 5);
    /// myImageCut.Transparence = 220;
    /// myImageCut.LineStrength = 3;            
    /// myImageCut.ColorSliders = Color.Green;
    /// myImageCut.ColorRolloverSlider = Color.Red;
    /// myImageCut.MinSizeOfImage = 100;
    /// 
    /// //Completes the initialization, need to be called after setting properties
    /// myImageCut.init();
    /// 
    /// //Adds the ImageCut control to the form
    /// myForm.Controls.Add(myImageCut);
    /// </code>
    /// <para><b>Sample control's look:</b></para>
    /// <img src="ImageCut.jpg" width="358" height="289" />
    /// </remarks>
    public class ImageCut : Control
    {
        /// <summary>
        /// Represents the course of a slider.
        /// </summary>
        private enum Course
        {
            Horicontal,
            Vertical,
            Both
        }

        /// <summary>
        /// Represents the framework for a graphic object.
        /// </summary>
        private abstract class GraphicObject
        {
            /// <summary>
            /// This Pen-Objekt is used to check, if a point is located over the line of an object. 
            /// The color is irrelevant. As width the value <code>4</code> makes a good job.
            /// </summary>
            static Pen HitTestPen = new Pen(Brushes.Black, 4);
            Pen pen;
            bool visible = true;
            GraphicsPath path = new GraphicsPath();
            Course allowedCourse = Course.Both;
            private Point start;
            public Point Start
            {
                get { return start; }
                set { start = value; }
            }

            private Point end;
            public Point End
            {
                get { return end; }
                set { end = value; }
            }

            public GraphicObject(Pen pen)
            {
                this.pen = pen;
            }

            public GraphicsPath Path
            {
                get { return path; }
                set { path = value; }
            }

            public Color ColorOfPen
            {
                get { return pen.Color; }
                set { pen.Color = value; }
            }

            public Pen Pen
            {
                get { return pen; }
                //set { _pen = value; }
            }

            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }

            public Course AllowedCourse
            {
                get { return allowedCourse; }
                set { allowedCourse = value; }
            }

            /// <summary>
            /// Checks, if the given point is on the contour of the object.
            /// </summary>
            public virtual bool Hit(Point pt)
            {                
                return path.IsOutlineVisible(pt, HitTestPen);
            }

            /// <summary>
            /// Checks, if the given point is inside the object.
            /// </summary>
            public virtual bool Contains(Point pt)
            {
                return path.IsVisible(pt);
            }

            /// <summary>
            /// Draws the graphic object.
            /// </summary>
            /// <param name="g"></param>
            public virtual void Draw(Graphics g)
            {
                g.DrawPath(pen, path);
            }

            /// <summary>
            /// Moves the graphic object <para>deltaX</para> pixel in x-direction (horizontal)
            /// and <para>deltaY</para> pixel in y-direction (vertical)
            /// </summary>
            public virtual void Move(int deltaX, int deltaY)
            {
                Matrix mat = new Matrix();
                mat.Translate(deltaX, deltaY);
                path.Transform(mat);
                start.X = (int)Path.PathPoints[0].X;
                start.Y = (int)Path.PathPoints[0].Y;
                end.X = (int)Path.PathPoints[1].X;
                end.Y = (int)Path.PathPoints[1].Y;
            }
        }

        /// <summary>
        /// Represents a graphic rectangle.
        /// </summary>
        private class GraphicRectangle : GraphicObject
        {
            public GraphicRectangle(Pen pen, Rectangle rect)
                : base(pen)
            {
                Path.AddRectangle(rect);
                //Path.FillMode = FillMode.Winding;
            }

            public void Fill(Graphics g)
            {
                g.FillPath(new SolidBrush(Pen.Color), Path);
            }
        }

        /// <summary>
        /// Represents a graphic line.
        /// </summary>
        private class GraphicLine : GraphicObject
        {
            public GraphicLine(Pen pen, Point start, Point end, Course direction)
                : base(pen)
            {
                Path.AddLine(start, end);
                AllowedCourse = direction;
                Start = start;
                End = end;
            }
        }

        #region public properties
        /// <summary>
        /// The distance between image- and control border.
        /// </summary>
        /// <remarks>
        /// <para>The value should be bigger than <value>0</value>.</para>
        /// <para>Otherwise it is difficult to use the mouse cursor for moving a slider exactly
        /// to the image border</para>
        /// <para>NOTE: The distance value is the sum of a site pair, 
        /// e.g. <code>mDistanceToImage = 10</code> means 5 pixel distance between 
        /// left site of control- and image border, and 5 pixel distance between 
        /// right site of control- and image border, equivalent for up and down.</para>
        /// <para>Default value: <code>10</code> pixel</para>
        /// </remarks>        
        private byte distanceToImage;
        /// <summary>
        /// The distance between image- and control border.
        /// </summary>
        /// <remarks>
        /// <para>The value should be bigger than <value>0</value>.</para>
        /// <para>Otherwise it is difficult to use the mouse cursor for moving a slider exactly
        /// to the image border</para>
        /// <para>NOTE: The distance value is the sum of a site pair, 
        /// e.g. <code>mDistanceToImage = 10</code> means 5 pixel distance between 
        /// left site of control- and image border, and 5 pixel distance between 
        /// right site of control- and image border, equivalent for up and down.</para>
        /// <para>Default value: <code>10</code> pixel</para>
        /// </remarks>        
        public byte DistanceToImage
        {
            get { return distanceToImage; }
            set { distanceToImage = value; }
        }

        /// <summary>
        /// The size-adapted picture, which will be seen.
        /// </summary>
        public Bitmap AdaptedPicture
        {
            get { return (Bitmap)this.BackgroundImage; }
            set { this.BackgroundImage = value; }
        }

        /// <summary>
        /// The original picture, unmodified.
        /// </summary>
        private Bitmap originalPicture;
        /// <summary>
        /// The original picture, unmodified.
        /// </summary>
        public Bitmap OriginalPicture
        {
            get { return originalPicture; }
            //set { mOriginalPicture = value; }
        }

        /// <summary>
        /// The factor, which is used to scale and adapt the <see cref="OriginalPicture"/>
        /// to the <see>AdaptedPicture</see>.
        /// </summary>
        private float scaleFactor;
        /// <summary>
        /// The factor, which is used to scale and adapt the <see cref="OriginalPicture"/>
        /// to the <see>AdaptedPicture</see>.
        /// </summary>
        public float ScaleFactor
        {
            get { return scaleFactor; }
        }

        /// <summary>
        /// The line strength of the sliders
        /// </summary>
        /// <remarks>
        /// <para>Default value: <code>3</code> pixel</para>
        /// </remarks>
        private byte lineStrength;
        /// <summary>
        /// The line strength of the sliders
        /// </summary>
        /// <remarks>
        /// <para>Default value: <code>3</code> pixel</para>
        /// </remarks>
        public byte LineStrength
        {
            get { return lineStrength; }
            set { lineStrength = value; }
        }

        /// <summary>
        /// The general color of the sliders.
        /// </summary>
        private Color colorSliders;
        /// <summary>
        /// The general color of the sliders.
        /// </summary>
        public Color ColorSliders
        {
            get { return colorSliders; }
            set { colorSliders = value; }
        }

        /// <summary>
        /// The color of the slider, when the mouse cursor is rollovered.
        /// </summary>
        private Color colorRolloverSlider;
        /// <summary>
        /// The color of the slider, when the mouse cursor is rollovered.
        /// </summary>
        public Color ColorRolloverSlider
        {
            get { return colorRolloverSlider; }
            set { colorRolloverSlider = value; }
        }

        /// <summary>
        /// The transparency value of the graphic rectangles (also called Slider space), 
        /// which represents the cutted areas of the picture.
        /// </summary>
        private byte transparency;
        /// <summary>
        /// The transparency value of the graphic rectangles (also called Slider space), 
        /// which represents the cutted areas of the picture.
        /// </summary>
        public byte Transparency
        {
            get { return transparency; }
            set { transparency = value; }
        }

        /// <summary>
        /// The color of the graphic rectangles (also called Slider space), 
        /// which represents the cutted areas of the picture.
        /// </summary>
        private Color colorSliderSpace;
        /// <summary>
        /// The color of the graphic rectangles (also called Slider space), 
        /// which represents the cutted areas of the picture.
        /// </summary>
        public Color ColorSliderSpace
        {
            get { return colorSliderSpace; }
            set { colorSliderSpace = value; }
        }

        private byte minSizeOfImage;
        /// <summary>
        /// Represents the minimum width and height of the picture.
        /// </summary>
        public byte MinSizeOfImage
        {
            get { return minSizeOfImage; }
            set { minSizeOfImage = value; }
            //set { mMinSizeOfImage = (byte)((float)value / mScaleFactor); }
        }

        private byte neighbourTolerance;
        /// <summary>
        /// Represents the tolerance value (in pixel), how far away a horicontal and a
        /// vertical slider could be to be selected together as an edge.
        /// </summary>
        public byte NeighbourTolerance
        {
            get { return neighbourTolerance; }
            set { neighbourTolerance = value; }
        }

        private Cursor cursorMoveDisplayWindow;
        /// <summary>
        /// The cursor, which is displayed, when the mouse cursor is inside the 
        /// cutted picture without touching any slider.
        /// </summary>
        public Cursor CursorMoveDisplayWindow
        {
            get { return cursorMoveDisplayWindow; }
            set { cursorMoveDisplayWindow = value; }
        }

        private Cursor cursorDefault;
        /// <summary>
        /// The cursor, which is displayed, when the mouse cursor neither selects
        /// a slider nor moves the display window.
        /// </summary>
        public Cursor CursorDefault
        {
            get { return cursorDefault; }
            set { cursorDefault = value; }
        }

        private Cursor cursorRolloverSlider;
        /// <summary>
        /// The cursor, which is displayed, when the mouse cursor rollover a slider.
        /// </summary>
        public Cursor CursorRolloverSlider
        {
            get { return cursorRolloverSlider; }
            set { cursorRolloverSlider = value; }
        }

        /// <summary>
        /// Gets the left-slider's position internal (of the adapted picture).
        /// </summary>
        /// <value>The left-slider's position internal.</value>
        private int LeftPositionInternal
        {
            get { return sliders[(byte)Sliders.Left].Start.X - distanceToImage / 2; }
        }

        private int leftPosition;
        /// <summary>
        /// Gets the left-slider's position.
        /// </summary>
        /// <value>The left-slider's position.</value>
        public int LeftPosition
        {
            get { return leftPosition; }
        }

        /// <summary>
        /// Gets the right-slider's position.
        /// </summary>
        /// <value>The right-slider's position.</value>
        public int RightPosition
        {
            get { return ActualWidth + LeftPosition; }
        }

        /// <summary>
        /// Gets up-slider's position internal (of the adapted picture).
        /// </summary>
        /// <value>Up-slider's position internal.</value>
        private int UpPositionInternal
        {
            get { return sliders[(byte)Sliders.Up].Start.Y - distanceToImage / 2; }
        }

        private int upPosition;
        /// <summary>
        /// Gets up-slider's position.
        /// </summary>
        /// <value>Up-slider's position.</value>
        public int UpPosition
        {
            get { return upPosition; }
        }

        /// <summary>
        /// Gets down-slider's position.
        /// </summary>
        /// <value>Down-slider's position.</value>
        public int DownPosition
        {
            get { return ActualHeight + UpPosition; }
        }

        /// <summary>
        /// Actual temporar width of the <see cref="AdaptedPicture"/> after using vertical sliders.
        /// </summary>
        private int ActualWidthInternal
        {
            get { return sliders[(byte)Sliders.Right].Start.X - sliders[(byte)Sliders.Left].Start.X; }
        }

        private int actualWidth;
        /// <summary>
        /// Actual temporar width of the <see cref="OriginalPicture"/> after using vertical sliders.
        /// </summary>
        public int ActualWidth
        {
            get { return actualWidth; }
            //get { return (int)((float)mActualWidthIntern * mScaleFactor); }
        }

        /// <summary>
        /// Actual temporar height of the <see cref="AdaptedPicture"/> after using horicontal sliders.
        /// </summary>
        private int ActualHeightInternal
        {
            get { return sliders[(byte)Sliders.Down].Start.Y - sliders[(byte)Sliders.Up].Start.Y; }
        }

        private int actualHeight;
        /// <summary>
        /// Actual temporar height of the <see cref="OriginalPicture"/> after using horicontal sliders.
        /// </summary>
        public int ActualHeight
        {
            get { return actualHeight; }            
        }

        /// <summary>
        /// Gets the height of the original picture.
        /// </summary>
        /// <value>The height of the original picture.</value>
        public int OriginalHeight
        {
            get { return originalPicture.Height; }
        }

        /// <summary>
        /// Gets the width of the original picture.
        /// </summary>
        /// <value>The width of the original picture.</value>
        public int OriginalWidth
        {
            get { return originalPicture.Width; }
        }

        private float ratio;
        /// <summary>
        /// Gets or sets the ratio.
        /// </summary>
        /// <value>The ratio.</value>
        public float Ratio
        {
            get { return ratio; }
            set { ratio = value; }
        }

        /// <summary>
        /// This variable handles the OnSliderMoved-event at the client.        
        /// </summary>
        public OnSliderMovedEventHandler OnSliderMovedEvent;
        #endregion public properties

        private GraphicObject[] sliders;
        private GraphicObject[] choosedSliders;
        private GraphicRectangle[] slidersWaste;
        private Rectangle canvasRect;
        private Point lastMouseLocation;
        private bool isMouseDown;
        private bool isAlreadyInit;
        private bool isSliderChoosed;
        private bool isCheckNecessary = true;
        private int up;
        private int down;
        private int left;
        private int right;
        private float[] spaces = new float[4];

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCut"/> class.
        /// </summary>
        /// <remarks>The picture seen on the <see cref="ImageCut"/> control will not
        /// be bigger than the given <paramref name="maxWidth"/> and 
        /// <paramref name="maxHeight"/> </remarks>
        /// <param name="originalPicture">The original picture.</param>
        /// <param name="maxWidth">Maximum Width.</param>
        /// <param name="maxHeight">Maximum Height.</param>
        public ImageCut(Bitmap originalPicture, float maxWidth, float maxHeight)
        {         
            this.originalPicture = originalPicture;
            adaptPicture(maxWidth, maxHeight);//Calculates and sets 'adaptedPicture' and 'scaleFactor'
            defaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCut"/> class,
        /// already with the correct-sized picture.
        /// </summary>
        /// <param name="originalPicture">The original picture.</param>
        public ImageCut(Bitmap originalPicture)
        {            
            this.originalPicture = originalPicture;
            AdaptedPicture = originalPicture;
            scaleFactor = 1.0f;
            defaultValues();
        }

        /// <summary>
        /// Defaults the values.
        /// </summary>
        private void defaultValues()
        {
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageCut_MouseMove);
            sliders = new GraphicObject[4];
            choosedSliders = new GraphicObject[2];
            slidersWaste = new GraphicRectangle[4];
            isMouseDown = false;
            actualWidth = originalPicture.Width;
            actualHeight = originalPicture.Height;

            //properties: default values
            ratio = 0.0f;
            distanceToImage = 10;
            lineStrength = 3;
            minSizeOfImage = 50;
            neighbourTolerance = 50;
            transparency = 220;
            colorSliders = Color.Green;//Color.FromArgb(0);
            colorRolloverSlider = Color.FromArgb(255, 20, 20);
            colorSliderSpace = Color.FromArgb(220, 220, 255);
            cursorMoveDisplayWindow = Cursors.Hand;
            cursorDefault = Cursors.Default;
            cursorRolloverSlider = Cursors.Cross;
        }

        /// <summary>      
        /// Finalizes the initialization of this control.
        /// </summary>
        /// <remarks>After initialization per constructor
        /// and setting the properties, it is necessary to call this function.</remarks>
        public void init()
        {
            isAlreadyInit = true;
            this.Size = new Size(AdaptedPicture.Width + distanceToImage, AdaptedPicture.Height + distanceToImage);
            this.BackgroundImageLayout = ImageLayout.Center;

            initBorderValues();
            initSliders();
            setSlidersSpace();

            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Forces the ImageCut-control to invalidate its client area and 
        /// immediately redraw itself and any child controls.
        /// </summary>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        public override void Refresh()
        {
            //Saves the old positions
            int leftPos = LeftPosition;
            int rightPos = RightPosition;//ActualWidth + LeftPosition;
            int upPos = UpPosition;
            int downPos = DownPosition;

            //Resetting of the properties of the ImgaCut-components (sliders, slider-space,..)
            actualWidth = originalPicture.Width;
            actualHeight = originalPicture.Height;
            leftPosition = 0;
            upPosition = 0;
            init();
            //fireSliderMovedEvent();

            //Puts back the sliders in its old position
            movingInDirectly(sliders[(byte)Sliders.Left], leftPos);
            movingInDirectly(sliders[(byte)Sliders.Right], -(originalPicture.Width - rightPos));
            movingInDirectly(sliders[(byte)Sliders.Up], upPos);
            movingInDirectly(sliders[(byte)Sliders.Down], -(originalPicture.Height - downPos));

            base.Refresh();
            
        }

        /// <summary>
        /// Moves the slider.
        /// </summary>
        /// <param name="moveValue">The move value.</param>
        /// <param name="id">The id, which represents the
        /// slider, <seealso cref="Sliders"/>.</param>
        public void moveSlider(int moveValue, Sliders id)
        {
            resetChoosedSliders();
            choosedSliders[0] = sliders[(byte)id];
            sliders[(byte)id].ColorOfPen = colorRolloverSlider;
            movingInDirectly(sliders[(byte)id], moveValue);
        }

        /// <summary>
        /// Moves a choosed vertical slider outside of this control.
        /// </summary>
        /// <remarks>
        /// <para>A negative value moves the slider left, a positive right</para>
        /// <para>Note: This method has to be used, when a vertical slider was 
        /// choosed/rollovered by mouse and it should be moved (without mouse navigation). 
        /// If you know sure, if you want to move the right
        /// (or left) slider, you have to use  the <see cref="moveSlider"/> method.
        /// </para>
        /// </remarks>
        /// <param name="moveValue">The move value.</param>
        public void moveSelectedVerticalSlider(int moveValue)
        {            
            if (choosedSliders[0] == sliders[(byte)Sliders.Left])
            {
                movingInDirectly(choosedSliders[0], moveValue);
                //Has to be copied back, otherwise the selection of the slider is damaged
                choosedSliders[0] = sliders[(byte)Sliders.Left];
            }
            else if(choosedSliders[0] == sliders[(byte)Sliders.Right])
            {
                movingInDirectly(choosedSliders[0], moveValue);
                choosedSliders[0] = sliders[(byte)Sliders.Right];
            }                                
            else if (choosedSliders[1] == sliders[(byte)Sliders.Left])
            {
                movingInDirectly(choosedSliders[1], moveValue);
                choosedSliders[1] = sliders[(byte)Sliders.Left];
            }
            else if (choosedSliders[1] == sliders[(byte)Sliders.Right])
            {
                movingInDirectly(choosedSliders[1], moveValue);
                choosedSliders[1] = sliders[(byte)Sliders.Right];
            }
        }

        /// <summary>
        /// Moves a choosed horizontal slider outside of this control.
        /// </summary>
        /// <remarks>
        /// <para>A negative value moves the slider up, a positive down</para>
        /// <para>Note: This method has to be used, when a horizontal slider was 
        /// choosed/rollovered by mouse and it should be moved (without mouse navigation). 
        /// If you know sure, if you want to move the right
        /// (or left) slider, you have to use  the <see cref="moveSlider"/> method.
        /// </para>
        /// </remarks>
        /// <param name="moveValue">The move value.</param>
        public void moveSelectedHorizontalSlider(int moveValue)
        {
            if (choosedSliders[0] == sliders[(byte)Sliders.Up])
            {
                movingInDirectly(choosedSliders[0], moveValue);
                //Has to be copied back, otherwise the selection of the slider is damaged
                choosedSliders[0] = sliders[(byte)Sliders.Up];
            }
            else if (choosedSliders[0] == sliders[(byte)Sliders.Down])
            {
                movingInDirectly(choosedSliders[0], moveValue);
                choosedSliders[0] = sliders[(byte)Sliders.Down];
            }
            else if (choosedSliders[1] == sliders[(byte)Sliders.Up])
            {
                movingInDirectly(choosedSliders[1], moveValue);
                choosedSliders[1] = sliders[(byte)Sliders.Up];
            }
            else if (choosedSliders[1] == sliders[(byte)Sliders.Down])
            {
                movingInDirectly(choosedSliders[1], moveValue);
                choosedSliders[1] = sliders[(byte)Sliders.Down];
            }
        }

        /// <summary>
        /// Gets the cutted picture in <seealso cref="Bitmap"/> format.
        /// </summary>
        /// <returns>The cutted Image (in <seealso cref="Bitmap"/> format)</returns>
        public Bitmap getCuttedImage()
        {
            int w = ActualWidthInternal;
            if ((LeftPositionInternal + ActualWidthInternal) > AdaptedPicture.Width)
                w -= (LeftPositionInternal + ActualWidthInternal) - AdaptedPicture.Width;
            int h = ActualHeightInternal;
            if ((UpPositionInternal + ActualHeightInternal) > AdaptedPicture.Height)
                h -= (UpPositionInternal + ActualHeightInternal) - AdaptedPicture.Height;            

            Rectangle tempSize = new Rectangle(LeftPositionInternal,
                                            UpPositionInternal,
                                            w,
                                            h);
            AdaptedPicture = AdaptedPicture.Clone(tempSize, AdaptedPicture.PixelFormat);
            init();

            tempSize = new Rectangle(leftPosition,
                                  upPosition,
                                  actualWidth,
                                  actualHeight);

            originalPicture = (Bitmap)originalPicture.Clone(tempSize, originalPicture.PixelFormat);
            //would make a 32 bit BMP smaller to 24 bit
            //originalPicture = originalPicture.Clone(new Rectangle(0, 0, originalPicture.Width, 
            //originalPicture.Height), PixelFormat.Format24bppRgb);
            return originalPicture;
        }

        /// <summary>
        /// Moves a slider directly.
        /// </summary>
        /// <param name="slider">The slider.</param>
        /// <param name="moveX">The move X.</param>
        /// <param name="moveY">The move Y.</param>
        /// <param name="isDirectMove">if set to <c>true</c> [is direct move].</param>
        private void movingDirectly(GraphicObject slider, int moveX, int moveY, bool isDirectMove)
        {            
            switch (slider.AllowedCourse)
            {
                case Course.Horicontal:
                    slider.Move(0, moveY);
                    checkSlidersExceedsBorder(slider.Start.X, slider.Start.Y);
                    if (sliders[(byte)Sliders.Down].Start.Y - sliders[(byte)Sliders.Up].Start.Y <
                        (byte)((float)minSizeOfImage / scaleFactor))
                    {
                        slider.Move(0, -moveY);
                        return;
                    }
                    else
                    {
                        if (isDirectMove)
                        {
                            actualHeight = (int)((float)ActualHeightInternal * scaleFactor);
                            //Check, if there is a rounding error
                            //if (ActualHeight > OriginalHeight)
                            //    moveSelectedHorizontalSlider(-(ActualHeight - OriginalHeight));

                            upPosition = (int)((float)UpPositionInternal * scaleFactor);

                            //Check, if there is a rounding error
                            if (upPosition + ActualHeight > OriginalHeight)
                                actualHeight = OriginalHeight - upPosition;

                            spaces[(int)Sliders.Up] = 0.0f;
                            spaces[(int)Sliders.Down] = 0.0f;
                            fireSliderMovedEvent();
                        }
                    }
                    break;
                case Course.Vertical:                    
                    slider.Move(moveX, 0);
                    checkSlidersExceedsBorder(slider.Start.X, slider.Start.Y);
                    if (sliders[(byte)Sliders.Right].Start.X - sliders[(byte)Sliders.Left].Start.X <
                        (byte)((float)minSizeOfImage / scaleFactor))
                    {
                        slider.Move(-moveX, 0);
                        return;
                    }
                    else
                    {
                        if (isDirectMove)
                        {
                            actualWidth = (int)((float)ActualWidthInternal * scaleFactor);
                            //Check, if there is a rounding error
                            //if (ActualWidth > OriginalWidth)
                            //    moveSelectedVerticalSlider(-(ActualWidth - OriginalWidth));                               

                            leftPosition = (int)((float)LeftPositionInternal * scaleFactor);

                            //Check, if there is a rounding error
                            if (leftPosition + ActualWidth > OriginalWidth)
                                actualWidth = OriginalWidth - leftPosition;

                            spaces[(int)Sliders.Left] = 0.0f;
                            spaces[(int)Sliders.Right] = 0.0f;
                            fireSliderMovedEvent();
                        }
                    }
                    break;
            }

            setSlidersSpace();
            this.Invalidate();
        }

        /// <summary>
        /// Moves a slider indirectly.
        /// </summary>
        /// <param name="slider">The slider.</param>
        /// <param name="moveValue">The move value.</param>
        private void movingInDirectly(GraphicObject slider, int moveValue)
        {
            float move = (float)moveValue / scaleFactor;
            int index = getSliderIndex(slider, sliders);
            spaces[index] = spaces[index] + move;
            int intNumber = (int)spaces[index];
            spaces[index] -= (float)intNumber;

            if (index == (int)Sliders.Left || index == (int)Sliders.Right)
            {
                movingDirectly(slider, intNumber, 0, false);
                if (index == (int)Sliders.Left)//pSlider == mSliders[(byte)SLIDERS.LEFT]) -> DOES NOT WORK!
                {
                    leftPosition += moveValue;
                    actualWidth -= moveValue;
                }
                else
                    actualWidth += moveValue;
            }
            else
            {
                movingDirectly(slider, 0, intNumber, false);
                if (index == (int)Sliders.Up)//pSlider == mSliders[(byte)SLIDERS.UP]) -> DOES NOT WORK!
                {
                    upPosition += moveValue;
                    actualHeight -= moveValue;
                }
                else
                    actualHeight += moveValue;
            }

            checkValues();
            if (isCheckNecessary)
                checkRatio();
            fireSliderMovedEvent();
        }

        /// <summary>
        /// Fires the slider moved event.
        /// </summary>
        private void fireSliderMovedEvent()
        {
            //fire the event now
            if (this.OnSliderMovedEvent != null) //is there a EventHandler?
            {
                this.OnSliderMovedEvent.Invoke(); //calls its EventHandler                
            }
            else { } //if not, ignore
        }

        /// <summary>
        /// Handles the MouseMove event of the ImageCut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ImageCut_MouseMove(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        /// <summary>
        /// Checks the values of the pictures sizes.
        /// </summary>
        private void checkValues()
        {
            if (leftPosition == -1)
            {
                leftPosition += 1;
                actualWidth -= 1;
            }
            if (actualWidth > originalPicture.Width)
                actualWidth = originalPicture.Width;
            else if (actualWidth < minSizeOfImage)
                actualWidth = minSizeOfImage;

            if (upPosition == -1)
            {
                upPosition += 1;
                actualHeight -= 1;
            }

            if (actualHeight > originalPicture.Height)
                actualHeight = originalPicture.Height;
            else if (actualHeight < minSizeOfImage)
                actualHeight = minSizeOfImage;
        }

        /// <summary>
        /// Checks, if there is a ratio constraint. If yes the sliders will be 
        /// set on the correct positions to conform the ratio constraint.
        /// </summary>
        private void checkRatio()
        {
            isCheckNecessary = false;
            if (ratio != 0.0f)
            {
                float tempRatio = (float)ActualHeight /
                               (float)ActualWidth;
                if ((tempRatio + 0.01f) < ratio)
                {
                    float tempNewWidth = (float)ActualHeight / ratio;
                    float tempDiff = (float)ActualWidth - tempNewWidth;
                    moveSlider((int)(tempDiff / 2.0f), Sliders.Left);
                    moveSlider((int)(-tempDiff / 2.0f), Sliders.Right);
                }
                else if ((tempRatio + 0.01f) > ratio)
                {
                    float tempNewHeight = (float)ActualWidth * ratio;
                    float tempDiff = (float)ActualHeight - tempNewHeight;
                    moveSlider((int)(tempDiff / 2.0f), Sliders.Up);
                    moveSlider((int)(-tempDiff / 2.0f), Sliders.Down);
                }

            }
            isCheckNecessary = true;
        }

        /// <summary>
        /// Creates an adapted image, which is not bigger than the given maximum values. 
        /// </summary>
        /// <remarks>
        /// <para>It sets the <see cref="AdaptedPicture"/> and the <see cref="ScaleFactor"/>.</para>
        /// <para>Note: It also sets the original image, it is not necessary to set it manual.</para>
        /// <para>Note: If the original image is smaller than the given values, the adapted
        /// image is just a clone of the original image.</para>
        /// </remarks>
        /// <param name="maxWidth">The biggest allowed width of the image</param>
        /// <param name="maxHeight">The biggest allowed height of the image</param>
        private void adaptPicture(float maxWidth, float maxHeight)
        {
            Size adaptedSize;
            float screenRatio = maxWidth / maxHeight;

            float picRatio = (float)originalPicture.Width / (float)originalPicture.Height;

            if (maxWidth < originalPicture.Width || maxHeight < originalPicture.Height)
            {
                if (screenRatio < picRatio)
                    adaptedSize = new Size((int)maxWidth, (int)(maxWidth / picRatio));
                else
                    adaptedSize = new Size((int)(maxHeight * picRatio), (int)maxHeight);
            }
            else
            {
                adaptedSize = new Size(originalPicture.Width, originalPicture.Height);
            }
            //the ratio original size and adapted size (as average of widht and height ratio)
            scaleFactor = ((float)originalPicture.Size.Width / (float)adaptedSize.Width +
                            (float)originalPicture.Size.Height / (float)adaptedSize.Height) / 2.0f;
            AdaptedPicture = new Bitmap(originalPicture, adaptedSize);
        }

        /// <summary>
        /// Inits the border values.
        /// </summary>
        private void initBorderValues()
        {
            up = distanceToImage / 2;// -mLineStrength;
            down = Size.Height - distanceToImage / 2;// -mLineStrength;
            left = distanceToImage / 2;// -2;
            right = Size.Width - distanceToImage / 2;// -1;
        }

        /// <summary>
        /// Sets the transparent area behind a slider.
        /// These areas represent the cut offed image areas.
        /// </summary>
        private void setSlidersSpace()
        {
            slidersWaste[(byte)Sliders.Left] = (new GraphicRectangle(
                                new Pen(Color.FromArgb(transparency, colorSliderSpace), lineStrength),
                                new Rectangle(  left,
                                                up,
                                                sliders[(byte)Sliders.Left].Start.X - left - (lineStrength-1),
                                                down - up)));

            slidersWaste[(byte)Sliders.Right] = (new GraphicRectangle(
                                new Pen(Color.FromArgb(transparency, colorSliderSpace), lineStrength),
                                new Rectangle(  sliders[(byte)Sliders.Right].Start.X + (lineStrength - 1),
                                                up,
                                                right - sliders[(byte)Sliders.Right].Start.X,
                                                down - up)));

            slidersWaste[(byte)Sliders.Up] = (new GraphicRectangle(
                                new Pen(Color.FromArgb(transparency, colorSliderSpace), lineStrength),
                                new Rectangle(  sliders[(byte)Sliders.Left].Start.X,
                                                up,
                                                sliders[(byte)Sliders.Right].Start.X - sliders[(byte)Sliders.Left].Start.X + (lineStrength - 1),
                                                sliders[(byte)Sliders.Up].Start.Y - up - (lineStrength - 1) )));

            slidersWaste[(byte)Sliders.Down] = (new GraphicRectangle(
                                new Pen(Color.FromArgb(transparency, colorSliderSpace), lineStrength),
                                new Rectangle(  sliders[(byte)Sliders.Left].Start.X,
                                                sliders[(byte)Sliders.Down].Start.Y + (lineStrength - 1),
                                                sliders[(byte)Sliders.Right].Start.X - sliders[(byte)Sliders.Left].Start.X + (lineStrength - 1),
                                                down - sliders[(byte)Sliders.Down].Start.Y)));
        }

        /// <summary>
        /// Inits the sliders with its original positions and the slider color.
        /// Is called only one time in the init()-fct.
        /// </summary>
        private void initSliders()
        {
            sliders[(byte)Sliders.Left] = (new GraphicLine(
                                new Pen(colorSliders, lineStrength),
                                new Point(left, distanceToImage / 2),
                                new Point(left, Size.Height - distanceToImage / 2 - 1),
                                Course.Vertical));

            sliders[(byte)Sliders.Right] = (new GraphicLine(
                                new Pen(colorSliders, lineStrength),
                                new Point(right, distanceToImage / 2),
                                new Point(right, Size.Height - distanceToImage / 2 - 1),
                                Course.Vertical));

            sliders[(byte)Sliders.Up] = (new GraphicLine(
                                new Pen(colorSliders, lineStrength),
                                new Point(distanceToImage / 2, up),
                                new Point(Size.Width - distanceToImage / 2 - 1, up),
                                Course.Horicontal));

            sliders[(byte)Sliders.Down] = (new GraphicLine(
                                new Pen(colorSliders, lineStrength),
                                new Point(distanceToImage / 2, down),
                                new Point(Size.Width - distanceToImage / 2 - 1, down),
                                Course.Horicontal));
        }

        /// <summary>
        /// Checks after a Slider- or window display - moving, if a slider
        /// exceeds a limit (border).
        /// </summary>
        /// <remarks>
        /// <para>The mouse cursor moves a slider, so the cursor location is important for 
        /// the check.</para>
        /// </remarks>
        /// <param name="x">X-coord of mouse</param>
        /// <param name="y">Y-coord of mouse</param>
        private void checkSlidersExceedsBorder(int x, int y)
        {
            bool choosed1 = false;
            bool choosed2 = false;
            if (x < left)
            {
                if (getSliderIndex(choosedSliders[0], sliders) == (int)Sliders.Left)
                    choosed1 = true;
                else if (getSliderIndex(choosedSliders[1], sliders) == (int)Sliders.Left)
                    choosed2 = true;
                sliders[(byte)Sliders.Left] = (new GraphicLine(
                                    new Pen(colorRolloverSlider, lineStrength),
                                    new Point(left, distanceToImage / 2),
                                    new Point(left, Size.Height - distanceToImage / 2 - 1),
                                    Course.Vertical));
                if (choosed1)
                    choosedSliders[0] = sliders[(byte)Sliders.Left];
                else if (choosed2)
                    choosedSliders[1] = sliders[(byte)Sliders.Left];
            }

             choosed1 = false;
             choosed2 = false;
             if (x > right)
             {
                 if (getSliderIndex(choosedSliders[0], sliders) == (int)Sliders.Right)
                     choosed1 = true;
                 else if (getSliderIndex(choosedSliders[1], sliders) == (int)Sliders.Right)
                     choosed2 = true;
                 sliders[(byte)Sliders.Right] = (new GraphicLine(
                                     new Pen(colorRolloverSlider, lineStrength),
                                     new Point(right, distanceToImage / 2),
                                     new Point(right, Size.Height - distanceToImage / 2 - 1),
                                     Course.Vertical));
                 if (choosed1)
                     choosedSliders[0] = sliders[(byte)Sliders.Right];
                 else if (choosed2)
                     choosedSliders[1] = sliders[(byte)Sliders.Right];
             }

            choosed1 = false;
            choosed2 = false;
            if (y < up)
             {
                 if (getSliderIndex(choosedSliders[0], sliders) == (int)Sliders.Up)
                     choosed1 = true;
                 else if (getSliderIndex(choosedSliders[1], sliders) == (int)Sliders.Up)
                     choosed2 = true;
                sliders[(byte)Sliders.Up] = (new GraphicLine(
                                    new Pen(colorRolloverSlider, lineStrength),
                                    new Point(distanceToImage / 2, up),
                                    new Point(Size.Width - distanceToImage / 2 - 1, up),
                                    Course.Horicontal));
                if (choosed1)
                    choosedSliders[0] = sliders[(byte)Sliders.Up];
                else if (choosed2)
                    choosedSliders[1] = sliders[(byte)Sliders.Up];
            }

            choosed1 = false;
            choosed2 = false;
            if (y > down)
             {
                 if (getSliderIndex(choosedSliders[0], sliders) == (int)Sliders.Down)
                     choosed1 = true;
                 else if (getSliderIndex(choosedSliders[1], sliders) == (int)Sliders.Down)
                     choosed2 = true;
                sliders[(byte)Sliders.Down] = (new GraphicLine(
                                    new Pen(colorRolloverSlider, lineStrength),
                                    new Point(distanceToImage / 2, down),
                                    new Point(Size.Width - distanceToImage / 2 - 1, down),
                                    Course.Horicontal));
                if (choosed1)
                    choosedSliders[0] = sliders[(byte)Sliders.Down];
                else if (choosed2)
                    choosedSliders[1] = sliders[(byte)Sliders.Down];
            }
        }

        /// <summary>
        /// Checks, if the mouse cursor is over the image. 
        /// If yes, set the cursor for moving the display window over the image.
        /// Otherwise, set the default cursor icon.
        /// </summary>
        /// <param name="x">X-coord of mouse</param>
        /// <param name="y">Y-coord of mouse</param>
        private void setMoveDisplayWindowCursor(int x, int y)
        {
            if (sliders[(byte)Sliders.Down].Start.Y > y &&
                sliders[(byte)Sliders.Up].Start.Y < y &&
                sliders[(byte)Sliders.Left].Start.X < x &&
                sliders[(byte)Sliders.Right].Start.X > x)
                this.Cursor = cursorMoveDisplayWindow;

            else
                this.Cursor = cursorDefault;
        }

        /// <summary>
        /// Sets the cursor icon which represents a cursor, that rollover a slider.
        /// </summary>
        private void setRollOverCursor()
        {
            this.Cursor = cursorRolloverSlider;
        }

        /// <summary>
        /// Moves the display window, which is located over the image.
        /// </summary>
        /// <param name="x">X-coord of mouse</param>
        /// <param name="y">Y-coord of mouse</param>
        private void moveDisplayWindow(int x, int y)
        {
            if ((sliders[(byte)Sliders.Down].Start.Y < down || y < lastMouseLocation.Y) &&
                (sliders[(byte)Sliders.Up].Start.Y > up || y > lastMouseLocation.Y))
            {
                movingDirectly(sliders[(byte)Sliders.Down], 0, y - lastMouseLocation.Y, true);
                movingDirectly(sliders[(byte)Sliders.Up], 0, y - lastMouseLocation.Y, true);
            }
            if ((sliders[(byte)Sliders.Left].Start.X > left || x > lastMouseLocation.X) &&
                (sliders[(byte)Sliders.Right].Start.X < right || x < lastMouseLocation.X))
            {
                movingDirectly(sliders[(byte)Sliders.Left], x - lastMouseLocation.X, 0, true);
                movingDirectly(sliders[(byte)Sliders.Right], x - lastMouseLocation.X, 0, true);
            }
        }

        /// <summary>
        /// Deletes the choosed sliders.
        /// </summary>
        private void resetChoosedSliders()
        {
            //Draw all Sliders black
            for (byte i = 0; i < 4; i++)
                sliders[i].ColorOfPen = colorSliders;
            //Erase choosed Sliders
            choosedSliders[0] = null;
            choosedSliders[1] = null;
        }

        /// <summary>
        /// Determines whether [is rollovered any slider] at [the specified position].
        /// </summary>
        /// <param name="position">The mouse position.</param>
        /// <returns>
        /// 	<c>true</c> if [is rollovered any slider] [the specified position]; otherwise, <c>false</c>.
        /// </returns>
        private bool isRolloveredAnySlider(Point position)
        {
            bool choosed = false;
            if (!(choosed = isRolloveredVerticalSlider(sliders[(byte)Sliders.Left], position)))
                if (!(choosed = isRolloveredVerticalSlider(sliders[(byte)Sliders.Right], position)))
                    if (!(choosed = isRolloveredHoricontalSlider(sliders[(byte)Sliders.Up], position)))
                        choosed = isRolloveredHoricontalSlider(sliders[(byte)Sliders.Down], position);

            return choosed;
        }

        /// <summary>
        /// Checks, if the given <see cref="GraphicObject"/>is a
        /// rollovered vertical slider.
        /// </summary>
        /// <param name="verticalSlider">The vertical slider.</param>
        /// <param name="location">The location.</param>
        /// <returns>true - if it is a rollovered vertical slider.</returns>
        private bool isRolloveredVerticalSlider(GraphicObject verticalSlider, Point location)
        {
            if (verticalSlider.Hit(location))
            {
                resetChoosedSliders();
                verticalSlider.ColorOfPen = colorRolloverSlider;
                choosedSliders[0] = verticalSlider;
                if (Math.Abs(sliders[(byte)Sliders.Up].Start.Y - location.Y) <= neighbourTolerance)
                {
                    sliders[(byte)Sliders.Up].ColorOfPen = colorRolloverSlider;
                    choosedSliders[1] = sliders[(byte)Sliders.Up];
                    setRollOverCursor();
                    return true;
                }
                if (Math.Abs(sliders[(byte)Sliders.Down].Start.Y - location.Y) <= neighbourTolerance)
                {
                    sliders[(byte)Sliders.Down].ColorOfPen = colorRolloverSlider;
                    choosedSliders[1] = sliders[(byte)Sliders.Down];
                }
                setRollOverCursor();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks, if the given <see cref="GraphicObject"/>is a
        /// rollovered horizontal slider.
        /// </summary>
        /// <param name="horizontalSlider">The horizontal slider.</param>
        /// <param name="location">The location.</param>
        /// <returns>true - if it is a rollovered horizontal slider.</returns>
        private bool isRolloveredHoricontalSlider(GraphicObject horizontalSlider, Point location)
        {
            if (horizontalSlider.Hit(location))
            {
                resetChoosedSliders();
                horizontalSlider.ColorOfPen = colorRolloverSlider;
                choosedSliders[0] = horizontalSlider;
                if (Math.Abs(sliders[(byte)Sliders.Left].Start.X - location.X) <= neighbourTolerance)
                {
                    sliders[(byte)Sliders.Left].ColorOfPen = colorRolloverSlider;
                    choosedSliders[1] = sliders[(byte)Sliders.Left];
                    setRollOverCursor();
                    return true;
                }
                if (Math.Abs(sliders[(byte)Sliders.Right].Start.X - location.X) <= neighbourTolerance)
                {
                    sliders[(byte)Sliders.Right].ColorOfPen = colorRolloverSlider;
                    choosedSliders[1] = sliders[(byte)Sliders.Right];
                }
                setRollOverCursor();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fires the <see cref="E:System.Windows.Forms.Control.Paint"/>-Event.
        /// </summary>
        /// <param name="e">An instance of <see cref="T:System.Windows.Forms.PaintEventArgs"/>.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!isAlreadyInit)
            {
                MessageBox.Show("You have to call the 'init()'-function before using the ImageCuttingPanel.");
                Application.Exit();
                return;
            }
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            // Only draw new the area of clip, objects outside of clip will be cutted.
            Region clip = new Region(canvasRect);
            clip.Intersect(e.Graphics.Clip);
            e.Graphics.Clip = clip;
            //e.Graphics.Clear(Color.White);
            foreach (GraphicObject go in sliders)
            {
                go.Draw(e.Graphics);
            }
            foreach (GraphicRectangle go in slidersWaste)
            {
                go.Fill(e.Graphics);
            }
        }

        /// <summary>
        /// Fires the <see cref="E:System.Windows.Forms.Control.MouseDown"/>-Event.
        /// </summary>
        /// <param name="e">An instance of <see cref="T:System.Windows.Forms.MouseEventArgs"/>.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isMouseDown = true;
            lastMouseLocation = e.Location;
            if (!isRolloveredAnySlider(e.Location))
                resetChoosedSliders();
        }

        /// <summary>
        /// Fires the <see cref="E:System.Windows.Forms.Control.MouseMove"/>-Event.
        /// </summary>
        /// <param name="e">An instance of <see cref="T:System.Windows.Forms.MouseEventArgs"/>.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);            

            if (isMouseDown)
            {
                if (this.Cursor == cursorMoveDisplayWindow && !isSliderChoosed)
                {
                    resetChoosedSliders();
                    moveDisplayWindow(e.X, e.Y);
                }
                else
                {
                    // Wenn gerade ein Objekt verschoben werden soll, wird die Differenz zur letzten
                    // Mausposition ausgerechnet und das Objekt um diese verschoben,
                    //in Abhängigkeit seines Verlaufs (horizontale Linie, ...).
                    int number = choosedSliders[1] != null ? 2 : choosedSliders[0] != null ? 1 : 0;
                    int mouseX = e.X - lastMouseLocation.X;
                    int mouseY = e.Y - lastMouseLocation.Y;
                    for (byte i = 0; i < number; i++)
                        movingDirectly(choosedSliders[i], mouseX, mouseY, true);
                }
                lastMouseLocation = e.Location;
            }
            else
            {
                setMoveDisplayWindowCursor(e.X, e.Y);
                // the flag 'isSliderChoosed' will set FALSE
                isSliderChoosed = false;
                // Check all Sliders for cursor-rollovering, if a Slider is rollovered,
                // set the flag 'mIsSliderChoosed' TRUE
                isSliderChoosed = isRolloveredAnySlider(e.Location);
                //if (!(isSliderChoosed = isRolloveredVerticalSlider(sliders[(byte)Sliders.Left], e.Location)))
                //    if (!(isSliderChoosed = isRolloveredVerticalSlider(sliders[(byte)Sliders.Right], e.Location)))
                //        if (!(isSliderChoosed = isRolloveredHoricontalSlider(sliders[(byte)Sliders.Up], e.Location)))
                //            isSliderChoosed = isRolloveredHoricontalSlider(sliders[(byte)Sliders.Down], e.Location);
                this.Invalidate();
            }            
        }

        /// <summary>
        /// Fires the <see cref="E:System.Windows.Forms.Control.MouseUp"/>-Event.
        /// </summary>
        /// <param name="e">An instance of <see cref="T:System.Windows.Forms.MouseEventArgs"/>.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isMouseDown = false;
        }

        /// <summary>
        /// Fires the <see cref="E:System.Windows.Forms.Control.SizeChanged"/>-Event.
        /// </summary>
        /// <param name="e">An instance of <see cref="T:System.EventArgs"/>.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            // Wenn sich die Größe des Fensters ändert, wird die Größe der Zeichenfläche angepasst.
            canvasRect = new Rectangle(new Point(0, 0),
                new Size(this.ClientSize.Width, this.ClientSize.Height));
            this.Invalidate();
        }

        /// <summary>
        /// Static function, gets the id of the given slider.
        /// </summary>
        /// <param name="choosedSlider">The choosed slider.</param>
        /// <param name="allSliders">All sliders.</param>
        /// <returns></returns>
        private static int getSliderIndex(GraphicObject choosedSlider, 
                                          GraphicObject[] allSliders)
        {
            if (choosedSlider == allSliders[(byte)Sliders.Left])
                return (int)Sliders.Left;
            else if (choosedSlider == allSliders[(byte)Sliders.Right])
                return (int)Sliders.Right;
            if (choosedSlider == allSliders[(byte)Sliders.Up])
                return (int)Sliders.Up;
            else //if (pChoosedSlider == pAllSliders[(byte)SLIDERS.DOWN])
                return (int)Sliders.Down;
        }
    }
}
