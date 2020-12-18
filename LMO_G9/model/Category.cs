using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Category : BaseModel
    {
        private int categoryId;
        private string name;

        public Category()
        {
        }

        public Category(int categoryId, string name)
        {
            this.categoryId = categoryId;
            this.name = name;
        }

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string Name { get => name; set => name = value; }
    }
}