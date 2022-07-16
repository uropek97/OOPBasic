

namespace Lesson_2
{
    internal class BankAcc
    {
        private static int count;
        private string _numb;//использую string потому что банковские счета состоят из 20 цифр и каждая часть счёта что-то означает, например одна из частей - тип счёта
        //кажется, будто string тут использовать более уместно. При генерации счёта использовать конкатенацию разных "смысловых" и "порядковых" частей. 
        private int _balance;
        private accType _type;
        /// <summary>
        /// Чтение поля _numb
        /// </summary>
        /// <returns>Возврат номера счёта</returns>
        public string GetNumber()
        {
            return this._numb;
        }
        /// <summary>
        /// Присвоение полю _numb значения
        /// </summary>
        /// <param name="numb">номер счета</param>
        public void SetNumber(string numb)
        {
            count++;
            this._numb = numb;
        }
        public void SetNumber()
        {
            this._numb = this.GenerateNumb();
        }
        /// <summary>
        /// Чтение поля _balance
        /// </summary>
        /// <returns>Возвращает баланс</returns>
        public int GetBalance()
        {
            return this._balance;
        }
        /// <summary>
        /// Присвоение полю _balance значения
        /// </summary>
        /// <param name="balance">баланс</param>
        public void SetBalance(int balance)
        {
            this._balance = balance;
        }
        /// <summary>
        /// Чтение поля _type
        /// </summary>
        /// <returns>Возвращает тип счёта</returns>
        public accType GetAccType()
        {
            return this._type;
        }
        /// <summary>
        /// Присвоение полю _type значения
        /// </summary>
        /// <param name="type">тип счёта</param>
        public void SetAccType(accType type)
        {
            this._type = type;
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
