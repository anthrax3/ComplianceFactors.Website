<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ccamiris-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.ccamiris_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Src="~/Compliance/MIRIS/Controls/uccb-01.ascx" TagPrefix="uc1" TagName="uccb1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
            $(".addEmployee").click(function () {

                $(".addEmployee").fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 733,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': 'Popup/sasumsm-01.aspx',
                    'onComplete': function () {
                        $.fancybox.showActivity();
                        $('#fancybox-frame').load(function () {
                            $.fancybox.hideActivity();
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
    <script language="javascript" type="text/javascript">
        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {
            //            alert(document.getElementById('<%=hdWitness.ClientID %>').value)
            document.getElementById('<%=hdWitness.ClientID %>').value = '';
            document.getElementById('<%=hdPolice.ClientID %>').value = '';
            document.getElementById('<%=hdPhoto.ClientID %>').value = '';
            document.getElementById('<%=hdSceneSketch.ClientID %>').value = '';
            document.getElementById('<%=hdExtenautingcond.ClientID %>').value = '';
            document.getElementById('<%=hdEmployeeInterview.ClientID %>').value = '';
            document.getElementById('<%=txtName.ClientID %>').value = '';
            document.getElementById('<%=txtContactInfo.ClientID %>').value = '';
            var oFileUpload = document.getElementsByName('<%=FileUpload1.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);
            HideFileValidationSummary();

        }
    </script>
    <script language="javascript" type="text/javascript">

        //Function to Show ModalPopUp
        function Showpopup(clicked_id) {
            if (clicked_id == "ContentPlaceHolder1_btnAddWitness") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Witness:";
                document.getElementById('divInfo').style.display = "inline";

            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddPoliceReport") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Police Report:";
                document.getElementById('divInfo').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddPhoto") {


                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";


                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Photo:";
                document.getElementById('divInfo').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddSceneSketch") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";


                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Scene Sketch:";
                document.getElementById('divInfo').style.display = "none";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddExtenuatingCondition") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";


                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Extenuating Condition:";
                document.getElementById('divInfo').style.display = "inline";
            }

            else if (clicked_id == "ContentPlaceHolder1_btnAddEmployeeInterview") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "inline";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Interview:";
                document.getElementById('divInfo').style.display = "inline";
            }


        }
    </script>
    <script type="text/javascript">
        function Showeditpopup(clicked_id) {

            if (clicked_id == "witness") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Witness:";
                document.getElementById('divInfo').style.display = "inline";

            }
            else if (clicked_id == "policereport") {


                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Police Report:";
                document.getElementById('divInfo').style.display = "none";
            }
            else if (clicked_id == "photo") {


                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";


                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Photo:";
                document.getElementById('divInfo').style.display = "none";
            }
            else if (clicked_id == "scenesketch") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";


                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Scene Sketch:";
                document.getElementById('divInfo').style.display = "none";
            }
            else if (clicked_id == "extenuatingcondition") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";


                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Extenuating Condition:";
                document.getElementById('divInfo').style.display = "inline";
            }
            else if (clicked_id == "employeeinterview") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "inline";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Interview:";
                document.getElementById('divInfo').style.display = "inline";
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function confirmremove() {
            if (confirm('Are you sure you want to remove this file.?') == true)
                return true;
            else
                return false;

        }
        function ConfirmComplete() {
            if (confirm('Are you sure.?') == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateFileUpload(source, args) {

            // var fileupload = document.getElementById('<%=FileUpload1.UniqueID%>')[0];

            var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                window.scrollTo = function () { }
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function checkIncidentDate(source, args) {

            var incidentDate = document.getElementById('<%=txtIncidentDate.ClientID %>');
            if (Date.parse(incidentDate.value) > new Date()) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function HideFileValidationSummary() {
            $("#<%=vsFileUpload.ClientID%>").hide();
        }
    </script>
    <script type="text/javascript">

        function checkdateofbirth() {
            var year = $('#' + '<% =ddlYear.ClientID %>').val();
            var month = $('#' + '<% =ddlMonth.ClientID %>').val();
            if ((year != 0) && (month != 0)) {
                var lastday = 32 - new Date(year, month - 1, 32).getDate();
                var selected_day = $('#' + '<% =dob_day.ClientID %>').val();
                // Change selected day if it is greater than the number of days in current month
                if (selected_day > lastday) {
                    $('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + selected_day + ']').attr('selected', false);
                    $('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + lastday + ']').attr('selected', true);
                }
                // Remove possibly offending days
                for (var i = lastday + 1; i < 32; i++) {
                    //$('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').remove();
                    $('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').css('display', 'none');
                }
                // Add possibly missing days
                for (var i = 29; i < lastday + 1; i++) {
                    //if (!$('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').length) {
                    //$('#' + '<% =dob_day.ClientID %>').append($("<option></option>").attr("value", i).text(i));
                    $('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').css('display', 'block');
                    //}
                }
            }
        }
    </script>
    <script type="text/javascript">

        function checkhiredate() {
            var year = $('#' + '<% =ddlHireYear.ClientID %>').val();
            var month = $('#' + '<% =ddlHireMonth.ClientID %>').val();
            if ((year != 0) && (month != 0)) {
                var lastday = 32 - new Date(year, month - 1, 32).getDate();
                var selected_day = $('#' + '<% =doh_hire_day.ClientID %>').val();

                // Change selected day if it is greater than the number of days in current month
                if (selected_day > lastday) {
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + selected_day + ']').attr('selected', false);
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + lastday + ']').attr('selected', true);
                }

                // Remove possibly offending days
                for (var i = lastday + 1; i < 32; i++) {
                    //$('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').remove();
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + i + ']').css('display', 'none');
                }

                // Add possibly missing days
                for (var i = 29; i < lastday + 1; i++) {
                    //if (!$('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').length) {
                    //$('#' + '<% =dob_day.ClientID %>').append($("<option></option>").attr("value", i).text(i));
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + i + ']').css('display', 'block');
                    //}
                }
            }
        }
        function checkdateintitle() {
            var year = $('#' + '<% =ddlDateInTitleYear.ClientID %>').val();
            var month = $('#' + '<% =ddlDateInTitleMonth.ClientID %>').val();
            if ((year != 0) && (month != 0)) {
                var lastday = 32 - new Date(year, month - 1, 32).getDate();
                var selected_day = $('#' + '<% =doh_date_in_time_day.ClientID %>').val();

                // Change selected day if it is greater than the number of days in current month
                if (selected_day > lastday) {
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + selected_day + ']').attr('selected', false);
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + lastday + ']').attr('selected', true);
                }

                // Remove possibly offending days
                for (var i = lastday + 1; i < 32; i++) {
                    //$('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').remove();
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + i + ']').css('display', 'none');
                }

                // Add possibly missing days
                for (var i = 29; i < lastday + 1; i++) {
                    //if (!$('#' + '<% =dob_day.ClientID %>' + ' > option[value=' + i + ']').length) {
                    //$('#' + '<% =dob_day.ClientID %>').append($("<option></option>").attr("value", i).text(i));
                    $('#' + '<% =doh_hire_day.ClientID %>' + ' > option[value=' + i + ']').css('display', 'block');
                    //}
                }
            }
        }
    </script>
    <script type="text/javascript">

        function isValidDate(d) {
            if (Object.prototype.toString.call(d) !== "[object Date]")
                return false;
            return !isNaN(d.getTime());
        }

        function validateDOB(source, args) {
            var dob_day = document.getElementById('<% =dob_day.ClientID %>').value;
            var dob_month = document.getElementById('<% =ddlMonth.ClientID %>').value;
            var dob_year = document.getElementById('<% =ddlYear.ClientID %>').value;

            var dob = new Date(dob_year, dob_month, dob_day);
            var d = new Date(dob_month + "/" + dob_day + "/" + dob_year);

            if (d.toString() == 'Invalid Date') {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">

        function isValidDate(d) {
            if (Object.prototype.toString.call(d) !== "[object Date]")
                return false;
            return !isNaN(d.getTime());
        }

        function validateHireDate(source, args) {
            var doh_day = document.getElementById('<% =doh_hire_day.ClientID %>').value;
            var doh_month = document.getElementById('<% =ddlHireMonth.ClientID %>').value;
            var doh_year = document.getElementById('<% =ddlHireYear.ClientID %>').value;

            var doh = new Date(doh_year, doh_month, doh_day);
            var d = new Date(doh_month + "/" + doh_day + "/" + doh_year);

            if (d.toString() == 'Invalid Date') {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_cccmiris" runat="server"
        ValidationGroup="ccamiris" />
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
        <%=LocalResources.GetText("app_date_not_inserted_error_wrong")%>
    </div>
    <asp:CustomValidator ID="cvDOB" runat="server" ErrorMessage="<%$ TextResourceExpression: app_date_of_birth_error_empty %>"
        ForeColor="Red" ValidationGroup="ccamiris" ClientValidationFunction="validateDOB">&nbsp;</asp:CustomValidator>
    <asp:CustomValidator ID="cvHireDate" runat="server" ErrorMessage="<%$ TextResourceExpression: app_emp_hire_date_error_empty %>"
        ForeColor="Red" ValidationGroup="ccamiris" ClientValidationFunction="validateHireDate">&nbsp;</asp:CustomValidator>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="controls_long">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnSavenewcase_header" ValidationGroup="ccamiris" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_new_case_button_text %>" runat="server"
                            OnClick="btnSavenewcase_header_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderCompleteCase" OnClientClick="return ConfirmComplete();"
                            runat="server" Text="<%$ LabelResourceExpression: app_complete_case_button_text %>"
                            ValidationGroup="ccamiris" CssClass="cursor_hand" OnClick="btnHeaderCompleteCase_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnReset_Header" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Header_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel_header" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_header_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_case_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_case_number_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:UpdatePanel ID="uptCaseNumber" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblCaseNumber" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCaseTitle" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtCaseTitle" ErrorMessage="<%$ TextResourceExpression: app_case_title_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_case_title_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCaseTitle" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_case_date_text")%>
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCaseDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_case_category_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseCategory" DataValueField="c_category_id" DataTextField="c_category_name"
                            AutoPostBack="true" CssClass="ddl_user_advanced_search" runat="server" OnSelectedIndexChanged="ddlCaseCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                   
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_case_status_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseStatus" CssClass="ddl_user_advanced_search" DataValueField="c_status_id"
                            DataTextField="c_status_name" runat="server">
                        </asp:DropDownList>
                    </td>
                     <td style="display: none;">
                        *
                        <%=LocalResources.GetLabel("app_case_types_text")%>
                    </td>
                    <td style="display: none;">
                        <asp:DropDownList ID="ddlCaseTypes" DataValueField="c_type_id" DataTextField="c_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr><uc1:uccb1 runat="server" id="uccb1" /></tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_case_description_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
               <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtEmployeeName" ErrorMessage="<%$ TextResourceExpression: app_emp_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        First Name:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="textbox_width"></asp:TextBox>
                        <asp:Button ID="btnAddEmployee" runat="server" ValidationGroup="samcp_employee" CssClass="addEmployee cursor_hand"
                            Text="Select Employee" />
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtLastName" ErrorMessage="<%$ TextResourceExpression: app_emp_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        Last Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox_width"></asp:TextBox>
                     
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_date_of_birth_text")%>:
                    </td>
                    <td class="width_200 align_left">
                        <asp:DropDownList ID="ddlMonth" onchange="checkdateofbirth();" runat="server">
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <select name="dob_day" id="dob_day" runat="server" class="input_pulldown">
                            <option value="-1" selected="selected">Day:</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                            <option value="24">24</option>
                            <option value="25">25</option>
                            <option value="26">26</option>
                            <option value="27">27</option>
                            <option value="28">28</option>
                            <option value="29">29</option>
                            <option value="30">30</option>
                            <option value="31">31</option>
                        </select>
                        <asp:DropDownList ID="ddlYear" onchange="checkdateofbirth();" runat="server">
                        </asp:DropDownList>
                    </td>
                   
                </tr>
                <tr>
                     <td>
                        *
                        <%=LocalResources.GetLabel("app_employee_hire_date_text")%>:
                    </td>
                    <td class="width_200 align_left">
                        <asp:DropDownList ID="ddlHireMonth" onchange="checkhiredate();" runat="server">
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <select name="dob_day" id="doh_hire_day" runat="server" class="input_pulldown">
                            <option value="-1" selected="selected">Day:</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                            <option value="24">24</option>
                            <option value="25">25</option>
                            <option value="26">26</option>
                            <option value="27">27</option>
                            <option value="28">28</option>
                            <option value="29">29</option>
                            <option value="30">30</option>
                            <option value="31">31</option>
                        </select>
                        <asp:DropDownList ID="ddlHireYear" onchange="checkhiredate();" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtEmployeeId" ErrorMessage="<%$ TextResourceExpression: app_emp_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_employee_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLastDigitofSSN" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtLastFourDigitOfSSN" ErrorMessage="<%$ TextResourceExpression: app_last_four_digit_ssn_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_last_digit_of_ssn#_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtLastFourDigitOfSSN" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                      
                        *
                        <%=LocalResources.GetLabel("app_date_in_title")%>:
                    </td>
                    <td class="align_left">
                       <asp:DropDownList ID="ddlDateInTitleMonth" onchange="checkdateintitle();" runat="server">
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <select name="dob_day" id="doh_date_in_time_day" runat="server" class="input_pulldown">
                            <option value="-1" selected="selected">Day:</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                            <option value="24">24</option>
                            <option value="25">25</option>
                            <option value="26">26</option>
                            <option value="27">27</option>
                            <option value="28">28</option>
                            <option value="29">29</option>
                            <option value="30">30</option>
                            <option value="31">31</option>
                        </select>
                        <asp:DropDownList ID="ddlDateInTitleYear" onchange="checkdateintitle();" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvIncidentLocation" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtIncidentLocation" ErrorMessage="<%$ TextResourceExpression: app_incident_location_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_incident_location_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtIncidentLocation" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserIncidentDate" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtIncidentDate" ErrorMessage="<%$ TextResourceExpression: app_incident_date_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revIncidentDate" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtIncidentDate" ErrorMessage="<%$ TextResourceExpression: app_incident_date_format_error_empty %>"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                        <asp:CustomValidator ValidationGroup="ccamiris" ID="cvIncidentDate" runat="server" ErrorMessage="<%$ TextResourceExpression: app_incident_date_error_empty %>"
                            ControlToValidate="txtIncidentDate" EnableClientScript="true" ClientValidationFunction="checkIncidentDate">&nbsp;</asp:CustomValidator>
                        *
                        <%=LocalResources.GetLabel("app_incident_date_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CalendarExtender ID="ceIncidentTime" Format="MM/dd/yyyy" TargetControlID="txtIncidentDate"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtIncidentDate" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                     <td>
                        <asp:RequiredFieldValidator ID="rfvIncidentTime" runat="server" ControlToValidate="IncidentTime"
                            ErrorMessage="<%$ TextResourceExpression: app_incident_time_error_empty %>" ValidationGroup="ccamiris">&nbsp;</asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_incident_time_text")%>:
                    </td>
                    <td class="timer">
                        <MKB:TimeSelector ID="IncidentTime" MinuteIncrement="1" CssClass="timer" DisplaySeconds="false"
                            runat="server" Date="">
                        </MKB:TimeSelector>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployeeReportLocation" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="ddlEmployeeReportLocation" ErrorMessage="<%$ TextResourceExpression: app_emp_report_location_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_employee_report_location_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEmployeeReportLocation" DataValueField="c_type_id" DataTextField="c_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_timezone_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:UpdatePanel ID="upnlTimeZone" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlTimezone" AutoPostBack="true" DataValueField="u_time_zone_id_pk"
                                    DataTextField="u_time_zone_location" runat="server" CssClass="ddl_user_advanced_search">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                </tr>
                <tr id="trAddEstablishment" runat="server" visible="false">
                    <td>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                    </td>
                    <td>
                        <input type="button" id="btnAddEstablishment" value='Add Establishment' />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtSupervisor" ErrorMessage="<%$ TextResourceExpression: app_supervisor_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_supervisor_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtSupervisor" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_note_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_additional_Information_text")%>
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_witness(es)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddWitness" runat="server" OnClientClick="Showpopup(this.id);"
                            CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_witness_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvAddWitness" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_name,c_contact_info"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvAddWitness_RowCommand"
                OnRowEditing="gvAddWitness_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("c_name") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_contact_information_text")%>
                            :&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("c_contact_info") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewWitnessFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditWitnessFiles" OnClientClick="Showeditpopup('witness');" CommandName="Edit"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveWitnessFiles" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_police_reports(s)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddPoliceReport" OnClientClick="Showpopup(this.id);" runat="server"
                            Text="<%$ LabelResourceExpression: app_add_police_report_button_text %>" CssClass="cursor_hand" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvPoliceReport" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvPoliceReport_RowCommand"
                OnRowEditing="gvPoliceReport_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewPoliceReportFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditPoliceReportFiles" OnClientClick="Showeditpopup('policereport');"
                                CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemovePoliceReportFiles" OnClientClick="return confirmremove();"
                                CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_photo(s)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddPhoto" OnClientClick="Showpopup(this.id);" runat="server" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_add_photo_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvPhoto" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvPhoto_RowCommand"
                OnRowEditing="gvPhoto_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewPhotoFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditPhotoFiles" CommandName="Edit" OnClientClick="Showeditpopup('photo');"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemovePhotoFiles" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_scene_sketch(es)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddSceneSketch" OnClientClick="Showpopup(this.id);" runat="server"
                            Text="<%$ LabelResourceExpression: app_add_sketch_button_text %>" CssClass="cursor_hand" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvSceneSketch" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvSceneSketch_RowCommand"
                OnRowEditing="gvSceneSketch_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewSceneSketchFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditSceneSketchFiles" OnClientClick="Showeditpopup('scenesketch');"
                                CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveSceneSketchFiles" OnClientClick="return confirmremove();"
                                CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_extenuating_condition(s)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddExtenuatingCondition" OnClientClick="Showpopup(this.id);" runat="server"
                            Text="<%$ LabelResourceExpression: app_add_extenuating_condition_button_text %>"
                            CssClass="cursor_hand" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvExtenuatingcondition" GridLines="None" CssClass="grid_table_850"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_name,c_contact_info"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvExtenuatingcondition_RowCommand"
                OnRowEditing="gvExtenuatingcondition_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("c_name") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_contact_information_text")%>
                            :&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("c_contact_info") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewExtenuatingConditionFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditExtenuatingConditionFiles" OnClientClick="Showeditpopup('extenuatingcondition');"
                                CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveExtenuatingConditionFiles" OnClientClick="return confirmremove();"
                                CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_employee_interview(s)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddEmployeeInterview" OnClientClick="Showpopup(this.id);" runat="server"
                            Text="<%$ LabelResourceExpression: app_add_employee_interview_button_text %>"
                            CssClass="cursor_hand" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvEmployeeInterview" GridLines="None" CssClass="grid_table_850"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_name,c_contact_info"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvEmployeeInterview_RowCommand"
                OnRowEditing="gvEmployeeInterview_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("c_name") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_contact_information_text")%>
                            :&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("c_contact_info") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewEmployeeInterviewFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditEmployeeInterviewFiles" OnClientClick="Showeditpopup('employeeinterview');"
                                CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveEmployeeInterviewsFiles" OnClientClick="return confirmremove();"
                                CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_root_cause_analysis_infornation_text")%>
        </div>
        <br />
        <div class="div_long_textbox  font_1">
            <%=LocalResources.GetLabel("app_root_cause_analysis_details_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtRootCauseAnalysisDetails" Rows="5" cols="125" runat="server"
                CssClass="textarea_long_width" TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_corrective_action_information_text")%>
        </div>
        <br />
        <div class="div_long_textbox font_1">
            <%=LocalResources.GetLabel("app_corrective_action_details_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtCorrectiveActionDetails" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <%-- <div class="div_header_long">
            <%=LocalResources.GetLabel("app_osha_300_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        *<%=LocalResources.GetLabel("app_case_outcome_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseOutCome" DataValueField="c_outcome_id" DataTextField="c_outcome_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_days_away_from_work_text")%>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revDaysAwayFromWork" ControlToValidate="txtDaysAwayFromWork"
                            runat="server" ErrorMessage="<%$ LabelResourceExpression: app_days_away_from_work_validation_msg %>"
                            ValidationGroup="ccamiris" ValidationExpression="\d+">&nbsp;</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtDaysAwayFromWork" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_days_of_restrictions_text")%>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revdaysofrestriction" ControlToValidate="txtDaysOfRestrictions"
                            runat="server" ErrorMessage="<%$ LabelResourceExpression: app_days_restrictions_validation_msg %>"
                            ValidationGroup="ccamiris" ValidationExpression="\d+">&nbsp;</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtDaysOfRestrictions" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="rfvDateOfDeath" runat="server" ValidationGroup="ccamiris"
                            ControlToValidate="txtDateOfDeath" ErrorMessage="<%$ LabelResourceExpression: app_death_date_invalid_msg %>"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_data_of_death_text")%>
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceDateofDeath" Format="MM/dd/yyyy" TargetControlID="txtDateOfDeath"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtDateOfDeath" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_type_of_illness_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeOfIllness" DataValueField="c_illness_type_id" DataTextField="c_illness_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="div_long_textbox">
            <%=LocalResources.GetLabel("app_describe_injury_or_illness_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtOSHA300info" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_oosha_301_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_worker_gender_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlWorkerGender" CssClass="ddl_user_advanced_search" runat="server">
                            <asp:ListItem Selected="True" Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_works_start_time_text")%>
                    </td>
                    <td class="timer">
                        <asp:UpdatePanel ID="upnlWorkStartTime" runat="server">
                            <ContentTemplate>
                                <MKB:TimeSelector ID="WorkStartTime" CssClass="timer" DisplaySeconds="false" runat="server"
                                    Date="">
                                </MKB:TimeSelector>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_physician_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhysician" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_treatment_facility_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTreatMentFacility" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_emergency_room_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkEmergencyRoom" runat="server" />
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_hospitalized_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkHospitalized" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_address_1_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_address_2_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_address_3_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress3" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_city_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_state_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_zip_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZip" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_long_textbox">
            <%=LocalResources.GetLabel("app_what_was_the_employee_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtOSHA301Info1" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div class="div_long_textbox">
            <%=LocalResources.GetLabel("app_what_happened_tell_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtOSHA301Info2" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div class="div_long_textbox">
            <%=LocalResources.GetLabel("app_what_was_the_injury_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtOSHA301Info3" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="div_long_textbox">
            <%=LocalResources.GetLabel("app_what_object_or_substance_text")%>
            <br />
            <br />
            <asp:TextBox ID="txtOSHA301Info4" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />--%>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_01_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom01" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_02_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom02" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_03_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom03" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_04_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom04" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_05_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom05" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_06_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom06" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_07_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom07" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_08_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom08" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_09_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom09" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_10_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom10" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_11_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom11" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_12_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom12" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_13_text")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom13" CssClass="textbox_width" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div class="label_required_field">
            *
            <%=LocalResources.GetLabel("app_required_fields_text")%>
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="controls_long">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnSaveNewCase_footer" ValidationGroup="ccamiris" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_new_case_button_text %>" runat="server"
                            OnClick="btnSaveNewCase_footer_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterCompleteCase" OnClientClick="return ConfirmComplete();"
                            runat="server" Text="<%$ LabelResourceExpression: app_complete_case_button_text %>"
                            ValidationGroup="ccamiris" CssClass="cursor_hand" OnClick="btnFooterCompleteCase_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnReset_Footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Footer_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel_footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_footer_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:ModalPopupExtender ID="mpeWitness" runat="server" TargetControlID="btnAddWitness"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpePoliceReport" runat="server" TargetControlID="btnAddPoliceReport"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpePhoto" runat="server" TargetControlID="btnAddPhoto"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeSceneSketch" runat="server" TargetControlID="btnAddSceneSketch"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeExtenautingCondition" runat="server" TargetControlID="btnAddExtenuatingCondition"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeEmployeeInterview" runat="server" TargetControlID="btnAddEmployeeInterview"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <%--<asp:UpdatePanel ID="Upbdt" runat="server">
                <ContentTemplate>--%>
            <asp:HiddenField ID="hdWitness" runat="server" />
            <asp:HiddenField ID="hdPolice" runat="server" />
            <asp:HiddenField ID="hdPhoto" runat="server" />
            <asp:HiddenField ID="hdSceneSketch" runat="server" />
            <asp:HiddenField ID="hdExtenautingcond" runat="server" />
            <asp:HiddenField ID="hdEmployeeInterview" runat="server" />
            <asp:Button ID="btnUploadFile" runat="server" CssClass="cursor_hand" Style="display: none;" />
            <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background"
                Style="display: none; padding-left: 0px; padding-right: 0px;">
                <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                    <div>
                        <div class="uploadpopup_header">
                            <div class="left">
                                <asp:Label ID="lblHeading" runat="server"></asp:Label>
                            </div>
                            <div class="right">
                                <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                                    z-index: 1103; position: absolute; width: 30px; height: 30px;" runat="server"
                                    ImageUrl="~/Images/Zoom/fancy_close.png" />
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div>
                    <br />
                    <div class="uploadpanel font_normal">
                        <asp:ValidationSummary class="validation_summary_error_popup" ID="vsFileUpload" runat="server"
                            ValidationGroup="ccamirisfileupload" />
                        <asp:CustomValidator ValidationGroup="ccamirisfileupload" ID="cvFileUpload" runat="server"
                            EnableClientScript="true" ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty %>"
                            ClientValidationFunction="ValidateFileUpload">&nbsp;</asp:CustomValidator>
                        <div id="divInfo" style="display: none;">
                            <div class="div_controls">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <%=LocalResources.GetLabel("app_name_text")%>:
                                        </td>
                                        <td class="align_left">
                                            <asp:TextBox ID="txtName" CssClass="textbox_width" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <%=LocalResources.GetLabel("app_contact_information_text")%>:
                                        </td>
                                        <td class="align_left">
                                            <textarea id="txtContactInfo" runat="server" rows="3" cols="55"></textarea>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="div_controls">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top">
                                        <%=LocalResources.GetLabel("app_select_file_text")%>:
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="460" size="60" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="multiple_button">
                            <asp:Button ID="btnUploadWitness" ValidationGroup="ccamirisfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadWitness_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadPhoto" ValidationGroup="ccamirisfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadPhoto_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadPolice" ValidationGroup="ccamirisfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadPolice_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadSceneSketch" ValidationGroup="ccamirisfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadSceneSketch_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadExtenautingcond" ValidationGroup="ccamirisfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadExtenautingcond_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadEmployeeInterview" ValidationGroup="ccamirisfileupload"
                                Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadEmployeeInterview_Click" CssClass="cursor_hand" />
                        </div>
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </div>
                    <br />
                </div>
            </asp:Panel>
            <asp:Button ID="btnpnlCompleteCase" runat="server" Style="display: none;" />
            <div class="font_normal">
                <asp:Panel ID="pnlCompleteCase" runat="server" CssClass="modalPopup_width_620 modal_popup_background"
                    Style="display: none; padding-left: 0px; padding-right: 0px;">
                    <asp:Panel ID="pnlCompleteCasePageHeading" runat="server" CssClass="drag">
                        <div>
                            <div class="div_header_620">
                                <%=LocalResources.GetLabel("app_select_approver_for_complete_case_text")%>
                            </div>
                            <div class="right">
                                <asp:ImageButton ID="imgCloseCompleteCase" CssClass="cursor_hand" Style="top: -15px;
                                    right: -15px; z-index: 1103; position: absolute; width: 30px; height: 30px;"
                                    runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                            </div>
                        </div>
                    </asp:Panel>
                    <br />
                    <div class="div_controls">
                        <table>
                            <tr>
                                <td>
                                    <%=LocalResources.GetLabel("app_select_approver_text")%>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlComplianceApprover" DataValueField="u_user_id_pk" DataTextField="u_first_name"
                                        CssClass="ddl_user_advanced_search" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div class="div_padding_10">
                        <div class="left">
                        </div>
                        <div class="right">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="cursor_hand"
                                Text="<%$ LabelResourceExpression: app_submit_button_text %>" />
                            <asp:Button ID="btnCancelCompleteCase" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <asp:ModalPopupExtender ID="mpCompleteCase" runat="server" TargetControlID="btnpnlCompleteCase"
                PopupControlID="pnlCompleteCase" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlSplashPageHeading" OkControlID="imgCloseCompleteCase"
                CancelControlID="btnCancelCompleteCase">
            </asp:ModalPopupExtender>
        </div>
    </div>
</asp:Content>
