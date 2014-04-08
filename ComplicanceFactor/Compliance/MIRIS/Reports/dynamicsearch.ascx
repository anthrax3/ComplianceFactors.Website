<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dynamicsearch.ascx.cs"
    Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.dynamicsearch" %>
<script type="text/javascript">
    function SelectUsers() {
        $.fancybox({
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
            'href': 'popup/sasumsm-01.aspx',
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
    function SelectCourse() {
        $.fancybox({
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
            'href': 'popup/sasstcp-01.aspx',
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

    function SelectDelivery() {
        $.fancybox({
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
            'href': 'popup/sasstdp-01.aspx',
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

    function SelectCompletionStatus() {
        $.fancybox({
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
            'href': 'popup/sasstcsp-01.aspx',
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
</script>
<tr style="display: none;">
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
</tr>
<asp:PlaceHolder ID="phConditions" runat="server"></asp:PlaceHolder>
 
<div class="div_padding_25" id="SelectDetails" runat="server" style="display:none;">   
</div>
