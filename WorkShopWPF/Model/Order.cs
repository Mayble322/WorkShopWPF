using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace WorkShopWPF.Model
{
    class Order : Material
    {

        private static string basketStr;
        private Recipe recipeLink;
        private static Dictionary<string, int> basketOrder = new Dictionary<string, int>();

        public static string BasketStr { get => basketStr; set => basketStr = value; }
        internal Recipe RecipeLink { get => recipeLink; set => recipeLink = value; }
        public static Dictionary<string, int> BasketOrder { get => basketOrder; set => basketOrder = value; }

        public Order(string Name, int Quantity, Recipe RecipeLink) : base(Name, Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.RecipeLink = RecipeLink;
        }

        public Order()
        {

        }

        public static List<String> GetRecipes()
        {
            List<String> Recipes = new List<String>();

            foreach (Recipe R in WorkShop.Recipes)
            {
                Recipes.Add(R.Name);
            }
            return Recipes;
        }    

        public static void AddOrder(string RecipeName, int Quantity)
        {
            foreach (Recipe R in WorkShop.Recipes)
            {
                if (RecipeName == R.Name)
                {
                    Order Order_N = new Order
                    {
                        Name = RecipeName,
                        Quantity = Quantity,
                        RecipeLink = R
                    };

                    WorkShop.Orders.Add(Order_N);
                }
            }
        }


        public static void GenBasketOfProd()
        {
            foreach (Order o in WorkShop.Orders)
            {
                foreach (Material i in o.RecipeLink.MaterialsForRecipe)
                {
                    if (BasketOrder.ContainsKey(i.Name))
                    {
                        BasketOrder[i.Name] += i.Quantity * o.Quantity;
                        
                    }
                    else
                    {
                        BasketOrder.Add(i.Name, i.Quantity * o.Quantity);
                        
                    }
                }
            }
        }

       

        public static string MaterialСalculation(Dictionary<string, int> Basket)
        {
            foreach (KeyValuePair<string, int> c in Basket)
            {
                BasketStr += (c.Key + " - " + c.Value + "\n");
            }
            return BasketStr;
        }

        public static bool AvailabilityMaterials(List<Material> MaterialsInStorage)
        {
            foreach (KeyValuePair<string, int> c in BasketOrder)
            {
                foreach (Material i in MaterialsInStorage)
                {
                    if (c.Key == i.Name)
                    {
                        if (c.Value > i.Quantity)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static string Treatment()
        {
            string answer = null;

            Order.GenBasketOfProd();
            if (Order.AvailabilityMaterials(WorkShop.MaterialsInStorage))
            {
                Order.MaterialСalculation(Order.BasketOrder);
                answer = "enough materials " ;
            }
            else

            {
                Order.MaterialСalculation(Order.BasketOrder);
                answer = "Error, not enough materials" ;
            }
            return answer;

        }

        public static void ClearBasket()
        {
            BasketOrder.Clear();
            BasketStr = "";
        }
    }
}
