using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Music : BaseModel
    {
        private int musicId;
        private string name;
        private string filePath;
        private string imagePath;
        private int signerId;
        private int categoryId;

        public Music()
        {
        }

        public Music(int musicId, string name,string filePath, string imagePath, int signerId, int categoryId)
        {
            this.MusicId = musicId;
            this.Name = name;
            this.FilePath = filePath;
            this.ImagePath = imagePath;
            this.SignerId = signerId;
            this.CategoryId = categoryId;
        }

        public int MusicId { get => musicId; set => musicId = value; }
        public string Name { get => name; set => name = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public int SignerId { get => signerId; set => signerId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string FilePath { get => filePath; set => filePath = value; }
    }
}