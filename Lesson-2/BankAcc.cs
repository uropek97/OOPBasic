

namespace Lesson_2
{
    internal class BankAcc
    {
        private static int count;

        private string? _numb;//использую string потому что банковские счета состоят из 20 цифр и каждая часть счёта что-то означает, например одна из частей - тип счёта
        //кажется, будто string тут использовать более уместно. При генерации счёта использовать конкатенацию разных "смысловых" и "порядковых" частей. 
        private int _balance;
        private AccType _type;

        public string Numb
        {
            get { return _numb; }
            set { if (value is null) { _numb = "0000000"; } else { _numb = value; } }
        }
        public int Balance
        {
            get { return _balance; }
            set { if (value < 0) { _balance = 0; } else { _balance = value; }; }
        }
        public AccType Type { get { return _type; } set { _type = value; } }

        public BankAcc()
        {
            this.Numb = this.GenerateNumb();
        }
        public BankAcc(int balance)
        {
            this.Balance = balance;
            this.Numb = this.GenerateNumb();
        }
        public BankAcc(AccType type)
        {
            this.Type = type;
            this.Numb = this.GenerateNumb();
        }
        public BankAcc(int balance, AccType type)
        {
            this.Type = type;
            this.Balance = balance;
            this.Numb = this.GenerateNumb();
        }
        /// <summary>
        /// Генерация уникального номера счёта за счёт увеличения статической переменной count  
        /// </summary>
        /// <returns>Возвращает уникальный номер счёта</returns>
        private string GenerateNumb()
        {
            count++;
            return $"{(int)this.Type}{count.ToString().PadLeft(6, '0')}";
        }
        /// <summary>
        /// Положить деньги на счета
        /// </summary>
        /// <param name="money">сумма</param>
        public void PutMoney(int money)
        {
            Balance += money;
        }
        /// <summary>
        /// Снять деньги со счёта
        /// </summary>
        /// <param name="money">сумма</param>
        /// <returns>Возвращает true, если успешно</returns>
        public bool WithdrawMonye(int money)
        {
            if (money > Balance)
            {
                return false;
            }
            else
            {
                Balance -= money;
                return true;
            }
        }
        /// <summary>
        /// Информация для пользователя, усмешно ли прошло снятие со счёта
        /// </summary>
        /// <param name="operation"></param>
        public static string PrintChange(bool operation)
        {
            if (operation)
            {
                return "Баланс успешно изменён.";
            }
            else
            {
                return "Недостаточно средств на счету.";
            }
        }
        /// <summary>
        /// Перевод денег с одного счёта на другой
        /// </summary>
        /// <param name="acc">счёт с которого переводим</param>
        /// <param name="sum">сумма перевода</param>
        public void TransferMoney(BankAcc acc, int sum)
        {
            bool operation = acc.WithdrawMonye(sum);
            if (operation)
            {
                PutMoney(sum);
            }           
        }
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns>строку, содержащую тип счёта, номер счёта и баланс.</returns>
        public override string ToString()
        {
            return $"Тип счёта: {this.Type}\nНомер счёта: {this.Numb}\nБаланс: {this.Balance}";
        }

        public static bool operator ==(BankAcc first, BankAcc second)
        {
            return first.Balance== second.Balance;
        }

        public static bool operator !=(BankAcc first, BankAcc second)
        {
            return !(first.Balance == second.Balance);
        }

        public bool Equals(BankAcc compared)
        {
            return this.Balance == compared.Balance;
        }

        public override bool Equals(object? obj)//есть здесь, только потому что в задании было сказано "переопределить", не "перезагрузить". 
        {
            if(obj == null)
                return false;
            var notObj = obj as BankAcc;
            if (notObj is null)
                return false;
            return this.Balance == notObj.Balance;
        }

        public override int GetHashCode()
        {
            return int.Parse(this.Numb).GetHashCode();
        }
    }
    public enum AccType
    {
        Deposit = 1,
        Savings,
        LowCost,
        Numbered,
        TaxFree
    }
}
