using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec202
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public List<Item> Items { get; set; }

        virtual public CategoryDescription Description { get; set; }
    }
}