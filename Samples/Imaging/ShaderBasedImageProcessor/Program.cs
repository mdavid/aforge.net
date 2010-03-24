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
            //// create HLSLExtractChannel filter
            //HLSLExtractChannel extractChannel = new HLSLExtractChannel();
            //processor.Filter = extractChannel;
            //// optional: configure filter
            //extractChannel.Channel = RGB.R;
            //// get result texture
            //Texture2D texture = processor.RenderToTexture();
            //processor.ChangeTexture(texture);
            //// create HLSLThreshold filter
            //HLSLThreshold threshold = new HLSLThreshold();
            //processor.Filter = threshold;
            //// optional: configure filter
            //threshold.Threshold = 230;
            //texture = processor.RenderToTexture();
            //// reset source texture to original image
            //processor.ResetTexture();
            //// create HLSLReplaceChannel filter
            //HLSLReplaceChannel replaceChannel = new HLSLReplaceChannel();
            //processor.Filter = replaceChannel;
            //// optional: configure filter
            //replaceChannel.Channel = RGB.R;
            //replaceChannel.ChannelTexture = texture;
            //// apply the filter
            //Bitmap resultImage = processor.RenderToBitmap();
            ////Texture2D resultTexture = processor.RenderToTexture( );
            //resultImage.Save("HLSLReplaceChannel.jpg", ImageFormat.Jpeg);
            //processor.End();

            //// 2. Online rendering
            //// create any windows control for rendering in
            //Form myForm = new Form();
            //// create HLSLProcessor, used as rendering framework
            //HLSLProcessor processor2 = new HLSLProcessor();
            //// starts HLSLProcessor
            //processor2.Begin(image, myForm);
            //// create HLSLExtractChannel filter
            //HLSLExtractChannel filter2a = new HLSLExtractChannel();
            //processor2.Filter = filter2a;
            //// optional: configure filter
            //filter2a.Channel = RGB.R;
            //// get result texture
            //texture = processor2.RenderToTexture();
            //// change source texture to result texture
            //processor2.ChangeTexture(texture);

            //HLSLThreshold filter2b = new HLSLThreshold();
            //processor2.Filter = filter2b;
            //// optional: configure filter
            //filter2b.Threshold = 230;
            //texture = processor2.RenderToTexture();
            //// reset source texture to original image
            //processor2.ResetTexture();

            //HLSLReplaceChannel filter2c = new HLSLReplaceChannel();
            //processor2.Filter = filter2c;
            //// optional: configure filter
            //filter2c.Channel = RGB.R;
            //filter2c.ChannelTexture = texture;

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
