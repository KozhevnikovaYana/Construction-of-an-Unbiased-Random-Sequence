using System;

namespace Math
{
    public sealed class Fraction: IEquatable<Fraction>
    {
        private int _numerator;				// Числитель
        private int _denominator;			// Знаменатель
        private readonly int _sign;			// Знак

        #region Конструкторы

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("В знаменателе не может быть нуля");
            }
            this._numerator = System.Math.Abs(numerator);
            this._denominator = System.Math.Abs(denominator);
            if (numerator * denominator < 0)
            {
                this._sign = -1;
            }
            else
            {
                this._sign = 1;
            }
        }
        // Вызов первого конструктора со знаменателем равным единице
        public Fraction(int number) : this(number, 1) { }        

        #endregion

        #region Вспомогательные функции
        // Возвращает дробь, обратную данной
        private Fraction GetReverse()
        {
            return new Fraction(this._denominator * this._sign, this._numerator);
        }
        // Возвращает дробь с противоположным знаком
        private Fraction GetWithChangedSign()
        {
            return new Fraction(-this._numerator * this._sign, this._denominator);
        }
        // Метод создан для устранения повторяющегося кода в методах сложения и вычитания дробей.
        // Возвращает дробь, которая является результатом сложения или вычитания дробей a и b,
        // В зависимости от того, какая операция передана в параметр operation.
        // P.S. использовать только для сложения и вычитания
        private static Fraction PerformOperation(Fraction a, Fraction b, Func<int, int, int> operation)
        {
            // Наименьшее общее кратное знаменателей
            int leastCommonMultiple = Util.GetLeastCommonMultiple(a._denominator, b._denominator);
            // Дополнительный множитель к первой дроби
            int additionalMultiplierFirst = leastCommonMultiple / a._denominator;
            // Дополнительный множитель ко второй дроби
            int additionalMultiplierSecond = leastCommonMultiple / b._denominator;
            // Результат операции
            int operationResult = operation(a._numerator * additionalMultiplierFirst * a._sign,
                b._numerator * additionalMultiplierSecond * b._sign);
            return new Fraction(operationResult, a._denominator * additionalMultiplierFirst);
        }
        
        // Возвращает сокращенную дробь
        public Fraction Reduce()
        {
            Fraction result = this;
            int greatestCommonDivisor = Util.GetGreatestCommonDivisor(this._numerator, this._denominator);
            result._numerator /= greatestCommonDivisor;
            result._denominator /= greatestCommonDivisor;
            return result;
        }
        #endregion


        #region Перегрузка операторов

        #region Перегрузка оператора +
        // Перегрузка оператора "+" для случая сложения двух дробей
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return PerformOperation(a, b, (x, y) => x + y);
        }
        // Перегрузка оператора "+" для случая сложения дроби с числом
        public static Fraction operator +(Fraction a, int b)
        {
            return a + new Fraction(b);
        }
        // Перегрузка оператора "+" для случая сложения числа с дробью
        public static Fraction operator +(int a, Fraction b)
        {
            return b + a;
        }
        #endregion

        #region Перегрузка оператора -
        // Перегрузка оператора "-" для случая вычитания двух дробей
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return PerformOperation(a, b, (x, y) => x - y);
        }
        // Перегрузка оператора "-" для случая вычитания из дроби числа
        public static Fraction operator -(Fraction a, int b)
        {
            return a - new Fraction(b);
        }
        // Перегрузка оператора "-" для случая вычитания из числа дроби
        public static Fraction operator -(int a, Fraction b)
        {
            return b - a;
        }
        #endregion

        #region Перегрузка оператора *
        // Перегрузка оператора "*" для случая произведения двух дробей
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * a._sign * b._numerator * b._sign, a._denominator * b._denominator);
        }
        // Перегрузка оператора "*" для случая произведения дроби и числа
        public static Fraction operator *(Fraction a, int b)
        {
            return a * new Fraction(b);
        }
        // Перегрузка оператора "*" для случая произведения числа и дроби
        public static Fraction operator *(int a, Fraction b)
        {
            return b * a;
        }
        #endregion

        #region Перегрузка оператора -
        // Перегрузка оператора "/" для случая деления двух дробей
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * b.GetReverse();
        }
        // Перегрузка оператора "/" для случая деления дроби на число
        public static Fraction operator /(Fraction a, int b)
        {
            return a / new Fraction(b);
        }
        // Перегрузка оператора "/" для случая деления числа на дробь
        public static Fraction operator /(int a, Fraction b)
        {
            return new Fraction(a) / b;
        }
        #endregion

        #region перегрузка -, ++, --

        // Перегрузка оператора "унарный минус"
        public static Fraction operator -(Fraction a)
        {
            return a.GetWithChangedSign();
        }
        // Перегрузка оператора "++"
        public static Fraction operator ++(Fraction a)
        {
            return a + 1;
        }
        // Перегрузка оператора "--"
        public static Fraction operator --(Fraction a)
        {
            return a - 1;
        }
        #endregion
        
        #region Equals and HashCode and ToString
        // Мой метод Equals
        public bool Equals(Fraction that)
        {
            Fraction a = this.Reduce();
            Fraction b = that.Reduce();
            return a._numerator == b._numerator &&
                   a._denominator == b._denominator &&
                   a._sign == b._sign;
        }
        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Fraction)
            {
                result = this.Equals(obj as Fraction);
            }
            return result;
        }
        // Переопределение метода GetHashCode
        public override int GetHashCode()
        {
            return this._sign * (this._numerator * this._numerator + this._denominator * this._denominator);
        }
        
            
        // Переопределение метода ToString
        public override string ToString()
        {
            if (_numerator == 0)
            {
                return "0";
            }
            var result = this._sign < 0 ? "-" : "";
            if (_numerator == this._denominator)
            {
                return result + "1";
            }
            if (_denominator == 1)
            {
                return result + this._numerator;
            }
            return result + _numerator + "/" + this._denominator;
        }
        #endregion

        #region Перегрузка == != и CompareTo
        // Перегрузка оператора "Равенство" для двух дробей
        public static bool operator ==(Fraction a, Fraction b)
        {
            // Приведение к Object необходимо для того, чтобы
            // можно было сравнивать дроби с null.   
            // Обычное сравнение a.Equals(b) в данном случае не подходит,
            // так как если a есть null, то у него нет метода Equals,
            // следовательно будет выдано исключение, а если
            // b окажется равным null, то исключение будет вызвано в
            // методе this.Equals
            var aAsObj = a as object;
            var bAsObj = b as object;
            if (aAsObj == null || bAsObj == null)
            {
                return aAsObj == bAsObj;
            }
            return a.Equals(b);
        }
        // Перегрузка оператора "Равенство" для дроби и числа
        public static bool operator ==(Fraction a, int b)
        {
            return a == new Fraction(b);
        }
        // Перегрузка оператора "Равенство" для числа и дроби
        public static bool operator ==(int a, Fraction b)
        {
            return new Fraction(a) == b;
        }
        // Перегрузка оператора "Неравенство" для двух дробей
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }
        // Перегрузка оператора "Неравенство" для дроби и числа
        public static bool operator !=(Fraction a, int b)
        {
            return a != new Fraction(b);
        }
        // Перегрузка оператора "Неравенство" для числа и дроби
        public static bool operator !=(int a, Fraction b)
        {
            return new Fraction(a) != b;
        }
        // Метод сравнения двух дробей
        // Возвращает	 0, если дроби равны    
        //				 1, если this больше that
        //				-1, если this меньше that
        private int CompareTo(Fraction that)
        {
            if (this.Equals(that))
            {
                return 0;
            }
            Fraction a = this.Reduce();
            Fraction b = that.Reduce();
            if (a._numerator * a._sign * b._denominator > b._numerator * b._sign * a._denominator)
            {
                return 1;
            }
            return -1;
        }

        #endregion
        
        #region Операторы сравнения
        // Перегрузка оператора ">" для двух дробей
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }
        // Перегрузка оператора ">" для дроби и числа
        public static bool operator >(Fraction a, int b)
        {
            return a > new Fraction(b);
        }
        // Перегрузка оператора ">" для числа и дроби
        public static bool operator >(int a, Fraction b)
        {
            return new Fraction(a) > b;
        }
        // Перегрузка оператора "<" для двух дробей
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }
        // Перегрузка оператора "<" для дроби и числа
        public static bool operator <(Fraction a, int b)
        {
            return a < new Fraction(b);
        }
        // Перегрузка оператора "<" для числа и дроби
        public static bool operator <(int a, Fraction b)
        {
            return new Fraction(a) < b;
        }
        // Перегрузка оператора ">=" для двух дробей
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }
        // Перегрузка оператора ">=" для дроби и числа
        public static bool operator >=(Fraction a, int b)
        {
            return a >= new Fraction(b);
        }
        // Перегрузка оператора ">=" для числа и дроби
        public static bool operator >=(int a, Fraction b)
        {
            return new Fraction(a) >= b;
        }
        // Перегрузка оператора "<=" для двух дробей
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }
        // Перегрузка оператора "<=" для дроби и числа
        public static bool operator <=(Fraction a, int b)
        {
            return a <= new Fraction(b);
        }
        // Перегрузка оператора "<=" для числа и дроби
        public static bool operator <=(int a, Fraction b)
        {
            return new Fraction(a) <= b;
        }
        #endregion
        #endregion

        public int GetNumerator()
        {
            return _numerator;

        }
    }
}