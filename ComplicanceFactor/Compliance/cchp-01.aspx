<%@ Page Title="ComplicanceFactor&#0153 - Compliance Home" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="cchp-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.cchp_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_compliance').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_compliance').addClass('selected');
            return false;
        });
    });

    </script>

<%--<br />
<br />
<center ><b><%=LocalResources.GetLocaleResourceText("app_cchp_pagename")%> - <%=LocalResources.GetLocaleResourceText("app_coming_soon")%> </b> </center>
<br />
<br />
<br />
<br />--%>
<div class="content_align ">
       
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                     <a href ="IRIS/ccasip-01.aspx" >  <%=LocalResources.GetLabel("app_compliance_pod_mincident_report_title")%>  </a> 
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="right ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                   <a href ="MyToDo/cctdl-01.aspx" >  <%=LocalResources.GetLabel("app_compliance_pod_mtodo_title")%>   </a>  
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear ">
        </div>
        <br />
        <br />
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                     <a href ="HARM/ccjhap-01.aspx" >  <%=LocalResources.GetLabel("app_compliance_pod_mhazard_analysis_title")%>   </a>  
                    
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
         <div class="right ">
           <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                   <a href ="MyDashboard/ccmdd-01.aspx" >  <%=LocalResources.GetLabel("app_compliance_pod_mdashboard_title")%>   </a>  
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear ">
        </div>
         <br />
        <br />
         <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                     <a href ="SiteView/ccsv-01.aspx" >   <%=LocalResources.GetLabel("app_compliance_pod_site_view_title")%>  </a>  
                     
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>

        <div class="clear ">
        </div>
    </div>
    <div class="clear ">
    </div>
    <br />
    <br />
</asp:Content>
