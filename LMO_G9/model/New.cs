using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class New :BaseModel
    {
        private int newsId;
        private string title;
        private string shortContent;
        private string content;
        private string imagePath;
        public New()
        {
        }
        public New(int newsId, string title, string shortContent, string content, string imagePath)
        {
            this.NewsId = newsId;
            this.Title = title;
            this.ShortContent = shortContent;
            this.Content = content;
            this.ImagePath = imagePath;
        }

        public int NewsId { get => newsId; set => newsId = value; }
        public string Title { get => title; set => title = value; }
        public string ShortContent { get => shortContent; set => shortContent = value; }
        public string Content { get => content; set => content = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}