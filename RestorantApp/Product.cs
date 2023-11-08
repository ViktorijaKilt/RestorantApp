using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorantApp
{
    public class Product
    {
        private int no;

        private string name;

        private string type;

        private decimal price;

        public Product(int no, string name, string type, decimal price)
        {
            this.no = no;
            this.name = name;
            this.type = type;
            this.price = price;
        }
        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
        public int No
        {
            get => no;
        }
        public string Name
        {
            get => name;
        }
        public string Type
        {
            get => type;
        }
        public decimal Price
        {
            get => price;
        }

    }
}
