using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

namespace ClassExercise_Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza p1 = new Pizza(Size.Medium, Dough.GlutenFree, "cheese");
            Console.WriteLine(p1);

            p1.AddTopping("chili");
            Console.WriteLine(p1);

            p1.AddTopping("pepper flakes");
            Console.WriteLine(p1);

            p1.AddSide(Sides.Chips);
            p1.ChangeSize(Size.XLarge);
            p1.AddTopping("mushrooms");
            Console.WriteLine(p1);

            p1.AddSide(Sides.DippingSauce);
            p1.ChangeDough(Dough.Wholewheat);
            Console.WriteLine(p1);

            p1.RemoveSide(Sides.Chips);
            try
            {
                // try to remove a topping that was not there
                p1.RemoveTopping("pepper");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }

            string filename = "pizza.txt";
            Console.WriteLine($"Saving the pizza to {filename}");
            File.WriteAllText(filename, p1.ToString());
            //File.WriteAllText(filename, new JavaScriptSerializer().Serialize(p1));
        }
    }
}
