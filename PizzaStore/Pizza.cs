using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExercise_Pizza
{
    enum Size { Small = 0, Medium = 1, Large = 2, XLarge = 3 }
    enum Dough { Plain = 0, Wholewheat = 1, GlutenFree = 2 }
    enum Sides { DippingSauce = 0, Chips = 1, Wedges = 2, GarlicBread = 3, Pop = 4, Wings = 5 }

    class Pizza
    {
        private static readonly double[] SIZE_PRICES = { 6.99, 8.99, 10.99, 11.99 };
        private static readonly double[] SIDE_PRICES = { 0.85, 0.75, 3.50, 2.75, 1.10, 6.99 };
        private static readonly double TOPPING_PRICES = 0.5;
        private Size size { get; set; }
        private Dough dough { get; set; }
        private List<Sides> sides { get; set; }
        private List<string> toppings { get; set; }
        public double cost;

        // constructor
        public Pizza(Size size, Dough dough = Dough.Plain, string topping = "Cheese")
        {
            this.size = size;
            this.dough = dough;
            this.toppings = new List<string>();
            sides = new List<Sides>();
            toppings.Add(topping);
        }
        public double Cost
        {
            get
            {
                double sizeTotalCost = SIZE_PRICES[(int)size];
                double toppingsTotalCost;
                double sideTotalCost = 0;

                if (toppings.Count() <= 2)
                {
                    toppingsTotalCost = 0;
                }
                else
                {
                    toppingsTotalCost = toppings.Count() * TOPPING_PRICES - 1;
                }

                for (int i = 0; i < sides.Count(); i++)
                {
                    sideTotalCost = sideTotalCost + SIDE_PRICES[(int)sides[i]];
                }

                cost = sizeTotalCost + toppingsTotalCost + sideTotalCost;
                return cost;
            }
        }
        public void AddTopping(string topping)
        {
            toppings.Add(topping);
        }
        public void AddTopping(string[] topping)
        {
            toppings.AddRange(topping);
        }
        public void RemoveTopping(string topping)
        {
            if (toppings.Contains(topping))
            {
                toppings.Remove(topping);
                return;
            }
            throw new Exception($"EXCEPTION: This {topping} was not ordered.");
        }
        public void AddSide(Sides side)
        {
            sides.Add(side);
        }
        public void RemoveSide(Sides side)
        {
            if (sides.Contains(side))
            {
                sides.Remove(side);
                return;
            }
            throw new Exception($"EXCEPTION: This {side} was not ordered.");
        }
        public void ChangeSize(Size size)
        {
            this.size = size;
        }
        public void ChangeDough(Dough dough)
        {
            this.dough = dough;
        }
        public override string ToString()
        {
            return $"{size} Pizza with {dough} dough: {Cost:C2}\nPizza toppings:\n {string.Join(", ", toppings)}\nPizza Sides:\n {string.Join(", ", sides)}";
        }
    }
}
