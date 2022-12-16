using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Alchemy
{
    public class AlchemyElement : IComparable
    {
        public int ID { get; set; }
        public string Name 
        {
            get { return AlchemyResources.Elements.LocalizedName(ID); }
        }
        public bool Terminal { get; set; }
        public BitmapImage Icon { get; set; }
        public AlchemyElementGroup Group { get; set; }

        public int CompareTo(object obj)
        {
            AlchemyElement element = obj as AlchemyElement;
            if (element != null)
                return this.Name.CompareTo(element.Name);
            else
                throw new ArgumentException("Object is not an AlchemyElement");
        }
    }
}
