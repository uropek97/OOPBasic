

namespace Lesson_2
{
    internal class BankAcc
    {
        private static int count;
        private string _numb;//использую string потому что банковские счета состоят из 20 цифр и каждая часть счёта что-то означает, например одна из частей - тип счёта
        //кажется, будто string тут использовать более уместно. При генерации счёта использовать конкатенацию разных "смысловых" и "порядковых" частей. 
        private int _balance;
        private accType _type;

        public BankAcc()
        {
            this._numb = this.GenerateNumb();
        }
        public BankAcc(int balance)
        {
            this._balance = balance;
            this._numb = this.GenerateNumb();
        }
        public BankAcc(accType type)
        {
            this._type = type;
            this._numb = this.GenerateNumb();
        }
        public BankAcc(int balance, accType type)
        {
            this._type = type;
            this._balance = balance;
            this._numb = this.GenerateNumb();
        }

        /// <summary>
        /// Чтение поля _numb
        /// </summary>
        /// <returns>Возврат номера счёта</returns>
        public string GetNumber()
        {
            return this._numb;
        }
        /// <summary>
        /// Чтение поля _balance
        /// </summary>
        /// <returns>Возвращает баланс</returns>
        public int GetBalance()
        {
            return this._balance;
        }
        public accType GetAccType()
        {
            return this._type;
        }
        /// <summary>
        /// Генерация уникального номера счёта за счёт увеличения статической переменной count  
        /// </summary>
        /// <returns>Возвращает уникальный номер счёта</returns>
        public string GenerateNumb()
        {
            count++;
            return $"{(int)this._type}{count.ToString().PadLeft(6, '0')}";
        }
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns>строку, содержащую тип счёта, номер счёта и баланс.</returns>
        public override string ToString()
        {
            return $"Тип счёта: {this._type}\nНомер счёта: {this._numb}\nБаланс: {this._balance}";
        }
    }
    enum accType
    {
        Текущий = 1,
        Сберегательный,
        Накопительный,
        Валютный,
        Общий
    }
}
