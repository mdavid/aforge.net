using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Fuzzy;
using AForge.Fuzzy;

namespace FuzzyRulesSample
{
    public partial class MainForm : Form
    {
        public MainForm( )
        {
            InitializeComponent( );
        }

        /// <summary>
        /// Just testing the fuzzy expression parsing. Example not complete. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click( object sender, EventArgs e )
        {

            // create the linguistic labels (fuzzy sets) that compose the temperature 
            TrapezoidalFunction function1 = new TrapezoidalFunction( 10, 15, TrapezoidalFunction.EdgeType.Right );
            FuzzySet fsCold = new FuzzySet( "Cold", function1 );
            TrapezoidalFunction function2 = new TrapezoidalFunction( 10, 15, 20, 25 );
            FuzzySet fsCool = new FuzzySet( "Cool", function2 );
            TrapezoidalFunction function3 = new TrapezoidalFunction( 20, 25, 30, 35 );
            FuzzySet fsWarm = new FuzzySet( "Warm", function3 );
            TrapezoidalFunction function4 = new TrapezoidalFunction( 30, 35, TrapezoidalFunction.EdgeType.Left );
            FuzzySet fsHot = new FuzzySet( "Hot", function4 );

            // create a linguistic variable to represent steel temperature
            LinguisticVariable lvSteel = new LinguisticVariable( "Steel", 0, 80 );
            // adding labels to the variable
            lvSteel.AddLabel( fsCold );
            lvSteel.AddLabel( fsCool );
            lvSteel.AddLabel( fsWarm );
            lvSteel.AddLabel( fsHot );

            // create a linguistic variable to represent stove temperature
            LinguisticVariable lvStove = new LinguisticVariable( "Stove", 0, 80 );
            // adding labels to the variable
            lvStove.AddLabel( fsCold );
            lvStove.AddLabel( fsCool );
            lvStove.AddLabel( fsWarm );
            lvStove.AddLabel( fsHot );

            // create a linguistic variable database
            Database db = new Database( );
            db.AddVariable( lvSteel );
            db.AddVariable( lvStove );

            // sample rules just to test the expression parsing
            Rule r1 = new Rule( db, "Test1",
                "IF Steel is Cold and Stove is Hot then ..." );
            Rule r2 = new Rule( db, "Test2",
                "IF Steel is Cold and (Stove is Warm or Stove is Hot) then ..." );
            Rule r3 = new Rule( db, "Test3",
                "IF Steel is Cold and Stove is Warm or Stove is Hot then ..." );

            // Showing the Reverse Polish Notation of the fuzzy expression
            textBox1.Text += r1.GetRPNExpression( ) + "\r\n";
            textBox1.Text += r2.GetRPNExpression( ) + "\r\n";
            textBox1.Text += r3.GetRPNExpression( ) + "\r\n";

            // Testing the firing strength!
            lvSteel.NumericInput = 12;
            lvStove.NumericInput = 35;
            textBox1.Text += r1.EvaluateFiringStrength( ).ToString( ) + "\r\n";

            // Checking exceptions
            // Rule r4 = new Rule( db, "Test4", "IF Steel is Cold and Tove is Warm or Stove is Hot then ..." );
            // Rule r5 = new Rule( db, "Test4", "IF Steel is Kold and Stove is Warm or Stove is Hot then ..." );

        }

        private void MainForm_Load( object sender, EventArgs e )
        {

        }

    }
}
