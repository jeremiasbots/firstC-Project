using System.Text.Json;
namespace SaleProgram
{
    interface IProduct
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string GetInfo();
    }
    interface IFunction
    {
        public int GetPrice();
    }
    class Beer : IProduct, IFunction
    {
        public decimal Price { get; set; }
        public required string Name { get; set; }
        public string GetInfo() => $"Nombre: {Name}\nPrecio: {Price}";
        public int GetPrice() => decimal.ToInt32(Price);
    }
    class MyList<T>
    {
        private T[] _data;
        private int _index = 0;
        public MyList(int length) => _data = new T[length];
        public void Add(T item)
        {
            _data[_index++] = item;
        }
        public T Get(int index)
        {
            return _data[index];
        }
    }
    class Program
    {
        static string Message() => "Hello".ToLower();
        static void DoSomething(Func<string> fn)
        {
            Console.WriteLine(fn());
        }
        static void Show<T>(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {data[i]}");
            }
        }
        static void Main(string[] args)
        {
            MyList<string> list = new MyList<string>(3);
            list.Add("Nintendo");
            list.Add("Xbox");
            list.Add("PlayStation");
            Console.WriteLine(list.Get(0));
            var myNumbers = new List<int>() {
                1, 2, 3
            };
            foreach (var n in myNumbers)
            {
                Console.WriteLine(n);
            }
            string[] myArray = new string[3] {
                "Nintendo", "Xbox", "PlayStation"
            };
            Show(myArray);
            var myIntArray = new int[3] {
                50, 100, 150
            };
            Show<int>(myIntArray);
            Beer beer = new()
            {
                Name = "Polar",
                Price = 5000,
            };
            string jsonBeer = JsonSerializer.Serialize(beer);
            Console.WriteLine(jsonBeer);
            Console.WriteLine(beer.GetInfo());
            Console.WriteLine(beer.GetPrice());
            var add = (int a, int b) => a + b;
            Console.WriteLine(add(2, 3));
            DoSomething(Message);
            int[] numbers = new int[10] {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            numbers.Where(n => n % 2 == 0).ToList().ForEach(n => Console.WriteLine(n));
        }
    }
}