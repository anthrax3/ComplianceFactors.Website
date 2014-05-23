<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="coi-01.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ComplicanceFactor.Compliance.MIRIS.coi_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Src="~/Compliance/MIRIS/Controls/uccb-01.ascx" TagPrefix="uc1" TagName="uccb1" %>
<%@ Register Src="Controls/urc-01.ascx" TagName="urc" TagPrefix="uc1" %>
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
            $("#btnAddEstablishment").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 950,
                'height': 250,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../../SystemHome/Configuration/Establishment/Popup/saanen-01.aspx',
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
            $("#<%=txtIncidentDate.ClientID%>").change(function () {

                $("#<%=lblDateofIncident.ClientID%>").html($("#<%=txtIncidentDate.ClientID%>").val());
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

            else if (clicked_id == "ContentPlaceHolder1_btnAddEmployeeStatement") {


                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Statement:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "ContentPlaceHolder1_btnAddPolicies") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Policies/Procedures:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "ContentPlaceHolder1_btnAddTrainigHistory") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Training History:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "ContentPlaceHolder1_btnAddObservation") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Observation:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "ContentPlaceHolder1_btnAddIncidentHistory") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "inline";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Incident History:";
                document.getElementById('divInfo').style.display = "none";
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

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

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

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

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

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";


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

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

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

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

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

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Interview:";
                document.getElementById('divInfo').style.display = "inline";
            }

            else if (clicked_id == "employeestatement") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Employee Statement:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "policies") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Policies/Procedures:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "traininghistory") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Training History:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "observation") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "none";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Observation:";
                document.getElementById('divInfo').style.display = "none";
            }

            else if (clicked_id == "incidenthistory") {

                document.getElementById('<%=btnUploadWitness.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPhoto.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolice.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadSceneSketch.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadExtenautingcond.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadEmployeeInterview.ClientID%>').style.display = "none";

                document.getElementById('<%=btnUploadEmployeeStatement.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadPolicies.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadTrainingHistory.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadObservation.ClientID%>').style.display = "none";
                document.getElementById('<%=btnUploadIncidentHistory.ClientID%>').style.display = "inline";

                document.getElementById('<%=lblHeading.ClientID%>').innerHTML = "Add Incident History:";
                document.getElementById('divInfo').style.display = "none";
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
        function ConfirmReset() {
            if (confirm('Are you sure you want to reset.?') == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function ConfirmCancel() {
            if (confirm('Are you sure you want to cancel.?') == true) {
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
        function ShowContributingFactors() {
            var selectedvalue = document.getElementById('<%=ddlContributingFactors.ClientID %>');

            if (selectedvalue.value == "Tools/Equipment/Vehicles") {

                document.getElementById('<%=ddlObject2.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject3.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject4.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject5.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObjects6.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject1.ClientID%>').style.display = "inline";
            }

            if (selectedvalue.value == "Weather Related/Surface Conditions") {

                document.getElementById('<%=ddlObject1.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject3.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject4.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject5.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObjects6.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject2.ClientID%>').style.display = "inline";
            }

            if (selectedvalue.value == "Insects/Animal/Plants") {
                //alert(selectedvalue);
                document.getElementById('<%=ddlObject2.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject1.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject4.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject5.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObjects6.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject3.ClientID%>').style.display = "inline";
            }

            if (selectedvalue.value == "Facilities/Facility Equipment or Furnishings") {
                //alert(selectedvalue);
                document.getElementById('<%=ddlObject2.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject1.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject3.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject5.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObjects6.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject4.ClientID%>').style.display = "inline";
            }

            if (selectedvalue.value == "Air Quality/Hazardous Substances") {
                //alert(selectedvalue);
                document.getElementById('<%=ddlObject2.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject1.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject4.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject3.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObjects6.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject5.ClientID%>').style.display = "inline";
            }

            if (selectedvalue.value == "Misc") {
                //alert(selectedvalue);
                document.getElementById('<%=ddlObject2.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject1.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject4.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject5.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObject3.ClientID%>').style.display = "none";
                document.getElementById('<%=ddlObjects6.ClientID%>').style.display = "inline";
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
    <asp:ValidationSummary class="validation_summary_error" ID="vs_coi" runat="server"
        ValidationGroup="coi" />
    <asp:CustomValidator ID="cvDOB" runat="server" ErrorMessage="<%$ TextResourceExpression: app_date_of_birth_error_empty %>"
        ForeColor="Red" ValidationGroup="coi" OnServerValidate="cvDOB_ServerValidate"
        ClientValidationFunction="validateDOB">&nbsp;</asp:CustomValidator>
    <asp:CustomValidator ID="cvHireDate" runat="server" ErrorMessage="<%$ TextResourceExpression: app_emp_hire_date_error_empty %>"
        ForeColor="Red" ValidationGroup="coi" ClientValidationFunction="validateHireDate">&nbsp;</asp:CustomValidator>
    <div id="success_msg" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        <%=LocalResources.GetText("app_date_not_updated_error_wrong")%>
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="controls_long">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnSavenewcase_header" ValidationGroup="coi" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_new_case_button_text %>" runat="server"
                            OnClick="btnSavenewcase_header_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderCompleteCase" OnClientClick="return ConfirmComplete();"
                            runat="server" Text="<%$ LabelResourceExpression: app_complete_case_button_text %>"
                            OnClick="btnHeaderCompleteCase_Click" ValidationGroup="coi" CssClass="cursor_hand" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnReset_Header" CssClass="cursor_hand" OnClientClick="return ConfirmReset();" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>"
                            OnClick="btnReset_Header_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCancel_header" CssClass="cursor_hand" runat="server" OnClientClick="return ConfirmCancel();" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
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
                        <asp:RequiredFieldValidator ID="rfvCaseTitle" runat="server" ValidationGroup="coi"
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
                            AutoPostBack="true" CssClass="ddl_user_advanced_search" runat="server" OnSelectedIndexChanged="ddlCaseCategory_SelectedIndexChanged">
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
                    <td>
                        *
                        <%=LocalResources.GetLabel("app_case_types_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCaseTypes" DataValueField="c_type_id" DataTextField="c_type_name"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%--  <tr><uc1:uccb1 runat="server" id="uccb1" /></tr>--%>
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
                        <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ValidationGroup="cmv"
                            ControlToValidate="txtEmployeeName" ErrorMessage="<%$ TextResourceExpression: app_emp_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * First Name:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="textbox_width"></asp:TextBox>
                        <asp:Button ID="btnAddEmployee" runat="server" ValidationGroup="samcp_employee" CssClass="addEmployee cursor_hand"
                            Text="Select Employee" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="cmv"
                            ControlToValidate="txtLastName" ErrorMessage="<%$ TextResourceExpression: app_emp_name_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        * Last Name:
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
                        <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ValidationGroup="cmv"
                            ControlToValidate="txtEmployeeId" ErrorMessage="<%$ TextResourceExpression: app_emp_id_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_employee_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLastDigitofSSN" runat="server" ValidationGroup="cmv"
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
                        <asp:RequiredFieldValidator ID="rfvIncidentLocation" runat="server" ValidationGroup="cmv"
                            ControlToValidate="txtIncidentLocation" ErrorMessage="<%$ TextResourceExpression: app_incident_location_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_incident_location_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtIncidentLocation" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserIncidentDate" runat="server" ValidationGroup="cmv"
                            ControlToValidate="txtIncidentDate" ErrorMessage="<%$ TextResourceExpression: app_incident_date_error_empty %>">&nbsp;
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revIncidentDate" runat="server" ValidationGroup="cmv"
                            ControlToValidate="txtIncidentDate" ErrorMessage="<%$ TextResourceExpression: app_incident_date_format_error_empty %>"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                        <asp:CustomValidator ValidationGroup="cmv" ID="cvIncidentDate" runat="server" ErrorMessage="<%$ TextResourceExpression: app_fultue_date_error_wrong %>"
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
                            ErrorMessage="<%$ TextResourceExpression: app_incident_time_error_empty %>" ValidationGroup="cmv">&nbsp;</asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_incident_time_text")%>:
                    </td>
                    <td class="timer">
                        <MKB:TimeSelector ID="IncidentTime" MinuteIncrement="1" CssClass="timer" DisplaySeconds="false"
                            runat="server" Date="">
                        </MKB:TimeSelector>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployeeReportLocation" runat="server" ValidationGroup="cmv"
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="cmv"
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
                    <td>
                        <asp:RegularExpressionValidator ID="revTimeDateNotified" runat="server" ValidationGroup="coi"
                            ControlToValidate="txtTimeDateNotified" ErrorMessage="<%$ TextResourceExpression: app_notified_date_error_wrong %>"
                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$">
                            &nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_time_and_date_notified_text")%>:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceTimeDateNotified" Format="MM/dd/yyyy" TargetControlID="txtTimeDateNotified"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtTimeDateNotified" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_job_title_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtJobTitle" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_dept_code_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtDepartmentCode" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 0px;">
                            <tr>
                                <td class="align_right">
                                    <%=LocalResources.GetLabel("app_privacy_case_text")%>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblPrivacyCase" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_location_description_text")%>:
                    </td>
                    <td colspan="5">
                        <textarea id="txtLocationDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_brief_description_of_incident_text")%>:
                    </td>
                    <td colspan="5">
                        <textarea id="txtIncidentDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_injury_illness_complaint_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtInjuryCompliant" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_injury_illness_type_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlInjuryType" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            runat="server">
                            <asp:ListItem Text="Multiple Body Parts Injured" Value="Multiple Body Parts Injured"></asp:ListItem>
                            <asp:ListItem Text="Bone, Muscle or Ligment" Value="Bone, Muscle or Ligment"></asp:ListItem>
                            <asp:ListItem Text="Skin Diseases or Disorders" Value="Skin Diseases or Disorders"></asp:ListItem>
                            <asp:ListItem Text="Skin Injury" Value="Skin Injury"></asp:ListItem>
                            <asp:ListItem Text="Eye Injury" Value="Eye Injury"></asp:ListItem>
                            <asp:ListItem Text="Heart Condition/Heart Attack" Value="Heart Condition/Heart Attack"></asp:ListItem>
                            <asp:ListItem Text="Head Injury" Value="Head Injury"></asp:ListItem>
                            <asp:ListItem Text="Asphyxiation" Value="Asphyxiation"></asp:ListItem>
                            <asp:ListItem Text="Drowning/Near Drowning" Value="Drowning/Near Drowning"></asp:ListItem>
                            <asp:ListItem Text="Poisoning" Value="Poisoning"></asp:ListItem>
                            <asp:ListItem Text="Respiratory/Lung Condition" Value="Respiratory/Lung Condition"></asp:ListItem>
                            <asp:ListItem Text="Hearing Loss/Impairment" Value="Hearing Loss/Impairment"></asp:ListItem>
                            <asp:ListItem Text="Amputation" Value="Amputation"></asp:ListItem>
                            <asp:ListItem Text="Job Related Stress" Value="Job Related Stress"></asp:ListItem>
                            <asp:ListItem Text="Non-Job Related Stress" Value="Non-Job Related Stress"></asp:ListItem>
                            <asp:ListItem Text="Electrical Shock/Electrocution" Value="Electrical Shock/Electrocution"></asp:ListItem>
                            <asp:ListItem Text="Reptile/Insect Bite" Value="Reptile/Insect Bite"></asp:ListItem>
                            <asp:ListItem Text="Weather/Temperature Related" Value="Weather/Temperature Related"></asp:ListItem>
                            <asp:ListItem Text="Communicable Disease" Value="Communicable Disease"></asp:ListItem>
                            <asp:ListItem Text="All Other Injuries" Value="All Other Injuries"></asp:ListItem>
                            <asp:ListItem Text="All Other Illnesses" Value="All Other Illnesses"></asp:ListItem>
                            <asp:ListItem Text="Other - Not Job Related" Value="Other - Not Job Related"></asp:ListItem>
                            <asp:ListItem Text="Records Only" Value="Records Only"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_injury_illness_cause_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlInjuryCause" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            runat="server">
                            <asp:ListItem Text="Struck by" Value="Struck by"></asp:ListItem>
                            <asp:ListItem Text="Struck Against" Value="Struck Against"></asp:ListItem>
                            <asp:ListItem Text="Caught In/Under/Between" Value="Caught In/Under/Between"></asp:ListItem>
                            <asp:ListItem Text="Rubbed/Scraped or Irritated" Value="Rubbed/Scraped or Irritated"></asp:ListItem>
                            <asp:ListItem Text="Slip/Trip/Fall" Value="Slip/Trip/Fall"></asp:ListItem>
                            <asp:ListItem Text="Contact Exposure" Value="Contact Exposure"></asp:ListItem>
                            <asp:ListItem Text="Body Mechanics/Movements/Activities" Value="Body Mechanics/Movements/Activities"></asp:ListItem>
                            <asp:ListItem Text="Assults/Houseplay/Fight" Value="Assults/Houseplay/Fight"></asp:ListItem>
                            <asp:ListItem Text="Motor Vehicle" Value="Motor Vehicle"></asp:ListItem>
                            <asp:ListItem Text="Animal/Insect Bite" Value="Animal/Insect Bite"></asp:ListItem>
                            <asp:ListItem Text="Acoustical Shock" Value="Acoustical Shock"></asp:ListItem>
                            <asp:ListItem Text="Allergies/Allergic Reation" Value="Allergies/Allergic Reation"></asp:ListItem>
                            <asp:ListItem Text="Radiation Exposure" Value="Radiation Exposure"></asp:ListItem>
                            <asp:ListItem Text="Mental Stress" Value="Mental Stress"></asp:ListItem>
                            <asp:ListItem Text="Non-Job Related" Value="Non-Job Related"></asp:ListItem>
                            <asp:ListItem Text="No Cause" Value="No Cause"></asp:ListItem>
                            <asp:ListItem Text="Misc" Value="Misc"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_contributing_factors_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlContributingFactors" CssClass="ddl_user_advanced_search"
                            OnChange="ShowContributingFactors();" runat="server">
                            <asp:ListItem Text="Tools/Equipment/Vehicles" Value="Tools/Equipment/Vehicles"></asp:ListItem>
                            <asp:ListItem Text="Weather Related/Surface Conditions" Value="Weather Related/Surface Conditions"></asp:ListItem>
                            <asp:ListItem Text="Insects/Animal/Plants" Value="Insects/Animal/Plants"></asp:ListItem>
                            <asp:ListItem Text="Facilities/Facility Equipment or Furnishings" Value="Facilities/Facility Equipment or Furnishings"></asp:ListItem>
                            <asp:ListItem Text="Air Quality/Hazardous Substances" Value="Air Quality/Hazardous Substances"></asp:ListItem>
                            <asp:ListItem Text="Misc" Value="Misc"></asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="txtContributingFactors" runat="server" CssClass="textbox_width"></asp:TextBox>--%>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_contributing_objects_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlObject1" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            Style="display: none;" runat="server">
                            <asp:ListItem Text="Ladders" Value=""></asp:ListItem>
                            <asp:ListItem Text="Tools and Equipment" Value=""></asp:ListItem>
                            <asp:ListItem Text="Vehicle" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlObject2" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            Style="display: none;" runat="server">
                            <asp:ListItem Text="Weather" Value=""></asp:ListItem>
                            <asp:ListItem Text="Natural Disasters" Value=""></asp:ListItem>
                            <asp:ListItem Text="Surfaces" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlObject3" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            Style="display: none;" runat="server">
                            <asp:ListItem Text="Insects" Value=""></asp:ListItem>
                            <asp:ListItem Text="Animal" Value=""></asp:ListItem>
                            <asp:ListItem Text="Plants" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlObject4" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            Style="display: none;" runat="server">
                            <asp:ListItem Text="Building Components" Value=""></asp:ListItem>
                            <asp:ListItem Text="Components/Equipment" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlObject5" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            Style="display: none;" runat="server">
                            <asp:ListItem Text="Air Quality" Value=""></asp:ListItem>
                            <asp:ListItem Text="Hazardous Substances" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlContributingObjects" DataTextField="" DataValueField=""
                            CssClass="ddl_user_advanced_search" Style="display: none;" runat="server">
                            <asp:ListItem Text="Step" Value="Step"></asp:ListItem>
                            <asp:ListItem Text="Fixed" Value="Fixed"></asp:ListItem>
                            <asp:ListItem Text="Rolling" Value="Rolling"></asp:ListItem>
                            <asp:ListItem Text="Extension -16'" Value="Extension -16'"></asp:ListItem>
                            <asp:ListItem Text="Extension -24'" Value="Extension -24'"></asp:ListItem>
                            <asp:ListItem Text="Extension -28'" Value="Extension -28'"></asp:ListItem>
                            <asp:ListItem Text="Extension -32'" Value="Extension -32'"></asp:ListItem>
                            <asp:ListItem Text="Extension ->32'" Value="Extension ->32'"></asp:ListItem>
                            <asp:ListItem Text="Powered" Value="Powered"></asp:ListItem>
                            <asp:ListItem Text="Scaffolding" Value="Scaffolding"></asp:ListItem>
                            <asp:ListItem Text="Hand Tools" Value="Hand Tools"></asp:ListItem>
                            <asp:ListItem Text="Handled Power Tools" Value="Handled Power Tools"></asp:ListItem>
                            <asp:ListItem Text="Pneumatic" Value="Pneumatic"></asp:ListItem>
                            <asp:ListItem Text="Hydraulic" Value="Hydraulic"></asp:ListItem>
                            <asp:ListItem Text="Electric" Value="Electric"></asp:ListItem>
                            <asp:ListItem Text="Machine Mounted Tools" Value="Machine Mounted Tools"></asp:ListItem>
                            <asp:ListItem Text="Mobile Machinary/Equipment" Value="Mobile Machinary/Equipment"></asp:ListItem>
                            <asp:ListItem Text="Company Car" Value="Company Car"></asp:ListItem>
                            <asp:ListItem Text="Company Light Track" Value="Company Light Track"></asp:ListItem>
                            <asp:ListItem Text="Company Van" Value="Company Van"></asp:ListItem>
                            <asp:ListItem Text="Leased Car" Value="Leased Car"></asp:ListItem>
                            <asp:ListItem Text="Leased Truck" Value="Leased Truck"></asp:ListItem>
                            <asp:ListItem Text="Leased Van" Value="Leased Van"></asp:ListItem>
                            <asp:ListItem Text="Personal Vehicle" Value="Personal Vehicle"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlContributingObjects1" DataTextField="" DataValueField=""
                            CssClass="ddl_user_advanced_search" Style="display: none;" runat="server">
                            <asp:ListItem Text="Snow" Value="Snow"></asp:ListItem>
                            <asp:ListItem Text="Ice" Value="Ice"></asp:ListItem>
                            <asp:ListItem Text="Hail" Value="Hail"></asp:ListItem>
                            <asp:ListItem Text="Rain" Value="Rain"></asp:ListItem>
                            <asp:ListItem Text="Mud" Value="Mud"></asp:ListItem>
                            <asp:ListItem Text="Wind" Value="Wind"></asp:ListItem>
                            <asp:ListItem Text="Extreme Heat" Value="Extreme Heat"></asp:ListItem>
                            <asp:ListItem Text="Extreme Cold" Value="Extreme Cold"></asp:ListItem>
                            <asp:ListItem Text="Flooding" Value="Flooding"></asp:ListItem>
                            <asp:ListItem Text="Tornado" Value="Tornado"></asp:ListItem>
                            <asp:ListItem Text="Hurricane" Value="Hurricane"></asp:ListItem>
                            <asp:ListItem Text="Earth Quake" Value="Earth Quake"></asp:ListItem>
                            <asp:ListItem Text="Wild Fire" Value="Wild Fire"></asp:ListItem>
                            <asp:ListItem Text="Volcanic Activity" Value="Volcanic Activity"></asp:ListItem>
                            <asp:ListItem Text="Wet" Value="Wet"></asp:ListItem>
                            <asp:ListItem Text="Foreign Substance" Value="Foreign Substance"></asp:ListItem>
                            <asp:ListItem Text="UnEven" Value="UnEven"></asp:ListItem>
                            <asp:ListItem Text="Grass" Value="Grass"></asp:ListItem>
                            <asp:ListItem Text="Sloping" Value="Sloping"></asp:ListItem>
                            <asp:ListItem Text="Parking Lot" Value="Parking Lot"></asp:ListItem>
                            <asp:ListItem Text="Side Walk" Value="Side Walk"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlContributingObjects2" DataTextField="" DataValueField=""
                            CssClass="ddl_user_advanced_search" Style="display: none;" runat="server">
                            <asp:ListItem Text="Bee/Wasp/Hornet" Value="Bee/Wasp/Hornet"></asp:ListItem>
                            <asp:ListItem Text="Spiders" Value="Spiders"></asp:ListItem>
                            <asp:ListItem Text="Ants" Value="Ants"></asp:ListItem>
                            <asp:ListItem Text="Ticks" Value="Ticks"></asp:ListItem>
                            <asp:ListItem Text="Rodants" Value="Rodants"></asp:ListItem>
                            <asp:ListItem Text="Snakes/Reptiles" Value="Snakes/Reptiles"></asp:ListItem>
                            <asp:ListItem Text="Bats" Value="Bats"></asp:ListItem>
                            <asp:ListItem Text="Dogs" Value="Dogs"></asp:ListItem>
                            <asp:ListItem Text="Deer" Value="Deer"></asp:ListItem>
                            <asp:ListItem Text="Poisonous" Value="Poisonous"></asp:ListItem>
                            <asp:ListItem Text="Trees" Value="Trees"></asp:ListItem>
                            <asp:ListItem Text="Pollen" Value="Pollen"></asp:ListItem>
                            <asp:ListItem Text="Briars" Value="Briars"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlContributingObjects3" DataTextField="" DataValueField=""
                            CssClass="ddl_user_advanced_search" Style="display: none;" runat="server">
                            <asp:ListItem Text="StairWays" Value="StairWays"></asp:ListItem>
                            <asp:ListItem Text="Attic" Value="Attic"></asp:ListItem>
                            <asp:ListItem Text="Crawl Space" Value="Crawl Space"></asp:ListItem>
                            <asp:ListItem Text="Mechanical Space" Value="Mechanical Space"></asp:ListItem>
                            <asp:ListItem Text="Confined Space" Value="Confined Space"></asp:ListItem>
                            <asp:ListItem Text="Working Floor" Value="Working Floor"></asp:ListItem>
                            <asp:ListItem Text="Manufacturing Floor" Value="Manufacturing Floor"></asp:ListItem>
                            <asp:ListItem Text="Industrial Floor" Value="Industrial Floor"></asp:ListItem>
                            <asp:ListItem Text="Office/Admin area" Value="Office/Admin area"></asp:ListItem>
                            <asp:ListItem Text="Warehouse" Value="Warehouse"></asp:ListItem>
                            <asp:ListItem Text="Storage" Value="Storage"></asp:ListItem>
                            <asp:ListItem Text="Roof" Value="Roof"></asp:ListItem>
                            <asp:ListItem Text="Perimeter" Value="Perimeter"></asp:ListItem>
                            <asp:ListItem Text="Parking Lot" Value="Parking Lot"></asp:ListItem>
                            <asp:ListItem Text="Sidewalks" Value="Sidewalks"></asp:ListItem>
                            <asp:ListItem Text="Computer Equipment - Main" Value="Computer Equipment - Main"></asp:ListItem>
                            <asp:ListItem Text="Computer Equipment - Personal" Value="Computer Equipment - Personal"></asp:ListItem>
                            <asp:ListItem Text="Furniture/Desks" Value="Furniture/Desks"></asp:ListItem>
                            <asp:ListItem Text="Cubicles/Partitions" Value="Cubicles/Partitions"></asp:ListItem>
                            <asp:ListItem Text="Office Supplies" Value="Office Supplies"></asp:ListItem>
                            <asp:ListItem Text="Copiers/Printers/Fax" Value="Copiers/Printers/Fax"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlContributingObjects4" DataTextField="" DataValueField=""
                            CssClass="ddl_user_advanced_search" Style="display: none;" runat="server">
                            <asp:ListItem Text="Fresh Air Intake/Mixture" Value="Fresh Air Intake/Mixture"></asp:ListItem>
                            <asp:ListItem Text="Air Flow" Value="Air Flow"></asp:ListItem>
                            <asp:ListItem Text="O2/CO" Value="O2/CO"></asp:ListItem>
                            <asp:ListItem Text="Mold spores" Value="Mold spores"></asp:ListItem>
                            <asp:ListItem Text="Dust" Value="Dust"></asp:ListItem>
                            <asp:ListItem Text="Odors" Value="Odors"></asp:ListItem>
                            <asp:ListItem Text="Fumes/Smoke" Value="Fumes/Smoke"></asp:ListItem>
                            <asp:ListItem Text="Asbestos" Value="Asbestos"></asp:ListItem>
                            <asp:ListItem Text="Paints" Value="Paints"></asp:ListItem>
                            <asp:ListItem Text="Solvents" Value="Solvents"></asp:ListItem>
                            <asp:ListItem Text="Office Supplies" Value="Office Supplies"></asp:ListItem>
                            <asp:ListItem Text="Chemicals" Value="Chemicals"></asp:ListItem>
                            <asp:ListItem Text="Lead" Value="Lead"></asp:ListItem>
                            <asp:ListItem Text="Toxic Agents" Value="Toxic Agents"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlObjects6" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            Style="display: none;" runat="server">
                            <asp:ListItem Text="Weapons" Value="Weapons"></asp:ListItem>
                            <asp:ListItem Text="Machinary" Value="Machinary"></asp:ListItem>
                            <asp:ListItem Text="Sharp Objects" Value="Sharp Objects"></asp:ListItem>
                            <asp:ListItem Text="Hot Objects" Value="Hot Objects"></asp:ListItem>
                            <asp:ListItem Text="Cold Objects" Value="Cold Objects"></asp:ListItem>
                            <asp:ListItem Text="Falling Objects" Value="Falling Objects"></asp:ListItem>
                            <asp:ListItem Text="Moving Objects" Value="Moving Objects"></asp:ListItem>
                            <asp:ListItem Text="Noise" Value="Noise"></asp:ListItem>
                            <asp:ListItem Text="Fire" Value="Fire"></asp:ListItem>
                            <asp:ListItem Text="Electricity" Value="Electricity"></asp:ListItem>
                            <asp:ListItem Text="Lighting" Value="Lighting"></asp:ListItem>
                            <asp:ListItem Text="Clothing" Value="Clothing"></asp:ListItem>
                            <asp:ListItem Text="FootWear" Value="FootWear"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                        </asp:DropDownList>
                        <%-- <asp:TextBox ID="txtContributingObjects" runat="server" CssClass="textbox_width"></asp:TextBox>--%>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_severity_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlSeverity" DataTextField="" DataValueField="" CssClass="ddl_user_advanced_search"
                            runat="server">
                            <asp:ListItem Text="Near miss" Value="Near miss"></asp:ListItem>
                            <asp:ListItem Text="Incident without TX" Value="Incident without TX"></asp:ListItem>
                            <asp:ListItem Text="Medical Tx" Value="Medical Tx"></asp:ListItem>
                            <asp:ListItem Text="Restricted/Transferred" Value="Restricted/Transferred"></asp:ListItem>
                            <asp:ListItem Text="Other recordable" Value="Other recordable"></asp:ListItem>
                            <asp:ListItem Text="Records Only" Value="Records Only"></asp:ListItem>
                            <asp:ListItem Text="Non-Occupational" Value="Non-Occupational"></asp:ListItem>
                            <asp:ListItem Text="Fatality" Value="Fatality"></asp:ListItem>
                            <asp:ListItem Text="Fatality-Not job related" Value="Fatality-Not job related"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_hospital_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtHospital" runat="server" CssClass="textbox_width"></asp:TextBox>
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
            <%=LocalResources.GetLabel("app_additional_details_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_treatment_description_text")%>:
                    </td>
                    <td style="width: 800px;">
                        <textarea id="txtTreatmentdescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_work_status_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <%-- <td>
                        <%=LocalResources.GetLabel("app_dart_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDART" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>--%>
                    <td>
                        Date of Incident:
                    </td>
                    <td>
                        <asp:Label ID="lblDateofIncident" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_first_day_of_days_away_text")%>:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceFirstDayofDaysAway" Format="MM/dd/yyyy" TargetControlID="txtFirstDayofDaysAway"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtFirstDayofDaysAway" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_first_days_restricted_tranferred_text")%>:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceFirstdayRestrictedorTransferred" Format="MM/dd/yyyy"
                            TargetControlID="txtFirstdayRestrictedorTransferred" runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtFirstdayRestrictedorTransferred" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_esr_lwds_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEstLWDs" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_actual_lwd_and_osha_lwd_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtActualLWDandOSHA" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_actual_ld_and_osha_restricted_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtActualLDandOSHA" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_restricted_transferred_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_restricted_transferred_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRestrictedorTransferred" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_light_duty_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLightDuty" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_last_day_of_days_away_text")%>:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceLastDatDaysAway" Format="MM/dd/yyyy" TargetControlID="txtLastDatDaysAway"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtLastDatDaysAway" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_last_days_restricted_transferred_text")%>:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceLastDayRestrictedorTransferred" Format="MM/dd/yyyy" TargetControlID="txtLastDayRestrictedorTransferred"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtLastDayRestrictedorTransferred" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_est_ld_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEstLD" runat="server" CssClass="textbox_width"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Short Term Disability:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblShortTerm" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        Long Term Disability:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblLongTerm" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
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
            <%=LocalResources.GetLabel("app_additional_information_text")%>:
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
                        <%=LocalResources.GetLabel("app_extenuating_condition(s)_text")%>:
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
                        <%=LocalResources.GetLabel("app_employee_statement_text")%>:
                    </td>
                    <td class="align_left" valign="top">
                        <asp:Button ID="btnAddEmployeeStatement" OnClientClick="Showpopup(this.id);" runat="server"
                            CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_employee_statement_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvEmployeeStatement" GridLines="None" CssClass="grid_table_850"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvEmployeeStatement_RowCommand"
                OnRowEditing="gvEmployeeStatement_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewEmployeeStatement" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditEmployeeStatement" CommandName="Edit" OnClientClick="Showeditpopup('employeestatement');"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveEmployeeStatement" OnClientClick="return confirmremove();"
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
                        <%=LocalResources.GetLabel("app_policies_procedures_text")%>:
                    </td>
                    <td class="align_left" valign="top">
                        <asp:Button ID="btnAddPolicies" OnClientClick="Showpopup(this.id);" runat="server"
                            CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_policies_procedures_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvPolicies" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvPolicies_RowCommand"
                OnRowEditing="gvPolicies_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewPolicies" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditPolicies" CommandName="Edit" OnClientClick="Showeditpopup('policies');"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemovePolicies" OnClientClick="return confirmremove();" CommandName="Remove"
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
                        <%=LocalResources.GetLabel("app_training_history_text")%>:
                    </td>
                    <td class="align_left" valign="top">
                        <asp:Button ID="btnAddTrainigHistory" OnClientClick="Showpopup(this.id);" runat="server"
                            CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_training_history_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvTrainingHistory" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvTrainingHistory_RowCommand"
                OnRowEditing="gvTrainingHistory_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewTrainingHistory" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditTrainingHistory" CommandName="Edit" OnClientClick="Showeditpopup('traininghistory');"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveTrainingHistory" OnClientClick="return confirmremove();"
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
                        <%=LocalResources.GetLabel("app_observation_text")%>:
                    </td>
                    <td class="align_left" valign="top">
                        <asp:Button ID="btnAddObservation" OnClientClick="Showpopup(this.id);" runat="server"
                            CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_observation_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvObservation" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvObservation_RowCommand"
                OnRowEditing="gvObservation_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewObservation" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditObservation" CommandName="Edit" OnClientClick="Showeditpopup('observation');"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveObservation" OnClientClick="return confirmremove();" CommandName="Remove"
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
                        <%=LocalResources.GetLabel("app_incident_history_text")%>:
                    </td>
                    <td class="align_left" valign="top">
                        <asp:Button ID="btnAddIncidentHistory" OnClientClick="Showpopup(this.id);" runat="server"
                            CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_incident_history_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_padding_135">
            <asp:GridView ID="gvIncidentHistory" GridLines="None" CssClass="grid_table_850" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_file_guid,c_file_name"
                runat="server" AutoGenerateColumns="False" OnRowCommand="gvIncidentHistory_RowCommand"
                OnRowEditing="gvIncidentHistory_RowEditing">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_740" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text='<%#Eval("c_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnViewIncidentHistory" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_view_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEditIncidentHistory" CommandName="Edit" OnClientClick="Showeditpopup('incidenthistory');"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                Text="<%$ LabelResourceExpression: app_edit_button_text %>" CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnRemoveIncidentHistory" OnClientClick="return confirmremove();"
                                CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>"
                                CssClass="cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>:
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
        <uc1:urc ID="urc1" runat="server" />
        <div class="div_header_long">
            <br />
        </div>
        <br />
        <div class="label_required_field">
            *
            <%=LocalResources.GetLabel("app_required_fields_text")%>
        </div>
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="controls_long">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnSaveNewCase_footer" ValidationGroup="coi" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_new_case_button_text %>" runat="server"
                            OnClick="btnSaveNewCase_footer_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterCompleteCase" OnClientClick="return ConfirmComplete();"
                            runat="server" Text="<%$ LabelResourceExpression: app_complete_case_button_text %>"
                            OnClick="btnFooterCompleteCase_Click" ValidationGroup="coi" CssClass="cursor_hand" />
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
            <asp:ModalPopupExtender ID="mpeEmployeeStatement" runat="server" TargetControlID="btnAddEmployeeStatement"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpePolicies" runat="server" TargetControlID="btnAddPolicies"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeTrainingHistory" runat="server" TargetControlID="btnAddTrainigHistory"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeObservation" runat="server" TargetControlID="btnAddObservation"
                PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
                PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
                OnCancelScript="cleartext();" CancelControlID="btnCancel">
            </asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="mpeIncidentHistory" runat="server" TargetControlID="btnAddIncidentHistory"
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
            <asp:HiddenField ID="hdEmployeeStatement" runat="server" />
            <asp:HiddenField ID="hdPolicies" runat="server" />
            <asp:HiddenField ID="hdTrainingHistory" runat="server" />
            <asp:HiddenField ID="hdObservation" runat="server" />
            <asp:HiddenField ID="hdIncidentHistory" runat="server" />
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
                            ValidationGroup="coifileupload" />
                        <asp:CustomValidator ValidationGroup="coifileupload" ID="cvFileUpload" runat="server"
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
                            <asp:Button ID="btnUploadWitness" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadWitness_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadPhoto" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadPhoto_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadPolice" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadPolice_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadSceneSketch" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadSceneSketch_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadExtenautingcond" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadExtenautingcond_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadEmployeeInterview" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                OnClick="btnUploadEmployeeInterview_Click" CssClass="cursor_hand" />
                            <asp:Button ID="btnUploadEmployeeStatement" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                CssClass="cursor_hand" OnClick="btnUploadEmployeeStatement_Click" />
                            <asp:Button ID="btnUploadPolicies" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                CssClass="cursor_hand" OnClick="btnUploadPolicies_Click" />
                            <asp:Button ID="btnUploadTrainingHistory" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                CssClass="cursor_hand" OnClick="btnUploadTrainingHistory_Click" />
                            <asp:Button ID="btnUploadObservation" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                CssClass="cursor_hand" OnClick="btnUploadObservation_Click" />
                            <asp:Button ID="btnUploadIncidentHistory" ValidationGroup="coifileupload" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text %>"
                                CssClass="cursor_hand" OnClick="btnUploadIncidentHistory_Click" />
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
    </div>
    <%--<div class="div_header_long">
            Advanced Search for MIRIS:
        </div>
        <br />--%>
</asp:Content>
