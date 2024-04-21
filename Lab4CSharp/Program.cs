//Task 1
using System;

// Представлення кольорів ромбів
public enum RombColor
{
    Red = 1,    // Числове значення червоного кольору
    Blue = 2,   // Числове значення синього кольору
    Green = 3,  // Числове значення зеленого кольору
    Yellow = 4  // Числове значення жовтого кольору
}

class Romb
{
    protected int side;         // Довжина сторони ромба
    protected int diagonal;     // Довжина діагоналі ромба
    protected RombColor color;  // Колір ромба

    // Властивості для отримання та встановлення значень сторін, діагоналі та кольору
    public int Side
    {
        get { return side; }
        set { side = value; }
    }

    public int Diagonal
    {
        get { return diagonal; }
        set { diagonal = value; }
    }

    public RombColor Color
    {
        get { return color; }
    }

    // Конструктор для створення екземпляру класу з заданими значеннями
    public Romb(int side, int diagonal, RombColor color)
    {
        this.side = side;
        this.diagonal = diagonal;
        this.color = color;
    }

    // Метод для виведення довжин сторін та діагоналі на консоль
    public void DisplayLengths()
    {
        Console.WriteLine($"Сторона: {side}, Діагональ: {diagonal}");
    }

    // Метод для розрахунку периметру ромба
    public int CalculatePerimeter()
    {
        return 4 * side;
    }

    // Метод для розрахунку площі ромба
    public int CalculateArea()
    {
        return (side * diagonal) / 2;
    }

    // Метод для перевірки, чи ромб є квадратом
    public bool IsSquare()
    {
        return side == diagonal;
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return side;
                case 1:
                    return diagonal;
                case 2:
                    return color;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Неприпустимий індекс");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    side = (int)value;
                    break;
                case 1:
                    diagonal = (int)value;
                    break;
                case 2:
                    color = (RombColor)value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Неприпустимий індекс");
            }
        }
    }

    // Перевантаження операторів
    public static Romb operator ++(Romb r)
    {
        r.side++;
        r.diagonal++;
        return r;
    }

    public static Romb operator --(Romb r)
    {
        r.side--;
        r.diagonal--;
        return r;
    }

    public static bool operator true(Romb r)
    {
        return r.IsSquare();
    }

    public static bool operator false(Romb r)
    {
        return !r.IsSquare();
    }

    public static Romb operator *(Romb r, int scalar)
    {
        r.side *= scalar;
        r.diagonal *= scalar;
        return r;
    }

    public static Romb operator *(int scalar, Romb r)
    {
        return r * scalar;
    }

    public static explicit operator string(Romb r)
    {
        return $"Сторона: {r.side}, Діагональ: {r.diagonal}, Колір: {r.color}";
    }

    public static explicit operator Romb(string s)
    {
        // Розбити рядок на компоненти
        string[] parts = s.Split(new char[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 6)
        {
            throw new ArgumentException("Рядок має бути в форматі 'Сторона:значення, Діагональ:значення, Колір:значення'", nameof(s));
        }

        // Отримати значення сторони
        if (!int.TryParse(parts[1].Trim(), out int side))
        {
            throw new ArgumentException("Неможливо розпізнати значення сторони", nameof(s));
        }

        // Отримати значення діагоналі
        if (!int.TryParse(parts[3].Trim(), out int diagonal))
        {
            throw new ArgumentException("Неможливо розпізнати значення діагоналі", nameof(s));
        }

        // Отримати значення кольору
        if (!Enum.TryParse<RombColor>(parts[5].Trim(), out RombColor color))
        {
            throw new ArgumentException("Неможливо розпізнати значення кольору", nameof(s));
        }

        return new Romb(side, diagonal, color);
    }
}

class Program
{
    static void Main()
    {
        // Створення масиву ромбів з використанням конструктора
        Romb[] rombs = new Romb[]
        {
            new Romb(5, 8, RombColor.Red),     // Створення ромба зі стороною 5, діагоналлю 8 та червоним кольором
            new Romb(7, 10, RombColor.Blue),   // Створення ромба зі стороною 7, діагоналлю 10 та синім кольором
            new Romb(6, 6, RombColor.Green),   // Створення ромба зі стороною 6, діагоналлю 6 та зеленим кольором
            new Romb(8, 8, RombColor.Yellow)   // Створення ромба зі стороною 8, діагоналлю 8 та жовтим кольором
        };

        int squareCount = 0; // Лічильник кількості квадратних ромбів

        // Цикл для ітерації через всі ромби в масиві
        foreach (var romb in rombs)
        {
            // Виведення інформації про ромб з використанням властивостей та методів класу Romb
            Console.WriteLine($"Ромб зі стороною {romb.Side}, діагоналлю {romb.Diagonal}, кольором {romb.Color} ({(int)romb.Color}):");

            // Виведення периметру ромба
            Console.WriteLine($"Периметр: {romb.CalculatePerimeter()}");

            // Виведення площі ромба
            Console.WriteLine($"Площа: {romb.CalculateArea()}");

            // Перевірка, чи ромб є квадратом
            if (romb.IsSquare())
            {
                squareCount++;
                Console.WriteLine("Цей ромб - квадрат.");
            }
            else
            {
                Console.WriteLine("Цей ромб - не квадрат.");
            }

            Console.WriteLine(); // Порожній рядок для відокремлення інформації про різні ромби
        }

        // Виведення загальної кількості квадратних ромбів
        Console.WriteLine($"Загальна кількість квадратів: {squareCount}");

        // Перевірка індексатора
        Console.WriteLine("Перевірка індексатора:");
        Console.WriteLine($"Сторона першого ромба: {rombs[0][0]}");
        Console.WriteLine($"Діагональ другого ромба: {rombs[1][1]}");
        Console.WriteLine($"Колір третього ромба: {rombs[2][2]}");

        // Перевірка перевантажених операторів
        Console.WriteLine("\nПеревірка перевантажених операторів:");
        Romb testRomb = new Romb(3, 3, RombColor.Red);
        Console.WriteLine($"Початковий ромб: {testRomb}");
        Console.WriteLine($"Постінкремент: {++testRomb}");
        Console.WriteLine($"Постдекремент: {--testRomb}");
        Console.WriteLine($"Множення на скаляр (2): {testRomb * 2}");
        Console.WriteLine($"Перетворення у рядок: {(string)testRomb}");

        try
        {
            Romb fromString = (Romb)"Сторона: 4, Діагональ: 4, Колір: Red";
            Console.WriteLine($"Створений ромб з рядка: {fromString}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

//Task 2

using System;

class VectorUshort
{
    protected ushort[] ArrayUShort; // масив для зберігання елементів вектора
    protected uint num; // розмір вектора
    public uint codeError; // код помилки
    static uint num_vs; // кількість векторів

    // Конструктори
    public VectorUshort()
    {
        ArrayUShort = new ushort[1]; // виділення пам'яті для масиву з одним елементом
        num = 1; // встановлення розміру вектора
        codeError = 0; // початкове значення коду помилки
        num_vs++; // збільшення лічильника створених векторів
    }

    public VectorUshort(uint size)
    {
        ArrayUShort = new ushort[size]; // виділення пам'яті для масиву з заданим розміром
        num = size; // встановлення розміру вектора
        codeError = 0; // початкове значення коду помилки
        num_vs++; // збільшення лічильника створених векторів
    }

    public VectorUshort(uint size, ushort value)
    {
        ArrayUShort = new ushort[size]; // виділення пам'яті для масиву з заданим розміром
        num = size; // встановлення розміру вектора
        for (int i = 0; i < size; i++)
        {
            ArrayUShort[i] = value; // ініціалізація елементів вектора значенням value
        }
        codeError = 0; // початкове значення коду помилки
        num_vs++; // збільшення лічильника створених векторів
    }

    // Деструктор
    ~VectorUshort()
    {
        Console.WriteLine("Об'єкт вектора знищено."); // виведення повідомлення про знищення об'єкта
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент[{i}]: ");
            ArrayUShort[i] = Convert.ToUInt16(Console.ReadLine()); // зчитування значення елементу з клавіатури
        }
    }

    public void Display()
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент[{i}] = {ArrayUShort[i]}"); // виведення елементів вектора на екран
        }
    }

    public void Assign(ushort value)
    {
        for (int i = 0; i < num; i++)
        {
            ArrayUShort[i] = value; // присвоєння всім елементам вектора заданого значення
        }
    }

    public static uint CountVectors()
    {
        return num_vs; // повернення кількості створених векторів
    }

    // Властивості
    public uint Size
    {
        get { return num; } // властивість для отримання розміру вектора
    }

    public uint CodeError
    {
        get { return codeError; } // властивість для отримання значення коду помилки
        set { codeError = value; } // властивість для встановлення значення коду помилки
    }

    // Індексатор
    public ushort this[int index]
    {
        get
        {
            if (index < 0 || index >= num)
            {
                codeError = 1; // встановлення коду помилки, якщо індекс некоректний
                return 0;
            }
            else
            {
                codeError = 0; // скидання коду помилки
                return ArrayUShort[index]; // повернення значення елемента за індексом
            }
        }
        set
        {
            if (index >= 0 && index < num)
            {
                ArrayUShort[index] = value; // присвоєння значення елементу за індексом
            }
            else
            {
                codeError = 1; // встановлення коду помилки, якщо індекс некоректний
            }
        }
    }

    // Перевантаження операторів

    // Оператор інкременту (++v)
    public static VectorUshort operator ++(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v[i]++; // збільшення значення кожного елемента на 1
        }
        return v;
    }

    // Оператор додавання для двох векторів (v1 + v2)
    public static VectorUshort operator +(VectorUshort v1, VectorUshort v2)
    {
        uint size = Math.Max(v1.num, v2.num); // визначення максимального розміру
        VectorUshort result = new VectorUshort(size); // створення нового вектора
        for (int i = 0; i < size; i++)
        {
            result[i] = (ushort)(v1[i] + v2[i]); // додавання відповідних елементів і запис результату в новий вектор
        }
        return result;
    }

    // Оператор порівняння рівності для двох векторів (v1 == v2)
    public static bool operator ==(VectorUshort v1, VectorUshort v2)
    {
        if (v1.num != v2.num)
            return false; // якщо розміри векторів відрізняються, вони не рівні
        for (int i = 0; i < v1.num; i++)
        {
            if (v1[i] != v2[i])
                return false; // якщо хоча б один елемент не рівний, вектори не рівні
        }
        return true; // якщо всі елементи рівні, вектори рівні
    }

    // Оператор порівняння нерівності для двох векторів (v1 != v2)
    public static bool operator !=(VectorUshort v1, VectorUshort v2)
    {
        return !(v1 == v2); // використовуємо визначений раніше оператор порівняння рівності
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення першого вектора та ініціалізація його значеннями
        VectorUshort vector1 = new VectorUshort(3, 5);
        Console.WriteLine("Елементи вектора 1:");
        vector1.Display(); // вивід елементів вектора на екран

        // Створення другого вектора та ініціалізація його значеннями
        VectorUshort vector2 = new VectorUshort(3, 3);
        Console.WriteLine("\nЕлементи вектора 2:");
        vector2.Display(); // вивід елементів вектора на екран

        // Порівняння векторів
        if (vector1 != vector2)
        {
            Console.WriteLine("\nВектори не рівні."); // виведення результату порівняння
        }
        else
        {
            Console.WriteLine("\nВектори рівні.");
        }

        Console.WriteLine("\nКількість створених векторів: " + VectorUshort.CountVectors()); // виведення кількості створених векторів
    }
}

//Task 3

using System;

class MatrixUshort
{
    protected ushort[,] ShortIntArray; // Поле для зберігання елементів матриці
    protected int n, m; // Розміри матриці
    protected int codeError; // Код помилки
    protected static int num_m; // Кількість створених матриць

    // Конструктор без параметрів, створює однорозмірну матрицю ініціалізовану нулями
    public MatrixUshort()
    {
        n = m = 1;
        ShortIntArray = new ushort[n, m];
        num_m++; // Збільшення лічильника кількості матриць
    }

    // Конструктор з параметрами розмірів матриці, створює матрицю ініціалізовану нулями
    public MatrixUshort(int n, int m)
    {
        this.n = n;
        this.m = m;
        ShortIntArray = new ushort[n, m];
        num_m++; // Збільшення лічильника кількості матриць
    }

    // Конструктор з параметрами розмірів та початковим значенням, створює матрицю з початковими значеннями
    public MatrixUshort(int n, int m, ushort initialValue)
    {
        this.n = n;
        this.m = m;
        ShortIntArray = new ushort[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = initialValue;
            }
        }
        num_m++; // Збільшення лічильника кількості матриць
    }

    // Деструктор, викликається при видаленні об'єкта та виводить повідомлення
    ~MatrixUshort()
    {
        Console.WriteLine("Destructor called");
    }

    // Метод для введення елементів матриці з клавіатури
    public void InputMatrix()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Enter element at position [{i},{j}]: ");
                ShortIntArray[i, j] = ushort.Parse(Console.ReadLine());
            }
        }
    }

    // Метод для виведення елементів матриці на екран
    public void DisplayMatrix()
    {
        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{ShortIntArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    // Статичний метод для отримання кількості створених матриць
    public static int CountMatrices()
    {
        return num_m;
    }

    // Індексатор для доступу до елементів матриці
    public ushort this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                codeError = 0;
                return ShortIntArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                ShortIntArray[i, j] = value;
                codeError = 0;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    // Властивості для отримання розмірів матриці та коду помилки
    public int N => n;
    public int M => m;
    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Перевантаження оператора додавання для матриць
    public static MatrixUshort operator +(MatrixUshort mat1, MatrixUshort mat2)
    {
        MatrixUshort result = new MatrixUshort(mat1.n, mat1.m);
        if (mat1.n != mat2.n || mat1.m != mat2.m)
        {
            Console.WriteLine("Matrix dimensions are not equal. Returning first matrix.");
            return mat1;
        }
        else
        {
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    result.ShortIntArray[i, j] = (ushort)(mat1.ShortIntArray[i, j] + mat2.ShortIntArray[i, j]);
                }
            }
            return result;
        }
    }

    // Перевантаження оператора порівняння для матриць
    public static bool operator ==(MatrixUshort mat1, MatrixUshort mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return false;

        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.ShortIntArray[i, j] != mat2.ShortIntArray[i, j])
                    return false;
            }
        }
        return true;
    }

    // Перевантаження оператора нерівності для матриць
    public static bool operator !=(MatrixUshort mat1, MatrixUshort mat2)
    {
        return !(mat1 == mat2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        MatrixUshort matrix1 = new MatrixUshort(rows, cols);
        Console.WriteLine("Enter elements for matrix1:");
        matrix1.InputMatrix();

        MatrixUshort matrix2 = new MatrixUshort(rows, cols);
        Console.WriteLine("Enter elements for matrix2:");
        matrix2.InputMatrix();

        MatrixUshort sum = matrix1 + matrix2;

        Console.WriteLine("Matrix (sum of matrix1 and matrix2):");
        sum.DisplayMatrix();

        Console.WriteLine($"Number of matrices created: {MatrixUshort.CountMatrices()}");
    }
}


