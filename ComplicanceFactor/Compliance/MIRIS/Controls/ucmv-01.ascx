<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucmv-01.ascx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.Controls.ucmv_01" %>
<link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function confirmation() {
        if (confirm("Are you sure you want to delete this entry?") == true) {
            return true;
        }
        else {
            return false;
        }
    }

</script>
<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblVehicle" runat="server" Text="Vechicle"></asp:Label>
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
                Type:
            </td>
            <td class="width_200 align_left">
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
            </td>
            <td>
                <asp:Button ID="btnVechicleRemove" OnClientClick="return confirmation();" CausesValidation="false"
                    Width="28px" runat="server" Text="X" onclick="btnVechicleRemove_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Vehicle Id:
            </td>
            <td>
                <asp:TextBox ID="txtVehicleId" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
            <td>
                VIN:
            </td>
            <td class="align_left">
                <asp:TextBox ID="txtVIN" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
            <td>
                License Number:
            </td>
            <td>
                <asp:TextBox ID="txtLicenseNumber" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Vehicle Make:
            </td>
            <td>
                <asp:TextBox ID="txtVehicleMake" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
            <td>
                Model:
            </td>
            <td class="align_left">
                <asp:TextBox ID="txtVehicleModel" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
            <td>
                Year:
            </td>
            <td>
                <asp:TextBox ID="txtYear" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                State:
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server" CssClass="textbox_width"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
