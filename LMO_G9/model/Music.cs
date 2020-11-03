using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Music : BaseModel
    {
        private long musicId;
        private string name;
        private string imagePath;
        private long signerId;
        private long typeId;

        public Music()
        {
        }

        public Music(long musicId, string name, string imagePath, long signerId, long typeId)
        {
            this.MusicId = musicId;
            this.Name = name;
            this.ImagePath = imagePath;
            this.SignerId = signerId;
            this.TypeId = typeId;
        }

        public long MusicId { get => musicId; set => musicId = value; }
        public string Name { get => name; set => name = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public long SignerId { get => signerId; set => signerId = value; }
        public long TypeId { get => typeId; set => typeId = value; }
    }
}