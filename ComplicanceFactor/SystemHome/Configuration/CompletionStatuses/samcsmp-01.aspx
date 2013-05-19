<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcsmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Completion_Statuses.samcsmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <style type="text/css">
        .table_td_500 td
        {
            font-size: 14px;
            font-weight: 700;
            padding: 3px 7px 0 10px;
            text-align: left;
            width: 500px;
        }
    </style>
    <script type="text/javascript">
        var btnName;
        var btnId;
        function test(Id) {
            var id = Id;
            btnName = id;
        }

        $(document).ready(function () {

            $(".EditUi").click(function () {
                if (btnName == "btnAssingedManageLocales") {
                    btnId = document.getElementById('<%= hfldAssignId.ClientID%>').value;
                }
                else if (btnName == "btnEnrolledManageLocales") {
                    btnId = document.getElementById('<%= hfldEnrolled.ClientID%>').value;
                }
                else if (btnName == "btnIncompleteManageLocales") {
                    btnId = document.getElementById('<%= hfldIncomplete.ClientID%>').value;
                }
                else if (btnName == "btnCompletedManageLocales") {
                    btnId = document.getElementById('<%= hfldCompleted.ClientID%>').value;
                }
                else if (btnName == "btnBrowseManageLocales") {
                    btnId = document.getElementById('<%= hfldBrowse.ClientID%>').value;
                }
                else if (btnName == "btnAttendedManageLocales") {
                    btnId = document.getElementById('<%= hfldAttended.ClientID%>').value;
                }
                else if (btnName == "btnDidNotAttendManageLocales") {
                    btnId = document.getElementById('<%= hfldDidNotAttend.ClientID%>').value;
                }
                else if (btnName == "btnAttendedWalkInManageLocales") {
                    btnId = document.getElementById('<%= hfldAttendedWaikIn.ClientID%>').value;
                }
                else if (btnName == "btnUnKnownManageLocales") {
                    btnId = document.getElementById('<%= hfldUnknown.ClientID%>').value;
                }
                else if (btnName == "btnOLTPlayerManageLocales") {
                    btnId = document.getElementById('<%= hfldOltPlayer.ClientID%>').value;
                }
                else if (btnName == "btnVLSSystemManageLocales") {
                    btnId = document.getElementById('<%= hfldVLSSystem.ClientID%>').value;
                }
                else if (btnName == "btnPassedManageLocales") {
                    btnId = document.getElementById('<%= hfldPassed.ClientID%>').value;
                }
                else if (btnName == "btnFailedManageLocales") {
                    btnId = document.getElementById('<%= hfldFailed.ClientID%>').value;
                }
                else if (btnName == "btnExemptManageLocales") {
                    btnId = document.getElementById('<%= hfldExempt.ClientID%>').value;
                }
                else if (btnName == "btnNotScoredManageLocales") {
                    btnId = document.getElementById('<%= hfldNotScord.ClientID%>').value;
                }
                else if (btnName == "btnPendingAssesmentSurveyManageLocales") {
                    btnId = document.getElementById('<%= hfldPendingAssesmentSurvey.ClientID%>').value;
                }
                else {
                    alert('Click the Manage Locales button');
                }

                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 683,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    //'href': '../UI Texts and Labels/p-seul-01.aspx?mode=edit' + '&id=' + document.getElementById('<%= hfldAssignId.ClientID%>').value,
                    'href': '../UI Texts and Labels/p-seud-01.aspx?mode=edit' + '&id=' + btnId,
                    'onComplete': function () {
                        $('#fancybox-frame').load(function () {
                            $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                            var heightPane = $(this).contents().find('#content').height();
                            $(this).contents().find('#fancybox-frame').css({
                                'height': heightPane + 'px'

                            })
                        });

                    }
                });
            });
        });

    </script>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        
    </div>
    <asp:Panel ID="pnlDefault" runat="server">
        <div class="content_area_long">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnUpdate" runat="server" Text="<%$ LabelResourceExpression: app_update_information_button_text %>"
                            OnClick="btnUpdate_Click" />
                    </td>
                    <td align="right">
<asp:Button ID="btnClose" runat="server" Text="<%$ LabelResourceExpression: app_close_button_text %>"                            OnClick="btnClose_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_completion_statuses_text")%>:
            </div>
            <div class="table_td_500">
                <table>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_assigned_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblAssigned" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnAssingedManageLocales" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_enrolled_or_not_attempted_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblEnrolled" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnEnrolledManageLocales" value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_incomplete_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblIncomplete" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnIncompleteManageLocales" value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_completed_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblCompleted" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnCompletedManageLocales" value='<asp:Literal ID="Literal4" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_browse_text")%>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblBrowse" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnBrowseManageLocales" value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkBrowse" runat="server" Checked="true" OnCheckedChanged="chkBrowse_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_attendance_text")%>:
            </div>
            <div class="table_td_500">
                <table>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_attended_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblAttended" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnAttendedManageLocales" value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_did_not_attend_no_show_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblDidNotAttend" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnDidNotAttendManageLocales" value='<asp:Literal ID="Literal7" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_attended_walk_in_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblAttendedWaikIn" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnAttendedWalkInManageLocales" value='<asp:Literal ID="Literal8" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_unknown_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblUnknown" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnUnKnownManageLocales" value='<asp:Literal ID="Literal9" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkUnknown" runat="server" Checked="true" OnCheckedChanged="chkUnknown_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_olt_player_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblOltPlayer" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnOLTPlayerManageLocales" value='<asp:Literal ID="Literal10" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkOLTPlayer" runat="server" Checked="true" OnCheckedChanged="chkOLTPlayer_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_vls_system_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblVLSSystem" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnVLSSystemManageLocales" value='<asp:Literal ID="Literal11" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkVLSSystem" runat="server" Checked="true"
                                OnCheckedChanged="chkVLSSystem_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="div_header_long">
                <%=LocalResources.GetLabel("app_passing_status_text")%>
            </div>
            <div class="table_td_500">
                <table>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_passed_text")%>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;&nbsp;<asp:TextBox ID="txtlblPassed"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnPassedManageLocales" value='<asp:Literal ID="Literal12" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_failed_text")%>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;&nbsp;<asp:TextBox ID="txtlblFailed"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnFailedManageLocales" value='<asp:Literal ID="Literal13" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_exempt_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;&nbsp;<asp:TextBox ID="txtlblExempt"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnExemptManageLocales" value='<asp:Literal ID="Literal14" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkExempt" runat="server" Checked="true" OnCheckedChanged="chkExempt_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_not_scored_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;&nbsp;<asp:TextBox ID="txtlblNotScord"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnNotScoredManageLocales" value='<asp:Literal ID="Literal15" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkNotScored" runat="server" Checked="true"
                                OnCheckedChanged="chkNotScored_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_pending_assesment_survey_text")%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_label_text")%>:&nbsp;
                            <asp:TextBox ID="txtlblPendingAssesmentSurvey" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnPendingAssesmentSurveyManageLocales" value='<asp:Literal ID="Literal16" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text%>" />'
                                class="EditUi cursor_hand" type="button" onclick="javascript:test(this.id);" />
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_enabled_text")%>:&nbsp;&nbsp;
                            <asp:CheckBox ID="chkPending" runat="server" Checked="true" OnCheckedChanged="chkPending_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="hfldAssignId" runat="server" />
        <asp:HiddenField ID="hfldEnrolled" runat="server" />
        <asp:HiddenField ID="hfldIncomplete" runat="server" />
        <asp:HiddenField ID="hfldCompleted" runat="server" />
        <asp:HiddenField ID="hfldBrowse" runat="server" />
        <asp:HiddenField ID="hfldAttended" runat="server" />
        <asp:HiddenField ID="hfldDidNotAttend" runat="server" />
        <asp:HiddenField ID="hfldAttendedWaikIn" runat="server" />
        <asp:HiddenField ID="hfldUnknown" runat="server" />
        <asp:HiddenField ID="hfldOltPlayer" runat="server" />
        <asp:HiddenField ID="hfldVLSSystem" runat="server" />
        <asp:HiddenField ID="hfldPassed" runat="server" />
        <asp:HiddenField ID="hfldFailed" runat="server" />
        <asp:HiddenField ID="hfldExempt" runat="server" />
        <asp:HiddenField ID="hfldNotScord" runat="server" />
        <asp:HiddenField ID="hfldPendingAssesmentSurvey" runat="server" />
    </asp:Panel>
</asp:Content>
