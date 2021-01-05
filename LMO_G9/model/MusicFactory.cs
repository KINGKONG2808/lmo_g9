using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class MusicFactory : BaseModel
    {
        private int musicFactoryId;
        private int musicId;
        private int singerId;

        public MusicFactory()
        {
        }

        public MusicFactory(int musicFactoryId, int musicId, int singerId)
        {
            this.MusicFactoryId = musicFactoryId;
            this.MusicId = musicId;
            this.SingerId = singerId;
        }

        public int MusicFactoryId { get => musicFactoryId; set => musicFactoryId = value; }
        public int MusicId { get => musicId; set => musicId = value; }
        public int SingerId { get => singerId; set => singerId = value; }
    }
}