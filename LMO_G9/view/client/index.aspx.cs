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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static Account account = new Account();
        public List<MusicDto> lms;
        ListMusicRepository lm = new ListMusicRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            lms = new List<MusicDto>();
            lms = lm.getList();
            if (lms.Count > 0)
            {
                sourcemp3.Src = lms[0].AudioPath;
                sourceogg.Src = lms[0].AudioPath;
                image.Src = lms[0].ImagePath;
                musicName.InnerText = lms[0].Name;
                composerName.InnerText = lms[0].ComposerName;
                if (lms[0].Composer.Count > 0)
                {
                    foreach (string ft in lms[0].Composer)
                    {
                        composerName.InnerText = composerName.InnerText + " ft " + ft;
                    }
                }
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
                    ms.ImgHTML = "<img src='" + ms.ImagePath + "' runat='" + "server' " + "id=" + "'Img'" + "class=" + "'img second'" + "/>";
                }
            }
            else
            {
                MusicDto ms = new MusicDto();
                ms.MusicId = 1;
                ms.AudioPath = sourcemp3.Src = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                sourceogg.Src = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                ms.ImagePath = image.Src = "http://i1285.photobucket.com/albums/a583/TheGreatOzz1/Hosted-Images/Noisy-Freeks-Image_zps4kilrxml.png";
                ms.Name = musicName.InnerText = "The Noisy Freaks";
                ms.ComposerName = composerName.InnerText = "Premiere";
                ms.SingerName = singerName.InnerText = "I Need You Back";
                ms.ImgHTML = "<img src='" + ms.ImagePath + "' runat='" + "server' " + "id=" + "'Img'" + "class=" + "'img second'" + "/>";
                lms.Add(ms);

                MusicDto ma = new MusicDto();
                ma.MusicId = 2;
                ma.AudioPath = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                ma.ImagePath = "http://i1285.photobucket.com/albums/a583/TheGreatOzz1/Hosted-Images/Noisy-Freeks-Image_zps4kilrxml.png";
                ma.Name = "The Noisy Freakss";
                ma.ComposerName =  "Premiere";
                ma.SingerName =  "I Need You Back";
                ma.ImgHTML = "<img src='" + ms.ImagePath + "' runat='" + "server' " + "id=" + "'Img'" + "class=" + "'img second'" + "/>";
                lms.Add(ma);
            }

        }

        protected void click(int a)
        {
            if (lms.Count > 0)
            {
                foreach (MusicDto ms in lms)
                {
                    if (ms.MusicId == a)
                    {
                        sourcemp3.Src = ms.AudioPath;
                        sourceogg.Src = ms.AudioPath;
                        image.Src = ms.ImagePath;
                        musicName.InnerText = ms.Name;
                        composerName.InnerText = ms.ComposerName;
                        if (ms.Composer.Count > 0)
                        {
                            foreach (string ft in ms.Composer)
                            {
                                composerName.InnerText = composerName.InnerText + " ft " + ft;
                            }
                        }
                        singerName.InnerText = ms.SingerName;
                        if (ms.Singer.Count > 0)
                        {
                            foreach (string ft in ms.Singer)
                            {
                                singerName.InnerText = singerName.InnerText + " ft " + ft;
                            }
                        }
                    }
                }
            }
            else
            {

                sourcemp3.Src = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                sourceogg.Src = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                image.Src = "http://i1285.photobucket.com/albums/a583/TheGreatOzz1/Hosted-Images/Noisy-Freeks-Image_zps4kilrxml.png";
                musicName.InnerText = "The Noisy Freaks";
                composerName.InnerText = "Premiere";
                singerName.InnerText = "I Need You Back";
            }
        }

        [WebMethod]
        public static string onRenderLogin()
        {
            string result = null;
            try
            {
                if (HttpContext.Current.Session["accountClient"] != null)
                {
                    account = (Account)HttpContext.Current.Session["accountClient"];
                    result = account.Fullname;
                }
            } catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        [WebMethod]
        public static string logout()
        {
            string result;
            try
            {
                HttpContext.Current.Session.Remove("accountClient");
                result = "/view/client/index.aspx";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}