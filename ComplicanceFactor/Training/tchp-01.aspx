<%@ Page Title="ComplicanceFactor&#0153 - Training Home" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="tchp-01.aspx.cs" Inherits="ComplicanceFactor.Training.tchp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_training').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_training').addClass('selected');
                return false;
            });
        });

    </script>
    <%--<br />
<br />
<center ><b><%=LocalResources.GetLocaleResourceText("app_tchp_pagename")%> - <%=LocalResources.GetLocaleResourceText("app_coming_soon")%> </b> </center>
<br />
<br />
<br />
<br />--%>
    <div class="content_align ">
        <div class="left ">
            <div class="roundedcorner">
                <div class="roundedcorner_tab">
                    <div class="roundedcorner_heading">
                        <a href="tcmtd-01.aspx">
                            <%=LocalResources.GetLabel("app_training_pod_mtraining_title")%>
                        </a>
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
                        <a href="tcmdd-01.aspx">
                            <%=LocalResources.GetLabel("app_training_pod_mdashboard_title")%>
                        </a>
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
                        <a href="tctdl-01.aspx">
                            <%=LocalResources.GetLabel("app_training_pod_mtodo_title")%>
                        </a>
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
                        <a href="tcmtc-01.aspx">
                            <%=LocalResources.GetLabel("app_training_pod_mtrainingcatalog_title")%>
                        </a>
                    </div>
                </div>
                <div class="roundedcorner_content">
                    <div style="float: left;">
                        <div class="roundedcorner_text" style="float: left; width: 130px;">
                            <%=LocalResources.GetLabel("app_quick_search_text")%>
                        </div>
                        <div style="float: left; padding: 18px 0 0 0; width: 205px;">
                            <asp:TextBox ID="txtQuickSearch" Width="180px" runat="server"></asp:TextBox>
                        </div>
                        <div style="float: left; padding: 15px 0 0 0;">
                            <asp:Button ID="btnGo" CssClass="btngo" Width="70px" Text="<%$ LabelResourceExpression: app_go_exclamation_button_text%>"
                                runat="server" />
                        </div>
                    </div>
                    <div class="clear ">
                    </div>
                    <div class="roundedcorner_text">
                        <a href="#">
                            <%=LocalResources.GetLabel("app_adv_search_link_text")%>
                        </a>
                    </div>
                    <div class="roundedcorner_text">
                        <a href="tcmtc-01.aspx">
                            <%=LocalResources.GetLabel("app_browse_link_text")%>
                        </a>
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
