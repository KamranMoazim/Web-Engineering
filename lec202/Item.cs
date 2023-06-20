using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lec202
{

    // Navigational Properties
    // we make them as a Virtual to make lazy loading - 
    // execution plan
    // ctx.Category.ToList();  -- To 
    // ctx.Category.First().Items.ToList();
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        [ForeignKey("cid")]
        virtual public Category category { get; set; }

        virtual public List<Company> Companies { get; set; }
    }
}