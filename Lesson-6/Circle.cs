namespace Lesson_6
{
    internal class Circle : Point
    {
        private double _Radius;
        public double Radius
        {
            get
            {
                return this._Radius;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Радиус должен быть больше 0");
                else
                    this._Radius = value;
            }
        }

        public Circle()
        {

        }

        public Circle(bool visible, string color):base(visible, color)
        {

        }

        public Circle(bool visible, string color, double radius) : this(visible, color)
        {
            this.Radius = radius;
        }

        public Circle(bool visible, string color, int horizontPosition, int verticalPosition) : base(visible, color, horizontPosition, verticalPosition)
        {

        }

        public Circle(bool visible, string color, int horizontPosition, int verticalPosition, double radius) : this(visible, color, horizontPosition, verticalPosition)
        {
            this.Radius = radius;
        }

        public override double CalcSqure()
        {
            return this.Radius * this.Radius * Math.PI;
        }
    }
}
