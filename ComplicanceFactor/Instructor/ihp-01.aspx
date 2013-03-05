<%@ Page Title="ComplicanceFactor&#0153 - Instructor Home" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ihp-01.aspx.cs" Inherits="ComplicanceFactor.Instructor.ihp_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_instructor').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_instructor').addClass('selected');
            return false;
        });
    });

    </script>

  <div class="content_align ">
       
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                     <a href ="imcr-01.aspx" >  <%=LocalResources.GetLabel("app_instructor_pod_mclassroster_title")%>  </a> 
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
                   <a href ="imdd-01.aspx" >  <%=LocalResources.GetLabel("app_instructor_pod_mdashboard_title")%>   </a>  
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
                    <a href ="itdl-01.aspx" >   <%=LocalResources.GetLabel("app_instructor_pod_mtodo_title")%>  </a>   
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div class="roundedcorner_text">
                    </div>
                </div>
            </div>
        </div>
       
    </div>
    <div class="clear ">
    </div>
    <br />
    <br />
</asp:Content>
