namespace Lesson_6
{
    internal class Figure
    {
        private bool _Visible;
        private string? _Color;
        private int _HorizontPosition;
        private int _VerticalPosition;

        public bool Visible;
        public string? Color;
        public int HorizontPosition
        {
            get
            {
                return this._HorizontPosition;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();//добавить ошибку
                else
                    this._HorizontPosition = value;
            }
        }
        public int VerticalPosition
        {
            get
            {
                return this._VerticalPosition;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();//добавить ошибку 
                else
                    this._VerticalPosition = value;
            }
        }
        public Figure()
        {

        }

        public Figure(bool visible, string color)
        {
            this.Visible = visible;
            this.Color = color;
        }

        public Figure(bool visible, string color, int horizontPosition, int verticalPosition) : this(visible, color)
        {
            this.HorizontPosition = horizontPosition;
            this.VerticalPosition = verticalPosition;
        }

        public void MoveHorisont(int change)
        {

        }

        public void MoveVertical(int change)
        {

        }

        public void ChangeColor(string color)
        {
            this.Color = color;
        }

        public void IsVisible()
        {
            this.Visible = !this.Visible;
        }

        public void IsVisible(bool visible)
        {
            this.Visible = visible;
        }

        public override string ToString()
        {
            string condition;
            if (this.Visible)
                condition = "видима";
            else
                condition = "не видима";
            return $"Фигура: {condition}\nЦвет: {this.Color}\nПозиция: X:{this.HorizontPosition}, Y:{this.VerticalPosition}";
        }
    }
}
