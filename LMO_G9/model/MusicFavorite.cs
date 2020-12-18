using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class MusicFavorite : BaseModel
    {
        private int musicFavoriteId;
        private int musicId;
        private int accountId;

        public MusicFavorite()
        {
        }

        public MusicFavorite(int musicFavoriteId, int musicId, int accountId)
        {
            this.MusicFavoriteId = musicFavoriteId;
            this.MusicId = musicId;
            this.AccountId = accountId;
        }

        public int MusicFavoriteId { get => musicFavoriteId; set => musicFavoriteId = value; }
        public int MusicId { get => musicId; set => musicId = value; }
        public int AccountId { get => accountId; set => accountId = value; }
    }
}