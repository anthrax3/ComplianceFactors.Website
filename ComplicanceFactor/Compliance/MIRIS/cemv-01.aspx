<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="cemv-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.cemv_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
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

        function expandDetailsCaseDetails(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgCourse", "div_casedetails") //GETTING THE ID OF SUMMARY ROW

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

        function expandDetailsDamageDesc(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgdamagedesc", "div_damage_description") //GETTING THE ID OF SUMMARY ROW

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

        function expandDetailsPublicVehicleInfo(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgPublicVehicle", "div_Public_vehicle") //GETTING THE ID OF SUMMARY ROW

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

        function expandDetailsPublicVehicleDamageDesc(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgpublicdamage", "div_public_vehicle_damage") //GETTING THE ID OF SUMMARY ROW

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
        function expandDetailsPedestrain(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgPedestrain", "div_Pedestrain") //GETTING THE ID OF SUMMARY ROW

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

        function expandDetailsBicycleIncident(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgBicycleIncident", "div_Bicycle_Incident") //GETTING THE ID OF SUMMARY ROW

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

        function expandDetailsFixedObjectIncident(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imgfixedobject", "div_fixed_object_incident") //GETTING THE ID OF SUMMARY ROW

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
        function expandDetailsAnimalIncident(_this) {

            var id = _this.id;
            var imgelem = document.getElementById(_this.id);

            var currowid = id.replace("imganimalincident", "div_animal_incident") //GETTING THE ID OF SUMMARY ROW

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
        function checkAddress(checkbox) {

            if (checkbox.checked) {
                document.getElementById('<%=txtNonCollision.ClientID%>').style.display = "inline";
            }
            else {
                document.getElementById('<%=txtNonCollision.ClientID%>').style.display = "none";
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtTimeofDay.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtTimeofDay.ClientID %>").click(
			function () {
			    $("#<%=txtTimeofDay.ClientID %>")[0].focus();
			}
		);
        });
    </script>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('#<%=txtTimeofDay.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });
            });
        })(jQuery);
    </script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $('#<%=rblDriverInjured.ClientID %>').click(function () {
                //alert("hai");
                var list = document.getElementById('<%=rblDriverInjured.ClientID %>'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                var selected;
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].checked) {
                        selected = inputs[i];
                        break;
                    }
                }
                if (selected.value == 'Yes') {
                    if (confirm('Occupation Injury case must be created,ACCEPT or DENY..?') == true)
                        return true;
                    else
                        return false;
                }

                //var selectedValue = $('#<%=rblDriverInjured.ClientID %>').val();
                //alert(selectedValue);
            });

            $('#<%=rblPublicDriverInjured.ClientID %>').click(function () {
                //alert("hai");
                var list = document.getElementById('<%=rblPublicDriverInjured.ClientID %>'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                var selected;
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].checked) {
                        selected = inputs[i];
                        break;
                    }
                }
                if (selected.value == 'Yes') {
                    document.getElementById('<%=txtPublicDriverInjured.ClientID%>').style.display = "inline";

                }
                else {
                    document.getElementById('<%=txtPublicDriverInjured.ClientID%>').style.display = "none";
                }
            });

            $('#<%=rblFatality.ClientID %>').click(function () {
                var list = document.getElementById('<%=rblFatality.ClientID %>'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                var selected;
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].checked) {
                        selected = inputs[i];
                        break;
                    }
                }
                if (selected.value == 'Yes') {
                    document.getElementById('<%=txtNoofPeopleKilled.ClientID%>').style.display = "inline";
                    document.getElementById('<%=lblNumberofFatilities.ClientID%>').style.display = "inline";
                }
                else {
                    document.getElementById('<%=txtNoofPeopleKilled.ClientID%>').style.display = "none";
                    document.getElementById('<%=lblNumberofFatilities.ClientID%>').style.display = "none";
                }
            });

        });                
    </script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $('#<%=rblPassengerInjured.ClientID %>').click(function () {
                //alert("hai");
                var list = document.getElementById('<%=rblPassengerInjured.ClientID %>'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                var selected;
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].checked) {
                        selected = inputs[i];
                        break;
                    }
                }
                if (selected.value == 'Yes') {
                    if (confirm('Occupation Injury case must be created ACCEPT or DENY..?') == true)
                        return true;
                    else
                        return false;
                }
            });

            $('#<%=rblPublicPassengerInjured.ClientID %>').click(function () {
                //alert("hai");
                var list = document.getElementById('<%=rblPublicPassengerInjured.ClientID %>'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                var selected;
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].checked) {
                        selected = inputs[i];
                        break;
                    }
                }
                if (selected.value == 'Yes') {
                    document.getElementById('<%=txtPublicPassengerInjured.ClientID%>').style.display = "inline";
                }
                else {
                    document.getElementById('<%=txtPublicPassengerInjured.ClientID%>').style.display = "none";
                }
            });
        });                
    </script>
    <script type="text/javascript">
        function ShowPublicVehicle() {
            var list = document.getElementById('<%=rblPublicVehicleInvolved.ClientID %>'); //Client ID of the radiolist
            var inputs = list.getElementsByTagName("input");
            var selected;
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked) {
                    selected = inputs[i];
                    break;
                }
            }
            if (selected.value == 'Yes') {
                document.getElementById('<%=div_public_vehicle_info.ClientID%>').style.display = "inline";
            }
            else {
                document.getElementById('<%=div_public_vehicle_info.ClientID%>').style.display = "none";
            }
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
    <asp:ValidationSummary class="validation_summary_error" ID="vs_cemv" runat="server"
        ValidationGroup="cemv"></asp:ValidationSummary>
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="error_vehicle" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div id="error_msg" runat="server" class="msgarea_error" style="display: none;">
        <%=LocalResources.GetText("app_date_not_updated_error_wrong")%>
    </div>
    <asp:HiddenField ID="hdnIsCompliance" runat="server" />
    <asp:CustomValidator ID="cvDOB" runat="server" ErrorMessage="<%$ TextResourceExpression: app_date_of_birth_error_empty %>"
        ForeColor="Red" ValidationGroup="cemv" ClientValidationFunction="validateDOB">&nbsp;</asp:CustomValidator>
    <asp:CustomValidator ID="cvHireDate" runat="server" ErrorMessage="<%$ TextResourceExpression: app_emp_hire_date_error_empty %>"
        ForeColor="Red" ValidationGroup="cemv" ClientValidationFunction="validateHireDate">&nbsp;</asp:CustomValidator>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <table cellpadding="0" cellspacing="0" class="controls_long">
            <tr>
                <td align="left">
                    <asp:Button ID="btnSavenewcase_header" ValidationGroup="cemv" CssClass="cursor_hand"
                        Text="<%$ LabelResourceExpression: app_save_button_text %>" runat="server" OnClick="btnSavecase_header_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnHeaderCompleteCase" OnClientClick="return ConfirmComplete();"
                        runat="server" Text="<%$ LabelResourceExpression: app_complete_case_button_text %>"
                        OnClick="btnHeaderCompleteCase_Click" ValidationGroup="cemv" CssClass="cursor_hand" />
                </td>
                <td align="center">
                    <asp:Button ID="btnViewCaseDesc_header" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_view_case_description_button_text %>" />
                </td>
                <td align="left">
                    <asp:Button ID="btnReset_Header" CssClass="cursor_hand" OnClick="btnResetHeader_Click"
                        runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
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
        <%=LocalResources.GetLabel("app_case_information_text")%>:
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
                    <asp:RequiredFieldValidator ID="rfvCaseTitle" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtCaseTitle" ErrorMessage="<%$ TextResourceExpression: app_title_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_case_title_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCaseTitle" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_case_date_text")%>:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblCaseDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    *
                    <%=LocalResources.GetLabel("app_case_category_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCaseCategory" DataValueField="c_category_id" DataTextField="c_category_name"
                        AutoPostBack="true" CssClass="ddl_user_advanced_search" runat="server" OnSelectedIndexChanged="ddlCaseCategory_SelectedIndexChanged1">
                    </asp:DropDownList>
                </td>
                <td>
                    *
                    <%=LocalResources.GetLabel("app_case_types_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCaseTypes" CssClass="ddl_user_advanced_search" DataValueField="c_type_id"
                        DataTextField="c_type_name" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    *
                    <%=LocalResources.GetLabel("app_case_status_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCaseStatus" CssClass="ddl_user_advanced_search" DataValueField="c_status_id"
                        DataTextField="c_status_name" runat="server">
                    </asp:DropDownList>
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
        <%=LocalResources.GetLabel("app_case_description_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtEmployeeName" ErrorMessage="<%$ TextResourceExpression: app_emp_name_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_employee_name_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="textbox_width"></asp:TextBox>
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
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtEmployeeId" ErrorMessage="<%$ TextResourceExpression: app_emp_id_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_employee_id_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvLastDigitofSSN" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtLastFourDigitOfSSN" ErrorMessage="<%$ TextResourceExpression: app_last_four_digit_ssn_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_last_digit_of_ssn#_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtLastFourDigitOfSSN" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvsupervisor" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtSupervisor" ErrorMessage="<%$ TextResourceExpression: app_supervisor_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_supervisor_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtSupervisor" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvIncidentLocation" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtIncidentLocation" ErrorMessage="<%$ TextResourceExpression: app_incident_location_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_incident_location_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtIncidentLocation" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvUserIncidentDate" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtIncidentDate" ErrorMessage="<%$ TextResourceExpression: app_incident_date_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revIncidentDate" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtIncidentDate" ErrorMessage="<%$ TextResourceExpression: app_incident_date_format_error_empty %>"
                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                    <asp:CustomValidator ValidationGroup="cemv" ID="cvIncidentDate" runat="server" ErrorMessage="<%$ TextResourceExpression: app_fultue_date_error_wrong %>"
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
                <td>
                    <asp:RequiredFieldValidator ID="rfvIncidentTime" runat="server" ControlToValidate="IncidentTime"
                        ErrorMessage="<%$ TextResourceExpression: app_incident_time_error_empty %>" ValidationGroup="cemv">&nbsp;</asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_incident_time_text")%>:
                </td>
                <td class="timer">
                    <MKB:TimeSelector ID="IncidentTime" CssClass="timer" DisplaySeconds="false" runat="server"
                        Date="">
                    </MKB:TimeSelector>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEmployeeReportLocation" runat="server" ValidationGroup="cemv"
                        ControlToValidate="txtEmployeeReportLocation" ErrorMessage="<%$ TextResourceExpression: app_emp_report_location_error_empty %>">&nbsp;
                    </asp:RequiredFieldValidator>
                    *
                    <%=LocalResources.GetLabel("app_employee_report_location_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeReportLocation" runat="server" CssClass="textbox_width"></asp:TextBox>
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
                <td>
                    <%=LocalResources.GetLabel("app_note_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_text")%>
                    01:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVehicle01" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Company Vehicle" Value="Company Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Leased Vehicle" Value="Leased Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rental" Value="Rental"></asp:ListItem>
                        <asp:ListItem Text="Personal Vehicle" Value="Personal Vehicle"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_type_text")%>:
                </td>
                <td class="align_left">
                    <asp:DropDownList ID="ddlVehicleType" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Car" Value="Car"></asp:ListItem>
                        <asp:ListItem Text="Lt Truck" Value="Lt Truck"></asp:ListItem>
                        <asp:ListItem Text="CMV" Value="CMV"></asp:ListItem>
                        <asp:ListItem Text="SUV" Value="SUV"></asp:ListItem>
                        <asp:ListItem Text="Car/SUV with trailer" Value="Car/SUV with trailer"></asp:ListItem>
                        <asp:ListItem Text="Bus" Value="Bus"></asp:ListItem>
                        <asp:ListItem Text="Trailer" Value="Trailer"></asp:ListItem>
                        <asp:ListItem Text="Combo" Value="Combo"></asp:ListItem>
                        <asp:ListItem Text="Motorcycle" Value="Motorcycle"></asp:ListItem>
                        <asp:ListItem Text="Off-Road" Value="Off-Road"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtVehicleId" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_vin_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtVIN" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_license_number_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtLicenseNumber" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_state_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtState" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtVehicleMake" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_model_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtVehicleModel" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_year_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtYear" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_text")%>
                    02:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVehicle02" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Company Vehicle" Value="Company Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Leased Vehicle" Value="Leased Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rental" Value="Rental"></asp:ListItem>
                        <asp:ListItem Text="Personal Vehicle" Value="Personal Vehicle"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_type_text")%>
                    :
                </td>
                <td class="align_left">
                    <asp:DropDownList ID="ddlVehicleType02" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Car" Value="Car"></asp:ListItem>
                        <asp:ListItem Text="Lt Truck" Value="Lt Truck"></asp:ListItem>
                        <asp:ListItem Text="CMV" Value="CMV"></asp:ListItem>
                        <asp:ListItem Text="SUV" Value="SUV"></asp:ListItem>
                        <asp:ListItem Text="Car/SUV with trailer" Value="Car/SUV with trailer"></asp:ListItem>
                        <asp:ListItem Text="Bus" Value="Bus"></asp:ListItem>
                        <asp:ListItem Text="Trailer" Value="Trailer"></asp:ListItem>
                        <asp:ListItem Text="Combo" Value="Combo"></asp:ListItem>
                        <asp:ListItem Text="Motorcycle" Value="Motorcycle"></asp:ListItem>
                        <asp:ListItem Text="Off-Road" Value="Off-Road"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtVehicleId02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_vin_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtVin02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_license_number_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtLicenseNumber02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_state_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtState02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtVehicleMake02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_model_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtModel02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_year_text")%>:
                </td>
                <td class="align_left">
                    <asp:TextBox ID="txtYear02" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:Panel ID="VehiclePanel" runat="server">
        </asp:Panel>
        <asp:Literal ID="ltlVehicleCount" runat="server" Text="0" Visible="false" />
        <asp:Literal ID="ltlRemoved" runat="server" Text="" Visible="false" />
        <div>
            <table>
                <tr>
                    <td class="align_right">
                        <asp:Button ID="btnAddVechicle" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_vehicle_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_company_vehicle_struck_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCompanyVehicleStruck" CssClass="ddl_user_advanced_search"
                            runat="server">
                            <asp:ListItem Text="Other Vehicle" Value="Other Vehicle"></asp:ListItem>
                            <asp:ListItem Text="Pedestrian" Value="Pedestrian"></asp:ListItem>
                            <asp:ListItem Text="Bicycle" Value="Bicycle"></asp:ListItem>
                            <asp:ListItem Text="Fixed Objects" Value="Fixed Objects"></asp:ListItem>
                            <asp:ListItem Text="Animals" Value="Animals"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_company_vehicle_struck_by_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCompanyVehicleStruckBy" CssClass="ddl_user_advanced_search"
                            runat="server">
                            <asp:ListItem Text="Other Vehicle" Value="Other Vehicle"></asp:ListItem>
                            <asp:ListItem Text="Pedestrian" Value="Pedestrian"></asp:ListItem>
                            <asp:ListItem Text="Bicycle" Value="Bicycle"></asp:ListItem>
                            <asp:ListItem Text="Fixed Objects" Value="Fixed Objects"></asp:ListItem>
                            <asp:ListItem Text="Animals" Value="Animals"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_non_collision_text")%>:
                                </td>
                                <td class="align_left">
                                    &nbsp;<input type="checkbox" id="chkNonCollision" name="checkAddress" runat="server"
                                        onclick="checkAddress(this)" />
                                    <%--<asp:CheckBox ID="chkNonCollision" runat="server"/>--%>
                                </td>
                                <td class="align_left">
                                    <asp:TextBox ID="txtNonCollision" runat="server" Style="display: none;" CssClass="textbox_width"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_case_details_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsCaseDetails(this);return false;" runat="server"
                ID="imgCourse" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_controls font_1 msg_display" id="div_casedetails" runat="server">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_drivers_lic_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtDriversLic" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_state_and_class_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtStateandClass" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revExpireDate" runat="server" ValidationGroup="cmv"
                        ControlToValidate="txtExpireDate" ErrorMessage="<%$ TextResourceExpression: app_expiry_date_error_wrong%>"
                        ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                    <%=LocalResources.GetLabel("app_expiry_state_text")%>:
                </td>
                <td>
                    <asp:CalendarExtender ID="ceExpireDate" Format="MM/dd/yyyy" TargetControlID="txtExpireDate"
                        runat="server">
                    </asp:CalendarExtender>
                    <asp:TextBox ID="txtExpireDate" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_address_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_city_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_state_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCaseState" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_nearest_cross_street_intersection_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtNearestCrossStreet" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_type_of_roadway_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtTypeofRoadway" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_road_condition_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoadCondition" CssClass="ddl_user_advanced_search" runat="server">
                        <asp:ListItem Text="Dry" Value="Dry"></asp:ListItem>
                        <asp:ListItem Text="Wet" Value="Wet"></asp:ListItem>
                        <asp:ListItem Text="Snow" Value="Snow"></asp:ListItem>
                        <asp:ListItem Text="Mud" Value="Mud"></asp:ListItem>
                        <asp:ListItem Text="Ice" Value="Ice"></asp:ListItem>
                        <asp:ListItem Text="Paved" Value="Paved"></asp:ListItem>
                        <asp:ListItem Text="Gravel" Value="Gravel"></asp:ListItem>
                        <asp:ListItem Text="Dirt" Value="Dirt"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_time_of_day_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtTimeofDay" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddl" CssClass="ddl_user_advanced_search" style="display:none;" runat="server">
                        <asp:ListItem Text="Dawn" Value="Dawn"></asp:ListItem>
                        <asp:ListItem Text="Daylight" Value="Daylight"></asp:ListItem>
                        <asp:ListItem Text="Overcast/Rain" Value="Overcast/Rain"></asp:ListItem>
                        <asp:ListItem Text="Dusk" Value="Dusk"></asp:ListItem>
                        <asp:ListItem Text="Night" Value="Night"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_weather_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlWeather" CssClass="ddl_user_advanced_search" runat="server">
                        <asp:ListItem Text="Clear" Value="Clear"></asp:ListItem>
                        <asp:ListItem Text="Cloudy" Value="Cloudy"></asp:ListItem>
                        <asp:ListItem Text="Rain" Value="Rain"></asp:ListItem>
                        <asp:ListItem Text="Fog" Value="Fog"></asp:ListItem>
                        <asp:ListItem Text="Snow" Value="Snow"></asp:ListItem>
                        <asp:ListItem Text="Ice" Value="Ice"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_traffic_condition_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTrafficCondition" CssClass="ddl_user_advanced_search" runat="server">
                        <asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>
                        <asp:ListItem Text="Congested" Value="Congested"></asp:ListItem>
                        <asp:ListItem Text="Heavy" Value="Heavy"></asp:ListItem>
                        <asp:ListItem Text="Moderate" Value="Moderate"></asp:ListItem>
                        <asp:ListItem Text="Variable" Value="Variable"></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_traffic_controls_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTrafficControls" CssClass="ddl_user_advanced_search" runat="server">
                        <asp:ListItem Text="Traffic light" Value="Traffic light"></asp:ListItem>
                        <asp:ListItem Text="Flashing traffic light (red/yellow)" Value="Flashing traffic light (red/yellow)"></asp:ListItem>
                        <asp:ListItem Text="Intersection sign (stop-1,2,3,4)" Value="Intersection sign (stop-1,2,3,4)"></asp:ListItem>
                        <asp:ListItem Text="Merge zone" Value="Merge zone"></asp:ListItem>
                        <asp:ListItem Text="Railroad crossing" Value="Railroad crossing"></asp:ListItem>
                        <asp:ListItem Text="Manual control (police, emergency, flagger)" Value="Manual control (police, emergency, flagger)"></asp:ListItem>
                        <asp:ListItem Text="Yield" Value="Yield"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_operating_speed_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtOperatingSpeed" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_speed_limit_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtSpeedLimit" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_struck_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVehicleStruck" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Parked Vehicle" Value="Parked Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Stopped Vehicle" Value="Stopped Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Moving Vehicle" Value="Moving Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Stationary Object" Value="Stationary Object"></asp:ListItem>
                        <asp:ListItem Text="Pedestrian" Value="Pedestrian"></asp:ListItem>
                        <asp:ListItem Text="Animal" Value="Animal"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_vehicle_struck_by_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVehicleStruckBy" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Other Vehicle" Value="Other Vehicle"></asp:ListItem>
                        <asp:ListItem Text="Pedestrian" Value="Pedestrian"></asp:ListItem>
                        <asp:ListItem Text="Animal" Value="Animal"></asp:ListItem>
                        <asp:ListItem Text="Train" Value="Train"></asp:ListItem>
                        <asp:ListItem Text="Other object" Value="Other object"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_collision_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCollisionType" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Rear-Ended other vehicle" Value="Rear-Ended other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rear-ended by other vehicle" Value="Rear-ended by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Hit vehicle head-on" Value="Hit vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="Hit by vehicle head-on" Value="Hit by vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="T-Boned other vehicle" Value="T-Boned other vehicle"></asp:ListItem>
                        <asp:ListItem Text="T-Boned by other vehicle" Value="T-Boned by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Backed into other vehicle/object" Value="Backed into other vehicle/object"></asp:ListItem>
                        <asp:ListItem Text="Backed into by other vehicle" Value="Backed into by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped other vehicle" Value="Sideswiped other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped by other vehicle" Value="Sideswiped by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Roll over" Value="Roll over"></asp:ListItem>
                        <asp:ListItem Text="Left roadway" Value="Left roadway"></asp:ListItem>
                        <asp:ListItem Text="Lane change" Value="Lane change"></asp:ListItem>
                        <asp:ListItem Text="Struck fixed object" Value="Struck fixed object"></asp:ListItem>
                        <asp:ListItem Text="Backed into fixed object" Value="Backed into fixed object"></asp:ListItem>
                        <asp:ListItem Text="Road hazard" Value="Road hazard"></asp:ListItem>
                        <asp:ListItem Text="Multi car pile up" Value="Multi car pile up"></asp:ListItem>
                        <asp:ListItem Text="Jack-knife" Value="Jack-knife"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_collision_location_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCollisionLocation" DataValueField=" " DataTextField=" "
                        runat="server" CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Intersection" Value="Intersection"></asp:ListItem>
                        <asp:ListItem Text="Single Lane" Value="Single Lane"></asp:ListItem>
                        <asp:ListItem Text="Two Lane" Value="Two Lane"></asp:ListItem>
                        <asp:ListItem Text="4 lane – undivided" Value="4 lane – undivided"></asp:ListItem>
                        <asp:ListItem Text="Divided" Value="Divided"></asp:ListItem>
                        <asp:ListItem Text="Merge/yield area" Value="Merge/yield area"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_collision_direction_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCollisionDirection" DataValueField=" " DataTextField=" "
                        runat="server" CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Traveling in the same direction" Value="Traveling in the same direction"></asp:ListItem>
                        <asp:ListItem Text="Traveling in opposite directions" Value="Traveling in opposite directions"></asp:ListItem>
                        <asp:ListItem Text="Traveling perpendicular" Value="Traveling perpendicular"></asp:ListItem>
                        <asp:ListItem Text="Turning left" Value="Turning left"></asp:ListItem>
                        <asp:ListItem Text="Turning right" Value="Turning right"></asp:ListItem>
                        <asp:ListItem Text="Lane change" Value="Lane change"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_non_collision_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlNonCollisionType" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Vandalism" Value="Vandalism"></asp:ListItem>
                        <asp:ListItem Text="Weather" Value="Weather"></asp:ListItem>
                        <asp:ListItem Text="Fire" Value="Fire"></asp:ListItem>
                        <asp:ListItem Text="Theft" Value="Theft"></asp:ListItem>
                        <asp:ListItem Text="Glass only" Value="Glass only"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_number_of_vehicles_involved_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtNumberofVehicleInvolved" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_number_of_vehicles_towed_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtNumberofVehicletowed" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_driver_injured_text")%>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblDriverInjured" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_passenger_injured_text")%>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblPassengerInjured" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_situation_issued_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblCituationIssued" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_number_of_people_injured_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtNoofPeopleInjured" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_was_there_a_fatality_text")%>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblFatality" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="lblNumberofFatilities" Style="display: none;" runat="server" Text="<%$ LabelResourceExpression: app_number_of_fatalities_text %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNoofPeopleKilled" Style="display: none;" runat="server" CssClass="textbox_width"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_at_home_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtAtWhom" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_at_fault_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblAtfault" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_contributory_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblContributory" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_cross_vehicle_weight_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtGrossVehicleWeight" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_combined_gross_vehicle_weight_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCombinedGrossVehicleWeight" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_dot_vehicle_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblDotVehicle" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_dot_driver_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblDotDriver" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_seat_belt_used_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblSeatBeltUsed" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_air_bag_equipped_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblAirbagEquipped" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_air_bag_deployed_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblAirBagDeployed" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_cellphone_use_during_operation_text")%>:
                            </td>
                            <td class="align_left">
                                <asp:RadioButtonList ID="rblCellphoneinUse" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_computer_use_during_operation_text")%>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblComputerInUse" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="3">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                <%=LocalResources.GetLabel("app_special_equipment_text")%>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblSpecialEquipment" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSpecialEquibment" runat="server" Visible="false" CssClass="textbox_width"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_location_of_impact_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLocationofImpact" DataValueField=" " DataTextField=" " runat="server"
                        CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Front" Value="Front"></asp:ListItem>
                        <asp:ListItem Text="Right front quarter" Value="Right front quarter"></asp:ListItem>
                        <asp:ListItem Text="Right side" Value="Right side"></asp:ListItem>
                        <asp:ListItem Text="Right left quarter" Value="Right left quarter"></asp:ListItem>
                        <asp:ListItem Text="Rear" Value="Rear"></asp:ListItem>
                        <asp:ListItem Text="Left front quarter" Value="Left front quarter"></asp:ListItem>
                        <asp:ListItem Text="Left side" Value="Left side"></asp:ListItem>
                        <asp:ListItem Text="Left rear quarter" Value="Left rear quarter"></asp:ListItem>
                        <asp:ListItem Text="Top" Value="Top"></asp:ListItem>
                        <asp:ListItem Text="Undercarriage" Value="Undercarriage"></asp:ListItem>
                        <asp:ListItem Text="Other-explain" Value="Other-explain"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                        <tr>
                            <td class="align_right">
                                   <%=LocalResources.GetLabel("app_public_vehicle_involved_text")%>:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblPublicVehicleInvolved" onchange="ShowPublicVehicle();"
                                    RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
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
        <%=LocalResources.GetLabel("app_description_of_damage_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsDamageDesc(this);return false;" runat="server"
                ID="imgdamagedesc" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_controls font_1 msg_display" id="div_damage_description" runat="server">
        <table>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_heavy_text")%>:
                </td>
                <td style="width: 800px;">
                    <textarea id="txtHeavyDamage" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_moderate_text")%>:
                </td>
                <td>
                    <textarea id="txtModerateDamage" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_light_text")%>:
                </td>
                <td>
                    <textarea id="txtLightDamage" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_public_vehicle_info" style="display: none;" runat="server">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_public_vehicle_info_text")%>:
            <div class="right div_padding_10">
                <asp:ImageButton OnClientClick="expandDetailsPublicVehicleInfo(this);return false;"
                    runat="server" ID="imgPublicVehicle" ImageUrl="~/Images/addplus-sm.gif" />
            </div>
        </div>
        <br />
        <div class="div_controls font_1 msg_display" id="div_Public_vehicle" runat="server">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_driver_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_driver_address_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDriverAddress" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_driver_contact_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDriverContact" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOwnerName" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_address_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOwnerAddress" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_contact_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOwnerContact" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_vehicle_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicVehicleID" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_vin_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicVehicleVIN" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_license_number_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicLicenseNumber" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_vehicle_make_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicVehicleMake" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_model_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicVehicleModel" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_type_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPublicVehicleType" runat="server" CssClass="ddl_user_advanced_search">
                            <asp:ListItem Text="Car" Value="Car"></asp:ListItem>
                            <asp:ListItem Text="Lt Truck" Value="Lt Truck"></asp:ListItem>
                            <asp:ListItem Text="CMV" Value="CMV"></asp:ListItem>
                            <asp:ListItem Text="SUV" Value="SUV"></asp:ListItem>
                            <asp:ListItem Text="Car/SUV with trailer" Value="Car/SUV with trailer"></asp:ListItem>
                            <asp:ListItem Text="Bus" Value="Bus"></asp:ListItem>
                            <asp:ListItem Text="Trailer" Value="Trailer"></asp:ListItem>
                            <asp:ListItem Text="Combo" Value="Combo"></asp:ListItem>
                            <asp:ListItem Text="Motorcycle" Value="Motorcycle"></asp:ListItem>
                            <asp:ListItem Text="Off-Road" Value="Off-Road"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_year_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicYear" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_state_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicState" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_vehicle_weight_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicGrossWeight" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_combined_gross_vehicle_weight_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicCombinedVehicleWeight" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_dot_vehicle_text")%>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblPublicDotVehicle" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_dot_driver_text")%>:
                                </td>
                                <td class="align_left">
                                    <asp:RadioButtonList ID="rblPublicDotDriver" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_seat_belt_used_text")%>:
                                </td>
                                <td class="align_left">
                                    <asp:RadioButtonList ID="rblPublicSeatBeltUsed" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_air_bag_equipped_text")%>:
                                </td>
                                <td class="align_left">
                                    <asp:RadioButtonList ID="rblPublicAirBagEquipped" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_air_bag_deployed_text")%>:
                                </td>
                                <td class="align_left">
                                    <asp:RadioButtonList ID="rblPublicAirBagDeployed" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_cellphone_use_during_operation_text")%>:
                                </td>
                                <td class="align_left">
                                    <asp:RadioButtonList ID="rblPublicCellphoneinUse" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_computer_use_during_operation_text")%>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblPublicComputerInUse" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_special_equipment_text")%>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblPublicSpecialEquipment" RepeatDirection="Horizontal"
                                        runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPublicSpecialEquipment" runat="server" Visible="false" CssClass="textbox_width"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_location_of_impact_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPublicLocationOfImpact" DataValueField=" " DataTextField=" "
                            runat="server" CssClass="ddl_user_advanced_search">
                            <asp:ListItem Text="Front" Value="Front"></asp:ListItem>
                            <asp:ListItem Text="Right front quarter" Value="Right front quarter"></asp:ListItem>
                            <asp:ListItem Text="Right side" Value="Right side"></asp:ListItem>
                            <asp:ListItem Text="Right left quarter" Value="Right left quarter"></asp:ListItem>
                            <asp:ListItem Text="Rear" Value="Rear"></asp:ListItem>
                            <asp:ListItem Text="Left front quarter" Value="Left front quarter"></asp:ListItem>
                            <asp:ListItem Text="Left side" Value="Left side"></asp:ListItem>
                            <asp:ListItem Text="Left rear quarter" Value="Left rear quarter"></asp:ListItem>
                            <asp:ListItem Text="Top" Value="Top"></asp:ListItem>
                            <asp:ListItem Text="Undercarriage" Value="Undercarriage"></asp:ListItem>
                            <asp:ListItem Text="Other-explain" Value="Other-explain"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_driver_injured_text")%>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblPublicDriverInjured" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPublicDriverInjured" runat="server" Style="display: none;" CssClass="textbox_width"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_passenger_injured_text")%>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblPublicPassengerInjured" RepeatDirection="Horizontal"
                                        runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPublicPassengerInjured" runat="server" Style="display: none;"
                                        CssClass="textbox_width"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_number_total_vehicle_occupant_injuries_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalvehicleOccupant" runat="server" CssClass="textbox_width"></asp:TextBox>
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
            <%=LocalResources.GetLabel("app_description_public_vehicle_damage_text")%>:
            <div class="right div_padding_10">
                <asp:ImageButton OnClientClick="expandDetailsPublicVehicleDamageDesc(this);return false;"
                    runat="server" ID="imgpublicdamage" ImageUrl="~/Images/addplus-sm.gif" />
            </div>
        </div>
        <div class="div_controls font_1 msg_display" id="div_public_vehicle_damage" runat="server">
            <table>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_heavy_text")%>:
                    </td>
                    <td style="width: 800px;">
                        <textarea id="txtPublicHeavyDamage" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_moderate_text")%>:
                    </td>
                    <td colspan="5">
                        <textarea id="txtPublicModerateDamage" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_light_text")%>:
                    </td>
                    <td colspan="5">
                        <textarea id="txtPubliclightDamage" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_pedestrain_incident_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsPedestrain(this);return false;" runat="server"
                ID="imgPedestrain" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_controls font_1 msg_display" id="div_Pedestrain" runat="server">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_name_of_the_pedestrain_involved_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtNameofPedestrian" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_address_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtPedestrianAddress" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_phone_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtPedestrianPhone" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_sex_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtPedestrianSex" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_age_text")%>:
                    <asp:RegularExpressionValidator ID="revPedestrainAge" runat="server" ControlToValidate="txtPedestrainAge"
                        ErrorMessage="<%$ TextResourceExpression: app_pedestrain_age_error_wrong%>" ValidationExpression="^\d+$"
                        ValidationGroup="cemv">&nbsp;
                    </asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPedestrainAge" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_collision_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlPedestrainCollisionType" DataValueField=" " DataTextField=" "
                        runat="server" CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Rear-Ended other vehicle" Value="Rear-Ended other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rear-ended by other vehicle" Value="Rear-ended by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Hit vehicle head-on" Value="Hit vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="Hit by vehicle head-on" Value="Hit by vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="T-Boned other vehicle" Value="T-Boned other vehicle"></asp:ListItem>
                        <asp:ListItem Text="T-Boned by other vehicle" Value="T-Boned by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Backed into other vehicle/object" Value="Backed into other vehicle/object"></asp:ListItem>
                        <asp:ListItem Text="Backed into by other vehicle" Value="Backed into by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped other vehicle" Value="Sideswiped other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped by other vehicle" Value="Sideswiped by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Roll over" Value="Roll over"></asp:ListItem>
                        <asp:ListItem Text="Left roadway" Value="Left roadway"></asp:ListItem>
                        <asp:ListItem Text="Lane change" Value="Lane change"></asp:ListItem>
                        <asp:ListItem Text="Struck fixed object" Value="Struck fixed object"></asp:ListItem>
                        <asp:ListItem Text="Backed into fixed object" Value="Backed into fixed object"></asp:ListItem>
                        <asp:ListItem Text="Road hazard" Value="Road hazard"></asp:ListItem>
                        <asp:ListItem Text="Multi car pile up" Value="Multi car pile up"></asp:ListItem>
                        <asp:ListItem Text="Jack-knife" Value="Jack-knife"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_description_text")%>:
                </td>
                <td colspan="5">
                    <textarea id="txtPedestrianDescription" runat="server" class="txtInput_long" rows="3"
                        cols="100"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_bicycle_incident_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsBicycleIncident(this);return false;"
                runat="server" ID="imgBicycleIncident" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_controls font_1 msg_display" id="div_Bicycle_Incident" runat="server">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_name_person_involved_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtBicycleNameofPerson" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_address_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtBicyclePersonAddress" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_phone_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtBicyclePersonPhone" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_sex_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtBicyblePersonSex" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revBicycleAge" runat="server" ControlToValidate="txtBicycleAge"
                        ErrorMessage="<%$ TextResourceExpression: app_bicyle_person_age_error_wrong%>"
                        ValidationExpression="^\d+$" ValidationGroup="cemv">&nbsp;
                    </asp:RegularExpressionValidator>
                    <%=LocalResources.GetLabel("app_age_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtBicycleAge" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_collision_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBicycleCollisionType" DataValueField=" " DataTextField=" "
                        runat="server" CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Rear-Ended other vehicle" Value="Rear-Ended other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rear-ended by other vehicle" Value="Rear-ended by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Hit vehicle head-on" Value="Hit vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="Hit by vehicle head-on" Value="Hit by vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="T-Boned other vehicle" Value="T-Boned other vehicle"></asp:ListItem>
                        <asp:ListItem Text="T-Boned by other vehicle" Value="T-Boned by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Backed into other vehicle/object" Value="Backed into other vehicle/object"></asp:ListItem>
                        <asp:ListItem Text="Backed into by other vehicle" Value="Backed into by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped other vehicle" Value="Sideswiped other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped by other vehicle" Value="Sideswiped by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Roll over" Value="Roll over"></asp:ListItem>
                        <asp:ListItem Text="Left roadway" Value="Left roadway"></asp:ListItem>
                        <asp:ListItem Text="Lane change" Value="Lane change"></asp:ListItem>
                        <asp:ListItem Text="Struck fixed object" Value="Struck fixed object"></asp:ListItem>
                        <asp:ListItem Text="Backed into fixed object" Value="Backed into fixed object"></asp:ListItem>
                        <asp:ListItem Text="Road hazard" Value="Road hazard"></asp:ListItem>
                        <asp:ListItem Text="Multi car pile up" Value="Multi car pile up"></asp:ListItem>
                        <asp:ListItem Text="Jack-knife" Value="Jack-knife"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_description_text")%>:
                </td>
                <td colspan="5">
                    <textarea id="txtBicycleIncidentDesc" runat="server" class="txtInput_long" rows="3"
                        cols="100"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_animal_incident_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsAnimalIncident(this);return false;"
                runat="server" ID="imganimalincident" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_controls font_1 msg_display" id="div_animal_incident" runat="server">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_name_of_animal_involved_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtAnimalName" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_place_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtPlace" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_collision_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlAnimalCollisionType" DataValueField=" " DataTextField=" "
                        runat="server" CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Rear-Ended other vehicle" Value="Rear-Ended other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rear-ended by other vehicle" Value="Rear-ended by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Hit vehicle head-on" Value="Hit vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="Hit by vehicle head-on" Value="Hit by vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="T-Boned other vehicle" Value="T-Boned other vehicle"></asp:ListItem>
                        <asp:ListItem Text="T-Boned by other vehicle" Value="T-Boned by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Backed into other vehicle/object" Value="Backed into other vehicle/object"></asp:ListItem>
                        <asp:ListItem Text="Backed into by other vehicle" Value="Backed into by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped other vehicle" Value="Sideswiped other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped by other vehicle" Value="Sideswiped by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Roll over" Value="Roll over"></asp:ListItem>
                        <asp:ListItem Text="Left roadway" Value="Left roadway"></asp:ListItem>
                        <asp:ListItem Text="Lane change" Value="Lane change"></asp:ListItem>
                        <asp:ListItem Text="Struck fixed object" Value="Struck fixed object"></asp:ListItem>
                        <asp:ListItem Text="Backed into fixed object" Value="Backed into fixed object"></asp:ListItem>
                        <asp:ListItem Text="Road hazard" Value="Road hazard"></asp:ListItem>
                        <asp:ListItem Text="Multi car pile up" Value="Multi car pile up"></asp:ListItem>
                        <asp:ListItem Text="Jack-knife" Value="Jack-knife"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_description_text")%>:
                </td>
                <td colspan="5">
                    <textarea id="txtAnimalDescription" runat="server" class="txtInput_long" rows="3"
                        cols="100"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_fixed_object_incident_text")%>:
        <div class="right div_padding_10">
            <asp:ImageButton OnClientClick="expandDetailsFixedObjectIncident(this);return false;"
                runat="server" ID="imgfixedobject" ImageUrl="~/Images/addplus-sm.gif" />
        </div>
    </div>
    <br />
    <div class="div_controls font_1 msg_display" id="div_fixed_object_incident" runat="server">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_property_owner_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtPropertyOwner" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_address_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtPropertyAddress" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_contact_information_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtContactInformation" runat="server" CssClass="textbox_width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_collision_type_text")%>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlPropertyCollisionType" DataValueField=" " DataTextField=" "
                        runat="server" CssClass="ddl_user_advanced_search">
                        <asp:ListItem Text="Rear-Ended other vehicle" Value="Rear-Ended other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Rear-ended by other vehicle" Value="Rear-ended by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Hit vehicle head-on" Value="Hit vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="Hit by vehicle head-on" Value="Hit by vehicle head-on"></asp:ListItem>
                        <asp:ListItem Text="T-Boned other vehicle" Value="T-Boned other vehicle"></asp:ListItem>
                        <asp:ListItem Text="T-Boned by other vehicle" Value="T-Boned by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Backed into other vehicle/object" Value="Backed into other vehicle/object"></asp:ListItem>
                        <asp:ListItem Text="Backed into by other vehicle" Value="Backed into by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped other vehicle" Value="Sideswiped other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Sideswiped by other vehicle" Value="Sideswiped by other vehicle"></asp:ListItem>
                        <asp:ListItem Text="Roll over" Value="Roll over"></asp:ListItem>
                        <asp:ListItem Text="Left roadway" Value="Left roadway"></asp:ListItem>
                        <asp:ListItem Text="Lane change" Value="Lane change"></asp:ListItem>
                        <asp:ListItem Text="Struck fixed object" Value="Struck fixed object"></asp:ListItem>
                        <asp:ListItem Text="Backed into fixed object" Value="Backed into fixed object"></asp:ListItem>
                        <asp:ListItem Text="Road hazard" Value="Road hazard"></asp:ListItem>
                        <asp:ListItem Text="Multi car pile up" Value="Multi car pile up"></asp:ListItem>
                        <asp:ListItem Text="Jack-knife" Value="Jack-knife"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_description_text")%>:
                </td>
                <td colspan="5">
                    <textarea id="txtPropertyDesc" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <%=LocalResources.GetLabel("app_physical_description_of_property_text")%>:
                </td>
                <td colspan="5">
                    <textarea id="txtPhysicalPropertyDesc" runat="server" class="txtInput_long" rows="3"
                        cols="100"></textarea>
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
        <%=LocalResources.GetLabel("app_additional_Information_text")%>:
    </div>
    <br />
    <div class="div_controls_from_left">
        <table>
            <tr>
                <td valign="top" class="font_1">
                    <%=LocalResources.GetLabel("app_witness(es)_text")%>:
                </td>
                <td class="align_left" valign="top">
                    <asp:Button ID="btnAddWitness" runat="server" OnClientClick="Showpopup(this.id);"
                        CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_witness_button_text%>" />
                </td>
            </tr>
        </table>
    </div>
    <div class="div_padding_135">
        <asp:GridView ID="gvAddWitness" GridLines="None" CssClass="grid_table_850" CellPadding="0"
            CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_name,c_contact_info,c_witness_id_pk"
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
                        <%=LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                            <%#Eval("c_name") %></b>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                    ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%=LocalResources.GetLabel("app_contact_information_text")%>:&nbsp;&nbsp; &nbsp;
                        <b>
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
                    <%=LocalResources.GetLabel("app_police_reports(s)_text")%>:
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
            CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_police_report_id_pk"
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
                    <%=LocalResources.GetLabel("app_photo(s)_text")%>:
                </td>
                <td class="align_left" valign="top">
                    <asp:Button ID="btnAddPhoto" OnClientClick="Showpopup(this.id);" runat="server" CssClass="cursor_hand"
                        Text="<%$ LabelResourceExpression: app_add_photo_button_text%>" />
                </td>
            </tr>
        </table>
    </div>
    <div class="div_padding_135">
        <asp:GridView ID="gvPhoto" GridLines="None" CssClass="grid_table_850" CellPadding="0"
            CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_photo_id_pk"
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
                    <%=LocalResources.GetLabel("app_scene_sketch(es)_text")%>:
                </td>
                <td valign="top">
                    <asp:Button ID="btnAddSceneSketch" OnClientClick="Showpopup(this.id);" runat="server"
                        Text="<%$ LabelResourceExpression: app_add_scene_sketch_text%>" CssClass="cursor_hand" />
                </td>
            </tr>
        </table>
    </div>
    <div class="div_padding_135">
        <asp:GridView ID="gvSceneSketch" GridLines="None" CssClass="grid_table_850" CellPadding="0"
            CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_scene_sketch_id_pk"
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
                    :
                </td>
                <td valign="top">
                    <asp:Button ID="btnAddExtenuatingCondition" OnClientClick="Showpopup(this.id);" runat="server"
                        Text="<%$ LabelResourceExpression: app_add_extenuating_condition_button_text%>"
                        CssClass="cursor_hand" />
                </td>
            </tr>
        </table>
    </div>
    <div class="div_padding_135">
        <asp:GridView ID="gvExtenuatingcondition" GridLines="None" CssClass="grid_table_850"
            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_name,c_contact_info,c_extenauting_id_pk"
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
                        <%=LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                            <%#Eval("c_name") %></b>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                    ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%=LocalResources.GetLabel("app_contact_information_text")%>
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
                            runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
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
                    :
                </td>
                <td valign="top">
                    <asp:Button ID="btnAddEmployeeInterview" OnClientClick="Showpopup(this.id);" runat="server"
                        Text="<%$ LabelResourceExpression: app_add_employee_interview_button_text%>"
                        CssClass="cursor_hand" />
                </td>
            </tr>
        </table>
    </div>
    <div class="div_padding_135">
        <asp:GridView ID="gvEmployeeInterview" GridLines="None" CssClass="grid_table_850"
            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name,c_name,c_contact_info,c_employee_interivew_id_pk"
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
                        <%=LocalResources.GetLabel("app_name_text")%>:&nbsp;&nbsp; &nbsp; <b>
                            <%#Eval("c_name") %></b>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="width_300" ItemStyle-HorizontalAlign="Left"
                    ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%=LocalResources.GetLabel("app_contact_information_text")%>:&nbsp;&nbsp; &nbsp;
                        <b>
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
                            runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_root_cause_analysis_infornation_text")%>
        :
    </div>
    <br />
    <div class="div_long_textbox  font_1">
        <%=LocalResources.GetLabel("app_root_cause_analysis_details_text")%>
        :
        <br />
        <br />
        <asp:TextBox ID="txtRootCauseAnalysisDetails" Rows="5" cols="125" runat="server"
            CssClass="textarea_long_width" TextMode="MultiLine"></asp:TextBox>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_corrective_action_information_text")%>:
    </div>
    <br />
    <div class="div_long_textbox font_1">
        <%=LocalResources.GetLabel("app_corrective_action_details_text")%>:
        <br />
        <br />
        <asp:TextBox ID="txtCorrectiveActionDetails" Rows="5" cols="125" runat="server" CssClass="textarea_long_width"
            TextMode="MultiLine"></asp:TextBox>
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_corrective_action_details_text")%>:
    </div>
    <br />
    <div class="div_controls font_1">
        <table>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_custom_01_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom01" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_02_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom02" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_03_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom03" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_custom_04_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom04" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_05_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom05" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_06_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom06" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_custom_07_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom07" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_08_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom08" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_09_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom09" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_custom_10_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom10" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_11_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom11" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%=LocalResources.GetLabel("app_custom_12_text")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtCustom12" CssClass="textbox_width" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%=LocalResources.GetLabel("app_custom_13_text")%>:
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
                    <asp:Button ID="btnSaveNewCase_footer" ValidationGroup="cemv" CssClass="cursor_hand"
                        Text="<%$ LabelResourceExpression: app_save_button_text %>" runat="server" OnClick="btnSaveCase_footer_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnFooterCompleteCase" OnClientClick="return ConfirmComplete();"
                        runat="server" Text="<%$ LabelResourceExpression: app_complete_case_button_text %>"
                        OnClick="btnFooterCompleteCase_Click" ValidationGroup="cemv" CssClass="cursor_hand" />
                </td>
                <td align="center">
                    <asp:Button ID="btnViewCase_footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_view_case_description_button_text %>" />
                </td>
                <td align="left">
                    <asp:Button ID="btnReset_Footer" CssClass="cursor_hand" runat="server" OnClick="btnResetFooter_Click"
                        Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                </td>
                <td align="right">
                    <asp:Button ID="btnCancel_footer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                        OnClick="btnCancel_footer_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
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
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload" Style="display: none;
            padding-left: 0px; background-color: White; padding-right: 0px;">
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
                        ValidationGroup="cemvfileupload" />
                    <asp:CustomValidator ValidationGroup="cemvfileupload" ID="cvFileUpload" runat="server"
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
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="460" size="60" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="multiple_button">
                        <asp:Button ID="btnUploadWitness" ValidationGroup="cemvfileupload" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            OnClick="btnUploadWitness_Click" CssClass="cursor_hand" />
                        <asp:Button ID="btnUploadPhoto" ValidationGroup="cemvfileupload" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            OnClick="btnUploadPhoto_Click" CssClass="cursor_hand" />
                        <asp:Button ID="btnUploadPolice" ValidationGroup="cemvfileupload" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            OnClick="btnUploadPolice_Click" CssClass="cursor_hand" />
                        <asp:Button ID="btnUploadSceneSketch" ValidationGroup="cemvfileupload" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            OnClick="btnUploadSceneSketch_Click" CssClass="cursor_hand" />
                        <asp:Button ID="btnUploadExtenautingcond" ValidationGroup="cemvfileupload" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            OnClick="btnUploadExtenautingcond_Click" CssClass="cursor_hand" />
                        <asp:Button ID="btnUploadEmployeeInterview" ValidationGroup="cemvfileupload" Style="display: none;"
                            runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                            OnClick="btnUploadEmployeeInterview_Click" CssClass="cursor_hand" />
                    </div>
                    <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                </div>
                <br />
            </div>
        </asp:Panel>
        <asp:Button ID="btnpnlCompleteCase" runat="server" Style="display: none;" />
        <div class="font_normal">
            <asp:Panel ID="pnlCompleteCase" runat="server" CssClass="modalPopup_width_620" Style="display: none;
                padding-left: 0px; background-color: White; padding-right: 0px;">
                <asp:Panel ID="pnlCompleteCasePageHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_620">
                            <%=LocalResources.GetLabel("app_select_approver_for_complete_case_text")%>:
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
                            Text="Submit" />
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
</asp:Content>
