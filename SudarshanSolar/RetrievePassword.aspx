﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrievePassword.aspx.cs" Inherits="SudarshanSolar.RetrievePassword" %>

<!DOCTYPE html>

<html lang="en">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
  <meta name="description" content="Sudarshan Solar">
  <meta name="author" content="">

  <title>Sudarshan Solar</title>

  <link rel="apple-touch-icon" href="Content/i/topicon/assets/images/apple-touch-icon.png">
  <link rel="shortcut icon" href="Content/i/topicon/assets/images/favicon.ico">

  <!-- Stylesheets -->
  <link rel="stylesheet" href="Content/i/global/css/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/css/v2.2_3.css">
  <link rel="stylesheet" href="Content/i/topicon/assets/css/v2.2.css">

  <!-- Skin tools (demo site only) -->
  <link rel="stylesheet" href="Content/i/global/css/v2.2_2.css">
  <script src="Content/i/topicon/assets/js/sections/skintools.min.js"></script>

  <!-- Plugins -->
  <link rel="stylesheet" href="Content/i/global/vendor/animsition/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/vendor/asscrollable/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/vendor/switchery/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/vendor/intro-js/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/vendor/slidepanel/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/vendor/flag-icon-css/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/vendor/waves/v2.2.css">

  <!-- Page -->
  <link rel="stylesheet" href="Content/i/topicon/assets/examples/css/pages/v2.2_9.css">

  <!-- Fonts -->
  <link rel="stylesheet" href="Content/i/global/fonts/material-design/v2.2.css">
  <link rel="stylesheet" href="Content/i/global/fonts/brand-icons/v2.2.css">

  <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Roboto:400,400italic,700'>


  <!--[if lt IE 9]>
    <script src="Content/i/global/vendor/html5shiv/html5shiv.min.js"></script>
    <![endif]-->

  <!--[if lt IE 10]>
    <script src="Content/i/global/vendor/media-match/media.match.min.js"></script>
    <script src="Content/i/global/vendor/respond/respond.min.js"></script>
    <![endif]-->

  <!-- Scripts -->
  <script src="Content/i/global/vendor/modernizr/modernizr.min.js"></script>
  <script src="Content/i/global/vendor/breakpoints/breakpoints.min.js"></script>
  <script>
    Breakpoints();
  </script>
</head>
<body>
  <body class="page-forgot-password layout-full">
  <!--[if lt IE 8]>
        <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
    <![endif]-->


  <!-- Page -->
  <div class="page animsition vertical-align text-center" data-animsition-in="fade-in"
  data-animsition-out="fade-out">
    <div class="page-content vertical-align-middle">
      <h2>Forgot Your Password ?</h2>
      <p>Input your registered email to reset your password</p>

      <form id="form1" runat="server" >
           <div class="form-group form-material floating"> 
                <asp:RadioButton ID="Employee" runat="server" required Text="Employee" GroupName="type"/>  
                <asp:RadioButton ID="Customer" required runat="server" Text="Customer" GroupName="type" />
                 </div>
        <div class="form-group form-material floating">
          <asp:TextBox id="txtEmail" runat="server" class="form-control empty" required ></asp:TextBox>
          <label class="floating-label" for="inputEmail">Your Email</label>
        </div>
        <button  class="btn btn-primary btn-block"  runat="server" onserverclick="btnRetrieve_Click">Reset Your Password</button>
          
      </form>

      <footer class="page-copyright">
        <p>WEBSITE BY Anuvaasoft.com</p>
        <p>© 2016. All RIGHT RESERVED.</p>
        <div class="social">
          <a href="javascript:void(0)">
            <i class="icon bd-twitter" aria-hidden="true"></i>
          </a>
          <a href="javascript:void(0)">
            <i class="icon bd-facebook" aria-hidden="true"></i>
          </a>
          <a href="javascript:void(0)">
            <i class="icon bd-dribbble" aria-hidden="true"></i>
          </a>
        </div>
      </footer>
    </div>
  </div>
  <!-- End Page -->

 <!-- Core  -->
  <script src="Content/i/global/vendor/jquery/jquery.min.js"></script>
  <script src="Content/i/global/vendor/bootstrap/bootstrap.min.js"></script>
  <script src="Content/i/global/vendor/animsition/animsition.min.js"></script>
  <script src="Content/i/global/vendor/asscroll/jquery-asScroll.min.js"></script>
  <script src="Content/i/global/vendor/mousewheel/jquery.mousewheel.min.js"></script>
  <script src="Content/i/global/vendor/asscrollable/jquery.asScrollable.all.min.js"></script>
  <script src="Content/i/global/vendor/ashoverscroll/jquery-asHoverScroll.min.js"></script>
  <script src="Content/i/global/vendor/waves/waves.min.js"></script>

  <!-- Plugins -->
  <script src="Content/i/global/vendor/switchery/switchery.min.js"></script>
  <script src="Content/i/global/vendor/intro-js/intro.min.js"></script>
  <script src="Content/i/global/vendor/screenfull/screenfull.min.js"></script>
  <script src="Content/i/global/vendor/slidepanel/jquery-slidePanel.min.js"></script>

  <!-- Plugins For This Page -->
  <script src="Content/i/global/vendor/jquery-placeholder/jquery.placeholder.min.js"></script>

  <!-- Scripts -->
  <script src="Content/i/global/js/core.min.js"></script>
  <script src="Content/i/topicon/assets/js/site.min.js"></script>

  <script src="Content/i/topicon/assets/js/sections/menu.min.js"></script>
  <script src="Content/i/topicon/assets/js/sections/menubar.min.js"></script>
  <script src="Content/i/topicon/assets/js/sections/sidebar.min.js"></script>

  <script src="Content/i/global/js/configs/config-colors.min.js"></script>
  <script src="Content/i/topicon/assets/js/configs/config-tour.min.js"></script>

  <script src="Content/i/global/js/components/asscrollable.min.js"></script>
  <script src="Content/i/global/js/components/animsition.min.js"></script>
  <script src="Content/i/global/js/components/slidepanel.min.js"></script>
  <script src="Content/i/global/js/components/switchery.min.js"></script>
  <script src="Content/i/global/js/components/tabs.min.js"></script>

  <script src="Content/i/global/js/components/jquery-placeholder.min.js"></script>
  <script src="Content/i/global/js/components/material.min.js"></script>


  <script>
    (function(document, window, $) {
      'use strict';

      var Site = window.Site;
      $(document).ready(function() {
        Site.run();
      });
    })(document, window, jQuery);
  </script>
</body>
</html>
