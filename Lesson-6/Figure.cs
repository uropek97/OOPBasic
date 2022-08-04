using System.Text;

namespace Lesson_6
{
    public abstract class Figure
    {
        public abstract bool Visible { get; protected set; }
        public abstract string? Color { get; protected set; }
        public abstract double HorizontPosition { get; protected set; }
        public abstract double VerticalPosition { get; protected set; }

        /// <summary>
        /// Перемещение фигуры по горизонтали
        /// </summary>
        /// <param name="change">вещественное число, показывающее на сколько сдвинуть</param>
        public abstract void MoveHorizont(double change);

        /// <summary>
        /// Перемещение фигуры по вертикали
        /// </summary>
        /// <param name="change">вещественное число, показывающее на сколько сдвинуть</param>
        public abstract void MoveVertical(double change);

        /// <summary>
        /// Перемещение фигуры
        /// </summary>
        /// <param name="changeHoriz">вещественное число, показывающее на сколько сдвинуть по горизонтали</param>
        /// <param name="changeVert">вещественное число, показывающее на сколько сдвинуть по вертикали</param>
        public abstract void Move(double changeHoriz, double changeVert);

        /// <summary>
        /// Изменение цвета фигуры
        /// </summary>
        /// <param name="color">строковое представление цвета, на какой сменить</param>
        public abstract void ChangeColor(string color);

        /// <summary>
        /// Изменение видимости фигуры
        /// </summary>
        public abstract void ChangeVisible();

        /// <summary>
        /// Установить значение видимости фигуры
        /// </summary>
        /// <param name="visible">true - фигура будет видна</param>
        public abstract void SetVisible(bool visible);
    }
}
