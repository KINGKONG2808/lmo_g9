using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Composer : BaseModel
    {
        private long composerId;
        private string name;
        private string imagePath;

        public Composer()
        {
        }

        public Composer(long composerId, string name, string imagePath)
        {
            this.ComposerId = composerId;
            this.Name = name;
            this.ImagePath = imagePath;
        }

        public long ComposerId { get => composerId; set => composerId = value; }
        public string Name { get => name; set => name = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}