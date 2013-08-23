<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="p-spcs-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.CourseSearch.p_spcs_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 150px;
        }
    </style>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtCourseName.ClientID %>').value = '';
            document.getElementById('<%=txtCourseId.ClientID %>').value = '';

            return false;
        }
    </script>
   
    <div id="content">
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_700">
               <%=LocalResources.GetLabel("app_course_advanced_search_text")%>:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_course_name_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCourseName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_course_id_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text%>"
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                        <td class="align_left" >
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text%>" OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td class="align_right"  >
                            <asp:Button ID="btnCancel" CssClass="cursor_hand"  OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();" 
                            runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                        </td>
                    </tr>
                </table>
            </div>

        </asp:Panel>
    </div>
</asp:Content>

