using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.dto;
using LMO_G9.model;
using LMO_G9.respository;
using System.Web.Services;

namespace LMO_G9.view.client
{
    public partial class search : System.Web.UI.Page
    {
        public static Account account = new Account();
        public static List<MusicDto> lms;
        public static ListMusicRepository lm = new ListMusicRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["value"];
            if (id != null)
            {
                lms = lm.getListSearch(id);
            }
            else
            {
                lms = lm.getList();
            }
            if (lms.Count > 0)
            {
                sourcemp3.Src = lms[0].AudioPath;
                sourceogg.Src = lms[0].AudioPath;
                image.Src = lms[0].ImagePath;
                musicName.InnerText = lms[0].Name;
                composerName.InnerText = lms[0].ComposerName;
                singerName.InnerText = lms[0].SingerName;
                if (lms[0].Singer.Count > 0)
                {
                    foreach (string ft in lms[0].Singer)
                    {
                        singerName.InnerText = singerName.InnerText + " ft " + ft;
                    }
                }
                foreach (MusicDto ms in lms)
                {

                    string imagePath = ms.ImagePath.Replace("~/", "../../");
                    ms.ImgHTML = "<img src='" + imagePath + "' runat='" + "server' " + "id=" + "'Img'" + "class=" + "'img second'" + "/>";
                }
            }
        }
    }
}