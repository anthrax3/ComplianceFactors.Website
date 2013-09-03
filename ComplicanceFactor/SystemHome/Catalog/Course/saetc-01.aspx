<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saetc-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.saetc_01"
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
    <script src="../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
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
        $(document).ready(function () {

            var editCourseId = $('input#<%=hdCourseId.ClientID %>').val();

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
                'href': '/SystemHome/sasumsm-01.aspx?courseowner=true&page=saetc',
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
                'href': '/SystemHome/sasumsm-01.aspx?coursecoordinatorowner=true&page=saetc',
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
            //Prerequisites
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
                'href': '../Course/CourseSearch/sasstcp-01.aspx?page=saetc&select=prerequisites&editCourseId=' + editCourseId,
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
            //Equivalencies
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
                'href': '../Course/CourseSearch/sasstcp-01.aspx?page=saetc&select=Equivalencies&editCourseId=' + editCourseId,
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
            //Fulfillments
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
                'href': '../Course/CourseSearch/sasstcp-01.aspx?page=saetc&select=Fulfillments&editCourseId=' + editCourseId,
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

            //delivery popup

            $("#<%=btnAddDelivery.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 1040,
                'height': 200,
                'margin': 0,
                'padding': 0,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../Course/Delivery/sand-01.aspx?mode=adddelivery&page=saetc&editCourseId=' + editCourseId,
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
                'href': '../Course/DomainSearch/sasdn-01.aspx?page=saetc&editCourseId=' + editCourseId,
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
                'href': '../Course/CategorySearch/sascn-01.aspx?page=saetc&editCourseId=' + editCourseId,
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
            //Audience
            $("#<%=btnAddAudience.ClientID %>").fancybox({
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
                'href': '../Course/AudienceSearch/sasan-01.aspx?page=saetc&editCourseId=' + editCourseId,
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

            var editCourseId = $('input#<%=hdCourseId.ClientID %>').val();

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
                    'href': '../Course/CourseSearch/sastcrr-01.aspx?page=saetc&select=prerequisites&editprerequisities=' + record_id + '&editCourseId=' + editCourseId,
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

                        //saetc-01.aspx is the page name and DeleteUser is the server side method to delete records in saetc-01.aspx.cs
                        url: "saetc-01.aspx/DeletePrerequisite",

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

            var editCourseId = $('input#<%=hdCourseId.ClientID %>').val();

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
                    'href': '../Course/CourseSearch/sastcrr-01.aspx?page=saetc&select=Equivalencies&editEquivalencies=' + record_id + '&editCourseId=' + editCourseId,
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

                        //saetc-01.aspx is the page name and DeleteUser is the server side method to delete records in saetc-01.aspx.cs
                        url: "saetc-01.aspx/DeleteEquivalencies",

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

            var editCourseId = $('input#<%=hdCourseId.ClientID %>').val();

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
                    'href': '../Course/CourseSearch/sastcrr-01.aspx?page=saetc&select=Fulfillments&editFulfillments=' + record_id + '&editCourseId=' + editCourseId,
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

                        //saetc-01.aspx is the page name and DeleteUser is the server side method to delete records in saetc-01.aspx.cs
                        url: "saetc-01.aspx/DeleteFulfillments",

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
        function lastEquivalenciesrow() {

            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
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

            var editCourseId = $('input#<%=hdCourseId.ClientID %>').val();

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
                'href': '../Course/sautc-01.aspx?page=saetc&editCourseId=' + editCourseId,
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

            $(".deleteicon").click(function () {

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this file?")) {

                    $.ajax({
                        type: "POST",

                        //saetc-01.aspx is the page name and DeleteUser is the server side method to delete records in saetc-01.aspx.cs
                        url: "saetc-01.aspx/DeleteIcon",

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
    <script type="text/javascript" language="javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }
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
    <script type="text/javascript">

        $(document).ready(function () {

            var editcourseid = $('input#<%=hdCourseId.ClientID %>').val();

            $(".deletedelivery").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete instructor is the server side method to delete records in saantc-01.aspx.cs
                        url: "saetc-01.aspx/DeleteDelivery",

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


            $(".editdelivery").click(function () {

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
                    'width': 1040,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Course/Delivery/saed-02.aspx?page=sasw&editdelivery=' + record_id + "&editcourseid=" + editcourseid,
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
                        url: "saetc-01.aspx/DeleteDomain",

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

            $(".deleteaudience").click(function () { 

                //Get the Id of the record to delete-----
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");

                // Ask user's confirmation before delete records
                if (confirm("Do you want to delete this record?")) {

                    $.ajax({
                        type: "POST",

                        //saantc-01.aspx is the page name and DeleteUser is the server side method to delete records in saantc-01.aspx.cs
                        url: "saetc-01.aspx/DeleteAudience",

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
                        url: "saetc-01.aspx/DeleteCategory",

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
    <script type="text/javascript" language="javascript">
        function ClearVersion() {

            document.getElementById('<%=txtNewVersionNumber.ClientID %>').value = '';
            document.getElementById('<%=chkCategorys.ClientID %>').checked = false;
            document.getElementById('<%=chkDomains.ClientID %>').checked = false;
            document.getElementById('<%=chkAudiences.ClientID %>').checked = false;
            document.getElementById('<%=chkRecurrance.ClientID %>').checked = false;
            document.getElementById('<%=chkPrerequisite.ClientID %>').checked = false;
            document.getElementById('<%=chkEquivalencies.ClientID %>').checked = false;
            document.getElementById('<%=chkFulfillments.ClientID %>').checked = false;
            document.getElementById('<%=chkDeliveries.ClientID %>').checked = false;
            return false;
        }
    </script>
    <script language="javascript" type="text/javascript">
        //Function to Hide ModalPopUp
        function Hidepopup() {

            $find('ContentPlaceHolder1_mpVersionList').hide();
        }
        //Function to Show ModalPopUp
        function Showpopup() {           
            $find('ContentPlaceHolder1_mpVersionList').show();

        }

        function RemoveLocale(value) {

            var exists = false;
            $('#<%=ddlLocale.ClientID %>  option').each(function () {
                if (this.value == value) {
                    exists = true;
                    $('#<%=ddlLocale.ClientID %> option[value=' + value + ']').remove();
                }
            });



        }
    </script>
    <script type="text/javascript">

        // Add locale
        $(document).ready(function () {

            var editcourseId = $('input#<%=hdCourseId.ClientID %>').val();

            $("#btnCreateNewLocale").click(function (e) {

                var localeid = $("#<%=ddlLocale.ClientID %>").val();
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 668,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Course/Locale/saaloc-01.aspx?mode=edit' + '&localeid=' + localeid + "&localeText=" + localeText + "&editCourseId=" + editcourseId,
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


            $(".deletelocale").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                var element = $(this).attr("id").split(",");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "saetc-01.aspx/DeleteLocale",

                        //Pass the selected record id
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {

                            // Do some animation effect
                            tr_id.fadeOut(500, function () {

                                $("#<%= ddlLocale.ClientID %>").append("<option value=" + element[1] + ">" + element[2] + " </option>");
                                $("#<%= ddlLocale.ClientID %>").val(element[1]);
                                //Remove GridView row
                                tr_id.remove();

                            });
                        }
                    });

                }
                return false;
            });

            //edit locale
            $(".editlocale").click(function () {

                var localeid = $("#<%=ddlLocale.ClientID %>").val();
                var localeText = $("#<%=ddlLocale.ClientID %> option:selected").text();

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
                    'width': 668,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Course/Locale/saeloc-01.aspx?mode=edit' + '&localeid=' + localeid + "&localeText=" + localeText + "&id=" + record_id,
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

            var editcourseId = $('input#<%=hdCourseId.ClientID %>').val();
            $(".copydelivery").click(function () {

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
                    'width': 1040,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../Course/Delivery/sand-01.aspx?mode=editcopy&copydelivery=' + record_id + '&editcourseId=' + editcourseId,
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/SystemHome/Catalog/Course/GenerateFile/iframe.js" />
        </Scripts>
    </asp:ToolkitScriptManager>
    <asp:ValidationSummary class="validation_summary_error" ID="vs_saetc" runat="server"
        ValidationGroup="saetc"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvRecurranceEvery" EnableClientScript="true" ClientValidationFunction="RecurranceEvery"
        ValidationGroup="saetc" runat="server" ErrorMessage="<%$ TextResourceExpression: app_recurrance_error_empty%>">&nbsp;</asp:CustomValidator>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <asp:HiddenField ID="hdNav_selected" runat="server" />
    <asp:HiddenField ID="hdCourseId" runat="server" />
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveCourse" ValidationGroup="saetc" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_course_text%>" OnClick="btnHeaderSaveCourse_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text%>"
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
            <%=LocalResources.GetLabel("app_course_information_text")%>:
        </div>
        <br />
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
                        <asp:RequiredFieldValidator ID="rfvCourseId" runat="server" ValidationGroup="saetc"
                            ControlToValidate="txtCourseID" ErrorMessage="<%$ TextResourceExpression: app_course_id_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_course_id_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCourseID" CssClass="textbox_long" runat="server"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="rfvCourseTitle" runat="server" ValidationGroup="saetc"
                            ControlToValidate="txtTitle" ErrorMessage="<%$ TextResourceExpression: app_course_title_error_empty%>">&nbsp;
                        </asp:RequiredFieldValidator>
                        *
                        <%=LocalResources.GetLabel("app_course_title_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvCourseDescription" runat="server" ValidationGroup="saetc"
                            ControlToValidate="txtTitle" ErrorMessage="<%$ TextResourceExpression: app_description_error_empty%>">&nbsp;
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
                    <td colspan="4" class="align_left">
                        <asp:TextBox ID="txtVersion" runat="server" CssClass="textbox_long"></asp:TextBox>
                        <asp:Button ID="btnCreateNewVersion" runat="server" Text="<%$ LabelResourceExpression: app_create_new_version_button_text%>" />
                        <asp:Button ID="btnViewVersions" runat="server" Text="<%$ LabelResourceExpression: app_view_all_version_button_text%>" />
                    </td>
                    <td colspan="2" class="align_right">
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
                        <asp:Button ID="btnOnwer" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                    <td colspan="3" class="align_right">
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:&nbsp;
                        <asp:Label ID="lblcoordinator" CssClass="font_normal cursor_hand" runat="server"></asp:Label>
                        <asp:Button ID="btnCoordinator" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_button_text%>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revcost" runat="server" ErrorMessage="<%$ TextResourceExpression: app_cost_error_wrong%>"
                            ControlToValidate="txtcost" ValidationGroup="saetc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
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
                                        ControlToValidate="txtCreditHours" ValidationGroup="saetc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
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
                            ControlToValidate="txtCreditUnits" ValidationGroup="saetc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
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
                        <asp:DropDownList ID="ddlStatus" DataTextField="c_course_status_name" DataValueField="c_course_status_id"
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
                    <td>
                        <asp:DropDownList ID="ddlApprovalRequired" DataTextField="s_approval_workflow_name"
                            DataValueField="s_approval_workflow_system_id_pk" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_available_from_text")%>:
                        <asp:CustomValidator ID="cvValidateDate" EnableClientScript="true" ClientValidationFunction="DateCheck"
                            ValidationGroup="saetc" runat="server" ErrorMessage="<%$ TextResourceExpression: app_check_from_and_to_date_error_wrong%>">&nbsp;</asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="regexAvailableFrom" runat="server" ControlToValidate="txtAvailableFrom"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_available_from_date_error_wrong%>" Display="Dynamic" ValidationGroup="saetc">&nbsp;</asp:RegularExpressionValidator>
                    </td>
                    <td class="align_left">
                        <asp:CalendarExtender ID="ceAvailableFrom" Format="MM/dd/yyyy" TargetControlID="txtAvailableFrom"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtAvailableFrom" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 0 0 38px;">
                            <tr>
                                <td>
                                    <%=LocalResources.GetLabel("app_available_to_text")%>:
                                    <asp:RegularExpressionValidator ID="regexAvailableTo" runat="server" ControlToValidate="txtAvailableTo"
                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                        ErrorMessage="<%$ TextResourceExpression: app_available_to_date_error_wrong%>" Display="Dynamic" ValidationGroup="saetc">&nbsp;</asp:RegularExpressionValidator>
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
                        <%=LocalResources.GetLabel("app_effective_date_text")%>:
                        <asp:RegularExpressionValidator ID="regexEffectiveDate" runat="server" ControlToValidate="txtEffectiveDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_effective_date_error_wrong%>" Display="Dynamic" ValidationGroup="saetc">&nbsp;</asp:RegularExpressionValidator>
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
                       <%=LocalResources.GetLabel("app_cut_off_date_text")%>:
                        <asp:RegularExpressionValidator ID="regexCutOffDate" runat="server" ControlToValidate="txtCutOffDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="<%$ TextResourceExpression: app_cut_off_date_error_wrong%>" Display="Dynamic" ValidationGroup="saetc">&nbsp;</asp:RegularExpressionValidator>
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
                                    <%=LocalResources.GetLabel("app_cut_off_time_text")%>:
                                    <asp:RegularExpressionValidator ID="regexEndTime" runat="server" ControlToValidate="txtCutoffTime"
                                        ValidationExpression="^(1|01|2|02|3|03|4|04|5|05|6|06|7|07|8|08|9|09|10|11|12{1,2}):(([0-5]{1}[0-9]{1}\s{0,1})([AM|PM|am|pm]{2,2}))\W{0}$"                                        
                                        ErrorMessage="<%$ TextResourceExpression: app_cut_off_time_error_wrong%>" Display="Dynamic"
                                        ValidationGroup="saetc">&nbsp;</asp:RegularExpressionValidator>
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
            <%=LocalResources.GetLabel("app_delivery_(ies)_text")%>:
        </div>
        <br />
        <div class="div_control_normal">
            <div>
                <asp:GridView ID="gvDeliveries" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_width_95"
                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_delivery_system_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowDataBound="gvDeliveries_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td class="horizontal_line" colspan="3">
                                            <hr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="gridview_row_width_300 font_12_pixel">
                                            <%#Eval("c_delivery_type_text")%>
                                        </td>
                                        <td class="gridview_row_width_350 font_12_pixel">
                                            <%-- <%#Eval("c_delivery_title")%>--%>
                                            <asp:Label ID="lblSession" runat="server"></asp:Label>
                                        </td>
                                        <td class="gridview_row_width_300" align="right">
                                            <table>
                                                <tr>
                                                    <td class="gridview_row_width_1" align="right">
                                                        <input type="button" id='<%# Eval("c_delivery_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Edit" />'
                                                            class="editdelivery cursor_hand" />
                                                    </td>
                                                    <td class="gridview_row_width_1" align="right">
                                                        <input type="button" id='<%# Eval("c_delivery_system_id_pk") %>' value='<asp:Literal ID="Literal2" runat="server" Text="Copy" />'
                                                            class="copydelivery cursor_hand" />
                                                    </td>
                                                    <td class="gridview_row_width_1" align="right">
                                                        <input type="button" id='<%# Eval("c_delivery_system_id_pk") %>' value='<asp:Literal ID="Literal3" runat="server" Text="Remove" />'
                                                            class="deletedelivery cursor_hand" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="div_controls font_1">
            <asp:Button ID="btnAddDelivery" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_add_button_text%>" />
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
                                            <%#Eval("s_category_name_us_english")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- <%# "(" + Eval("u_domain_id_pk") + ")"%>--%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("CategoryID") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                    class="deleteCategory cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <div class="div_controls font_1">
            <asp:Button ID="btnAddCategory" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_button_text%>" />
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_domain_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
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
                                        <%-- <%# "(" + Eval("u_domain_id_pk") + ")"%>--%>
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
        <div class="div_controls font_1">
            <asp:Button ID="btnAddDomain" runat="server" CssClass="cursor_hand" Text="<%$ LabelResourceExpression: app_add_button_text%>" />
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_audience_text")%>:
        </div>
        <br />
        <div class="div_controls_from_left">
            <asp:GridView ID="gvAudience" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
                CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
                AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_5" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table class="gridview_row_width_5">
                                <tr>
                                    <td>
                                        <%#Eval("u_audience_name")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- <%# "(" + Eval("u_domain_id_pk") + ")"%>--%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <input type="button" id='<%# Eval("c_related_audience_id_fk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
                                class="deleteaudience cursor_hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
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
                            ControlToValidate="txtEvery" ValidationGroup="saetc" ValidationExpression="^[0-9]+$">&nbsp;</asp:RegularExpressionValidator>
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
                            ErrorMessage="<%$ TextResourceExpression: app_recurrance_date_error_wrong%>"
                            Display="Dynamic" ValidationGroup="saetc">&nbsp;</asp:RegularExpressionValidator>
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
                                                    <%#Eval("c_course_text") %>
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
                                        <input type="button" id='<%# Eval("c_related_course_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                            class="editprerequisities cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_course_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
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
                                                    <%#Eval("c_course_text") %>
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
                                        <input type="button" id='<%# Eval("c_related_course_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                            class="editEquivalencies cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_course_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
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
                                                    <%#Eval("c_course_text") %>
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
                                        <input type="button" id='<%# Eval("c_related_course_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text%>" />'
                                            class="editFulfillments cursor_hand" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <input type="button" id='<%# Eval("c_related_course_group_id") %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text%>" />'
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
            <%=LocalResources.GetLabel("app_all_locale_text")%>:
        </div>
        <div>
            <%-- locale list--%>
            <div class="div_padding_10">
                <br />
                <asp:GridView ID="gvLocale" RowStyle-CssClass="record" CssClass="grid_700" runat="server"
                    GridLines="None" AutoGenerateColumns="false" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="width_400">
                            <ItemTemplate>
                                <%#Eval("s_locale_text")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="width_40">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("s_locale_system_id_pk") %>' value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_edit_button_text %>" />'
                                    class="editlocale cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="width_35" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <input type="button" id='<%# Eval("s_locale_system_id_pk").ToString() + "," +  Eval("s_locale_id_fk").ToString() + "," +  Eval("s_locale_text").ToString()%>'
                                    value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_remove_button_text %>" />'
                                    class="deletelocale cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <div>
                    <table class="grid_700" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="width_300">
                                <asp:DropDownList ID="ddlLocale" CssClass="dropdown_width_300" runat="server" DataTextField="s_locale_description"
                                    DataValueField="s_locale_id_pk">
                                </asp:DropDownList>
                            </td>
                            <td class="align_right">
                                <input type="button" id="btnCreateNewLocale" value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_create_new_locale_button_text %>" />' />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
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
                        <asp:Button ID="btnFooterSaveCourse" ValidationGroup="saetc" CssClass="cursor_hand"
                            runat="server" Text="<%$ LabelResourceExpression: app_save_course_text%>" OnClick="btnFooterSaveCourse_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text%>"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <div class="font_normal">
            <asp:Panel ID="pnlCreateNewVersion" runat="server" CssClass="modalPopup_width_620 modal_popup_background"
                Style="display: none; padding-left: 0px; padding-right: 0px;">
                <asp:Panel ID="pnlCreateNewCersionHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_620">
                            <%=LocalResources.GetLabel("app_create_new_version_text")%>:
                        </div>
                        <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                            z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <br />
                <div class="table_right">
                    <table>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_new_version_number_text")%>:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewVersionNumber" runat="server"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_categories_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkCategorys" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_domains_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkDomains" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_audeiences_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkAudiences" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_recurrence_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkRecurrance" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_prerequisite_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkPrerequisite" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_equivalency_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkEquivalencies" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_fulfillments_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkFulfillments" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=LocalResources.GetLabel("app_copy_deliveries_text")%>:
                            </td>
                            <td class="align_left">
                                <input id="chkDeliveries" type="checkbox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="button_600">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnSaveNewVersion" CssClass="cursor_hand" OnClick="btnSaveNewVersion_Click"
                                    runat="server" Text="<%$ LabelResourceExpression: app_create_new_version_button_text%>" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnResetNewVersion" CssClass="cursor_hand" OnClientClick="return ClearVersion();"
                                    runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text%>" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnCancelNewVersion" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text%>" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
        <div class="font_normal">
            <asp:Panel ID="pnlViewPreviousVersionList" runat="server" CssClass="modalPopup_width_620 modal_popup_background"
                Style="display: none; padding-left: 0px; padding-right: 0px;">
                <asp:Panel ID="pnlViewPreviousVersionHeading" runat="server" CssClass="drag">
                    <div>
                        <div class="div_header_620">
                            <%=LocalResources.GetLabel("app_all_previous_version_text")%>:
                        </div>
                        <asp:ImageButton ID="imgClosePreviousVersionList" CssClass="cursor_hand" Style="top: -15px;
                            right: -15px; z-index: 1103; position: absolute;" runat="server" ImageUrl="~/Images/Zoom/fancy_close.png" />
                    </div>
                </asp:Panel>
                <div style="padding: 0 0 0 10px;">
                    <asp:GridView ID="gvVersionList" CssClass="table_left" GridLines="None" ShowHeader="false"
                        DataKeyNames="c_course_system_id_pk" runat="server" AutoGenerateColumns="false"
                        OnRowDataBound="gvVersionList_RowDataBound">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="width_320" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkViewVersion" runat="server" Text='<%#Eval("rev_history_date_time") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnViewVersion" CssClass="cursor_hand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                        runat="server" Text="<%$ LabelResourceExpression: app_view_button_text%>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div>
                    <table cellpadding="0" cellspacing="0" class="button_600">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnCloseVersionList" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_close_button_text%>" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
        <asp:ModalPopupExtender ID="mpeCreateNewVersion" runat="server" TargetControlID="btnCreateNewVersion"
            OkControlID="btnCancelNewVersion" CancelControlID="imgClose" OnOkScript="ClearVersion()"
            OnCancelScript="ClearVersion()" PopupControlID="pnlCreateNewVersion" BackgroundCssClass="transparent_class"
            DropShadow="false" PopupDragHandleControlID="pnlCreateNewCersionHeading">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="mpVersionList" runat="server" TargetControlID="btnViewVersions"
            OkControlID="btnCloseVersionList" CancelControlID="imgClosePreviousVersionList"
            PopupControlID="pnlViewPreviousVersionList" BackgroundCssClass="transparent_class"
            DropShadow="false" PopupDragHandleControlID="pnlViewPreviousVersionHeading">
        </asp:ModalPopupExtender>
    </div>
</asp:Content>
