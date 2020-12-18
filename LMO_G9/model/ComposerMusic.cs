using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class ComposerMusic : BaseModel
    {
        private int composerMusicId;
        private int composerId;
        private int musicId;

        public ComposerMusic()
        {
        }

        public ComposerMusic(int composerMusicId, int composerId, int musicId)
        {
            this.ComposerMusicId = composerMusicId;
            this.ComposerId = composerId;
            this.MusicId = musicId;
        }

        public int ComposerMusicId { get => composerMusicId; set => composerMusicId = value; }
        public int ComposerId { get => composerId; set => composerId = value; }
        public int MusicId { get => musicId; set => musicId = value; }
    }
}