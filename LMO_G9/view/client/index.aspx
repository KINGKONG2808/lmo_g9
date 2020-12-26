<%@ Page Title="" Language="C#" MasterPageFile="~/view/client/template-client.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LMO_G9.view.client.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="container">
            <div class="row width-100 play-audio">
                <div class="player">
                    <div class="row" style="padding: 2rem">
                        <div class="col-lg-3">
                            <div class="cover">
                                <img src="abc.png" class="cover__img" runat="server" id="image" />
                            </div>
                        </div>
                        <div class="col-lg-9">
                            <div class="infor">
                                <div class="row">
                                    <span id="singerName" class="infor__singer-name" runat="server"></span>
                                </div>
                                <div class="row">
                                    <span id="composerName" class="infor__composer-name" runat="server"></span>
                                </div>
                                <div class="row">
                                    <span id="musicName" class="infor__music-name" runat="server"></span>
                                </div>

                                <div class="button-items">
                                    <audio id="music" preload="auto" loop="false">
                                        <source src='acb' type="audio/mp3" runat="server" id="sourcemp3">
                                        <source src='abc' type="audio/ogg" runat="server" id="sourceogg">
                                    </audio>
                                    <div id="slider">
                                        <div id="elapsed"></div>
                                    </div>
                                    <div class="count-down">
                                        <p id="timer">0:00</p>
                                    </div>
                                    <div class="controls">
                                        <span class="expend">
                                            <svg class="step-backward" viewBox="0 0 25 25" xml:space="preserve">
                                                <g>
                                                    <polygon points="4.9,4.3 9,4.3 9,11.6 21.4,4.3 21.4,20.7 9,13.4 9,20.7 4.9,20.7" />
                                                </g>
                                            </svg>
                                        </span>

                                        <svg id="play" viewBox="0 0 25 25" xml:space="preserve">
                                            <defs>
                                                <rect x="-49.5" y="-132.9" width="446.4" height="366.4" />
                                            </defs>
                                            <g>
                                                <circle fill="none" cx="12.5" cy="12.5" r="10.8" />
                                                <path fill-rule="evenodd" clip-rule="evenodd" d="M8.7,6.9V18c0,0,0.2,1.4,1.8,0l8.1-4.8c0,0,1.2-1.1-1-2L9.8,6.5 C9.8,6.5,9.1,6,8.7,6.9z" />
                                            </g>
                                        </svg>

                                        <svg id="pause" viewBox="0 0 25 25" xml:space="preserve">
                                            <g>
                                                <rect x="6" y="4.6" width="3.8" height="15.7" />
                                                <rect x="14" y="4.6" width="3.9" height="15.7" />
                                            </g>
                                        </svg>

                                        <span class="expend">
                                            <svg class="step-foreward" viewBox="0 0 25 25" xml:space="preserve">
                                                <g>
                                                    <polygon points="20.7,4.3 16.6,4.3 16.6,11.6 4.3,4.3 4.3,20.7 16.7,13.4 16.6,20.7 20.7,20.7" />
                                                </g>
                                            </svg>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr class="hr-top" />

                    <div class="row width-100 no-padding no-margin">
                        <div class="music">
                            <%
                                foreach (LMO_G9.dto.MusicDto dto in lms)
                                { %>
                            <div class="row song-2">
                                <div class="col-lg-11 info">
                                    <div class="row">
                                        <div class="col-lg-1 text-center">
                                            <%= dto.ImgHTML %>
                                        </div>
                                        <div class="col-lg-10 titles">
                                            <h5><%= dto.Name %></h5>
                                            <p><%= dto.SingerName %></p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-1 state">
                                    <a href="index.aspx?index=<%=dto.MusicId %>" onclick="click(<%=dto.MusicId %>)">
                                        <i class="material-icons">play_arrow</i>
                                    </a>
                                </div>
                            </div>
                            <hr class="hr-list" />
                            <%  } %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
