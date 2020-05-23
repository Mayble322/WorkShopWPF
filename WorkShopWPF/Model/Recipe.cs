using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopWPF.Model
{
    class Recipe
    {
        private string name;
        private List<Material> materialsForRecipe = new List<Material>();

        public string Name { get => name; set => name = value; }
        public List<Material> MaterialsForRecipe { get => materialsForRecipe; set => materialsForRecipe = value; }

        public Recipe()
        { }
        public Recipe(string Name)
        {
            this.Name = Name;
        }
    }
}
