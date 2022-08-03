using System.Text;

namespace Lesson_7
{
    public class BCoder : Coder, ICoder
    {
        private string? _Text;
        private bool _IsEncrypted = false;
        private readonly string? _Primary;

        public override string? Text { get { return this._Text; } set { this._Text = value; } }
        public override bool IsEncrypted { get { return this._IsEncrypted; } set { this._IsEncrypted = value; } }

        public BCoder(string text) : base(text)
        {
            this._Primary = text;
        }

        public override string Encode()
        {
            var strbuilder = new StringBuilder();
            var arr = this.Text.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (_Untouchables.Contains(arr[i])) { }
                else
                {
                    ChangeCharEe(ref arr[i]);
                    arr[i] = (char)Move((int)arr[i]);
                }
                strbuilder.Append(arr[i]);
            }
            this.IsEncrypted = true;
            this.Text = strbuilder.ToString();
            return this.Text;
        }
        public override string Decode()
        {
            this.Text = this._Primary;
            this.IsEncrypted = false;
            return base.Decode();
        }

        /// <summary>
        /// вычисление нового числового значения символа 
        /// </summary>
        /// <param name="value">текущее числовое значение символа</param>
        /// <returns>возврат нового числового значения символа </returns>
        private static int Move(int value)
        {
            if (value >= _Beginnings[0] && value <= _Ends[0])
                return _Ends[0] - (value - _Beginnings[0]);
            else if (value >= _Beginnings[1] && value <= _Ends[1])
                return _Ends[1] - (value - _Beginnings[1]);
            else if (value >= _Beginnings[2] && value <= _Ends[2])
                return _Ends[2] - (value - _Beginnings[2]);
            else if (value >= _Beginnings[3] && value <= _Ends[3])
                return _Ends[3] - (value - _Beginnings[3]);
            else
                return value; //если какие-то элементы не предусмотрены для шифрования, например цифры. 
        }
    }
}