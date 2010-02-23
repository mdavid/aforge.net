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
        }
    }
}
