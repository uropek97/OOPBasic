namespace Lesson_6
{
    internal class Point : Figure
    {
        //private double _HorizontPosition;
        //private double _VerticalPosition;

        //public sealed double HorizontPosition;
        //public sealed double VerticalPosition;

        //можно ли как-то в этом классе запечатать поля и свойства наследуемые от Figure? подобное  не подходит

        protected Point()
        {

        }

        public Point(double horizontPosition, double verticalPosition)
        {
            this.HorizontPosition = horizontPosition;
            this.VerticalPosition = verticalPosition;
        }

        public Point(bool visible, string color, double horizontPosition, double verticalPosition) : base(visible, color, horizontPosition, verticalPosition)
        {

        }

        public override void MoveHorizont(double change)
        {
            base.MoveHorizont(change);
        }

        public override void MoveVertical(double change)
        {
            base.MoveVertical(change);
        }

        public override void Move(double changeHoriz, double changeVert)
        {
            base.Move(changeHoriz, changeVert);
        }


        public override string ToString()
        {
            if (Color is null)
                return $"Позиция: X: {this.HorizontPosition} Y: {this.VerticalPosition}";
            else
                return $"Фигура: точка\n{this.GetConditionForPrint()}Позиция: X: {this.HorizontPosition} Y: {this.VerticalPosition}";
        }
    }
}
