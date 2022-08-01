using System.Text;

namespace Lesson_6
{
    public class Figure
    {
        private bool _Visible;
        private string? _Color;
        private double _HorizontPosition;
        private double _VerticalPosition;

        public bool Visible;
        public string? Color;
        public double HorizontPosition;
        public double VerticalPosition;

        protected Figure()
        {

        }

        protected Figure(bool visible, string color, double horizontPosition, double verticalPosition)
        {
            this.Visible = visible;
            this.Color = color;
            this.HorizontPosition = horizontPosition;
            this.VerticalPosition = verticalPosition;
        }

        /// <summary>
        /// Перемещение фигуры по горизонтали
        /// </summary>
        /// <param name="change">вещественное число, показывающее на сколько сдвинуть</param>
        public virtual void MoveHorizont(double change)
        {
                this.HorizontPosition += change;
        }

        /// <summary>
        /// Перемещение фигуры по вертикали
        /// </summary>
        /// <param name="change">вещественное число, показывающее на сколько сдвинуть</param>
        public virtual void MoveVertical(double change)
        {
                this.VerticalPosition += change;
        }

        /// <summary>
        /// Перемещение фигуры
        /// </summary>
        /// <param name="changeHoriz">вещественное число, показывающее на сколько сдвинуть по горизонтали</param>
        /// <param name="changeVert">вещественное число, показывающее на сколько сдвинуть по вертикали</param>
        public virtual void Move(double changeHoriz, double changeVert)
        {
            this.MoveHorizont(changeHoriz);
            this.MoveVertical(changeVert);
        }

        /// <summary>
        /// Изменение цвета фигуры
        /// </summary>
        /// <param name="color">строковое представление цвета, на какой сменить</param>
        public void ChangeColor(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Изменение видимости фигуры
        /// </summary>
        public void ChangeVisible()
        {
            this.Visible = !this.Visible;
        }

        /// <summary>
        /// Установить значение видимости фигуры
        /// </summary>
        /// <param name="visible">true - фигура будет видна</param>
        public void SetVisible(bool visible)
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
