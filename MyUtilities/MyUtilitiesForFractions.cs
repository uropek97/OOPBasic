namespace MyUtilities
{
    public static class MyUtilitiesForFractions
    {
        /// <summary>
        /// Проверка простое ли число
        /// </summary>
        /// <param name="numb">число которое проверяем</param>
        /// <returns>true если число простое</returns>
        public static bool IsPrimeNumber(int numb)
        {
            if (numb < 2) { return false; }
            if (numb == 2) { return true; }
            for (int i = 2; i < numb; i++)
            {
                if (numb % i == 0) return false;
            }
            return true;
        }        
        /// <summary>
        /// Раскладывает числа на простые множители
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>возвращает 2 массива простых чисел, произведение которых дают 2 числа на входе.</returns>
        private static (int[],int[]) DecompIntoPrimeFr(int first, int second)
        {
            var firstList = new List<int>();
            var secondList = new List<int>();
            if (first == 0)
                firstList.Add(1);
            else
            {
                if (first == 1)
                    firstList.Add(first);
                else
                {
                    for (int i = 2; i <= first; i++)
                    {
                        if (IsPrimeNumber(i))
                        {
                            while (first % i == 0)
                            {
                                firstList.Add(i);
                                first /= i;
                            }
                        }
                    }
                }
            }
            if (second == 0) 
                secondList.Add(1);
            else
            {
                if (second == 1)
                    secondList.Add(second);
                else
                {
                    for (int i = 2; i <= second; i++)
                    {
                        if (IsPrimeNumber(i))
                        {
                            while (second % i == 0)
                            {
                                secondList.Add(i);
                                second /= i;
                            }
                        }
                    }
                }
            }
            return (firstList.ToArray(), secondList.ToArray());
        }
        /// <summary>
        /// Метод берёт за основу первый массив. И добавляет в него всё, что не совпадает у второго(для нахождения Наименьшего Общего Кратного(НОК))
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Возвращает новый массив, состоящий из неповторяющихся элементов одновременно в обоих массивах.</returns>
        private static int[] CombineArrForMult(int[] first, int[] second)
        {
            var list = new List<int>(first);
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] == second[j])//все совпадения мы заменим на -1
                    {
                        first[i] = -1;
                        second[j] = -1;
                    }
                }
            }
            for (int i = 0; i < second.Length; i++)
            {
                if (second[i] != -1)
                {
                    list.Add(second[i]);
                }
            }
            var arr = list.ToArray();
            return arr;
        }
        /// <summary>
        /// Метод выбирает общее у двух массивов и создаёт новый на базе этого общего(для нахождения Наибольшего Общего Делителя(НОД))
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Возвращает массив общих элементов</returns>
        private static int[] CombineArrForDiv(int[] first, int[] second)
        {
            var list = new List<int>();
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] == second[j])//все совпадения мы заменим на -1
                    {
                        if (first[i] == -1 || second[j] == -1)
                        {
                            continue;
                        }
                        list.Add((int)first[i]);
                        first[i] = -1;
                        second[j] = -1;
                    }
                }
            }
            var arr = list.ToArray();
            return arr;
        }
        private static int CalcMultiplicArr(int[] arr)
        {
            var multiplication = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                multiplication *= arr[i];
            }
            return multiplication;
        }
        /// <summary>
        /// Метод находит Наименьшее Общее Кратное(НОК) для 2 чисел.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Вовзвращает Наименьшее Общее Кратное(НОК)</returns>
        public static int FindLCM(int first, int second)
        {
            var a = DecompIntoPrimeFr(first, second);
            var b = CombineArrForMult(a.Item1, a.Item2);
            var c = CalcMultiplicArr(b);
            return c;
        }
        /// <summary>
        /// Метод находит Наибольший Общий Делитель(НОД) для 2 чисел.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Возвращает Наибольший Общий Делитель(НОД)</returns>
        public static int FindGSD(int first, int second)
        {
            var a = DecompIntoPrimeFr(first, second);
            var b = CombineArrForDiv(a.Item1, a.Item2);
            var c = CalcMultiplicArr(b);
            return c;
        }
        /// <summary>
        /// Метод перемножает все элементы массива
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Возвращает результат умножения всех элементов</returns>
        public static int MultipArrElem(int[] arr)
        {
            int result = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                result *= arr[i];
            }
            return result;
        }

        /// <summary>
        /// Метод сокращает дробь
        /// </summary>
        /// <param name="numerator">числитель</param>
        /// <param name="denumirator">знаменатель</param>
        /// <returns>Возвращает новые числитель и знаменатель(сокращённые)</returns>
        public static (int, int) ReduceFraction(int numerator, int denumirator)
        {
            var newNumerator = 1;
            var newDenumerator = 1;
            if (numerator % denumirator == 0)
            {
                newNumerator = numerator / denumirator;
                return (newNumerator, newDenumerator);
            }
            var devisor = FindGSD(numerator, denumirator);
            newNumerator = numerator / devisor;
            newDenumerator = denumirator / devisor;

            return (newNumerator, newDenumerator);
        }
    }
}