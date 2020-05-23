using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopWPF.Model
{
    class Material 
    {
        private string name;
        private int quantity;

        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Material()
        {

        }

        public Material(string Name, int Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
        }
    }
}
