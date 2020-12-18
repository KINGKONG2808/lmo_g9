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
        private int accountId;

        public MusicFactory()
        {
        }

        public MusicFactory(int musicFactoryId, int musicId, int accountId)
        {
            this.MusicFactoryId = musicFactoryId;
            this.MusicId = musicId;
            this.AccountId = accountId;
        }

        public int MusicFactoryId { get => musicFactoryId; set => musicFactoryId = value; }
        public int MusicId { get => musicId; set => musicId = value; }
        public int AccountId { get => accountId; set => accountId = value; }
    }
}