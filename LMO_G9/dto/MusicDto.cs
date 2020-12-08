using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.dto
{
    public class MusicDto
    {
        private long musicId;
        private string name;
        private string audioPath;
        private string imagePath;
        private string singerName;
        private List<string> singer;
        private string categoryName;
        private string composerName;
        private List<string> composer;
        private string imgHTML;

        public MusicDto()
        {
        }

        public MusicDto(long musicId, string name, string audioPath, string imagePath, string signerName, List<string> singer, string categoryName, string composerName, List<string> composer, string imgHTML)
        {
            this.MusicId = musicId;
            this.Name = name;
            this.AudioPath = audioPath;
            this.ImagePath = imagePath;
            this.SingerName = signerName;
            this.Singer = singer;
            this.CategoryName = categoryName;
            this.ComposerName = composerName;
            this.Composer = composer;
            this.ImgHTML = imgHTML;
        }

        public long MusicId { get => musicId; set => musicId = value; }
        public string Name { get => name; set => name = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public string AudioPath { get => audioPath; set => audioPath = value; }
        public string SingerName { get => singerName; set => singerName = value; }
        public List<string> Singer { get => singer; set => singer = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string ComposerName { get => composerName; set => composerName = value; }
        public List<string> Composer { get => composer; set => composer = value; }
        public string ImgHTML { get => imgHTML; set => imgHTML = value; }
    }
}