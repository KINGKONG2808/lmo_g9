using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Singer : BaseModel
    {
        private long singerId;
        private string name;
        private string imagePath;

        public Singer()
        {
        }

        public Singer(long singerId, string name, string imagePath)
        {
            this.SingerId = singerId;
            this.Name = name;
            this.ImagePath = imagePath;
        }

        public long SingerId { get => singerId; set => singerId = value; }
        public string Name { get => name; set => name = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}