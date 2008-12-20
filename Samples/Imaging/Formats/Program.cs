// AForge Image Formats Library Example
// AForge.NET framework
//
// Copyright © Frank Nagl, 2008
// admin@franknagl.de
// www.franknagl.de
//
using AForge.Imaging.Formats;
namespace AForge_2._0_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageConverter.ConvertTo
                (new JPGCodec(100), "RCX-brick.png", "result\\brick.jpg");

            //Wrong extension doesn't matter
            ImageConverter.ConvertTo
                (new BMPCodec(), "RCX-brick.png", "result\\brick.XXX");

            ImageConverter.ConvertTo
                (new PNGCodec(), "RCX-brick.png", false);

            ImageConverter.ConvertTo
                (new PNGCodec(), "RCX-brick_1.png", true);

            ImageConverter.ConvertTo
                (new EMFCodec(), "RCX-brick.png", "result/brick.emf");

            ImageConverter.ConvertTo
                (new TIFFCodec(), "RCX-brick.png", "result/brick.tif");

            //Case insensitivity of the extension
            ImageConverter.ConvertTo
                (new TIFFCodec(), "RCX-brick.png", "result/brick.TifF");

            ImageConverter.ConvertTo
                (new WMFCodec(), "RCX-brick.png", "result/brick.wmf");

            ImageConverter.ConvertTo
                (new GIFCodec(), "RCX-brick.png", "result/brick.gif");

            string[] images1 = new string[5];
            images1[0] = "result/brick.TifF";
            images1[1] = "result/brick.tif";
            images1[2] = "result/brick.jpg";
            images1[3] = "result/brick.bmp";
            images1[4] = "result/brick.gif";

            string[] images2 = new string[5];
            images2[0] = "result/newBrick01.jpg";
            images2[1] = "result/newBrick02.jpg";
            images2[2] = "result/newBrick03.JpG";//Case insensitivity of the extension
            images2[3] = "result/newBrick04.jpeg";
            images2[4] = "result/newBrick05.xxx";//Wrong extension doesn't matter.

            ImageConverter.ConvertAll(new JPGCodec(10), images1, images2, 100, 100);
        }
    }
}
