using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using WorkShopWPF.Model;


namespace WorkShopWPF.DataAccess
{
    class Loader
    {

        public static void LoadRecipeFromTxt(List<Recipe> Recipes)
        {
            var path = ConfigurationManager.AppSettings["binfile2"];
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strlist = line.Split(';');

                    Recipe Recipe_n = new Recipe(strlist[0]);

                    for (int l = 1; l < strlist.Length; l += 2)
                    {
                        Material baget = new Material (strlist[l], Convert.ToInt32(strlist[l + 1]));
                        Recipe_n.MaterialsForRecipe.Add(baget);
                    }

                    Recipes.Add(Recipe_n);
                }
            }
        }
       
        public static void LoadMaterialsFromTxt(List<Material> MaterialsInStorage)
        {
            var path = ConfigurationManager.AppSettings["binfile1"];
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine())
                    != null)
                {
                    string[] strlist = line.Split(';');

                    Material Material = new Material(strlist[0], Convert.ToInt32(strlist[1]));

                    MaterialsInStorage.Add(Material);
                }
            }
        }
    }
}
