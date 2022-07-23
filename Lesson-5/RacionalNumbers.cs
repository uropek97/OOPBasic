using MyUtilities;

namespace Lesson_5
{
    internal class RacionalNumbers
    {
        private int _Numerator;
        private int _Denominator;

        public int Numerator { get { return this._Numerator; } set { this._Numerator = value; } }
        public int Denominator { get { return this._Denominator; } set { if (value == 0) throw new DivideByZeroException(); else this._Denominator = value; } }

        public RacionalNumbers()
        {
            this.Numerator = 1;
            this.Denominator = 1;
        }
        public RacionalNumbers(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.CheckFr();
        }

        /// <summary>
        /// Метод сокращает дробь
        /// </summary>
        /// <returns>Возвращает сокращённую дробь</returns>
        public RacionalNumbers ReduceFr()
        {
            var somevar = MyUtilitiesForFractions.ReduceFraction(this.Numerator, this.Denominator);
            return new RacionalNumbers(this.Numerator = somevar.Item1, this.Denominator = somevar.Item2);
        }

        /// <summary>
        /// Метод проверяет дробь и меняет знаки в случае необходимости(если и числитель и знаменатель отрицательные - дробь положительная, меняет знаки на +,
        /// если числитель положительный, а знаменатель отрицательный, меняет знаки на противоположные)
        /// </summary>
        /// <returns>Возвращает дробь с корректными знаками в числителе и знаменателе</returns>      
        private RacionalNumbers CheckFr()
        {
            if (this.Numerator == 0)
                return this;
            else if (this.Numerator < 0 && this.Denominator < 0)
                return new RacionalNumbers(-this.Numerator, -this.Denominator);
            else if (this.Numerator < 0 && this.Denominator > 0)
                return this;
            else if (this.Numerator > 0 && this.Denominator < 0)
                return new RacionalNumbers(-this.Numerator, -this.Denominator);
            else
                return this;
        }

        /// <summary>
        /// Приводим дроби к общему знаменателю
        /// </summary>
        /// <param name="firstFraction">первая дробь</param>
        /// <param name="secondFraction">вторая дробь</param>
        /// <returns>возвращает кортеж из двух новых дробей с одинаковыми знаменателями</returns>
        private static (RacionalNumbers, RacionalNumbers) LeadCommonDenom(RacionalNumbers firstFraction, RacionalNumbers secondFraction)//математика в нашем случае не нужна. и приводить дроби к НАИМЕНЬШЕМУ общему знаменателю не имеет смысла.
        {
            var newFirst = new RacionalNumbers(firstFraction._Numerator * secondFraction.Denominator, firstFraction.Denominator * secondFraction.Denominator);
            var newSecond = new RacionalNumbers(secondFraction.Numerator * firstFraction.Denominator, secondFraction.Denominator * firstFraction.Denominator);

            return (newFirst, newSecond);
        }

        /// <summary>
        /// Приводим дроби к Наименьшему общему знаменателю
        /// </summary>
        /// <param name="firstFraction"></param>
        /// <param name="secondFraction"></param>
        /// <returns>Возвращает новые дроби, приведённые к общему знаменателю</returns>
        private static (RacionalNumbers, RacionalNumbers) LeadSmallCommonDemon(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var newFirstFraction = firstFraction.ReduceFr();
            var newSecondFraction = secondFraction.ReduceFr();
            var a = MyUtilitiesForFractions.FindLCM(newFirstFraction.Denominator, secondFraction.Denominator);
            newFirstFraction.Numerator = newFirstFraction.Numerator * a / newFirstFraction.Denominator;
            newFirstFraction.Denominator = a;
            newSecondFraction.Numerator = newSecondFraction.Numerator * a / newSecondFraction.Denominator;
            newSecondFraction.Denominator = a;

            return (newFirstFraction, newSecondFraction);
        }

        #region Логические операции
        public static bool operator ==(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var fractions = LeadCommonDenom(firstFraction, secondFraction);
            return fractions.Item1.Numerator == fractions.Item2.Numerator;
        }

        public static bool operator !=(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var fractions = LeadCommonDenom(firstFraction, secondFraction);
            return !(fractions.Item1.Numerator == fractions.Item2.Numerator);
        }

        public static bool operator >(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var fractions = LeadSmallCommonDemon(firstFraction, secondFraction);
            return fractions.Item1.Numerator > fractions.Item2.Numerator;
        }

        public static bool operator <(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var fractions = LeadSmallCommonDemon(firstFraction, secondFraction);
            return fractions.Item1.Numerator < fractions.Item2.Numerator;
        }

        public static bool operator >=(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var fractions = LeadSmallCommonDemon(firstFraction, secondFraction);
            return fractions.Item1.Numerator >= fractions.Item2.Numerator;
        }

        public static bool operator <=(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            var fractions = LeadSmallCommonDemon(firstFraction, secondFraction);
            return fractions.Item1.Numerator <= fractions.Item2.Numerator;
        }

        #endregion
        #region Математические операции (только дроби)
        public static RacionalNumbers operator +(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            firstFraction.ReduceFr();
            secondFraction.ReduceFr();
            var fractions = LeadSmallCommonDemon(firstFraction, secondFraction);
            return new RacionalNumbers(fractions.Item1.Numerator + fractions.Item2.Numerator, fractions.Item1.Denominator);
        }

        public static RacionalNumbers operator -(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            firstFraction.ReduceFr();
            secondFraction.ReduceFr();
            var fractions = LeadSmallCommonDemon(firstFraction, secondFraction);
            return new RacionalNumbers(fractions.Item1.Numerator - fractions.Item2.Numerator, fractions.Item1.Denominator);
        }

        public static RacionalNumbers operator *(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            RacionalNumbers newFraction = new(firstFraction.Numerator * secondFraction.Numerator, firstFraction.Denominator * secondFraction.Denominator);
            newFraction.ReduceFr();
            return newFraction;
        }

        public static RacionalNumbers operator /(RacionalNumbers firstFraction, RacionalNumbers secondFraction)
        {
            RacionalNumbers newFraction = new(firstFraction.Numerator * secondFraction.Denominator, firstFraction.Denominator * secondFraction.Numerator);
            newFraction.ReduceFr();
            return newFraction;
        }

        public static RacionalNumbers operator ++(RacionalNumbers fraction)
        {
            var newFraction = fraction.ReduceFr();
            newFraction.Numerator = newFraction.Numerator + newFraction.Denominator;
            return newFraction;
        }

        public static RacionalNumbers operator --(RacionalNumbers fraction)
        {
            var newFraction = fraction.ReduceFr();
            newFraction.Numerator = newFraction.Numerator - newFraction.Denominator;
            return newFraction;
        }

        public static RacionalNumbers operator -(RacionalNumbers fraction)
        {
            return new RacionalNumbers(-fraction.Numerator, fraction.Denominator);
        }
        //public static RacionalNumbers operator %(RacionalNumbers first, RacionalNumbers second)
        //{
        //Не предатавляю как реализовать перегрузку этого оператора. Ни исключительно с дробями, ни с int
        //}

        #endregion
        #region Математические операции (с int)
        public static RacionalNumbers operator +(RacionalNumbers fraction, int numb)
        {
            var newFraction = new RacionalNumbers(fraction.Numerator + numb * fraction.Denominator, fraction.Denominator);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator +(int numb, RacionalNumbers fraction)
        {
            var newFraction = new RacionalNumbers(fraction.Numerator + numb * fraction.Denominator, fraction.Denominator);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator -(RacionalNumbers fraction, int numb)
        {
            var newFraction = new RacionalNumbers(fraction.Numerator - numb * fraction.Denominator, fraction.Denominator);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator -(int numb, RacionalNumbers fraction)
        {
            var newFraction = new RacionalNumbers(numb * fraction.Denominator - fraction.Numerator, fraction.Denominator);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator *(RacionalNumbers fraction, int numb)
        {
            var newFraction = new RacionalNumbers(fraction.Numerator * numb, fraction.Denominator);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator *(int numb, RacionalNumbers fraction)
        {
            var newFraction = new RacionalNumbers(fraction.Numerator * numb, fraction.Denominator);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator /(RacionalNumbers fraction, int numb)
        {
            var newFraction = new RacionalNumbers(fraction.Numerator, fraction.Denominator * numb);
            return newFraction.ReduceFr();
        }

        public static RacionalNumbers operator /(int numb, RacionalNumbers fraction)
        {
            var newFraction = new RacionalNumbers(numb * fraction.Denominator, fraction.Numerator);
            return newFraction.ReduceFr();
        }

        #endregion
        #region Математические операции (с float)
        public static float operator +(RacionalNumbers fraction, float numb)
        {
            return (float)fraction + numb;
        }

        public static float operator +(float numb, RacionalNumbers fraction)
        {
            return (float)fraction + numb;
        }

        public static float operator -(RacionalNumbers fraction, float numb)
        {
            return (float)fraction - numb;
        }

        public static float operator -(float numb, RacionalNumbers fraction)
        {
            return numb - (float)fraction;
        }

        public static float operator *(RacionalNumbers fraction, float numb)
        {
            return (float)fraction * numb;
        }

        public static float operator *(float numb, RacionalNumbers fraction)
        {
            return (float)fraction * numb;
        }

        public static float operator /(RacionalNumbers fraction, float numb)
        {
            return (float)fraction / numb;
        }

        public static float operator /(float numb, RacionalNumbers fraction)
        {
            return numb / (float)fraction;
        }

        #endregion
        #region Математические операции (с double)
        public static double operator +(RacionalNumbers fraction, double numb)
        {
            return (double)fraction + numb;
        }

        public static double operator +(double numb, RacionalNumbers fraction)
        {
            return (double)fraction + numb;
        }

        public static double operator -(RacionalNumbers fraction, double numb)
        {
            return (double)fraction - numb;
        }

        public static double operator -(double numb, RacionalNumbers fraction)
        {
            return numb - (double)fraction;
        }

        public static double operator *(RacionalNumbers fraction, double numb)
        {
            return (double)fraction * numb;
        }

        public static double operator *(double numb, RacionalNumbers fraction)
        {
            return (double)fraction * numb;
        }

        public static double operator /(RacionalNumbers fraction, double numb)
        {
            return (double)fraction / numb;
        }

        public static double operator /(double numb, RacionalNumbers fraction)
        {
            return numb / (double)fraction;
        }

        #endregion
        #region Приведение типов
        public static explicit operator float(RacionalNumbers fraction)//в задании требовался этот тип данных
        {
            return (float)fraction.Numerator / (float)fraction.Denominator;
        }

        public static explicit operator double(RacionalNumbers fraction)//сначала сделал приведение к double имплицитным, но все дроби автоматически стали double
        {
            return (double)fraction.Numerator / (double)fraction.Denominator;
        }

        public static explicit operator int(RacionalNumbers fraction)
        {
            double a = (double)fraction;
            return (int)Math.Round(a);
        }

        #endregion
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            var fraction = obj as RacionalNumbers;
            if (fraction is null)
            {
                return false;
            }
            var a = this.ReduceFr();

            var newFirstFraction = new RacionalNumbers(a.Numerator * fraction.Denominator, a.Denominator * fraction.Denominator);
            var newSecondFraction = new RacionalNumbers(fraction.Numerator * a.Denominator, fraction.Denominator * a.Denominator);

            return newFirstFraction.Numerator == newSecondFraction.Numerator;
        }

        public override string ToString()
        {
            if (this.Numerator == 0)
            {
                return $"{this.Numerator}";
            }
            if (this.Denominator == 1)
            {
                return $"{this.Numerator}";
            }
            return $"{this.Numerator}/{this.Denominator}";
        }
    }
}
