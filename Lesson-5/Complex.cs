namespace Lesson_5
{
    internal class Complex
    {
        private double _RealPart;
        private double _ImaginaryPart;

        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public Complex()
        {

        }

        public Complex(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        public static Complex operator +(Complex first, Complex second)
        {
            return new Complex(first.RealPart + second.RealPart, first.ImaginaryPart + second.ImaginaryPart);
        }

        public static Complex operator -(Complex first, Complex second)
        {
            return new(first.RealPart - second.RealPart, first.ImaginaryPart - second.ImaginaryPart);
        }

        public static Complex operator *(Complex first, Complex second) //(a+bi)*(c+di) = ac + bci + adi + bdi^2 = (ac+bdi^2)+(bc+ad)i = (ac-bd)+(bc+ad)i
        {
            return new(first.RealPart * second.RealPart - first.ImaginaryPart * second.ImaginaryPart, first.ImaginaryPart * second.RealPart + first.RealPart * second.ImaginaryPart);
        }

        public static Complex operator /(Complex first, Complex second)
        {
            //a+bi (a+bi)(c-di) ac+bd   (bc-ad  )
            //----=------------=-------+(-------)i
            //c+di (c+di)(c-di) c^2+d^2 (c^2+d^2)
            var newComplex = new Complex();

            newComplex.RealPart = (first.RealPart * second.RealPart + first.ImaginaryPart * second.ImaginaryPart) /
                (second.RealPart * second.RealPart + second.ImaginaryPart * second.RealPart);
            newComplex.ImaginaryPart = (first.ImaginaryPart * second.RealPart - first.RealPart * second.ImaginaryPart) /
                (second.RealPart * second.RealPart + second.ImaginaryPart * second.RealPart);

            return newComplex;
        }

        public static bool operator ==(Complex first, Complex second)
        {
            return first.RealPart == second.RealPart && first.ImaginaryPart == second.ImaginaryPart;
        }

        public static bool operator !=(Complex first, Complex second)
        {
            return !(first.RealPart == second.RealPart && first.ImaginaryPart == second.ImaginaryPart);
        }

        public override bool Equals(object? obj)
        {
            if(obj == null)
                return false;
            var complex = obj as Complex;
            if(complex is null)
                return false;
            return this.RealPart == complex.RealPart && this.ImaginaryPart == complex.ImaginaryPart;
        }

        public override string ToString()
        {
            if (this.RealPart == 0)
                return $"{ImaginaryPart}i";
            else if (this.ImaginaryPart == 0)
                return $"{RealPart}";
            else if (this.ImaginaryPart == 1)
                return $"{RealPart} + i";
            else
                return $"{RealPart} + {ImaginaryPart}i";
        }

    }
}