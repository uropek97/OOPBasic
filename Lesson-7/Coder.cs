﻿using System.Text;

namespace Lesson_7
{
    public abstract class Coder : ICoder
    {
        public const int Shift = 1;
        public abstract string? Text { get; set; }
        public abstract bool IsEncrypted { get; set; }

        protected static char[] _Untouchables = { ' ', '!', ',', '.', ':', '?' };
        protected static char[] _Special = { 'Ё', 'ё' };

        protected static int[] _Beginnings = { 65, 97, 1040, 1072 };
        protected static int[] _Ends = { 90, 122, 1071, 1103 };

        protected Coder(string text)
        {
            this.Text = text;
            this.IsEncrypted = false;
        }

        /// <summary>
        /// кодирование
        /// </summary>
        /// <returns></returns>
        public virtual string Encode()
        {
            var strbuild = new StringBuilder();
            var arr = this.Text.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (_Untouchables.Contains(arr[i])) { }
                else
                {
                    ChangeCharEe(ref arr[i]);
                    arr[i] = (char)CheckMoving((int)arr[i], Shift);
                }
                strbuild.Append(arr[i]);
            }
            return strbuild.ToString();
        }

        /// <summary>
        /// декодирование
        /// </summary>
        /// <returns></returns>
        public virtual string Decode()
        {
            return this.Text;
        }

        /// <summary>
        /// проверка на символ Ё или ё. Замена его на Е или е соответсвенно. 
        /// </summary>
        /// <param name="fromArr"></param>
        protected static void ChangeCharEe(ref char fromArr)
        {
            if (_Special[0] == fromArr)
                fromArr = 'Е';
            else if (_Special[1] == fromArr)
                fromArr = 'е';
        }

        /// <summary>
        /// проверка, где значение и вычисление нового
        /// </summary>
        /// <param name="value">числовое значение символа</param>
        /// <param name="shift">сдвиг на это количесетсво </param>
        /// <returns>новое числовое значение символа</returns>
        private static int CheckMoving(int value, int shift)
        {
            if (value >= _Beginnings[0] && value <= _Ends[0])
            {
                if (value + shift > _Ends[0])
                    return value + shift - 26;
            }
            else if (value >= _Beginnings[1] && value <= _Ends[1])
            {
                if (value + shift > _Ends[1])
                    return value + shift - 26;
            }
            else if (value >= _Beginnings[2] && value <= _Ends[2])
            {
                if (value + shift > _Ends[2])
                    return value + shift - 32;
            }
            else if (value >= _Beginnings[3] && value <= _Ends[3])
            {
                if (value + shift > _Ends[3])
                    return value + shift - 32;
            }
            return value + shift;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
