namespace Lesson_6
{
    internal class Circle : Point
    {
        private double _Radius;
        private Point? _Center;

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
        public Point? Center
        {
            get
            {
                return this._Center;
            }
            set
            {
                this._Center = new Point(value.HorizontPosition, value.VerticalPosition);
            }
        }

        protected Circle()
        {

        }

        public Circle(double horizontPosition, double verticalPosition, double radius)
        {
            this.Center = new Point(horizontPosition, verticalPosition);
            this.Radius = radius;
        }

        public Circle(bool visible, string color, double horizontPosition, double verticalPosition, double radius) : this(horizontPosition, verticalPosition, radius)
        {
            this.Visible = visible;
            this.Color = color;
        }

        public override double CalcSqure()
        {
            return this.Radius * this.Radius * Math.PI;
        }

        public override void MoveHorizont(double change)
        {
            this.Center.MoveHorizont(change);
        }

        public override void MoveVertical(double change)
        {
            this.Center.MoveVertical(change);
        }

        public override void Move(double changeHoriz, double changeVert)
        {
            this.Center.Move(changeHoriz, changeVert);
        }

        public override string ToString()
        {
            if (this.Color is null)
                return $"Фигура: круг\nПозиция: X: {this.Center.HorizontPosition} Y: {this.Center.VerticalPosition}\nРадиус: {this.Radius}";
            else
                return $"Фигура: круг\n{this.GetConditionForPrint()}Позиция: X: {this.Center.HorizontPosition} Y: {this.Center.VerticalPosition}\nРадиус: {this.Radius}";
        }
    }
}
