﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoodFood._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="row">
        <div class="col-sm-3">
        <div id="container">
   <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" preserveAspectRatio="xMidYMin slice" viewBox="0 0 728 400">
      <defs>
         <style type="text/css">
            <![CDATA[
               /*Link your web fonts here*/
               @import url( "https://fonts.googleapis.com/css?family=Acme");
               /*Text style here*/
               text{
                   font-family: "Acme", "Helvetica", sans-serif;
                   font-weight: 500;
                   text-transform: uppercase;
               }
               .sign-txt{
                   font-size: 55px;
               }
               .dish-txt{
                   font-size: 70px;
               }
               /*Your color scheme design here*/
               .color-1 {

                   fill: seagreen;
               }
               .color-2 {
                   fill: #131e30;
               }
               .color-3 {
                   fill:#090e17;
               }
               .color-4 {
                   fill: #e5e5e3;
               }
               .color-5 {
                   fill: #ccccca;
               }
               .stroke{
                   fill: none;
                   stroke: #090e17;
                   stroke-width:5;
               }
               #camera{
                 overflow: hidden;
               }
               svg{
                   width:100%;
                   padding-bottom: 55.55%;
                   height: 1px;
                   overflow: visible;
                   visibility:hidden;
               }

               ]]>
         </style>
      </defs>
      <script type="text/javascript" xlink:href="https://cdnjs.cloudflare.com/ajax/libs/gsap/latest/TweenMax.min.js"></script>
      <script type="text/javascript">
         <![CDATA[
          document.addEventListener("DOMContentLoaded", function (event) {
              window.onload = function () {
                  var camera = document.getElementById("camera"),
                      hand3 = document.getElementById("hand3"),
                      plate = document.getElementById("plate"),
                      platecover = document.getElementById("platecover"),
                      fork = document.getElementById("fork"),
                      smoke = document.getElementById("smoke"),
                      smoke1 = document.getElementById("smoke1"),
                      smoke2 = document.getElementById("smoke2"),
                      smoke3 = document.getElementById("smoke3"),
                      smoke4 = document.getElementById("smoke4"),
                      smoke5 = document.getElementById("smoke5"),
                      smoke6 = document.getElementById("smoke6"),
                      smoke7 = document.getElementById("smoke7"),
                      smoke8 = document.getElementById("smoke8"),
                      smoke9 = document.getElementById("smoke9"),
                      dishtext = document.getElementById("dishtext"),
                      dishtext1 = document.getElementById("dishtext1"),
                      dishtext2 = document.getElementById("dishtext2"),
                      sign = document.getElementById("sign"),
                      hand_sign = document.getElementById("hand_sign"),
                      hand_dish = document.getElementById("hand_dish"),
                      hand_cover = document.getElementById("hand_cover"),
                      nale = document.getElementById("nale"),
                      mask1 = document.getElementById("mask1"),
                      mask2 = document.getElementById("mask2"),
                      hand1 = document.getElementById("hand1"),
                      hand2 = document.getElementById("hand2");
                  //settings
                  TweenMax.set("svg", { visibility: "visible" })
                  TweenMax.set([nale, sign, hand3, plate, hand1, hand2, platecover, dishtext, fork, smoke, mask1, mask2], { autoAlpha: 0 })
                  TweenMax.set(sign, { y: -37, rotation: -5, transformOrigin: "49% 0%", })
                  TweenMax.set(hand1, { x: -8, y: -1 })
                  TweenMax.set(hand2, { x: -8, y: -1 })
                  TweenMax.set([smoke1, smoke2, smoke3, smoke4, smoke5, smoke6, smoke7, smoke8, smoke9], { scale: 0 })
                  TweenMax.set(hand_dish, { transformOrigin: "0% 50%" })
                  TweenMax.set(hand_cover, { transformOrigin: "50% 100%" })
                  //timeline
                  var tl = new TimelineMax({ repeat: -1, delay: .5, repeatDelay: .5 })
                  //scene 1
                  tl.set(camera, { attr: { viewBox: "0 0 728 400" } })
                  tl.set([hand3, plate, platecover], { autoAlpha: 1 })
                  tl.from(hand_dish, 2, { x: -580, rotation: -5, ease: Elastic.easeOut.config(.1, .08) }, "+=.5")
                  tl.set([hand1, dishtext, smoke, mask1, mask2], { autoAlpha: 1 })
                  tl.fromTo(hand1, 1, { x: 580 }, { x: 1, ease: Power4.easeOut })
                  tl.to(hand_cover, 1, { x: 60, y: 60, rotation: 60, ease: Elastic.easeOut.config(.08, .1) })
                  tl.fromTo(smoke, 2, { y: 220 }, { y: -180, ease: Power0.easeNone }, "-=1")
                      .add("smoky", 3)
                  tl.set(smoke, { autoAlpha: 0 })
                  tl.to(hand_cover, 1, { x: 400, ease: Elastic.easeIn.config(.08, .1) }, "-=1")
                  tl.set([hand1, platecover], { autoAlpha: 0 })
                  tl.from(dishtext2, 1, { x: 160, y: 60, attr: { dx: "0,-50,-50,-50,-50,-50,-50,-50,-50,-50,0" }, z: .01, rotation: .01, ease: Elastic.easeOut.config(1, .4) })
                  tl.from(dishtext1, 1, { x: 220, y: 120, attr: { dx: "0,-50,-50,-50,-50,-50,-50,0" }, z: 0.01, rotation: 0.01, ease: Elastic.easeOut.config(1, .4) }, "-=.9")
                  tl.set([mask1, mask2], { autoAlpha: 0 })
                  tl.set([hand1, fork], { autoAlpha: 1, x: 250, y: -180 }),
                      tl.set(hand_cover, { rotation: 40 })
                  tl.to([hand_dish, dishtext], 2, { x: -140, ease: Elastic.easeInOut.config(.1, .08) }, "+=.5")
                  tl.to(hand_cover, 1, { x: -140, ease: Power4.easeOut }, "-=1")
                  tl.to([hand_cover, dishtext], .5, { x: 580, ease: Power2.easeIn })
                  tl.set([hand1, fork, dishtext], { autoAlpha: 0 })
                  tl.set(hand_cover, { x: 400, rotation: 60 })
                  tl.set(hand1, { x: 1 })
                  tl.to(hand_dish, 1, { x: -580, rotation: -5, ease: Power4.easeIn })
                  tl.set([hand3, plate], { autoAlpha: 0 })
                  //scene 2
                  tl.set(camera, { attr: { viewBox: "-380 0 728 400" } })
                  tl.set(nale, { autoAlpha: 1 })
                  tl.to(camera, 1, { attr: { viewBox: "0 0 728 400" }, ease: Elastic.easeOut.config(.1, .1) }, "+=.5")
                  tl.set([hand2, sign], { autoAlpha: 1 })
                  tl.from(hand_sign, 1, { x: 600, ease: Elastic.easeOut.config(.1, .1) })
                  tl.to(sign, 2, { rotation: .01, z: .01, ease: Elastic.easeOut.config(2, .2) }, "-=.8")
                  tl.set(hand2, { autoAlpha: 0 })
                  tl.set(hand1, { x: 20, y: 150, rotation: -55 })
                  tl.set(hand1, { autoAlpha: 1 })
                  tl.to(sign, .5, { y: 0, ease: Elastic.easeOut.config(1, 0.3) })
                  tl.to(sign, 5, { rotation: -6, ease: Elastic.easeOut.config(6, .2) }, "-=.4")
                  tl.to(hand1, 1, { x: 100, y: 65, ease: Elastic.easeOut.config(.1, .1) }, "-=4.5")
                  tl.to(hand1, 1, { x: 400, y: -165, ease: Elastic.easeIn.config(.1, .1) }, "-=3.5")
                  tl.set(hand1, { autoAlpha: 0 })
                  tl.to(camera, 1, { attr: { viewBox: "80 170 580 200" }, ease: Power1.easeInOut }, "-=2.5")
                  tl.to(camera, 1, { attr: { viewBox: "80 400 580 200" }, ease: Elastic.easeIn.config(.1, .1) })
                  tl.set([nale, sign], { autoAlpha: 0 })
                  //add smoke particles
                  tl.to(smoke1, 3, { scale: 1 }, "smoky")
                  tl.to(smoke2, 3, { scale: 1 }, "smoky")
                  tl.to(smoke3, 3, { scale: 1 }, "smoky")
                  tl.to(smoke4, 3, { scale: 1 }, "smoky")
                  tl.to(smoke5, 3, { scale: 1 }, "smoky")
                  tl.to(smoke6, 3, { scale: 1 }, "smoky")
                  tl.to(smoke7, 3, { scale: 1 }, "smoky")
                  tl.to(smoke8, 3, { scale: 1 }, "smoky")
                  tl.to(smoke9, 3, { scale: 1 }, "smoky")
              };
          });
                 ]]>
           
      </script>
      <path d="M0 0h728v400H0z" class="color-1"/>
      <svg id="camera" viewBox="0 0 728 400">
         <path id="nale" d="M365 138.5a12.4 6.37 0 0 0-13 6.3 12.4 6.37 0 0 0 6 5.2l4 21h4l3-21a12.4 6.37 0 0 0 7-5.2 12.4 6.37 0 0 0-11-6.3z" class="color-3"/>
         <g id="hand_sign">
            <g id="sign">
               <path d="M486.32 231.48l-242.352 4.08 3.536 116.96L483.6 356.6zM463.2 241h1.36c2.72 0 5.44 4.08 5.44 6.8 0 2.72-2.72 6.8-5.44 6.8-4.08 0-6.8-2.72-6.8-6.8 0-2.72 2.72-6.8 5.44-6.8zm-200.6 2.72c3.4 0 6.12 2.72 6.12 6.8s-2.72 6.8-6.12 6.8c-3.672 0-6.664-2.72-6.392-6.8-.272-4.08 2.72-6.8 6.392-6.8z" class="color-4"/>
               <path d="M490.234 227.576l-250.21 4.166 4.11 123.223 243.272 5.55zm-5.11 5.086l-2.61 122.742-233.54-5.33-3.783-113.418z" class="color-3"/>
               <path d="M362.52 158.81l-98.18 87.12a2.5 2.5 0 1 0 3.32 3.74l94.938-84.242 96.265 81.56a2.5 2.5 0 1 0 3.233-3.816z" class="color-3"/>
               <text x="295" y="288" class="color-3 sign-txt">
                  ORDER
               </text>
               <text x="300" y="338" class="color-3 sign-txt">
                  NOW !
               </text>
            </g>
            <g id="hand2">
               <path d="M367.914 9.93c-2.73 1.254-5.46 3.766-5.46 9.226 0 3.55 5.46 10.51 8.19 12.967 1.365 5.05 5.46 9.283 9.555 13.24-2.73-1.91-8.19-3.14-12.29-3.685l-9.56-2.047c-1.37-.27-4.1-.41-8.19-.68-5.46-1.77-8.19-2.32-8.19-2.32l-4.1-.68c-4.1-2.32-10.92-4.23-12.29-4.09-2.73 7.1 1.36 10.1 9.55 13.11 9.55 3.01 17.74 6.14 27.3 8.74-2.73 0-6.83.28-10.92 1.5-6.83 2.46-12.29 4.92-17.75 8.19l-12.28 4.5c-4.1.69-8.19 2.46-10.92 3.96-1.37 4.78 4.09 8.6 12.28 7.24 2.73-1.23 6.82-2.73 12.28-4.64 6.82-1.36 9.55-3 21.84-5.05 6.82.55 13.65 1.23 21.84 1.78-10.92 5.46-13.65 7.51-20.48 10.65-1.37 1.5-1.37 1.37-2.73 5.6 0 7.92 1.36 20.48 1.36 22.39 5.46 6.28 9.55 11.61 15.01 14.34 0 0 1.36 0 1.36-.13-2.73 1.23-5.46 3.14-5.46 6.15 5.46 1.91 9.554 2.73 13.65 3.41 1.364 2.05 6.824 6.55 9.554 7.92 2.73 0 15.01-7.097 19.11-10.1 6.82-2.73 9.55-3.276 13.65-6.28 2.73-1.5 9.55-3 9.55-3 6.827-2.73 23.207-9.01 28.667-12.42 9.558-4.37 16.38-4.51 32.76-5.46v12.42l43.68-.82-1.362-46.96-42.313-.273v2.32c-9.557-2.455-13.65-1.91-20.477 0-5.46 1.5-13.65.548-20.473-.82-4.1-.68-8.19-2.18-10.92-3.683-12.29-4.78-24.57-8.46-36.86-13.79-6.82-4.64-12.28-9.14-17.74-13.65-2.73-2.59-5.46-6-8.19-9.28-4.1-3.96-6.83-7.51-8.19-10.24-1.37-3.27-2.73-6-4.1-9.5zm20.475 78.977c1.36 1.775 4.09 2.185 6.82 1.912 4.09 2.04 5.46 2.59 10.92 5.05 2.73 4.23 0 12.69 0 17.74-6.83 6.96-9.56 6.69-15.02 9.69-4.1-.96-12.29-1.09-16.38.55 1.36-1.09 1.36-4.92 0-9.56-1.37-5.74-4.1-7.24-5.46-9.69 1.36-1.5 4.09-6.01 4.09-10.79 4.09-.41 6.82-2.73 10.92-4.51z" class="color-4"/>
               <path d="M325.6 38.54c1.364 3.275 5.46 5.186 16.38 8.735 4.094 1.365 15.014 4.914 20.474 6.416 2.73 0 23.205 3.42 23.205 3.42-12.29-4.91-36.86-13.65-38.22-13.92-2.73-.54-4.1-.27-6.83 0-1.37 0-9.56-3.14-15.02-4.64zm35.49 24.296c-8.19.546-15.016 2.32-21.84 4.368-15.016 5.46-17.746 7.37-25.936 10.647 2.73 1.23 5.46 2.05 8.19 1.51 8.19-.95 8.19-4.5 35.49-9.42 2.73-.13 13.65.96 21.84 1.23l4.095-.54c-8.19-4.23-15.02-6.41-21.84-7.78zm23.204 17.745c-8.19.55-12.285 5.06-12.285 6.83-4.1 4.92-4.1 10.92-2.73 17.2 1.36-1.23 4.09-6 4.09-10.51 4.09-.68 8.19-3.41 10.92-4.23 1.36-.54 2.73-.68 4.09-.68 1.36 1.64 5.46 2.19 6.82 1.64 2.73 1.5 6.82 3.28 10.92 5.05 2.73 3.96 0 14.47 0 17.75 4.09-8.19 6.82-13.78 6.82-18.7 0-4.5-12.29-12.01-19.11-13.51-2.73-.54-6.83-.82-9.56-.82zm152.88 6.15l-25.935.82c-4.1-.41-9.56-.68-16.38.41v.28c-8.19 1.23-16.38 4.1-24.57 9.69-2.73 2.32-4.1-8.19-9.56-4.91-5.46 4.23-12.29 10.24-19.11 14.74-17.75 10.24-20.48 8.47-23.21 10.93-4.1 4.09-21.84 14.47-32.76 18.7 0 0 4.09 4.1 5.46 4.1 2.73 0 15.01-7.78 19.11-9.96 8.19-3 10.92-5.05 13.65-6.82 4.09-1.23 5.46-1.77 9.55-2.73 4.09-1.77 20.47-7.5 28.66-12.28 8.19-3.82 15.01-3.68 32.76-5.32v12.42l43.68-1.09z" class="color-5"/>
               <path d="M528.5 66.25L803 66v64.25l-273.5-1z" class="color-2"/>
               <path d="M529 87.5l274 .5v42.25l-273.5-1z" class="color-3"/>
            </g>
         </g>
         <g id="dishtext">
            <text id="dishtext1" x="218" y="180" font-size="55" dx="0, 0, 0, 0, 0, 0, 0, 0" class="color-4 dish-txt">
               GOODFOOD
            </text>
            <path id="mask1" d="M150 185h430v55H150z" class="color-1"/>
            <text id="dishtext2" x="165" y="236" dx="0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0" class="color-4 dish-txt">
               RESTAURANT
            </text>
            <g id="smoke">
               <circle id="smoke1" cx="344" cy="74.5" r="30" class="color-5"/>
               <circle id="smoke2" cx="376" cy="108" r="30" class="color-4"/>
               <circle id="smoke3" cx="372" cy="53.5" r="30" class="color-4"/>
               <circle id="smoke4" cx="410" cy="108" r="30" class="color-5"/>
               <circle id="smoke5" cx="342" cy="110" r="30" class="color-4"/>
               <circle id="smoke6" cx="404" cy="76" r="30" class="color-4"/>
               <circle id="smoke7" cx="378" cy="83" r="30" class="color-5"/>
               <circle id="smoke8" cx="366" cy="146" r="30" class="color-4"/>
               <circle id="smoke9" cx="370" cy="130" r="30" class="color-5"/>
            </g>
            <path id="mask2" d="M200 239h340v200H200z" class="color-1"/>
         </g>
         <g id="hand_dish">
            <g id="hand3">
               <path d="M326.47 255.84c-4.08 0-8.16 0-8.16 4.08v20.4c-1.36 2.72-5.44 9.52-6.8 12.24-4.08 5.44-8.16 16.32-8.16 21.76-2.72 2.72-5.44 5.44-9.52 5.44-2.72 0-5.44 1.36-9.52 4.08h-40.8v51.68h35.36v-12.24c8.16-1.36 16.32-4.08 23.12-5.44 0 0 14.96-1.36 24.48-10.88l10.88-10.88c4.08-4.08 6.8-5.44 10.88-8.16 2.72-2.72 5.44-4.08 10.88-9.52 1.36-2.72 2.72-4.08 5.44-5.44 4.08-2.72 6.8-5.44 9.52-10.88 1.36-4.08 8.16-8.16 12.24-12.24 2.72-4.08 5.44-6.8 9.52-10.88 6.8-5.44 12.24-8.16 19.04-12.24 0 0 1.36 0 2.72-1.36 5.44-1.36 9.52-1.36 13.6-4.08-1.36-5.44-4.08-6.8-12.24-5.44-2.72 0-5.44 2.72-8.16 1.36-4.08-1.36-8.16-1.36-12.24 0-1.36 0-10.88 5.44-20.4 10.88-2.72 1.36-8.16 8.16-12.24 10.88-2.72 0-5.44 2.72-6.8 4.08l-2.72 2.72s-1.36-1.36-1.36-5.44c0-1.36 0 0 1.36-4.08 1.36-2.72 4.08-6.8 5.44-8.16 2.72-2.72 2.72-2.72 6.8-8.16-1.36-2.72-6.8-4.08-9.52-2.72-8.16 2.72-14.96 14.96-19.04 24.48l-6.8-1.36v-21.76c0-2.72-4.08-2.72-6.8-2.72z" class="color-4"/>
               <path d="M423.03 255.84c-2.72 0-8.16 0-12.24 2.72 1.36 1.36 1.36 2.72 1.36 2.72-1.36 1.36-2.72 2.72-4.08 2.72-2.72 1.36-10.88 6.8-13.6 8.16-2.72 2.72-6.8 6.8-9.52 10.88-2.72 2.72-10.88 12.24-16.32 19.04 13.6-10.88 23.12-23.12 25.84-24.48 6.8-5.44 17.68-12.24 20.4-13.6 2.72-1.36 5.44-1.36 5.44-1.36 2.72 0 6.8-1.36 9.52-2.72 0 0 0-2.72-2.72-4.08zm-96.56 0c-2.72 0-5.44 0-5.44 1.36-1.36 2.72-1.36 8.16-1.36 23.12 0 4.08-5.44 12.24-4.08 14.96 1.36 8.16-1.36 13.6-8.16 17.68l4.08 1.36c6.8-5.44 16.32-10.88 17.68-13.6 1.36-4.08 2.72-5.44 5.44-8.16l5.44-10.88-6.8-1.36c1.36-10.88 0-21.76 0-21.76-1.36-2.72-4.08-2.72-6.8-2.72zm77.52 2.72c-8.16 0-19.04 8.16-25.84 13.6l-19.04 19.04c-1.36 1.36-4.08 0-4.08-1.36-2.72-8.16-2.72-13.6 5.44-21.76 1.36-1.36 5.44-6.8 6.8-8.16-5.44-2.72-9.52-1.36-13.6 5.44-5.44 8.16-10.88 19.04-16.32 31.28-5.44 0-5.44 5.44-6.8 9.52-4.08 2.72-27.2 19.04-42.16 31.28-2.72 2.72-29.92 9.52-29.92 8.16v1.36h-14.96v28.56h35.36v-12.24c8.16-2.72 17.68-4.08 24.48-5.44 1.36 0 13.6-2.72 16.32-6.8 2.72-2.72 0-4.08 2.72-6.8 4.08-4.08 9.52-10.88 14.96-16.32 4.08-1.36 13.6-8.16 14.96-9.52 5.44-8.16 10.88-14.96 16.32-23.12 8.16-9.52 12.24-14.96 21.76-23.12 2.72-2.72 5.44-5.44 8.16-6.8 5.44 0 6.8-1.36 10.88-4.08 0 0 1.36-1.36-1.36-2.72h-2.72zm-38.08 20.4c-4.08 0-6.8 2.72-9.52 6.8 0 1.36 2.72 2.72 4.08 1.36 1.36-1.36 5.44-8.16 5.44-8.16z" class="color-5"/>
               <path d="M-56.643 322.48l302.872-1.36v66.64H-56.51z" class="color-2"/>
               <path d="M246.23 346.96l-303.01 4.08.273 36.72H246.23z" class="color-3"/>
            </g>
            <g id="plate">
               <path d="M232 242h265l-12 15H244z" class="color-3"/>
               <path d="M262 245c-1 4-1 5-1 9h18v-9z" class="color-4"/>
            </g>
            <g id="hand_cover">
               <g id="platecover">
                  <path d="M365 120a8.88 8.88 0 0 0-9 8 8.88 8.88 0 0 0 6 8v5c-57 1-105 43-114 98h235c-10-55-59-96-115-98v-5a8.88 8.88 0 0 0 6-8 8.88 8.88 0 0 0-9-8z" class="color-3"/>
                  <path d="M363 123c-3 0-5 2-5 5s2 5 5 5zm0 27c-49 0-92 37-100 85h16c13-64 48-75 84-85z" class="color-4"/>
               </g>
               <g id="hand1">
                  <path d="M367.914 9.065c-2.73 1.256-5.46 3.768-5.46 9.228 0 3.55 5.46 10.51 8.19 12.967 1.365 5.05 5.46 9.282 9.555 13.24-2.73-1.91-8.19-3.14-12.29-3.685l-9.56-2.047c-1.37-.274-4.1-.41-8.19-.683-5.46-1.774-8.19-2.32-8.19-2.32l-4.1-.683c-4.1-2.32-10.92-4.232-12.29-4.095-2.73 7.098 1.36 10.1 9.55 13.104 9.55 3.01 17.74 6.15 27.3 8.74-2.73 0-6.83.28-10.92 1.5-6.83 2.46-12.29 4.92-17.75 8.19l-12.27 4.51c-4.1.69-8.19 2.46-10.92 3.96-1.37 4.78 4.09 8.6 12.28 7.24 2.73-1.23 6.82-2.73 12.28-4.64 6.82-1.36 9.55-3 21.84-5.05 6.82.55 13.65 1.23 21.84 1.78-15.02 2.46-24.57 5.19-27.3 6.96-2.73 2.46-2.73 7.51-2.73 11.74-1.37 7.78-1.37 14.2 0 16.25 5.46 6.69 8.19 10.78 12.28 16.24 4.09-3 4.09-5.73 4.09-11.46-2.73-5.73-2.73-6.27-5.46-8.73 2.73-1.5 2.73-6 2.73-10.78 5.46-.54 10.92-2.18 16.38-3.95l9.55.957c2.73 1.773 4.09 2.32 6.82 2.046 4.093 1.91 8.19 3.96 12.283 6.55 4.093 6.96 2.73 13.11 1.363 18.16-5.46 6.96-9.555 9.416-13.65 12.42-6.825-1.5-21.84-1.64-23.205 8.053 4.096 1.64 9.556 1.64 13.65 3.004 2.73 1.366 8.19 6.826 10.92 6.826 2.73 0 10.92-6.826 15.016-10.375 6.827-3.41 12.287-6.003 16.38-9.01 2.73-1.5 12.287-6.412 12.287-6.412 6.828-2.73 16.38-6.55 21.84-9.96 9.558-4.37 16.38-4.504 32.76-5.46v12.42l43.68-.82L537.15 68l-42.31-.272v2.32c-9.56-2.456-13.65-1.91-20.48 0-5.46 1.5-13.65.547-20.47-.82-4.09-.68-8.19-2.183-10.92-3.685-12.28-4.778-24.57-8.464-36.85-13.787-6.82-4.64-12.28-9.148-17.74-13.65-2.73-2.596-5.46-6.008-8.19-9.284-4.096-3.96-6.826-7.51-8.19-10.24-1.366-3.277-2.73-6.007-4.096-9.5z" class="color-4"/>
                  <path d="M325.6 37.948c1.364 2.594 5.46 5.187 15.014 8.054 4.095 1.092 10.92 3.55 21.84 6.825 2.73 0 23.205 3.413 23.205 3.413-12.29-4.915-36.86-13.65-38.22-13.924-2.73-.545-4.1-.272-6.83 0-1.37 0-9.56-2.866-15.02-4.367zm35.49 24.024c-8.19.546-15.016 2.32-21.84 4.368-15.016 5.46-17.746 7.644-25.936 10.92 2.73 1.23 6.825 1.91 9.555 1.365 4.09-.82 6.82-4.64 34.12-9.69 2.73-.138 13.65 1.09 21.84 1.364l4.09-.55c-8.19-4.23-15.02-6.42-21.84-7.78zm23.204 17.745c-8.19.547-21.84 2.73-23.205 4.505-4.1 5.05-2.73 10.784-1.37 17.063 2.73-1.23 2.73-6.28 2.73-10.784 6.82-.68 10.92-1.77 16.38-3.54 4.09.55 5.46.28 9.55 1.09 2.73 1.5 5.46 2.46 6.82 1.91 1.36.55 9.55 4.78 12.28 6.83 1.36 1.23 2.73 7.65 2.73 14.88 5.46-8.19 2.73-12.69 2.73-17.61 0-4.5-12.29-12.01-19.11-13.51-2.73-.54-6.83-.82-9.56-.82zm152.88 6.28l-23.205.682c-4.1-.55-10.92-.96-19.11.54v.27c-6.83 1.36-15.02 4.09-23.21 9.55-2.73 2.18-4.1-8.33-9.56-5.05-5.46 4.23-12.29 10.51-19.11 14.74-17.75 10.24-15.02 13.92-17.75 16.24-4.1 3.96-24.57 14.74-34.13 18.83 0 0 4.09 2.73 5.46 2.73 4.09 1.36 12.28-6.83 15.01-10.1 8.19-3.69 12.28-6.28 16.38-9.29 2.73-1.5 12.28-6.01 12.28-6.01 5.46-2.18 16.38-4.91 23.2-9.96 6.82-4.23 15.01-4.23 31.39-5.73V116l43.68-1.09z" class="color-5"/>
                  <path d="M528.5 65.25L803 65v64.25L529.25 128z" class="color-2"/>
                  <path d="M529 86.5l274 .5v42.25L529.25 128z" class="color-3"/>
               </g>
               <path id="fork" d="M264.404 197.884l38.043-18.917-26.95 31.068 33.75-24.057-22.4 36.49 43.822-41.613c4.66-4.26 6.33-10.085 4.83-15.482l58.96-53.823c2.97-2.718 3.18-7.304.46-10.28-2.718-2.978-7.303-3.187-10.28-.47l-58.96 53.824c-5.238-1.99-11.19-.858-15.858 3.403z" class="color-3"/>
            </g>
         </g>
      </svg>
   </svg>
            </div>
            </div>
               <div class="col-lg-12">
                 <div style="width: 330px;  margin-left:800px; margin-top:-145px; padding-bottom :20px" >

         <img src="https://github.com/ehennes/gus-subs-and-pizza/blob/main/toasted-sandwich-with-pickles.jpg?raw=true" alt="sandwich with pickles" style="padding-bottom :20px; height: 230px;" >
                    
        <%--<img src="https://github.com/ehennes/gus-subs-and-pizza/blob/main/spinach-pomegranate-and-chicken-salad.jpg?raw=true" alt="spinach chicken salad" style="padding-bottom :20px">--%>
                     
        <img src="https://github.com/ehennes/gus-subs-and-pizza/blob/main/gus-philly.jpg?raw=true" alt="philly cheese steak"style="padding-bottom :20px; height: 230px;">
                     
        <%--<img src="https://github.com/ehennes/gus-subs-and-pizza/blob/main/chicken-salad.jpg?raw=true" alt="chicken salad">--%>
        </div>
           </div>
        
</div>

  


</asp:Content>
