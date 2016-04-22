﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Screen Task">
    <meta name="author" content="Eslam Hamouda">
    <title>Screen Task</title>

    <link href="bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            padding-top: 5px;
        }

        .footer {
            border-top: 1px solid #eee;
            margin-top: 40px;
            padding-top: 40px;
            padding-bottom: 40px;
        }

        /* Main marketing message and sign up button */
        .jumbotron {
            text-align: center;
            background-color: transparent;
        }

            .jumbotron .btn {
                font-size: 21px;
                padding: 14px 24px;
            }

        /* Customize the nav-justified links to be fill the entire space of the .navbar */

        .nav-justified {
            background-color: #eee;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

            .nav-justified > li > a {
                margin-bottom: 0;
                padding-top: 15px;
                padding-bottom: 15px;
                color: #777;
                font-weight: bold;
                text-align: center;
                border-bottom: 1px solid #d5d5d5;
                background-color: #e5e5e5; /* Old browsers */
                background-repeat: repeat-x; /* Repeat the gradient */
                background-image: -moz-linear-gradient(top, #f5f5f5 0%, #e5e5e5 100%); /* FF3.6+ */
                background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#f5f5f5), color-stop(100%,#e5e5e5)); /* Chrome,Safari4+ */
                background-image: -webkit-linear-gradient(top, #f5f5f5 0%,#e5e5e5 100%); /* Chrome 10+,Safari 5.1+ */
                background-image: -o-linear-gradient(top, #f5f5f5 0%,#e5e5e5 100%); /* Opera 11.10+ */
                filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f5f5f5', endColorstr='#e5e5e5',GradientType=0 ); /* IE6-9 */
                background-image: linear-gradient(top, #f5f5f5 0%,#e5e5e5 100%); /* W3C */
            }

            .nav-justified > .active > a,
            .nav-justified > .active > a:hover,
            .nav-justified > .active > a:focus {
                background-color: #ddd;
                background-image: none;
                box-shadow: inset 0 3px 7px rgba(0,0,0,.15);
            }

            .nav-justified > li:first-child > a {
                border-radius: 5px 5px 0 0;
            }

            .nav-justified > li:last-child > a {
                border-bottom: 0;
                border-radius: 0 0 5px 5px;
            }

        @media (min-width: 768px) {
            .nav-justified {
                max-height: 52px;
            }

                .nav-justified > li > a {
                    border-left: 1px solid #fff;
                    border-right: 1px solid #d5d5d5;
                }

                .nav-justified > li:first-child > a {
                    border-left: 0;
                    border-radius: 5px 0 0 5px;
                }

                .nav-justified > li:last-child > a {
                    border-radius: 0 5px 5px 0;
                    border-right: 0;
                }
        }

        /* Responsive: Portrait tablets and up */
        @media screen and (min-width: 768px) {
            /* Remove the padding we set earlier */
            .masthead,
            .marketing,
            .footer {
                padding-left: 0;
                padding-right: 0;
            }
        }
    </style>

    <script type="text/javascript">

        var refreshInterval = 500;

        var timer = null;
        setupIntv();

        function startStop(btn) {
            debugger;
            if (btn.className == "btn btn-lg btn-danger") {
               // btn.setAttribute('data-state', 'start');
                btn.className = "btn btn-lg btn-success";
                btn.value = "Start Watching!";
                clearInterval(timer);
                timer = null;
            } else {
               // btn.setAttribute('data-state', 'stop');
                btn.className = "btn btn-lg btn-danger";
                btn.value = "Stop Watching!";
                setupIntv();
            }

        };


        function setTimer() {
            debugger;
            var txtInterval = document.getElementById('txtInterval');
            refreshInterval = txtInterval.value;
            setupIntv();
        };


        var lnkAbout = document.getElementById('lnkAbout');
        var msgAbout = document.getElementById('msgAbout');
        var closeAbout = document.getElementById('closeAbout');
        lnkAbout.onclick = function () {

            msgAbout.className = "alert alert-info alert-dismissable";
        };
        closeAbout.onclick = function () {
            msgAbout.className = "alert alert-info alert-dismissable hidden";
        };

        function requestFullScreen(element) {
            // Supports most browsers and their versions.
            var requestMethod = element.requestFullScreen || element.webkitRequestFullScreen || element.mozRequestFullScreen || element.msRequestFullScreen;

            if (requestMethod) { // Native full screen.
                requestMethod.call(element);
            } else if (typeof window.ActiveXObject !== "undefined") { // Older IE.
                var wscript = new ActiveXObject("WScript.Shell");
                if (wscript !== null) {
                    wscript.SendKeys("{F11}");
                }
            }
        }

        var btnFullscreen = document.getElementById('btnFullscreen');
        btnFullscreen.onclick = function () {

            var viewer = document.getElementById('Viewer');
            requestFullScreen(viewer);
        };

        function setupIntv() {
            clearInterval(timer);
            timer = null;
            timer = setInterval(function () {
                HandleIT();
                var ImagePreview = document.getElementById('imgPrev');
                ImagePreview.src = 'Images/ScreenTask.jpeg?rand=' + Math.random();
            }, refreshInterval);
        }

        function HandleIT() {
            PageMethods.TakeScreenshot(onSucess, onError);
            function onSucess(result) {
               // alert(result);
            }
            function onError(result) {
               // alert('Something wrong.');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Say bye-bey to Postbacks.</p>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        </div>
        <div class="container">

            <div class="masthead">
                <h1 class="text-muted">Screen Task</h1>
                <ul class="nav nav-justified">
                    <li class="active"><a href="./">Home</a></li>
                    <li><a target="_blank" href="https://github.com/EslaMx7/ScreenTask">Project On Github</a></li>
                    <li><a id="lnkAbout" href="#">About</a></li>
                </ul>
            </div>
            <br />
            <div id="msgAbout" class="alert alert-info alert-dismissable hidden">
                <button id="closeAbout" type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>About!</strong>
                <p>Share Your Desktop With Your Friends Inside The Internal Network [No Internet Connection Required]</p>
                <p>This Application Developed by : Eslam Hamouda | &copy; EslaMxSoft 2014 </p>
                <p class="text-center"><em>Hope This Helps You On Your Work!</em></p>
                <p>Send Your Feedback to : EslaMx7@Gmail.Com</p>
            </div>

            <hr />
            <!-- Preview -->
            <div id="Viewer" class="imgPreview">
                <img id="imgPrev" src="ScreenTask.jpg" class="img-responsive" alt="LIVE! Sever Screen Now!" />
                <br />
                <div class="well text-center">

                    <div class="row">

                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Button id="btnStartStop" OnClientClick="startStop(this); return false;"  Text="Stop Watching!"  CssClass="btn btn-lg btn-danger"  runat="server" />
                        </div>

                        <div id="intervalSection" class="col-lg-4 col-md-4 col-sm-4">
                            <div class="input-group input-group-sm">
                                <input id="txtInterval" type="text" class="form-control" placeholder="Interval in Mellisecond" value="500">
                                <div class="input-group-btn">
                                             <asp:Button id="btnSetTimer" OnClientClick="setTimer(); return false;"  Text="Set Refresh Interval(ms)"  CssClass="btn btn-default btn-md dropdown-toggle"  runat="server" />

                                </div>
                                <!-- /btn-group -->
                            </div>
                            <!-- /input-group -->
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <button id="btnFullscreen" class="btn btn-lg btn-primary">Fullscreen</button>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                </div>

            </div>
            <!-- Site footer -->
            <div class="footer">
                <p>&copy; Screen Task 2014 | <a href="http://eslamx.com">EslaMxSoft</a>, by <a href="https://twitter.com/EslaMx7">@EslaMx7</a>.</p>
            </div>

        </div>

    </form>
</body>
</html>
