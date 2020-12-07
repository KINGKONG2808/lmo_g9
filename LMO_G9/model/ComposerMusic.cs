using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class ComposerMusic : BaseModel
    {
        private long composerMusicId;
        private long composerId;
        private long musicId;

        public ComposerMusic()
        {
        }

        public ComposerMusic(long composerMusicId, long composerId, long musicId)
        {
            this.ComposerMusicId = composerMusicId;
            this.ComposerId = composerId;
            this.MusicId = musicId;
        }

        public long ComposerMusicId { get => composerMusicId; set => composerMusicId = value; }
        public long ComposerId { get => composerId; set => composerId = value; }
        public long MusicId { get => musicId; set => musicId = value; }
    }
}