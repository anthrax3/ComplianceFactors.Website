<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saanc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.saanc_01"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
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
        function lastEquivalenciesrow() {

            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
        }

    </script>
    <script language="javascript" type="text/javascript">

        function cleartext() {

            document.getElementById('<%=hdAttachments.ClientID %>').value = '';
            var oFileUpload = document.getElementsByName('<%=FileUpload1.UniqueID%>')[0];
            oFileUpload.value = "";
            var oFileUpload2 = oFileUpload.cloneNode(false);
            oFileUpload2.onchange = oFileUpload.onchange;
            oFileUpload.parentNode.replaceChild(oFileUpload2, oFileUpload);


        }
    </script>
    <script type="text/javascript">


        function clearRadioButtonList() {

            var elementRef = document.getElementById('<%= rbtnDate.ClientID %>');
            var inputElementArray = elementRef.getElementsByTagName('input');

            for (var i = 0; i < inputElementArray.length; i++) {
                var inputElement = inputElementArray[i];

                inputElement.checked = false;
            }
            document.getElementById('<%=txtEvery.ClientID %>').value = '';
            document.getElementById('<%=txtGracePreiod.ClientID %>').value = '';
            document.getElementById('<%=txtDate.ClientID %>').value = '';
            document.getElementById('<%=ddlEvery.ClientID %>').selectedIndex = 0;

            return false;
        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            // Get Owner Popup
            $("#<%=btnOnwer.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 980,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../../sasumsm-01.aspx?curriculumowner=true&page=saanc',
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
            //Get Coordinator Popup
            $("#<%=btnCoordinator.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 980,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../../sasumsm-01.aspx?curriculumcoordinatorowner=true&page=saanc',
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

            //Get Prerequisites Popup
            $("#<%=btnPrerequisites.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 920,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Curriculum/p_sacs-01.aspx?page=saanc&select=prerequisites',
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

            //Get Equivalencies Popup
            $("#<%=btnEquivalencies.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 920,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Curriculum/p_sacs-01.aspx?page=saanc&select=Equivalencies',
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

            //Get Fulfillments Popup
            $("#<%=btnFulfillments.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 920,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Curriculum/p_sacs-01.aspx?page=saanc&select=Fulfillments',
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

            //Category Search Popup
            $("#<%=btnAddCategory.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 920,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                //'href': '../CategoryPopup/sascn-01.aspx?page=saanc',
                'href': '../Curriculum/CategorySearch/sascn-01.aspx?page=saanc',
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

            //Domain Saerch Popup
            $("#<%=btnAddDomain.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 920,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Curriculum/DomainSearch/sasdn-01.aspx?page=saanc',
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            //Edit Prerequisities
            $(".editprerequisities").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Curriculum/p_sacsr-01.aspx?page=saanc&select=prerequisites&editprerequisities=' + record_id,
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
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteprerequisities").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saanc-01.aspx/DeletePrerequisite",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();
                                $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
                            });
                        }
                    });

                }
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".editEquivalencies").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Curriculum/p_sacsr-01.aspx?page=saanc&select=Equivalencies&editEquivalencies=' + record_id,
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
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteEquivalencies").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saanc-01.aspx/DeleteEquivalencies",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();
                                $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
                            });
                        }
                    });

                }

                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".editFulfillments").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 920,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Curriculum/p_sacsr-01.aspx?page=saanc&&select=Fulfillments&editFulfillments=' + record_id,
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
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteFulfillments").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saanc-01.aspx/DeleteFulfillments",

                        //Pass the selected record id
                        data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                //Remove GridView row
                                tr_id.remove();

                                $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
                            });
                        }
                    });

                }
                return false;
            });

        });


       

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            //Select Image
            $(".selecticonuri").fancybox({
                'type': 'iframe',
                'titleShow': true,
                'titlePosition': 'over',
                'showCloseButton': true,
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 510,
                'height': 205,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'margin': 0,
                'padding': 0,
                'hideOnOverlayClick': false,
                'href': 'sautc-01.aspx?page=saanc',
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
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteicon").click(function () {

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this file?")) {

                    $.ajax({
                        type: "POST",

                        //saetc-01.aspx is the page name and DeleteUser is the server side method to delete records in saetc-01.aspx.cs

                        //url: "../saanc-01.aspx/DeleteIcon",
                        url: "saanc-01.aspx/DeleteIcon",


                        //Pass the selected record id
                        //data: "{'args': '" + record_id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                            $('#<%=btnRemove.ClientID %> ').css("display", "none");
                            $('#<%=btnSelectIconUri.ClientID %> ').css("display", "inline");
                            $('#<%=lnkDownload.ClientID %> ').css("display", "none");

                        }
                    });

                }
                return false;
            });

        });

    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deleteCategory").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saanc-01.aspx/DeleteCategory",

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
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".deletedomain").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saanc-01.aspx/DeleteDomain",

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
    </script>
    <script type="text/javascript">
        function RecurranceEvery(sender, args) {
            var txtEvery = document.getElementById('<%=txtEvery.ClientID %>').value;
            var txtGracePreiod = document.getElementById('<%=txtGracePreiod.ClientID %>').value;
            var txtDate = document.getElementById('<%=txtDate.ClientID %>').value;
            var chkRecurranceDate = checkRecurranceDate();
            var fixedDate = checkingFixedDate();

            if ((txtEvery == '' && txtGracePreiod == '' && txtDate == '' && chkRecurranceDate == false) || (txtEvery == 0 && txtGracePreiod == 0 && txtDate == '' && chkRecurranceDate == false)) {
                args.IsValid = true;
            }
            else if (txtEvery == "") {
                args.IsValid = false;
            }
            else if (txtGracePreiod == "") {
                args.IsValid = false;
            }
            else if (chkRecurranceDate == false) {
                args.IsValid = false;
            }
            else if (chkRecurranceDate == true && fixedDate == false && txtDate == "") {
                args.IsValid = false;
            }
            else if (chkRecurranceDate == true && fixedDate == false && txtDate != "") {
                args.IsValid = true;
            }
            else if (chkRecurranceDate == true && fixedDate == true) {
                args.IsValid = true;
                document.getElementById('<%=txtDate.ClientID %>').value = "";
            }
        }
        function checkRecurranceDate() {

            var RBL = document.getElementById('<%= rbtnDate.ClientID %>');
            var radiobuttonlist = RBL.getElementsByTagName("input");
            var counter = 0;
            var atLeast = 1
            var isChecked;
            for (var i = 0; i < radiobuttonlist.length; i++) {
                if (radiobuttonlist[i].checked) {
                    counter++;
                }
            }
            if (atLeast = counter) {
                isChecked = true;
            }
            else {
                isChecked = false;
            }
            return isChecked;
        }

        function checkingFixedDate() {
            var RB1 = document.getElementById("<%=rbtnDate.ClientID%>");
            var radio = RB1.getElementsByTagName("input");

            if (radio[0].checked) {

                return false;
            }
            else {
                return true;
            }

        }
    </script>
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtCutoffTime.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtCutoffTime.ClientID %>").click(
			function () {
			    $("#<%=txtCutoffTime.ClientID %>")[0].focus();
			}
		);
        });
    </script>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('#<%=txtCutoffTime.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });
            });
        })(jQuery);
    </script>
    <script type="text/javascript">
        function DateCheck(sender, args) {
            var StartDate = document.getElementById('<%=txtAvailableFrom.ClientID %>').value;
            var EndDate = document.getElementById('<%=txtAvailableTo.ClientID %>').value;
            var eDate = new Date(EndDate);
            var sDate = new Date(StartDate);
            if (StartDate != '' && StartDate != '' && sDate > eDate) {
                args.IsValid = false;
            }
        }    
    </script>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saanc" runat="server"
        ValidationGroup="saanc"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvRecurranceEvery" EnableClientScript="true" ClientValidationFunction="RecurranceEvery"
        ValidationGroup="saanc" runat="server" ErrorMessage="<%$ TextResourceExpression: app_recurrance_error_empty%>">&nbsp;</asp:CustomValidator>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/SystemHome/Catalog/Curriculum/GenerateFile/iframe.js" />
        </Scripts>
    </asp:ToolkitScriptManager>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <asp:HiddenField ID="hdNav_selected" runat="server" />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveNewCurriculum" ValidationGroup="saanc" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_new_curriculum_button_text%>"
                            OnClick="btnHeaderSaveNewCurriculum_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text%>"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_curriculum_information_text")%>:
        </div>
        <br />
        <div class="clear">
        </div>
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_created_by_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_created_on_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblCreatedOn" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCurriculumId" runat="server" ValidationGroup="saanc"
                            ControlToValidate="txtCurriculumId" ErrorMessage="<%$ TextResourceExpression: app_id_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_curriculum_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurriculumId" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCurriculumTitle" runat="server" ValidationGroup="saanc"
                            ControlToValidate="txtCurriculumTitle" ErrorMessage="<%$ TextResourceExpression: app_title_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_curriculum_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurriculumTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="saanc"
                            ControlToValidate="txtDescription" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_description_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtDescription" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_abstract_text")%>:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtAbstract" runat="server" class="txtInput_long" rows="3" cols="100"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_version_text")%>:
                    </td>
                    <td colspan="3" class="align_left">
                        <asp:TextBox ID="txtVersion" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                    <td colspan="3" class="align_right">
                        <div class="right">
                            <asp:Button ID="btnRemove" CssClass="deleteicon cursor_hand" Style="display: none;"
                                runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />
                        </div>
                        <div class="right">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="white-space: nowrap">
                                                <%=LocalResources.GetLabel("app_icon_text")%>:
                                                <asp:LinkButton ID="lnkDownload" CssClass="font_normal cursor_hand" runat="server"></asp:LinkButton>
                                                <asp:Button ID="btnSelectIconUri" runat="server" CssClass="selecticonuri cursor_hand"
                                                    Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="clear">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                    </td>
                    <td colspan="3" class="align_left">
                        <asp:Label ID="lblOwner" CssClass="font_normal cursor_hand" runat="server"></asp:Label>
                        <asp:Button ID="btnOnwer" runat="server" CausesValidation="false" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                    <td colspan="3" class="align_right">
                        <%=LocalResources.GetLabel("app_coordinator_text")%>
                        <asp:Label ID="lblcoordinator" CssClass="font_normal cursor_hand" runat="server"></asp:Label>
                        <asp:Button ID="btnCoordinator" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revcost" runat="server" ErrorMessage="<%$ TextResourceExpression: app_cost_error_wrong%>"
                            ControlToValidate="txtcost" ValidationGroup="saanc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_cost_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtcost" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                            <tr>
                                <td>
                                    <asp:RegularExpressionValidator ID="rfvCreditHours" runat="server" ErrorMessage="<%$ TextResourceExpression: app_credit_hours_error_wrong%>"
                                        ControlToValidate="txtCreditHours" ValidationGroup="saanc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                                    <%=LocalResources.GetLabel("app_credit_hours_text")%>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreditHours" CssClass="textbox_long" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="rfvCreditUnits" runat="server" ErrorMessage="<%$ TextResourceExpression: app_credit_units_error_wrong%>"
                            ControlToValidate="txtCreditUnits" ValidationGroup="saanc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_credit_units_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreditUnits" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_status_text")%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" DataTextField="c_curriculum_status_name" DataValueField="c_curriculum_status_id_pk"
                            CssClass="ddl_user_advanced_search" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 70px;">
                            <tr>
                                <td>
                                    <%=LocalResources.GetLabel("app_visible_text")%>:
                                </td>
                                <td class="align_left">
                                    <asp:CheckBox ID="chkVisible" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_approval_required_text")%>:
                        <asp:CheckBox ID="chkApprovalRequired" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlApprovalRequired" CssClass="ddl_user_advanced_search" DataTextField="s_approval_workflow_name"
                            DataValueField="s_approval_workflow_system_id_pk" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Available From:
                        <asp:RegularExpressionValidator ID="regexAvailableFrom" runat="server" ControlToValidate="txtAvailableFrom"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="Please Enter valid Date in Available From" Display="Dynamic" ValidationGroup="saanc">&nbsp;</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <div class="clear">
                            <asp:TextBox ID="txtAvailableFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="ceAvailableFrom" Format="MM/dd/yyyy" TargetControlID="txtAvailableFrom"
                                runat="server">
                            </asp:CalendarExtender>
                        </div>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                            <tr>
                                <td>
                                    Available To:
                                    <asp:CustomValidator ID="cvValidateDate" EnableClientScript="true" ClientValidationFunction="DateCheck"
                                        ValidationGroup="saanc" runat="server" ErrorMessage="Please select the Available To date as greater than Available Start date">&nbsp;</asp:CustomValidator>
                                    <asp:RegularExpressionValidator ID="regexAvailableTo" runat="server" ControlToValidate="txtAvailableTo"
                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                        ErrorMessage="Please Enter valid Date in Available To" Display="Dynamic" ValidationGroup="saanc">&nbsp;</asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:CalendarExtender ID="ceAvailableTo" Format="MM/dd/yyyy" TargetControlID="txtAvailableTo"
                                        runat="server">
                                    </asp:CalendarExtender>
                                    <asp:TextBox ID="txtAvailableTo" CssClass="textbox_long" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        Effective Date:
                        <asp:RegularExpressionValidator ID="regexEffectiveDate" runat="server" ControlToValidate="txtEffectiveDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="Please Enter valid Date in Effective Date" Display="Dynamic" ValidationGroup="saanc">&nbsp;</asp:RegularExpressionValidator>
                    </td>
                    <td class="align_left">
                        <asp:CalendarExtender ID="ceEffectiveDate" Format="MM/dd/yyyy" TargetControlID="txtEffectiveDate"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtEffectiveDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cut-off Date:
                        <asp:RegularExpressionValidator ID="regexCutOffDate" runat="server" ControlToValidate="txtCutOffDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="Please Enter valid Date in cuttoff Date" Display="Dynamic" ValidationGroup="saanc">&nbsp;</asp:RegularExpressionValidator>
                    </td>
                    <td class="align_left">
                        <asp:CalendarExtender ID="ceCutOffDate" Format="MM/dd/yyyy" TargetControlID="txtCutOffDate"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtCutOffDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                            <tr>
                                <td>
                                    Cut-off Time:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCutoffTime" CssClass="textbox_long" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_category_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <div>
                <asp:GridView ID="gvCategory" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                    AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_5">
                                    <tr>
                                        <td>
                                            <%#Eval("s_category_name")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- <%# "(" + Eval("s_category_id") + ")"%>--%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("c_related_category_id_fk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                    class="deleteCategory cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="div_controls font_1">
            <asp:Button ID="btnAddCategory" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_button_text%>" />
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_domain_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <div>
                <asp:GridView ID="gvDomain" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                    AutoGenerateColumns="False">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <table class="gridview_row_width_5">
                                    <tr>
                                        <td>
                                            <%#Eval("u_domain_name")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- <%# "(" + Eval("s_category_id") + ")"%>--%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("c_related_domain_id_fk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                    class="deletedomain cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="div_controls font_1">
            <asp:Button ID="btnAddDomain" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_button_text%>" />
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_audience_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:Button ID="btnAddAudience" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_button_text%>" />
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_Recurrance_text")%>:
        </div>
        <br />
        <div class="default_font_size ">
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td valign="top">
                        <asp:RegularExpressionValidator ID="rfvEvery" runat="server" ErrorMessage="<%$ TextResourceExpression: app_every_error_wrong%>"
                            ControlToValidate="txtEvery" ValidationGroup="saanc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
                        <%=LocalResources.GetLabel("app_every_text")%>
                        <asp:TextBox ID="txtEvery" runat="server" Width="50px"></asp:TextBox>
                        <asp:DropDownList ID="ddlEvery" runat="server">
                            <asp:ListItem Text="Days" Value="days"></asp:ListItem>
                            <asp:ListItem Text="Months" Value="months"></asp:ListItem>
                            <asp:ListItem Text="Years" Value="years"></asp:ListItem>
                        </asp:DropDownList>
                        <%=LocalResources.GetLabel("app_grace_period_text")%>:
                        <asp:TextBox ID="txtGracePreiod" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td valign="top">
                        <%=LocalResources.GetLabel("app_from_text")%>:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rbtnDate" RepeatColumns="1" RepeatDirection="Vertical">
                            <asp:ListItem Text="Fixed Date" Value="fixed"></asp:ListItem>
                            <asp:ListItem Text="Hire Date" Value="hire"></asp:ListItem>
                            <asp:ListItem Text="Assignment Date" Value="assignment"></asp:ListItem>
                            <asp:ListItem Text="Completion Date" Value="completion"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td valign="top">
                        <asp:RegularExpressionValidator ID="regexDate" runat="server" ControlToValidate="txtDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_date_error_wrong%>" Display="Dynamic"
                            ValidationGroup="saanc">&nbsp;</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtDate" runat="server">
                        </asp:CalendarExtender>
                        <asp:Button ID="btnClearRecurrences" CssClass="cursor_hand" OnClientClick="return clearRadioButtonList();"
                            runat="server" Text="<%$ LabelResourceExpression: app_clear_recurrance_button_text%>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_attachments_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <div>
                <asp:GridView ID="gvCurriculumAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_curriculum_attachment_file_guid,c_curriculum_attachment_file_name,c_curriculum_attchments_system_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvCurriculumAttachments_RowCommand"
                    OnRowEditing="gvCurriculumAttachments_RowEditing">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("c_curriculum_attachment_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnViewWitnessFiles" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnEditWitnessFiles" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnRemoveWitnessFiles" OnClientClick="return confirmStatus();" CommandName="Remove"
                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                                    Text="<%$ LabelResourceExpression: app_remove_button_text%>" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>
            <div class="div_controls font_1">
                <asp:Button ID="btnAddAttachment" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_attachment_button_text%>" />
            </div>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_prerequisites_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Button ID="btnPrerequisites" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                    <td>
                        <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_9"
                            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("c_curriculum_text") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_curriculum_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                            class="editprerequisities cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_curriculum_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                            class="deleteprerequisities cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_equivalencies_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Button ID="btnEquivalencies" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                    <td>
                        <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_9"
                            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("c_curriculum_text") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_curriculum_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                            class="editEquivalencies cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_curriculum_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                            class="deleteEquivalencies cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_fulfillments_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Button ID="btnFulfillments" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                    <td>
                        <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_9"
                            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="record"></RowStyle>
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table class="gridview_row_width_5">
                                            <tr>
                                                <td>
                                                    <%#Eval("c_curriculum_text") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_curriculum_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                            class="editFulfillments cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_curriculum_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                            class="deleteFulfillments cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_custom_fields_text")%>:
        </div>
        <br />
        <div class="div_controls font_1 ">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_01_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom01" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_02_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom02" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_03_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom03" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_04_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom04" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_05_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom05" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_06_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom06" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_07_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom07" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_08_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom08" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_09_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom09" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_10_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom10" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_11_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom11" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_12_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom12" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_custom_13_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustom13" CssClass="textbox_manage_user" runat="server"></asp:TextBox>
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
            &nbsp;
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveNewCurriculum" ValidationGroup="saanc" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_new_curriculum_button_text%>"
                            OnClick="btnFooterSaveNewCurriculum_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_reset_button_text%>"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <asp:ModalPopupExtender ID="mpeAttachment" runat="server" TargetControlID="btnAddAttachment"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hdAttachments" runat="server" />
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background"
            Style="display: none; padding-left: 0px; padding-right: 0px;">
            <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                <div>
                    <div class="uploadpopup_header">
                        <div class="left">
                            <%=LocalResources.GetLabel("app_upload_file_text")%>:
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
                <div class="uploadpanel">
                    <%=LocalResources.GetLabel("app_select_file_text")%>:
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="525" size="70" />
                    <br />
                    <br />
                    <br />
                    <div class="uploadbutton">
                        <asp:Button ID="btnUploadAttachements" runat="server" Text="<%$ LabelResourceExpression: app_upload_button_text%>"
                            OnClick="btnUploadattachments_Click" CssClass="cursor_hand" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
