<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="samcsmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Completion_Statuses.samcsmp_01" %>
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
<script type="text/javascript">
    $(document).ready(function () {

        $(".EditUi").click(function () {
//            alert('hi');
//            alert(document.getElementById('<%= hfldAssignId.ClientID%>').value);
            //var record_id = $(this).attr("id");
            //Get the GridView Row reference
            //var tr_id = $(this).parents("#.record");
            //var element = $(this).attr("id").split(",");
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
                'href': '../UI Texts and Labels/p-seud-01.aspx?mode=edit' + '&id=' + document.getElementById('<%= hfldAssignId.ClientID%>').value,
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
<%--<script type ="text/javascript" >
    $(document).ready(function () {

        //edit locale
        $(".EditUi").click(function () {
            alert('hi');
            //Get the Id of the record to delete
            var record_id = $(this).attr("id");
            //Get the GridView Row reference
            var tr_id = $(this).parents("#.record");
            var element = $(this).attr("id").split(",");
            if (element[1] == "Label") {
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
                    'href': '../UI Texts and Labels/p-seul-01.aspx?mode=edit' + '&id=' + element[0] + "&type=" + element[1],
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
            }
            else if (element[1] == "Dropdown") {
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
                    'href': '../UI Texts and Labels/p-seud-01.aspx?mode=edit' + '&id=' + element[0] + "&type=" + element[1],
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
            }
            else if (element[1] == "Text") {
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 783,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../UI Texts and Labels/p-seut-01.aspx?mode=edit' + '&id=' + element[0] + "&type=" + element[1],
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
            }
        });
    });
      </script>--%>
<asp:Panel ID="pnlDefault" runat="server">
<div class= "content_area_long">
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td align="left">
<asp:Button ID ="btnUpdate" runat ="server" Text ="Update Information" 
        onclick="btnUpdate_Click" />
</td>
<td align="right">
<asp:Button ID ="btnClose" runat ="server" Text ="Close" />
</td>
</tr>
<tr><td>&nbsp;</td></tr>
</table>
<div class="div_header_long">
Completion Statuses
</div>
<div class="table_td_300">
<table>
<tr><td colspan="5">&nbsp;</td></tr>
<tr>
<td>
Assigned
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblAssigned" runat ="server"></asp:TextBox></td>
<td><input id ="btnAssingedManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Enrolled/Not Attempted
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblEnrolled" runat ="server"></asp:TextBox></td>
<td><input id ="btnEnrolledManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Incomplete
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblIncomplete" runat ="server"></asp:TextBox></td>
<td><input id ="btnIncompleteManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Completed
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblCompleted" runat ="server"></asp:TextBox></td>
<td><input id ="btnCompletedManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Browse
</td>
<td>&nbsp;&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblBrowse" runat ="server"></asp:TextBox></td>
<td><input id ="btnBrowseManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>Enabled:&nbsp;&nbsp; <asp:CheckBox ID ="chkBrowse" runat ="server" Checked="true"/></td>
</tr>
<tr><td colspan="5">&nbsp;</td></tr>
</table>
</div>
<div class="div_header_long">
Attendance
</div>
<div class="table_td_300">
<table>
<tr><td colspan="5">&nbsp;</td></tr>
<tr>
<td>
Attended
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblAttended" runat ="server"></asp:TextBox></td>
<td><input id ="btnAttendedManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Did Not Attend/No Show
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblDidNotAttend" runat ="server"></asp:TextBox></td>
<td><input id ="btnDidNotAttendManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Attended/Walk in
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblAttendedWaikIn" runat ="server"></asp:TextBox></td>
<td><input id ="btnAttendedWalkInManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Unknown
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblUnknown" runat ="server"></asp:TextBox></td>
<td><input id ="btnUnKnownManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>Enabled:&nbsp;&nbsp; <asp:CheckBox ID ="CheckBox1" runat ="server" Checked="true"/></td>
</tr>
<tr>
<td>
OLT Player
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblOltPlayer" runat ="server"></asp:TextBox></td>
<td><input id ="btnOLTPlayerManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>Enabled:&nbsp;&nbsp; <asp:CheckBox ID ="CheckBox2" runat ="server" Checked="true"/></td>
</tr>
<tr>
<td>
VLS System
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblVLSSystem" runat ="server"></asp:TextBox></td>
<td><input id ="btnVLSSystemManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;&nbsp;&nbsp;</td>
</tr>
<tr><td colspan="5">&nbsp;</td></tr>
</table>
</div>
<div class="div_header_long">
Passing Status
</div>
<div class="table_td_300">
<table>
<tr><td colspan="5">&nbsp;</td></tr>
<tr>
<td>
Passed
</td>
<td>&nbsp;</td>
<td>Label:&nbsp;&nbsp;<asp:TextBox ID ="txtlblPassed" runat ="server"></asp:TextBox></td>
<td><input id ="btnPassedManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Failed
</td>
<td>&nbsp;</td>
<td>Label:&nbsp;&nbsp;<asp:TextBox ID ="txtlblFailed" runat ="server"></asp:TextBox></td>
<td><input id ="btnFailedManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Exempt
</td>
<td>&nbsp;</td>
<td>Label:&nbsp;&nbsp;<asp:TextBox ID ="txtlblExempt" runat ="server"></asp:TextBox></td>
<td><input id ="btnExemptManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
Not Scored
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblNotScord" runat ="server"></asp:TextBox></td>
<td><input id ="btnNotScoredManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp</td>
</tr>
<tr>
<td>
Pending Assesment/Survey
</td>
<td>&nbsp;</td>
<td>Label:&nbsp; <asp:TextBox ID ="txtlblPendingAssesmentSurvey" runat ="server"></asp:TextBox></td>
<td><input id ="btnPendingAssesmentSurveyManageLocales" value ="Manage Locales" class ="EditUi cursor_hand" type ="button" /></td>
<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
<tr><td colspan="5">&nbsp;</td></tr>
</table>
</div>
</div>
<asp:HiddenField ID ="hfldAssignId" runat ="server" />
</asp:Panel>
</asp:Content>
