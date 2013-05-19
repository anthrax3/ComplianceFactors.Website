<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="sascp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.sascp_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
  <script type="text/javascript">

      $(document).ready(function () {
          var navigationSelectedValue = document.getElementById('<%=hdNav_selected.ClientID %>').value

          $(navigationSelectedValue).addClass('selected');
          // toggles the slickbox on clicking the noted link  
          $('.main_menu li a').hover(function () {

              $('.main_menu li a').removeClass('selected');
              $(this).addClass('active');

              return false;
          });
          $('.main_menu li a').mouseleave(function () {

              $(navigationSelectedValue).addClass('selected');
              return false;
          });
      });

    </script>
 
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtCurriculumId.ClientID %>').value = '';
            document.getElementById('<%=txtTitle.ClientID %>').value = '';
            document.getElementById('<%=txtVersion.ClientID %>').value = '';
            document.getElementById('<%=txtOwner.ClientID %>').value = '';
            document.getElementById('<%=txtCoordinator.ClientID %>').value = '';
            document.getElementById('<%=ddlStatus.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlCurriculumType.ClientID %>').selectedIndex = '0';

            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            if (e.which == 13) {
                document.getElementById('<%=btnGosearch.ClientID %>').click();
                return true;

            }
        });


    </script>
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
        <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
            <div class="div_header_long">
                 <%=LocalResources.GetLabel("app_curriculum_search_text")%>: 
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_curriculum_id_text")%>:  
                        </td>
                        <td>
                            <asp:TextBox ID="txtCurriculumId" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_title_text")%>: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_version_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtVersion" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_status_text")%>: 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" DataTextField="c_curriculum_status_name" DataValueField="c_curriculum_status_id_pk" CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_owner_text")%>:  
                        </td>
                        <td>
                            <asp:TextBox ID="txtOwner" runat="server" CssClass="textbox_long"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCoordinator" runat="server" CssClass="textbox_long"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_type_text")%>: 
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlCurriculumType" DataValueField="s_curriculum_type_system_id_pk" CssClass="ddl_user_advanced_search"
                                    DataTextField="s_curriculum_type_name" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            <asp:Button ID="btnAddNewCurriculum" CssClass="cursor_hand" runat="server" 
                                Text="<%$ LabelResourceExpression: app_add_new_curriculum_button_text%>" onclick="btnAddNewCurriculum_Click"  />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text%>" OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text%>"
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

