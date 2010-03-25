// AForge Shader-Based Image Processing Library demo
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Frank Nagl, 2009-2010
// admin@franknagl.de
//
namespace ShaderBasedImageProcessor
{
    using System.Windows.Forms;
    using System;
    using AForge.Imaging.ShaderBased;
    using System.Drawing;
    using AForge.Imaging.ShaderBased.HLSLFilter;
    using System.Drawing.Imaging;

    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HLSLProcessorForm myForm = new HLSLProcessorForm();

            //Application.Run(form1);

            myForm.Show();
            while (myForm.Created)
            {
                myForm.processor.Render();
                Application.DoEvents();
            }

            #region TODO Frank Nagl: Delete this region.
            //Bitmap image = new Bitmap("sample1.jpg");

            //// 1. Offline rendering
            //// create HLSLProcessor, used as rendering framework
            //HLSLProcessor processor = new HLSLProcessor();
            //// starts HLSLProcessor
            //processor.Begin(image);
            //// create HLSLRotateChannels filter
            //HLSLRotateChannels filter = new HLSLRotateChannels();
            //processor.Filter = filter;
            //// optional: configure filter
            //filter.Order = RGBOrder.GBR;
            //// apply the filter
            //Bitmap resultImage = processor.RenderToBitmap();
            ////Texture2D resultTexture = processor.RenderToTexture( );
            //resultImage.Save("HLSLRotateChannels.jpg", ImageFormat.Jpeg);
            //processor.End();

            //// 2. Online rendering
            //// create any windows control for rendering in
            //Form myForm = new Form();
            //// create HLSLProcessor, used as rendering framework
            //HLSLProcessor processor2 = new HLSLProcessor();
            //// starts HLSLProcessor
            //processor2.Begin(image, myForm);
            //// create HLSLExtractChannel filter
            //HLSLRotateChannels filter2 = new HLSLRotateChannels();
            //processor2.Filter = filter2;
            //// optional: configure filter
            //filter2.Order = RGBOrder.GBR;

            //// apply the filter
            //myForm.Show();
            //while (myForm.Created)
            //{
            //    processor2.Render();
            //    Application.DoEvents();
            //}
            //processor2.End();

            #endregion TODO Frank Nagl: Delete this region.

        }
    }
}
