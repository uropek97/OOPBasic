namespace Lesson_6
{
    internal class Rectangle : Point
    {
        private double _Lenght;
        private double _Width;

        public double Lenght
        {
            get
            {
                return this._Lenght;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина должна быть больше 0.");
                else
                    this._Lenght = value;
            }
        }

        public double Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширина должна быть больше 0.");
                else
                    this._Width = value;
            }
        }

        public Rectangle()
        {

        }

        public Rectangle(bool visible, string color) : base(visible, color)
        {

        }

        public Rectangle(bool visible, string color, double lenght, double width) : this(visible, color)
        {
            this.Lenght = lenght;
            this.Width = width;
        }

        public Rectangle(bool visible, string color, int horizontPosition, int verticalPosition) : base(visible, color, horizontPosition, verticalPosition)
        {

        }

        public Rectangle(bool visible, string color, int horizontPosition, int verticalPosition, double lenght, double width) : this(visible, color, horizontPosition, verticalPosition)
        {
            this.Lenght = lenght;
            this.Width = width;
        }

        public override double CalcSqure()
        {
            return this.Lenght * this.Width;
        }
    }
}
