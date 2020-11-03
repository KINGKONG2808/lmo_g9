using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class MusicFavorite : BaseModel
    {
        private long musicFavoriteId;
        private long musicId;
        private long accountId;

        public MusicFavorite()
        {
        }

        public MusicFavorite(long musicFavoriteId, long musicId, long accountId)
        {
            this.MusicFavoriteId = musicFavoriteId;
            this.MusicId = musicId;
            this.AccountId = accountId;
        }

        public long MusicFavoriteId { get => musicFavoriteId; set => musicFavoriteId = value; }
        public long MusicId { get => musicId; set => musicId = value; }
        public long AccountId { get => accountId; set => accountId = value; }
    }
}