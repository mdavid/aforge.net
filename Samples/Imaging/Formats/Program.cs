using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AForge_2._0_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AForge.Imaging.Formats.JPGCodec jpg =
                new AForge.Imaging.Formats.JPGCodec(100);
            AForge.Imaging.Formats.ImageConverter.ConvertTo(jpg, "RCX-brick.png", false);
        }
    }
}
