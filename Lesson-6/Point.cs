using System.Text;

namespace Lesson_6
{
    internal class Point : Figure
    {
        private bool _Visible;
        private string? _Color;
        private double _HorizontPosition;
        private double _VerticalPosition;

        public override bool Visible { get; protected set; }
        public override string? Color { get; protected set; }
        public override sealed double HorizontPosition { get; protected set; }
        public override sealed double VerticalPosition { get; protected set; }

        protected Point()
        {

        }

        public Point(double horizontPosition, double verticalPosition)
        {
            this.HorizontPosition = horizontPosition;
            this.VerticalPosition = verticalPosition;
        }

        public Point(bool visible, string color, double horizontPosition, double verticalPosition) : this(horizontPosition, verticalPosition)
        {
            Visible = visible;
            Color = color;
        }

        public override void MoveHorizont(double change)
        {
            this.HorizontPosition += change;
        }

        public override void MoveVertical(double change)
        {
            this.VerticalPosition += change;
        }

        public override void Move(double changeHoriz, double changeVert)
        {
            this.MoveHorizont(changeHoriz);
            this.MoveVertical(changeVert);
        }




        public override void ChangeColor(string color)
        {
            this.Color = color;
        }

        public override void ChangeVisible()
        {
           this.Visible = !this.Visible;
        }

        public override void SetVisible(bool visible)
        {
            this.Visible = visible;
        }

        /// <summary>
        /// Подготовка информации, для представления фигуры в строковом виде
        /// </summary>
        /// <returns>Возвращает строковое представление о состоянии видимости и цвете</returns>
        protected string GetConditionForPrint()
        {
            StringBuilder condition = new();
            condition.Append("Состояние: ");
            if (this.Visible)
                condition.Append("видна\n");
            else
                condition.Append("не видна\n");

            condition.Append($"Цвет: {this.Color}\n");
            return condition.ToString();
        }

        public override string ToString()
        {
            if (Color is null)
                return $"Позиция: X: {this.HorizontPosition} Y: {this.VerticalPosition}";
            else
                return $"Фигура: точка\n{this.GetConditionForPrint()}Позиция: X: {this.HorizontPosition} Y: {this.VerticalPosition}";
        }

        /// <summary>
        /// Расчёт площади фигуры
        /// </summary>
        /// <returns></returns>
        public virtual double CalcSqure()
        {
            return 0;
        }
    }
}
