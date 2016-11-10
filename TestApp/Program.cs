using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attributes;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(1001);
            
            Console.WriteLine(Validator.IntIsValid(user));
            Console.ReadKey();
        }
    }
}
