// AForge Math Library
//
// Copyright © Andrew Kirillov, 2005-2007
// andrew.kirillov@gmail.com
//
// Copyright © Israel Lot, 2008
// israel.lot@gmail.com
//

namespace AForge.Math
{
	using System;
    using System.Text.RegularExpressions;
    using System.Runtime.Serialization;
	
	/// <summary>
	/// Complex number
	/// </summary>
	/// 
	/// <remarks>The class encapsulate complex number and provides
	/// basic complex operators.</remarks>
	/// 
	public struct Complex:ICloneable, ISerializable
	{
		/// <summary>
		/// Real part of the complex number
		/// </summary>
		public double Re;

		/// <summary>
		/// Imaginary part of the complex number
		/// </summary>
		public double Im;
		
				
		/// <summary>
		/// Magnitude value of the complex number
		/// </summary>
		public double Magnitude
		{
			get { return System.Math.Sqrt( Re * Re + Im * Im ); }
		}

		/// <summary>
		/// Phase value of the complex number
		/// </summary>
		public double Phase
		{
			get { return System.Math.Atan( Im / Re ); }
		}
		
		/// <summary>
		/// Squared magnitude value of the complex number
		/// </summary>
		public double SquaredMagnitude
		{
			get { return ( Re * Re + Im * Im ); }
		}
	
	
		/// <summary>
		/// Initializes a new instance of the <see cref="Complex"/> class
		/// </summary>
		/// 
		/// <param name="re">Real part</param>
		/// <param name="im">Imaginary part</param>
		/// 
		public Complex( double re, double im )
		{
			this.Re = re;
			this.Im = im;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Complex"/> class
		/// </summary>
		/// 
		/// <param name="c">Source complex number</param>
		/// 
		public Complex( Complex c )
		{
			this.Re = c.Re;
			this.Im = c.Im;
		}
		
		

        #region Public Static Complex Arithmetics
        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the sum.</returns>
        public static Complex Add(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }
        /// <summary>
        /// Adds a complex number and a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the sum.</returns>
        public static Complex Add(Complex a, double s)
        {
            return new Complex(a.Re + s, a.Im);
        }
        /// <summary>
        /// Adds two complex numbers and put the result in the third complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Add(Complex a, Complex b, ref Complex result)
        {
            result.Re = a.Re + b.Re;
            result.Im = a.Im + b.Im;
        }
        /// <summary>
        /// Adds a complex number and a scalar and put the result into another complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Add(Complex a, double s, ref Complex result)
        {
            result.Re = a.Re + s;
            result.Im = a.Im;
        }

        /// <summary>
        /// Subtracts a complex from a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the difference.</returns>
        public static Complex Subtract(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }
        /// <summary>
        /// Subtracts a scalar from a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the difference.</returns>
        public static Complex Subtract(Complex a, double s)
        {
            return new Complex(a.Re - s, a.Im);
        }
        /// <summary>
        /// Subtracts a complex from a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the difference.</returns>
        public static Complex Subtract(double s, Complex a)
        {
            return new Complex(s - a.Re, a.Im);
        }
        /// <summary>
        /// Subtracts a complex from a complex and put the result in the third complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Subtract(Complex a, Complex b, ref Complex result)
        {
            result.Re = a.Re - b.Re;
            result.Im = a.Im - b.Im;
        }
        /// <summary>
        /// Subtracts a scalar from a complex and put the result into another complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Subtract(Complex a, double s, ref Complex result)
        {
            result.Re = a.Re - s;
            result.Im = a.Im;
        }
        /// <summary>
        /// Subtracts a complex from a scalar and put the result into another complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Subtract(double s, Complex a, ref Complex result)
        {
            result.Re = s - a.Re;
            result.Im = a.Im;
        }
        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex Multiply(Complex a, Complex b)
        {
            // (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
            double x = a.Re, y = a.Im;
            double u = b.Re, v = b.Im;

            return new Complex(x * u - y * v, x * v + y * u);
        }
        /// <summary>
        /// Multiplies a complex by a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex Multiply(Complex a, double s)
        {
            return new Complex(a.Re * s, a.Im * s);
        }
        /// <summary>
        /// Multiplies a complex by a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex Multiply(double s, Complex a)
        {
            return new Complex(a.Re * s, a.Im * s);
        }
        /// <summary>
        /// Multiplies two complex numbers and put the result in a third complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Multiply(Complex a, Complex b, ref Complex result)
        {
            // (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
            double x = a.Re, y = a.Im;
            double u = b.Re, v = b.Im;

            result.Re = x * u - y * v;
            result.Im = x * v + y * u;
        }
        /// <summary>
        /// Multiplies a complex by a scalar and put the result into another complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Multiply(Complex a, double s, ref Complex result)
        {
            result.Re = a.Re * s;
            result.Im = a.Im * s;
        }
        /// <summary>
        /// Multiplies a complex by a scalar and put the result into another complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Multiply(double s, Complex a, ref Complex result)
        {
            result.Re = a.Re * s;
            result.Im = a.Im * s;

        }
        /// <summary>
        /// Divides a complex by a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex Divide(Complex a, Complex b)
        {
            double x = a.Re, y = a.Im;
            double u = b.Re, v = b.Im;
            double modulusSquared = u * u + v * v;

            if (modulusSquared == 0)
            {
                throw new DivideByZeroException();
            }

            double invModulusSquared = 1 / modulusSquared;

            return new Complex(
                (x * u + y * v) * invModulusSquared,
                (y * u - x * v) * invModulusSquared);
        }
        /// <summary>
        /// Divides a complex by a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex Divide(Complex a, double s)
        {
            if (s == 0)
            {
                throw new DivideByZeroException();
            }
            return new Complex(
                a.Re / s,
                a.Im / s);
        }
        /// <summary>
        /// Divides a scalar by a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex Divide(double s, Complex a)
        {
            if ((a.Re == 0) || (a.Im == 0))
            {
                throw new DivideByZeroException();
            }
            return new Complex(
                s / a.Re,
                s / a.Im);
        }
        /// <summary>
        /// Divides a complex by a complex and put the result in a third complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Divide(Complex a, Complex b, ref Complex result)
        {
            double x = a.Re, y = a.Im;
            double u = b.Re, v = b.Im;
            double modulusSquared = u * u + v * v;

            if (modulusSquared == 0)
            {
                throw new DivideByZeroException();
            }

            double invModulusSquared = 1 / modulusSquared;

            result.Re = (x * u + y * v) * invModulusSquared;
            result.Im = (y * u - x * v) * invModulusSquared;
        }
        /// <summary>
        /// Divides a complex by a scalar and put the result into another complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Divide(Complex a, double s, ref Complex result)
        {
            if (s == 0)
            {
                throw new DivideByZeroException();
            }

            result.Re = a.Re / s;
            result.Im = a.Im / s;
        }
        /// <summary>
        /// Divides a scalar by a complex and put the result into another complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <param name="result">A Complex instance to hold the result.</param>
        public static void Divide(double s, Complex a, ref Complex result)
        {
            if ((a.Re == 0) || (a.Im == 0))
            {
                throw new DivideByZeroException();
            }

            result.Re = s / a.Re;
            result.Im = s / a.Im;
        }
        /// <summary>
        /// Negates a complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <returns>A new Complex instance containing the negated values.</returns>
        public static Complex Negate(Complex a)
        {
            return new Complex(-a.Re, -a.Im);
        }
        /// <summary>
        /// Tests whether two complex numbers are approximately equal using default tolerance value.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
        public static bool ApproxEqual(Complex a, Complex b)
        {
            return ApproxEqual(a, b, 8.8817841970012523233891E-16);
        }
        /// <summary>
        /// Tests whether two complex numbers are approximately equal given a tolerance value.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <param name="tolerance">The tolerance value used to test approximate equality.</param>
        /// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
        public static bool ApproxEqual(Complex a, Complex b, double tolerance)
        {
            return
                (
                (System.Math.Abs(a.Re - b.Re) <= tolerance) &&
                (System.Math.Abs(a.Im - b.Im) <= tolerance)
                );
        }
        #endregion

        #region Public Static Parse Methods
        /// <summary>
        /// Converts the specified string to its Complex equivalent.
        /// </summary>
        /// <param name="s">A string representation of a Complex</param>
        /// <returns>A Complex that represents the vector specified by the <paramref name="s"/> parameter.</returns>
        public static Complex Parse(string s)
        {
            Regex r = new Regex(@"\((?<real>.*),(?<imaginary>.*)\)", RegexOptions.None);
            Match m = r.Match(s);
            if (m.Success)
            {
                return new Complex(
                    double.Parse(m.Result("${real}")),
                    double.Parse(m.Result("${imaginary}"))
                    );
            }
            else
            {
                throw new ExecutionEngineException("Unsuccessful Match.");
            }
        }
        /// <summary>
        /// Try to convert the specified string to its Complex equivalent.
        /// </summary>
        /// <param name="s">A string representation of a Complex</param>
        /// <param name="result">Complex to output the result</param>
        /// <returns>A boolean value that indicates if the parse was successful</returns>
        public static bool TryParse(string s,out Complex result)
        {
            try
            {
                Complex newComplex = Complex.Parse(s);
                result = newComplex;
                return true;

            }
            catch (ExecutionEngineException e)
            {

                result = new Complex();
                return false;
            }


        }

        #endregion

        #region Public Static Complex Special Functions
        public static Complex Sqrt(Complex a)
        {
            Complex result = Complex.Zero;

            if ((a.Re == 0.0) && (a.Im == 0.0))
            {
                return result;
            }
            else if (a.Im == 0.0)
            {
                result.Re = (a.Re > 0) ? System.Math.Sqrt(a.Re) : System.Math.Sqrt(-a.Re);
                result.Im = 0.0;
            }
            else
            {
                double modulus = a.Magnitude;

                result.Re = System.Math.Sqrt(0.5 * (modulus + a.Re));
                result.Im = System.Math.Sqrt(0.5 * (modulus - a.Re));
                if (a.Im < 0.0)
                    result.Im = -result.Im;
            }

            return result;
        }
        public static Complex Log(Complex a)
        {
            Complex result = Complex.Zero;

            if ((a.Re > 0.0) && (a.Im == 0.0))
            {
                result.Re = System.Math.Log(a.Re);
                result.Im = 0.0;
            }
            else if (a.Re == 0.0)
            {
                if (a.Im > 0.0)
                {
                    result.Re = System.Math.Log(a.Im);
                    result.Im = System.Math.PI / 2.0;
                }
                else
                {
                    result.Re = System.Math.Log(-(a.Im));
                    result.Im = -System.Math.PI / 2.0;
                }
            }
            else
            {
                result.Re = System.Math.Log(a.Magnitude);
                result.Im = System.Math.Atan2(a.Im, a.Re);
            }

            return result;
        }
        public static Complex Exp(Complex a)
        {
            Complex result = Complex.Zero;
            double r = System.Math.Exp(a.Re);
            result.Re = r * System.Math.Cos(a.Im);
            result.Im = r * System.Math.Sin(a.Im);

            return result;
        }
        #endregion

        #region Public Static Complex Trigonometry
        public static Complex Sin(Complex a)
        {
            Complex result = Complex.Zero;

            if (a.Im == 0.0)
            {
                result.Re = System.Math.Sin(a.Re);
                result.Im = 0.0;
            }
            else
            {
                result.Re = System.Math.Sin(a.Re) * System.Math.Cosh(a.Im);
                result.Im = System.Math.Cos(a.Re) * System.Math.Sinh(a.Im);
            }

            return result;
        }
        public static Complex Cos(Complex a)
        {
            Complex result = Complex.Zero;

            if (a.Im == 0.0)
            {
                result.Re = System.Math.Cos(a.Re);
                result.Im = 0.0;
            }
            else
            {
                result.Re = System.Math.Cos(a.Re) * System.Math.Cosh(a.Im);
                result.Im = -System.Math.Sin(a.Re) * System.Math.Sinh(a.Im);
            }

            return result;
        }
        public static Complex Tan(Complex a)
        {
            Complex result = Complex.Zero;

            if (a.Im == 0.0)
            {
                result.Re = System.Math.Tan(a.Re);
                result.Im = 0.0;
            }
            else
            {
                double real2 = 2 * a.Re;
                double imag2 = 2 * a.Im;
                double denom = System.Math.Cos(real2) + System.Math.Cosh(real2);

                result.Re = System.Math.Sin(real2) / denom;
                result.Im = System.Math.Sinh(imag2) / denom;
            }

            return result;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Re.GetHashCode() ^ Im.GetHashCode();
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to
        /// the specified object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is a Complex and has the same values as this instance; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex c = (Complex)obj;
                return (this.Re == c.Re) && (this.Im == c.Im);
            }
            return false;
        }

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", Re, Im);
        }
        #endregion

        #region Comparison Operators
        /// <summary>
        /// Tests whether two specified complex numbers are equal.
        /// </summary>
        /// <param name="u">The left-hand complex number.</param>
        /// <param name="v">The right-hand complex number.</param>
        /// <returns><see langword="true"/> if the two complex numbers are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Complex u, Complex v)
        {
            return ValueType.Equals(u, v);
        }
        /// <summary>
        /// Tests whether two specified complex numbers are not equal.
        /// </summary>
        /// <param name="u">The left-hand complex number.</param>
        /// <param name="v">The right-hand complex number.</param>
        /// <returns><see langword="true"/> if the two complex numbers are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Complex u, Complex v)
        {
            return !ValueType.Equals(u, v);
        }
        #endregion

        #region Unary Operators
        /// <summary>
        /// Negates the complex number.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <returns>A new Complex instance containing the negated values.</returns>
        public static Complex operator -(Complex a)
        {
            return Complex.Negate(a);
        }
        #endregion

        #region Binary Operators
        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the sum.</returns>
        public static Complex operator +(Complex a, Complex b)
        {
            return Complex.Add(a, b);
        }
        /// <summary>
        /// Adds a complex number and a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the sum.</returns>
        public static Complex operator +(Complex a, double s)
        {
            return Complex.Add(a, s);
        }
        /// <summary>
        /// Adds a complex number and a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the sum.</returns>
        public static Complex operator +(double s, Complex a)
        {
            return Complex.Add(a, s);
        }
        /// <summary>
        /// Subtracts a complex from a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the difference.</returns>
        public static Complex operator -(Complex a, Complex b)
        {
            return Complex.Subtract(a, b);
        }
        /// <summary>
        /// Subtracts a scalar from a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the difference.</returns>
        public static Complex operator -(Complex a, double s)
        {
            return Complex.Subtract(a, s);
        }
        /// <summary>
        /// Subtracts a complex from a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the difference.</returns>
        public static Complex operator -(double s, Complex a)
        {
            return Complex.Subtract(s, a);
        }

        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex operator *(Complex a, Complex b)
        {
            return Complex.Multiply(a, b);
        }
        /// <summary>
        /// Multiplies a complex by a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex operator *(double s, Complex a)
        {
            return Complex.Multiply(a, s);
        }
        /// <summary>
        /// Multiplies a complex by a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex operator *(Complex a, double s)
        {
            return Complex.Multiply(a, s);
        }
        /// <summary>
        /// Divides a complex by a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="b">A Complex instance.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex operator /(Complex a, Complex b)
        {
            return Complex.Divide(a, b);
        }
        /// <summary>
        /// Divides a complex by a scalar.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex operator /(Complex a, double s)
        {
            return Complex.Divide(a, s);
        }
        /// <summary>
        /// Divides a scalar by a complex.
        /// </summary>
        /// <param name="a">A Complex instance.</param>
        /// <param name="s">A scalar.</param>
        /// <returns>A new Complex instance containing the result.</returns>
        public static Complex operator /(double s, Complex a)
        {
            return Complex.Divide(s, a);
        }
        #endregion

        #region Conversion Operators
        /// <summary>
        /// Converts from a single-precision real number to a complex number. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator Complex(float value)
        {
            return new Complex((double)value, 0);
        }
        /// <summary>
        /// Converts from a double-precision real number to a complex number. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator Complex(double value)
        {
            return new Complex(value, 0);
        }
        #endregion

        #region Constants
        /// <summary>
        ///  A double-precision complex number that represents zero.
        /// </summary>
        public static readonly Complex Zero = new Complex(0, 0);
        /// <summary>
        ///  A double-precision complex number that represents one.
        /// </summary>
        public static readonly Complex One = new Complex(1, 0);
        /// <summary>
        ///  A double-precision complex number that represents the squere root of (-1).
        /// </summary>
        public static readonly Complex I = new Complex(0, 1);
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Creates an exact copy of this Complex object.
        /// </summary>
        /// <returns>The Complex object this method creates, cast as an object.</returns>
        object ICloneable.Clone()
        {
            return new Complex(this);
        }
        /// <summary>
        /// Creates an exact copy of this Complex object.
        /// </summary>
        /// <returns>The Complex object this method creates.</returns>
        public Complex Clone()
        {
            return new Complex(this);
        }
        #endregion

        #region ISerializable Members
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data. </param>
        /// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
        //[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Real", this.Re);
            info.AddValue("Imaginary", this.Im);
        }
        #endregion


	}
}