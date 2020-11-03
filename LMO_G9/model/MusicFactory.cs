using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class MusicFactory : BaseModel
    {
        private long musicFactoryId;
        private long musicId;
        private long accountId;

        public MusicFactory()
        {
        }

        public MusicFactory(long musicFactoryId, long musicId, long accountId)
        {
            this.MusicFactoryId = musicFactoryId;
            this.MusicId = musicId;
            this.AccountId = accountId;
        }

        public long MusicFactoryId { get => musicFactoryId; set => musicFactoryId = value; }
        public long MusicId { get => musicId; set => musicId = value; }
        public long AccountId { get => accountId; set => accountId = value; }
    }
}