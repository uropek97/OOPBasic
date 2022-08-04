namespace Lesson_6
{
    internal class Rectangle : Point
    {
        private double _Lenght;
        private double _Width;
        private Point? _Center;

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
        public Point? Center
        {
            get
            {
                return this._Center;
            }
            private set
            {
                this._Center = new Point(value.HorizontPosition, value.VerticalPosition);
            }
        }
        protected Rectangle()
        {

        }

        public Rectangle(double horizontPosition, double verticalPosition, double lenght, double width)
        {
            this.Center = new Point(horizontPosition, verticalPosition);
            this.Lenght = lenght;
            this.Width = width;
        }

        public Rectangle(bool visible, string color, double horizontPosition, double verticalPosition, double lenght, double width) : this(horizontPosition, verticalPosition, lenght, width)
        {
            this.Visible = visible;
            this.Color = color;
        }

        public override double CalcSqure()
        {
            return this.Lenght * this.Width;
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
            if (Color is null)
                return $"{this.GetTypeForPrint().Type}{this.Center}\n{this.GetTypeForPrint().Sides}";
            else
                return $"{this.GetTypeForPrint().Type}{this.GetConditionForPrint()}{this.Center}\n{this.GetTypeForPrint().Sides}";
        }

        /// <summary>
        /// Подготовка информации, для представления прямоугольника в строковом виде
        /// </summary>
        /// <returns>Возвращает тип прямоугольника и сторону(-ы) в строковом виде</returns>
        private (string Type, string Sides) GetTypeForPrint()
        {
            string type;
            string sides;
            if (this.Lenght == this.Width)
            {
                type = "Фигура: квадрат\n";
                sides = $"Длина: {this.Lenght}";
            }

            else
            {
                type = "Фигура: прямоугольник\n";
                sides = $"Длина: {this.Lenght} Ширина: {this.Width}";
            }
            return (type, sides);
        }
    }
}
