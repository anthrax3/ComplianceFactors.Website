<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="cccharm-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.cccharm_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
        });

    </script>
    <script language="javascript" type="text/javascript">
        /* On cancel of the Signin dialog, clear the fields */
        function cleartext() {

            document.getElementById('<%=hdAddForm.ClientID %>').value = '';

            document.getElementById('<%=hdPhoto.ClientID %>').value = '';
            document.getElementById('<%=hdSceneSketch.ClientID %>').value = '';
            document.getElementById('<%=hdExtenautingcond.ClientID %>').value = '';
            document.getElementById('<%=hdEmployeeInterview.ClientID %>').value = '';
            document.getElementById('<%=txtName.ClientID %>').value = '';
            document.getElementById('<%=txtContactInfo.ClientID %>').value = '';
            var oFileUpload = document.getElementsByName('<%=fupFiles.UniqueID%>')[0];
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
            if (clicked_id == "ContentPlaceHolder1_btnAddform") {
                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Form:";
            }

            else if (clicked_id == "ContentPlaceHolder1_btnAddPhoto") {
                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Photo:";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddSceneSketch") {

                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Scene Sketch:";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddExtenuatingcondition") {

                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Extenuating Condition:";
            }
            else if (clicked_id == "ContentPlaceHolder1_btnAddemployeeinterview") {

                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "inline";
                document.getElementById('divInfo').style.display = "inline";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Interview:";
            }
        }
    </script>
    <script type="text/javascript">
        function Showeditpopup(clicked_id) {

            if (clicked_id == "customcustomer") {

                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Form:";
            }

            else if (clicked_id == "photo") {
                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Photo:";
            }
            else if (clicked_id == "scenesketch") {
                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Scene Sketch:";
            }
            else if (clicked_id == "extenuatingcondition") {
                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";
                document.getElementById('divInfo').style.display = "none";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Extenuating Condition:";
            }
            else if (clicked_id == "employeeinterview") {
                document.getElementById('<%=btnUploadCustomCustomer.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "inline";
                document.getElementById('divInfo').style.display = "inline";
                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Interview:";
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
    </script>
    <script type="text/javascript" language="javascript">
        function ConfirmRemoveHazardControlMeasure() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {




            $("#<%=imgCloseHazardPopup.ClientID%>").click(function (e) {

                document.getElementById('<%=hdHazard.ClientID%>').value = "";
                document.getElementById('<%=txtHazardName.ClientID%>').value = "";



            });
            $("#<%=btnCancelHazardControlMeasure.ClientID%>").click(function (e) {

                document.getElementById('<%=hdHazard.ClientID%>').value = "";
                document.getElementById('<%=txtHazardName.ClientID%>').value = "";



            });

            $("#<%=btnCancelControlMeasure.ClientID%>").click(function (e) {
                document.getElementById('<%=hdControlMeasure.ClientID%>').value = "";


            });

            $("#<%=ImgCloseControlMeasure.ClientID%>").click(function (e) {
                document.getElementById('<%=hdControlMeasure.ClientID%>').value = "";



            });
        });

      

        

       
       
    </script>
    <script type="text/javascript">



        function ValidateFileUpload(source, args) {



            var fuData = document.getElementById('<%= fupFiles.ClientID %>');
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

        function HideFileValidationSummary() {
            $("#<%=vsFileUpload.ClientID%>").hide();
        }
    </script>
    <script language="javascript" type="text/javascript">

        function gvEmptyValidation(source, args) {
            var rowscount = document.getElementById('<%= gvNewControlMeasure.ClientID%>');

            if (!rowscount || rowscount.rows.length == 0) {


                args.IsValid = false;
            }
            else {

                var count = (rowscount.rows.length);
                if (count) {
                    args.IsValid = true;
                }
                else {

                    args.IsValid = false;
                }

            }
        }

        function gvEmpty(source, args) {

            var txtEmpty = gvTextBoxEmptyValidation();
            if (txtEmpty == true) {
                args.IsValid = true;
            }
            else {


                args.IsValid = false;
            }

        }
        function gvTextBoxEmptyValidation() {

            var isChecked;
            var counter = 0;
            var txtEmptyCount = 0;
            var f = document.getElementById('<%= gvNewControlMeasure.ClientID%>');
            if (!f) {

                isChecked = false;
            }
            else {
                var count = (f.rows.length);
                if (count) {
                    for (var i = 0; i < f.getElementsByTagName("input").length; i++) {
                        if (f.getElementsByTagName("input").item(i).type == "text") {

                            if (f.getElementsByTagName("input").item(i).value == 0) {

                                counter++;

                            }
                        }
                    }
                    if (counter > 0) {


                        isChecked = false;

                    }
                    else {

                        isChecked = true;

                    }
                }

            }

            return isChecked;

        }

        function gvEmptyEditControlMeasure(source, args) {
            var rowscount = document.getElementById('<%= gvAddEditControlMeasure.ClientID%>');

            if (!rowscount) {

                args.IsValid = false;
            }
            else {

                var count = (rowscount.rows.length);
                if (count) {
                    args.IsValid = true;
                }
                else {

                    args.IsValid = false;
                }

            }
        }

        function gvAddEditEmpty(source, args) {

            var txtEmpty = gvAddEditTextBoxEmptyValidation();
            if (txtEmpty == true) {
                args.IsValid = true;
            }
            else {


                args.IsValid = false;
            }

        }
        function gvAddEditTextBoxEmptyValidation() {

            var isChecked;
            var counter = 0;
            var txtEmptyCount = 0;
            var f = document.getElementById('<%= gvAddEditControlMeasure.ClientID%>');
            if (!f) {

                isChecked = false;
            }
            else {
                var count = (f.rows.length);
                if (count) {
                    for (var i = 0; i < f.getElementsByTagName("input").length; i++) {
                        if (f.getElementsByTagName("input").item(i).type == "text") {

                            if (f.getElementsByTagName("input").item(i).value == 0) {

                                counter++;

                            }
                        }
                    }
                    if (counter > 0) {


                        isChecked = false;

                    }
                    else {

                        isChecked = true;

                    }
                }

            }

            return isChecked;

        }
       
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_ccasharm" runat="server"
        ValidationGroup="cccharm" />
   <%-- <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
        <%=LocalResources.GetText("app_insert_succ_msg")%>
    </div>--%>
    <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
        <%=LocalResources.GetText("app_date_not_inserted_error_wrong")%>
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <script type="text/javascript">
        function pageLoad() {


            var rowscount = document.getElementById('<%= dlHazard.ClientID%>');
            if (!rowscount) {

                document.getElementById('<%=divAddJobTitle.ClientID%>').style.display = 'none';
            }
            else {
                var count = (rowscount.rows.length);
                if (count) {
                    document.getElementById('<%=divAddJobTitle.ClientID%>').style.display = 'inline';
                }
                else {
                    document.getElementById('<%=divAddJobTitle.ClientID%>').style.display = 'none';
                }
            }

            if (count >= 1) {
                document.getElementById('divjobtitle').style.display = 'none';
                ValidatorEnable(document.getElementById('<%=rfvHazardJobTitle.ClientID%>'), false);
            }
            $("#<%=imgCloseHazardPopup.ClientID%>").click(function (e) {

                document.getElementById('<%=hdHazard.ClientID%>').value = "";
                document.getElementById('<%=txtHazardName.ClientID%>').value = "";

                HideValidationSummary();
                HideDialog();
                e.preventDefault();
            });

            $(document).ready(function () {

                $(".h_control_measure").click(function () {

                    //Get the Id of the record to delete
                    var record_id = $(this).attr("id");

                    //Get the GridView Row reference
                    var tr_id = $(this).parents("#.record");

                    // Ask user's confirmation before delete records
                    if (confirm("Do you want to delete this record?")) {

                        $.ajax({
                            type: "POST",

                            //cchcharm-01.aspx is the page name and DeleteControlmeasure is the server side method to delete records in cchcharm-01.aspx.cs
                            url: "cccharm-01.aspx/DeleteControlmeasure",

                            //Pass the selected record id
                            data: "{'args': '" + record_id + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function () {

                                // Do some animation effect
                                tr_id.fadeOut(500, function () {

                                    //Remove GridView row
                                    tr_id.remove();

                                });
                            }
                        });

                    }
                    return false;
                });
            });
        }
    </script>
    <div class="content_area_long">
        <div class="div_controls">
            <table class="div_table">
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnSave_header" ValidationGroup="cccharm" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" runat="server" OnClick="btnSave_header_Click" />
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnReset_header" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_header_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel_header" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_header_Click1" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_harm_information_text")%>
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_harm_number_text")%>
                    </td>
                    <td style="text-align: left;">
                        <asp:UpdatePanel ID="upHarmNumber" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblHarmNumber" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvtitle" runat="server" ValidationGroup="cccharm"
                            ControlToValidate="txtCaseTitle" ErrorMessage="<%$ TextResourceExpression: app_case_title_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="retitle" runat="server" ErrorMessage="<%$ TextResourceExpression: app_size_limit_error_wrong%>"
                            ControlToValidate="txtCaseTitle" ValidationGroup="cccharm" ValidationExpression=".{0,20}">&nbsp;</asp:RegularExpressionValidator>
                        *
                        <%=LocalResources.GetLabel("app_analysis_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCaseTitle" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_analysis_date_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCaseDate" Width="150px" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_category_text")%>:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="upHarmCategory" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCaseCategory" AutoPostBack="true" CssClass="ddl_user_advanced_search"
                                    runat="server" DataValueField="h_category_id" DataTextField="h_category_name"
                                    OnSelectedIndexChanged="ddlCaseCategory_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_status_text")%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCasestatus" DataValueField="h_status_id" DataTextField="h_status_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--<asp:RequiredFieldValidator ID="rfvEmployeeReportLocation" runat="server" ValidationGroup="cccharm"
                            ControlToValidate="txtEmployeeReportLocation" ErrorMessage="<%$ LabelResourceExpression: app_employee_report_validation_msg%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_employee_report_location_text")%>--%>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtEmployeeReportLocation" runat="server" CssClass="textbox_width"></asp:TextBox>--%>
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
            <%=LocalResources.GetLabel("app_enter_hazards_and_control_measures_text")%>
        </div>
        <br />
        <div class="hazard_control_measure">
            <div id="divAddJobTitle" runat="server" class="div_left_40">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="width: 790px;">
                            <b>
                                <%=LocalResources.GetLabel("app_job_title_text")%>:</b>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="width: 55px;">
                            <asp:Button ID="btnEditJobTitle" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnRemoveJobTitle" OnClientClick="return ConfirmRemoveHazardControlMeasure();"
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" OnClick="btnRemoveJobTitle_Click" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
            <asp:DataList ID="dlHazard" runat="server" CellPadding="0" CellSpacing="0" DataKeyField="h_hazard_id_pk"
                OnItemDataBound="dlHazard_ItemDataBound" OnItemCommand="dlHazard_ItemCommand">
                <ItemTemplate>
                    <fieldset>
                        <legend>
                            <%=LocalResources.GetLabel("app_hazard_text")%>
                            #<asp:Label ID="lblHazardNumber" runat="server" Text="0"></asp:Label></legend>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="td_hazard_control_measure">
                                    <asp:Label ID="lblHazard" runat="server" Text='<%# Bind("h_hazard_description") %>'></asp:Label>
                                </td>
                                <td class="td_edit_hazard_control_measure">
                                    <asp:Button ID="btnEditHazard" CommandArgument='<%# DataBinder.Eval(Container, "ItemIndex") %>'
                                        CommandName="EditHazard" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />
                                </td>
                                <td>
                                    <asp:Button ID="btnRemoveHazard" CommandArgument='<%# DataBinder.Eval(Container, "ItemIndex") %>'
                                        OnClientClick="return ConfirmRemoveHazardControlMeasure();" CommandName="RemoveHazard"
                                        runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                    <b>
                                        <%=LocalResources.GetLabel("app_control_measures_text")%>:</b>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gvControlMeasure" CellPadding="0" CellSpacing="0" class="grid_table_normal"
                            ShowFooter="true" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvControlMeasure_RowDataBound"
                            OnRowCommand="gvControlMeasure_RowCommand" GridLines="none" DataKeyNames="h_hazard_id_fk,h_hazard_control_meausre_id_pk">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="3" align="left">
                                                    <b>
                                                        <asp:Label ID="lblControlCategory" runat="server" Text='<%#Eval("h_control_measure_text") %>'></asp:Label></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_hazard_control_measure">
                                                    <asp:Label ID="lblControlMeasure" runat="server" Text='<%#Eval("h_control_measure_summary") %>'></asp:Label>
                                                </td>
                                                <td class="td_edit_hazard_control_measure">
                                                    <asp:Button ID="btnEditControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>"
                                                        CommandName="EditControlMeasure" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnRemoveControlMeasure" OnClientClick="return ConfirmRemoveHazardControlMeasure();"
                                                        runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" CommandName="RemoveControlMeasure"
                                                        CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAddControlMeasure" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                        CommandName="AddControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_add_control_measure_button_text%>" />
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </fieldset>
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:HiddenField ID="hdHazard" runat="server" />
            <asp:HiddenField ID="hdControlMeasure" runat="server" />
            <asp:Button ID="btnAddHazard" CssClass='cursor_hand' runat="server" Text="<%$ LabelResourceExpression: app_add_hazard_button_text %>"
                OnClick="btnAddHazard_Click" />
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_hazard_and_control_measure_summary_text")%>
        </div>
        <br />
        <div class="hazard_control_measure">
            <div id="emptyrow" runat="server">
                <%=LocalResources.GetLabel("app_no_hazard_and_control_measure_text")%>
            </div>
            <asp:DataList ID="dlHazardSummary" runat="server" CellPadding="0" CellSpacing="0"
                ShowFooter="true" DataKeyField="h_hazard_id_pk" OnItemDataBound="dlHazardSummary_ItemDataBound">
                <ItemTemplate>
                    <fieldset>
                        <legend>
                            <%=LocalResources.GetLabel("app_hazard_text")%>
                            #<asp:Label ID="lblHazardNumber" runat="server" Text="0"></asp:Label></legend>
                        <br />
                        <table>
                            <tr>
                                <td class="td_hazard_control_measure">
                                    <asp:Label ID="lblHazard" runat="server" Text='<%# Bind("h_hazard_description") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="program_permit">
                                    <%=LocalResources.GetLabel("app_program_compliance_text")%>:
                                </td>
                                <td align="left">
                                    <asp:HiddenField runat="server" ID="hdnPrgCompliance" Value='<%# Eval("h_program_compliance_value") %>' />
                                    <asp:DropDownList ID="ddlPrgCompliance" DataValueField="h_program_compliance_id"
                                        CssClass="dropdownlist_width" DataTextField="h_program_compliance_name" OnSelectedIndexChanged="ddlPrgCompliance_SelectedIndexChanged"
                                        AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%=LocalResources.GetLabel("app_permit_compliance_text")%>:
                                </td>
                                <td align="left">
                                    <asp:HiddenField runat="server" ID="hdnPermitCompliance" Value='<%# Eval("h_permit_compliance_value") %>' />
                                    <asp:DropDownList ID="ddlPermitCompliance" DataValueField="h_permit_compliance_id"
                                        CssClass="dropdownlist_width" DataTextField="h_permit_compliance_name" OnSelectedIndexChanged="ddlPermitCompliance_SelectedIndexChanged"
                                        AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <b>
                                        <%=LocalResources.GetLabel("app_control_measures_text")%>:</b>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:GridView ID="gvControlMeasureSummary" CellPadding="0" CellSpacing="0" GridLines="None"
                            ShowHeader="false" runat="server" ShowFooter="true" CssClass="grid_900" AutoGenerateColumns="False"
                            OnRowCommand="gvControlMeasureSummary_RowCommand" OnRowDataBound="gvControlMeasureSummary_RowDataBound"
                            DataKeyNames="h_hazard_id_fk,h_hazard_control_meausre_id_pk">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gvrow_padding" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="lblControlCategory" runat="server" Text='<%#Eval("h_control_measure_text") %>'></asp:Label></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblControlMeasure" runat="server" Text='<%#Eval("h_control_measure_summary") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAddControlMeasure" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                        CommandName="AddControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_add_control_measure_button_text %>" />
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </fieldset>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_additional_information_text")%>
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top" class="font_1">
                        <%=LocalResources.GetLabel("app_custom_form(s)_text")%>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddform" CssClass='cursor_hand' runat="server" OnClientClick="Showpopup(this.id);"
                            Text="<%$ LabelResourceExpression: app_add_custom_form_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvCustomForm" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="h_file_guid,h_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvCustomForm_RowCommand"
                OnRowEditing="gvCustomForm_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="width_740">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="width_35">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" OnClientClick="Showeditpopup('customcustomer');" CommandName="Edit"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
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
                        <asp:Button ID="btnAddPhoto" CssClass='cursor_hand' runat="server" OnClientClick="Showpopup(this.id);"
                            Text="<%$ LabelResourceExpression: app_add_photo_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvPhoto" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="h_file_guid,h_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvPhoto_RowCommand"
                OnRowEditing="gvPhoto_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" OnClientClick="Showeditpopup('photo');" CommandName="Edit"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
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
                        <asp:Button ID="btnAddSceneSketch" CssClass='cursor_hand' OnClientClick="Showpopup(this.id);"
                            runat="server" Text="<%$ LabelResourceExpression: app_add_sketch_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvSceneSketch" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="h_file_guid,h_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvSceneSketch_RowCommand"
                OnRowEditing="gvSceneSketch_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" OnClientClick="Showeditpopup('scenesketch');" CommandName="Edit"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
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
                        <asp:Button ID="btnAddExtenuatingcondition" CssClass='cursor_hand' OnClientClick="Showpopup(this.id);"
                            runat="server" Text="<%$ LabelResourceExpression: app_add_extenuating_condition_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvExtenautingCondition" GridLines="None" CssClass="grid_table_850"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="h_file_guid,h_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvExtenautingCondition_RowCommand"
                OnRowEditing="gvExtenautingCondition_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" OnClientClick="Showeditpopup('extenautingcondition');" CommandName="Edit"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
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
                        <asp:Button ID="btnAddemployeeinterview" CssClass='cursor_hand' OnClientClick="Showpopup(this.id);"
                            runat="server" Text="<%$ LabelResourceExpression: app_add_employee_interview_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvEmployeeInterview" GridLines="None" CssClass="grid_table_850"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="h_file_guid,h_file_name,h_name,h_contact_info"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvEmployeeInterview_RowCommand"
                OnRowEditing="gvEmployeeInterview_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_230" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("h_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_210" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("h_name") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <%= LocalResources.GetLabel("app_contact_information_text")%>
                            :&nbsp;&nbsp; &nbsp; <b>
                                <%#Eval("h_contact_info") %></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" OnClientClick="Showeditpopup('employeeinterview');" CommandName="Edit"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" OnClientClick="return confirmremove();" CommandName="Remove"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
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
        <div class="div_controls">
            <table class="div_table">
                <tr>
                    <td class="align_left">
                        <asp:Button ID="btnSave_Footer" ValidationGroup="cccharm" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" runat="server" OnClick="btnSave_Footer_Click" />
                    </td>
                    <td class="btnreset_td">
                        <asp:Button ID="btnReset_Footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Footer_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel_footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                            OnClick="btnCancel_footer_Click1" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:ModalPopupExtender ID="mpeCustomCustomer" runat="server" TargetControlID="btnAddform"
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
            <asp:ModalPopupExtender ID="mpeExtenautingCondition" runat="server" TargetControlID="btnAddExtenuatingcondition"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeEmployeeInterview" runat="server" TargetControlID="btnAddemployeeinterview"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpJobTitle" runat="server" TargetControlID="btnEditJobTitle"
                PopupControlID="pnlJobTitle" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlJobTitleHeading" OkControlID="imgCloseJobTitle"
                CancelControlID="btnCloseJobTitle">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpHazard" runat="server" TargetControlID="btnTempHazard"
                PopupControlID="pnlHazard" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlHazardHeading" OkControlID="imgCloseHazardPopup"
                CancelControlID="btnCancelHazardControlMeasure">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpControlMeasure" runat="server" TargetControlID="btnTempControlMeasure"
                PopupControlID="pnlControlMeasure" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlControlMeasureHeading" OkControlID="ImgCloseControlMeasure"
                CancelControlID="btnCancelControlMeasure">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="hdAddForm" runat="server" />
            <asp:HiddenField ID="hdPhoto" runat="server" />
            <asp:HiddenField ID="hdSceneSketch" runat="server" />
            <asp:HiddenField ID="hdExtenautingcond" runat="server" />
            <asp:HiddenField ID="hdEmployeeInterview" runat="server" />
            <asp:Button ID="btnUploadFile" runat="server" CssClass="cursor_hand" Style="display: none;" />
            <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
                padding-left: 0px;  padding-right: 0px;">
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
                            ValidationGroup="ccaharmfileupload" />
                        <asp:CustomValidator ValidationGroup="ccaharmfileupload" ID="cvFileUpload" runat="server"
                            EnableClientScript="true" ErrorMessage="<%$ TextResourceExpression: app_select_file_error_empty%>"
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
                                        <asp:FileUpload ID="fupFiles" runat="server" Width="460" size="60" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="multiple_button">
                            <asp:Button ID="btnUploadCustomCustomer" ValidationGroup="ccaharmfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text%>" CssClass="cursor_hand"
                                OnClick="btnUploadCustomCustomer_Click" />
                            <asp:Button ID="btnUploadPhoto" ValidationGroup="ccaharmfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text%>" CssClass="cursor_hand"
                                OnClick="btnUploadPhoto_Click" />
                            <asp:Button ID="btnUploadSceneSketch" ValidationGroup="ccaharmfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text%>" CssClass="cursor_hand"
                                OnClick="btnUploadSceneSketch_Click" />
                            <asp:Button ID="btnUploadExtenautingcond" ValidationGroup="ccaharmfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text%>" CssClass="cursor_hand"
                                OnClick="btnUploadExtenautingcond_Click" />
                            <asp:Button ID="btnUploadEmployeeInterview" ValidationGroup="ccaharmfileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text%>" CssClass="cursor_hand"
                                OnClick="btnUploadEmployeeInterview_Click" />
                        </div>
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </div>
                    <br />
                </div>
            </asp:Panel>
        </div>
        <%-- edit job title popup--%>
        <div>
            <asp:Panel ID="pnlJobTitle" runat="server" CssClass="modalPopup_width_620 modal_popup_background" Style="display: none;
                padding-left: 0px;  padding-right: 0px;">
                <asp:Panel ID="pnlJobTitleHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_620">
                            <%=LocalResources.GetLabel("app_job_title_text")%>:
                        </div>
                        <asp:ImageButton ID="imgCloseJobTitle" CssClass="cursor_hand" Style="top: -15px;
                            right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <asp:ValidationSummary class="validation_summary_error" ID="vsJobTitle" runat="server"
                    ValidationGroup="JobTitle" />
                <asp:RequiredFieldValidator ID="rfvJobTitle" runat="server" ErrorMessage="<%$ TextResourceExpression: app_job_title_error_empty%>"
                    ControlToValidate="txtEditJobTitle" ValidationGroup="JobTitle">&nbsp;</asp:RequiredFieldValidator>
                <br />
                <div style="padding: 0 0 0 10px;" class="div_controls font_normal">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_enter_job_title_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditJobTitle" CssClass="textbox_width_260" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                    <table cellpadding="0" cellspacing="0" class="button_600">
                        <tr>
                            <td>
                                <asp:Button ID="btnSaveJobTitle" ValidationGroup="JobTitle" OnClick="btnSaveJobTitle_Click"
                                    runat="server" Text="Save" />
                            </td>
                            <td class="align_right">
                                <asp:Button ID="btnCloseJobTitle" CssClass="cursor_hand" runat="server" Text="Close" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
        <%-- Add Hazard popup--%>
        <div>
            <asp:Button ID="btnTempHazard" runat="server" Style="display: none;" />
            <asp:Panel ID="pnlHazard" runat="server" CssClass="modalPopup_width_700 modal_popup_background" Style="display: none;
                padding-left: 0px;  padding-right: 0px;">
                <asp:Panel ID="pnlHazardHEading" runat="server" CssClass="drag">
                    <div class="div_header_700">
                        <%=LocalResources.GetLabel("app_enter_potential_hazards_control_measure_text")%>:
                    </div>
                    <div>
                        <asp:ImageButton ID="imgCloseHazardPopup" CssClass="cursor_hand" Style="top: -15px;
                            right: -15px; z-index: 1103; position: absolute; width: 30px; height: 30px;"
                            runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <asp:ValidationSummary class="validation_summary_error" ID="vsHazard" runat="server"
                    ValidationGroup="Hazard" />
                <asp:RegularExpressionValidator ID="revHazardControlMeasure" runat="server" ErrorMessage="<%$ TextResourceExpression: app_hazard_text_limit_error_wrong%>"
                    ControlToValidate="txtHazardName" ValidationGroup="Hazard" ValidationExpression=".{0,100}">&nbsp;</asp:RegularExpressionValidator>
                <%--   <asp:RegularExpressionValidator ID="revHazardControlMasure1" runat="server" ErrorMessage="<%$ LabelResourceExpression: app_control_measure_allow_only_100_characters%>"
                                ControlToValidate="txtControlMeasureName" ValidationGroup="cccharmhazardcontrolmeasure"
                                ValidationExpression=".{0,100}">&nbsp;</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvHazardControlMeasure" runat="server" ErrorMessage="<%$ LabelResourceExpression: app_please_enter_the_control_measure_text%>"
                                ControlToValidate="txtControlMeasureName" ValidationGroup="cccharmhazardcontrolmeasure">&nbsp;</asp:RequiredFieldValidator>--%>
                <asp:RequiredFieldValidator ID="rfvHazard" runat="server" ErrorMessage="<%$ TextResourceExpression: app_hazard_error_empty%>"
                    ControlToValidate="txtHazardName" ValidationGroup="Hazard">&nbsp;</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvHazardJobTitle" runat="server" ErrorMessage="<%$ TextResourceExpression: app_job_title_error_empty%>"
                    ControlToValidate="txtJobTitle" ValidationGroup="Hazard">&nbsp;</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvOneControlMeasure" runat="server" ErrorMessage="<%$ TextResourceExpression: app_add_control_measure_error_empty%>"
                    ClientValidationFunction="gvEmptyValidation" EnableClientScript="true" ValidationGroup="Hazard">&nbsp;</asp:CustomValidator>
                <asp:CustomValidator ID="cvControlMeasure" runat="server" ErrorMessage="<%$ TextResourceExpression: app_control_measure_error_empty%>"
                    ClientValidationFunction="gvEmpty" Display="Dynamic" EnableClientScript="true"
                    ValidationGroup="Hazard">&nbsp;</asp:CustomValidator>
                <div style="padding: 0 0 0 10px;" class="div_controls font_normal">
                    <asp:UpdatePanel ID="upnl" runat="server">
                        <ContentTemplate>
                            <div class="div_controls font_normal">
                                <div id="divjobtitle">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <%=LocalResources.GetLabel("app_job_title_text")%>:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtJobTitle" CssClass="textbox_width_260" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <%=LocalResources.GetLabel("app_enter_hazard_text")%>
                                        </td>
                                        <td>
                                            <textarea id="txtHazardName" runat="server" rows="2" cols="63"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <%=LocalResources.GetLabel("app_control_measure_text")%>:
                                        </td>
                                        <td class="align_left">
                                            <asp:DropDownList ID="ddlControlMeasure" CssClass="ddl_user_advanced_search" DataTextField="c_control_measure_name"
                                                DataValueField="c_control_measure_system_id_pk" runat="server">
                                            </asp:DropDownList>
                                            <asp:Button ID="btnNewControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_add_button_text %>"
                                                OnClick="btnNewControlMeasure_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="clear">
                            </div>
                            <div style="padding: 0 0 0 70px;">
                                <asp:GridView ID="gvNewControlMeasure" RowStyle-CssClass="record" ShowHeader="false"
                                    GridLines="None" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="188px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdHazardid" runat="server" Value='<%#Eval("h_hazard_id_fk") %>' />
                                                <asp:HiddenField ID="hdnControlMeasureValue" runat="server" Value='<%#Eval("h_control_measure_id_fk") %>' />
                                                <asp:Label ID="lblControlMeasureText" runat="server" Text='<%#Eval("h_control_measure_text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAddControlMeasure" CssClass="textbox_width_260" Text='<%#Eval("h_control_measure_summary") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35px">
                                            <ItemTemplate>
                                                <input type="button" id='<%# Eval("h_hazard_control_meausre_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="X" />'
                                                    class="h_control_measure cursor_hand" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="padding: 0 10px 0 10px;">
                    <div class="left">
                        <asp:Button ID="btnSaveHazardControlMeausre" ValidationGroup="Hazard" runat="server"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" OnClick="btnSaveHazardControlMeausre_Click" />
                    </div>
                    <div class="right">
                        <asp:Button ID="btnCancelHazardControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </div>
                </div>
                <br />
            </asp:Panel>
        </div>
        <%--   Add edit control measure--%>
        <div>
            <asp:Button ID="btnTempControlMeasure" runat="server" Style="display: none;" />
            <asp:Panel ID="pnlControlMeasure" runat="server" CssClass="modalPopup_width_700 modal_popup_background"
                Style="display: none; padding-left: 0px;  padding-right: 0px;">
                <asp:Panel ID="pnlControlMeasureHeading" runat="server" CssClass="drag">
                    <div class="div_header_700">
                        <%=LocalResources.GetLabel("app_control_measure_text")%>:
                    </div>
                    <div>
                        <asp:ImageButton ID="ImgCloseControlMeasure" CssClass="cursor_hand" Style="top: -15px;
                            right: -15px; z-index: 1103; position: absolute; width: 30px; height: 30px;"
                            runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <asp:ValidationSummary class="validation_summary_error" ID="vsControlMeasure" runat="server"
                    ValidationGroup="ControlMeasure" />
                <%--  <asp:RequiredFieldValidator ID="revcontrolMeasure1" runat="server" ErrorMessage="<%$ LabelResourceExpression: app_please_enter_the_control_measure_text%>"
                                ControlToValidate="txtAddControlMeasure" ValidationGroup="cccharmcontrolmeasure">&nbsp;</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revControlMeasure" runat="server" ErrorMessage="<%$ LabelResourceExpression: app_control_measure_allow_only_100_characters%>"
                                ControlToValidate="txtAddControlMeasure" ValidationGroup="cccharmcontrolmeasure"
                                ValidationExpression=".{0,100}">&nbsp;</asp:RegularExpressionValidator>--%>
                <asp:CustomValidator ID="cvOneAddEditControlMeasure" runat="server" ErrorMessage="<%$ TextResourceExpression: app_add_control_measure_error_empty%>"
                    ClientValidationFunction="gvEmptyEditControlMeasure" EnableClientScript="true"
                    ValidationGroup="ControlMeasure">&nbsp;</asp:CustomValidator>
                <asp:CustomValidator ID="cvAddEditControlMeasure" runat="server" ErrorMessage="<%$ TextResourceExpression: app_control_measure_error_empty%>"
                    ClientValidationFunction="gvAddEditEmpty" EnableClientScript="true" ValidationGroup="ControlMeasure">&nbsp;</asp:CustomValidator>
                <asp:UpdatePanel ID="upControlMeasure" runat="server">
                    <ContentTemplate>
                        <div class="div_controls font_normal">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top">
                                        <%=LocalResources.GetLabel("app_control_measure_text")%>
                                    </td>
                                    <td class="align_left">
                                        <asp:DropDownList ID="ddlAddEditControlMeasure" DataTextField="c_control_measure_name"
                                            DataValueField="c_control_measure_system_id_pk" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="align_left">
                                        <asp:Button ID="btnAddEditControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_add_button_text%>"
                                            OnClick="btnAddEditControlMeasure_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div style="padding: 0 0 0 125px;">
                            <asp:GridView ID="gvAddEditControlMeasure" RowStyle-CssClass="record" ShowHeader="false"
                                GridLines="None" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="170px">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdHazardid" runat="server" Value='<%#Eval("h_hazard_id_fk") %>' />
                                            <asp:HiddenField ID="hdnControlMeasureValue" runat="server" Value='<%#Eval("h_control_measure_id_fk") %>' />
                                            <asp:Label ID="lblControlMeasureText" runat="server" Text='<%#Eval("h_control_measure_text")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAddControlMeasure" Text='<%#Eval("h_control_measure_summary") %>'
                                                runat="server" CssClass="textbox_width_260"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35px">
                                        <ItemTemplate>
                                            <input type="button" id='<%# Eval("h_hazard_control_meausre_id_pk") %>' value='<asp:Literal ID="Literal5" runat="server" Text="X" />'
                                                class="h_control_measure cursor_hand" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="padding: 0 10px 0 10px;">
                    <div class="left">
                        <asp:Button ID="btnSaveControlMeasure" ValidationGroup="ControlMeasure" runat="server"
                            Text="<%$ LabelResourceExpression: app_save_button_text %>" OnClick="btnSaveControlMeausre_Click" />
                    </div>
                    <div class="right">
                        <asp:Button ID="btnCancelControlMeasure" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </div>
                </div>
                <br />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
