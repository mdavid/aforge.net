// AForge.NET Framework
// Fyzzy Set sample application
//
// Copyright © Andrew Kirillov, 2008
// andrew.kirillov@gmail.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Fuzzy;
using AForge.Controls;
using AForge;

namespace FuzzySetSample
{
    public partial class Sample : Form
    {
        public Sample( )
        {
            InitializeComponent( );

            chart.RangeX = new DoubleRange( 0, 50 );
            chart.AddDataSeries( "COOL", Color.LightBlue, Chart.SeriesType.Line, 3, true );
            chart.AddDataSeries( "WARM", Color.LightCoral, Chart.SeriesType.Line, 3, true );
        }

        // Testing basic funcionality of fuzzy sets
        private void runTestButton_Click( object sender, EventArgs e )
        {
            // creat 2 fuzzy sets to represent the Cool and Warm temperatures. 
            TrapezoidalFunction function1 = new TrapezoidalFunction( 13, 18, 23, 28 );
            FuzzySet fsCool = new FuzzySet( "Cool", function1 );
            TrapezoidalFunction function2 = new TrapezoidalFunction( 23, 28, 33, 38 );
            FuzzySet fsWarm = new FuzzySet( "Warm", function2 );

            // get membership of some points to the cool fuzzy set
            double[,] coolValues = new double[20, 2];
            for ( int i = 10; i < 30; i++ )
            {
                coolValues[i - 10, 0] = i;
                coolValues[i - 10, 1] = fsCool.GetMembership( i );
            }

            // Getting memberships of some points to the warm fuzzy set
            double[,] warmValues = new double[20, 2];
            for ( int i = 20; i < 40; i++ )
            {
                warmValues[i - 20, 0] = i;
                warmValues[i - 20, 1] = fsWarm.GetMembership( i );
            }

            // plot membership to a chart
            chart.UpdateDataSeries( "COOL", coolValues );
            chart.UpdateDataSeries( "WARM", warmValues );
        }
    }
}