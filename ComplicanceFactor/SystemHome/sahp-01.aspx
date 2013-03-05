<%@ Page Title="ComplicanceFactor&#0153 - System Home" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="sahp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.sahp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });
        });

    </script>
    <br />
    <br />
    <center>
        <b>
            <%=LocalResources.GetLabel("app_nav_system")%>
            -
            <%=LocalResources.GetGlobalLabel("app_coming_soon")%>
        </b>
    </center>
    <br />
    <br />
    <br />
    <br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:Button ID="btnSplash" runat="server" Style="display: none;" />
    <div class="font_normal">
        <asp:Panel ID="pnlSplashPage" runat="server" CssClass="modalPopup_width_900" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
            <asp:Panel ID="pnlSplashPageHeading" runat="server" CssClass="drag">
                <div>
                    <div class="div_header_900">
                        Splash Preview:
                    </div>
                </div>
            </asp:Panel>
            <br />
            <div class="div_padding_10 font_normal" id="spalsh" style="height: 495px; overflow: auto"
                runat="server">
            </div>
            <br />
            <div class="div_header_900">
                &nbsp;
            </div>
            <br />
            <div>
                <div class="div_padding_10">
                    <div class="left">
                        <asp:Button ID="btnDonotShow" ValidationGroup="JobTitle" runat="server" Text="Do Not Display Again"
                            OnClick="btnDonotShow_Click" />
                    </div>
                    <div class="right">
                        <asp:Button ID="btnCloseSplashPage" OnClick="btnCloseSplashPage_Click" CssClass="cursor_hand"
                            runat="server" Text="Close Splash Page" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <asp:ModalPopupExtender ID="mpSplashPage" runat="server" TargetControlID="btnSplash"
        PopupControlID="pnlSplashPage" BackgroundCssClass="transparent_class" DropShadow="false"
        PopupDragHandleControlID="pnlSplashPageHeading">
    </asp:ModalPopupExtender>
</asp:Content>
