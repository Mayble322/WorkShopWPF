using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkShopWPF.Model
{
    class WorkShop
    {
        private static List<Material> materialsInStorage = new List<Material>();
        private static List<Recipe> recipes = new List<Recipe>();
        private static List<Order> orders = new List<Order>();

        internal static List<Material> MaterialsInStorage { get => materialsInStorage; set => materialsInStorage = value; }
        internal static List<Recipe> Recipes { get => recipes; set => recipes = value; }
        internal static List<Order> Orders { get => orders; set => orders = value; }
   
    }
}
