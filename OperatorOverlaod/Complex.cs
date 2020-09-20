using System;
namespace ClassExercise_Complex
{
    public class Complex
    {
        public int Real { get; }
        public int Imaginary { get; }
        public double Argument { get; }
        public double Modulus { get; }
        public static Complex zero;
        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
            Modulus = Math.Sqrt(real * real + imaginary * imaginary);
            Argument = Math.Atan(imaginary / real);
        }
        public Complex Zero
        {
            get
            {
                return new Complex(0, 0);
            }
        }
        public override string ToString()
        {
            return $"[({Real}), ({Imaginary})]";
        }
        // con este metodo se pueden sumar, restar, multiplar dividir o diferencia objetos!!!!!!!!!
        public static Complex operator +(Complex lhs, Complex rhs)
        {
            int real = lhs.Real + rhs.Real;
            int imaginary = lhs.Imaginary + rhs.Imaginary;
            return new Complex(real, imaginary);
        }
        public static Complex operator -(Complex lhs, Complex rhs)
        {
            int real = lhs.Real - rhs.Real;
            int imaginary = lhs.Imaginary - rhs.Imaginary;
            return new Complex(real, imaginary);
        }
        public static bool operator ==(Complex lhs, Complex rhs)
        {
            if (lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary) 
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Complex lhs, Complex rhs)
        {
            if (lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary)
            {
                return false;
            }
            return true;
        }
        public static Complex operator *(Complex lhs, Complex rhs)
        {
            int real = lhs.Real * rhs.Real - lhs.Imaginary * rhs.Imaginary;
            int imaginary = lhs.Real * rhs.Imaginary + lhs.Imaginary * rhs.Real;
            return new Complex(real, imaginary);
        }
        public static Complex operator -(Complex complex)
        {
            int real = complex.Real * -1;
            int imaginary = complex.Imaginary * -1;
            return new Complex(real, imaginary);
        }
    }
}

