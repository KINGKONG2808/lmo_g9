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
        public static List<MusicDto> lms;
        public static ListMusicRepository lm = new ListMusicRepository();
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
                ma.AudioPath = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=2";
                ma.ImagePath = "http://i1285.photobucket.com/albums/a583/TheGreatOzz1/Hosted-Images/Noisy-Freeks-Image_zps4kilrxml.png";
                ma.Name = "The Noisy Freakss";
                ma.ComposerName = "Premiere";
                ma.SingerName = "I Need You Back";
                ma.ImgHTML = "<img src='" + ms.ImagePath + "' runat='" + "server' " + "id=" + "'Img'" + "class=" + "'img second'" + "/>";
                lms.Add(ma);
            }
        }

        [WebMethod]
        public static MusicDto click(string id)
        {
            MusicDto json = new MusicDto();
            string musicName = "", sourcemp3Src = "", sourceoggSrc = "", imageSrc = "", composerName = "", singerName = "";
            if (lms.Count > 0)
            {
                foreach (MusicDto ms in lms)
                {
                    if (ms.MusicId == int.Parse(id))
                    {
                        sourcemp3Src = ms.AudioPath;
                        sourceoggSrc = ms.AudioPath;
                        imageSrc = ms.ImagePath;
                        musicName = ms.Name;
                        composerName = ms.ComposerName;
                        if (ms.Composer != null)
                        {
                            if (ms.Composer.Count > 0)
                            {
                                foreach (string ft in ms.Composer)
                                {
                                    composerName = composerName + " ft " + ft;
                                }
                            }
                        }
                        singerName = ms.SingerName;
                        if (ms.Singer != null)
                        {
                            if (ms.Singer.Count > 0)
                            {
                                foreach (string ft in ms.Singer)
                                {
                                    singerName = singerName + " ft " + ft;
                                }
                            }

                        }
                    }
                }
            }
            else
            {

                sourcemp3Src = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                sourceoggSrc = "https://dl.dropbox.com/s/oswkgcw749xc8xs/The-Noisy-Freaks.mp3?dl=1";
                imageSrc = "http://i1285.photobucket.com/albums/a583/TheGreatOzz1/Hosted-Images/Noisy-Freeks-Image_zps4kilrxml1.png";
                musicName = "The Noisy Freakss";
                composerName = "Premiere";
                singerName = "I Need You Back";
            }

            json.AudioPath = sourcemp3Src;
            json.ImagePath = imageSrc;
            json.Name = musicName;
            json.ComposerName = composerName;
            json.SingerName = singerName;

            return json;
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
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        [WebMethod]
        public static void logout()
        {
            try
            {
                HttpContext.Current.Session.Remove("accountClient");
            }
            catch (Exception ex)
            {
                
            }
        }

        [WebMethod]
        public static List<int> renderFavorite()
        {
            List<int> listId = new List<int>();
            try
            {
                if (HttpContext.Current.Session["accountClient"] != null)
                {
                    account = (Account)HttpContext.Current.Session["accountClient"];
                    listId = lm.getListFavoriteId(account.AccountId);
                }
            }
            catch (Exception)
            {
                account = null;
            }

            return listId;
        }

        [WebMethod]
        public static List<int> addToFavorite(string id)
        {
            List<int> listId = new List<int>();
            try
            {
                if (HttpContext.Current.Session["accountClient"] != null)
                {
                    account = (Account)HttpContext.Current.Session["accountClient"];
                    listId = lm.addToFavorite(account.AccountId,int.Parse(id));
                } else
                {
                    listId = null;
                }
            }
            catch (Exception)
            {
                account = null;
            }

            return listId;
        }

        [WebMethod]
        public static List<int> deleteFavorite(string id)
        {
            List<int> listId = new List<int>();
            try
            {
                if (HttpContext.Current.Session["accountClient"] != null)
                {
                    account = (Account)HttpContext.Current.Session["accountClient"];
                    listId = lm.deleteFavorite(account.AccountId, int.Parse(id));
                }
                else
                {
                    listId = null;
                }
            }
            catch (Exception)
            {
                account = null;
            }

            return listId;
        }
    }
}