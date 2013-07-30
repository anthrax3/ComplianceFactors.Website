<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="csvvojt.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.Ojt.csvvojt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="content">
        <div class="div_header_popup_1">
           <%=LocalResources.GetLabel("app_on_job_training_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_OJT_Number_text")%>: 
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtNumber" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_title_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtTitle" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtDescription" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_location_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtLocation" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_trainer_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtTrainer" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_date_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_start_time_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtStartTime" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_end_time_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtEndTime" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_duration_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtDuration" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_type_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtType" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_safety_brief_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:CheckBox ID="chkOjtIsSafety" Enabled="false" runat="server" />
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_frequency_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtFrequency" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_harm_related_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:CheckBox ID="chkOjtIsHarm" Enabled="false" runat="server" />
                    </td>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_harm_details_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:Label ID="lblOjtHarmDetail" runat="server" Text=""></asp:Label> 
                    </td>                     
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
                <tr>
                    <td class="text_font_normal">
                        <%=LocalResources.GetLabel("app_certification_related_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                        <asp:CheckBox ID="chkIsCertRelated" Enabled="false" runat="server" />
                    </td>
                    <td class="text_font_normal"><%=LocalResources.GetLabel("app_cerification_file_text")%></td>
                    <td class="lable_td_width_1 align_left">
                        <asp:LinkButton ID="lbtnCertificationFile" runat="server" 
                            onclick="lbtnCertificationFile_Click"></asp:LinkButton></td>
                    <td class="text_font_normal">
                       <%=LocalResources.GetLabel("app_others_text")%>:
                    </td>
                    <td class="lable_td_width_1">
                       <asp:Label ID="lblOthers" runat="server" Text=""></asp:Label>  
                    </td>
                    
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_popup_1">
            <%=LocalResources.GetLabel("app_attachments_text")%>:
        </div>
        <br />
        <div class="div_padding_40 align_center">
            <asp:GridView ID="gvAttachment" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0"  ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gridview_row_width_1" align="center">
                                        <%#Eval("sv_file_name")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
         <div class="div_header_popup_1">
            <%=LocalResources.GetLabel("app_acknowledgement_text")%>:
        </div>
        <br />
        <div  class="div_padding_40 font_1">
        <asp:GridView ID="gvAcknowledgement" RowStyle-CssClass="record" GridLines="None"
            CssClass="gridview_normal_800" CellPadding="0" CellSpacing="0" ShowHeader="false"
            ShowFooter="false" runat="server" AutoGenerateColumns="False">
            <RowStyle CssClass="record"></RowStyle>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="gridview_row_width_5">
                                    <%#Eval("acknowlegmentUser")%>
                                </td>
                                <td class="gridview_row_width_1" align="center">
                                    <%#Eval("acknowledged")%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <br />
        <br />
        <div class="div_controls font_1">
            <center>
                <input type="button" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />' onclick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                    class="cursor_hand" />
            </center>
        </div>
    </div>
</asp:Content>
