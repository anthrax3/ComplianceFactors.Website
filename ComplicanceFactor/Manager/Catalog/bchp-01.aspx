<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="bchp-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Catalog.bchp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_manager').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_manager').addClass('selected');
                return false;
            });
        });

    </script>
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtId.ClientID %>').value = '';
            document.getElementById('<%=txtTitle.ClientID %>').value = '';
            document.getElementById('<%=txtKeyword.ClientID %>').value = '';
            document.getElementById('<%=ddlType.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlDelivery.ClientID %>').selectedIndex = '0';
            document.getElementById('<%=ddlLanguage.ClientID %>').selectedIndex = '0';
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
    <script type="text/javascript">
        function expandDetailsInGrid(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("A_View", "TR_Summmary") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;

            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../../Images/addminus-sm.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../../Images/addplus-sm.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }
    </script>
    <br />
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
        <div class="content_area_long">
            <div class="div_header_long">
               <%=LocalResources.GetLabel("app_catalog_categories_text")%> 
            </div>
            <br />
            <div>
                <asp:ListView ID="lstCatalogCategories" runat="server" GroupItemCount="3" DataKeyNames="s_category_system_id_pk"
                    OnItemDataBound="lstCatalogCategories_ItemDataBound" OnItemCommand="lstCatalogCategories_ItemCommand">
                    <LayoutTemplate>
                        <table class="search_view">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td class="search_view_td">
                                        <asp:ImageButton OnClientClick="expandDetailsInGrid(this);return false;" runat="server"
                                            ID="A_View" ImageUrl="~/Images/addplus-sm.gif" AlternateText="plus" />
                                       <b> <asp:LinkButton CssClass="font_bold" ID="lnkCategoryName"  CommandArgument='<%#Eval("s_category_system_id_pk")%>' CommandName="MainCategory" runat="server" Text='<%#Eval("s_category_name") %>'></asp:LinkButton></b>
                                       
                                    </td>
                                </tr>
                                <tr id="TR_Summmary" runat="server" style="display: none;">
                                    <td class="search_view_td">
                                        <asp:GridView ID="gvSubCategories" GridLines="None" HorizontalAlign="Left" CellPadding="0"
                                            CellSpacing="0" runat="server" DataKeyNames="s_parent_category_id,s_category_system_id_pk" AutoGenerateColumns="false" ShowHeader="false"
                                            OnRowCommand="gvSubCategories_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td valign="top">
                                                                -
                                                                <asp:LinkButton ID="lnkSubCategoryName" CssClass="anchor" CommandName="SubCategory" runat="server" Text='<%#Eval("child_category_name") %>'
                                                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <br />
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_catalog_advanced_search_text")%> 
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_id_text")%> 
                        </td>
                        <td>
                            <asp:TextBox ID="txtId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_title_text")%> 
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                         <%=LocalResources.GetLabel("app_keyword_text")%> 
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyword" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                          <%=LocalResources.GetLabel("app_type_text")%> 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlType" DataValueField="c_type_id" DataTextField="c_type_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_delivery_text")%> 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDelivery"  DataValueField="s_delivery_type_system_id_pk" DataTextField="s_delivery_type_name"
                                CssClass="ddl_user_advanced_search" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                          <%=LocalResources.GetLabel("app_language_text")%> 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLanguage" CssClass="ddl_user_advanced_search" runat="server" DataTextField="s_locale_description" DataValueField="s_locale_id_pk">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnsave_new_user_td">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="btnreset_td">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text %>"  OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td colspan="2" class="btncancel_td">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_go_search_button_text %>"  
                                runat="server" onclick="btnGosearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
