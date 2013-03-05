<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="saru-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.saru_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_system').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_system').addClass('selected');
            return false;
        });
    });

    </script>
    <div class="content_area">
        <div class="home_content">
            <div class="add_edit_user_tab">
                <table class="button_div">
                    <tr>
                        <td class="btnsave_new_user_td">
                            <asp:Button ID="btnConfirm_header" CssClass="cursor_hand"  Text="<%$ LabelResourceExpression: app_confirm_retire_button_text %>" runat="server" 
                                onclick="btnConfirm_header_Click" />
                        </td>
                        <td class="btnreset_td">
                            &nbsp;
                        </td>
                        <td class="btncancel_td">
                            <asp:Button ID="btnCancel_header" CssClass="cursor_hand"  runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                                onclick="btnCancel_header_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="manage_user_header">
                <%=LocalResources.GetLabel("app_user_information_text")%>  
            </div>
            <br />
            <div class="add_edit_user_tab">
                <table>
                    <tr>
                        <td>
                            * <%=LocalResources.GetLabel("app_last_name_text")%>  
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblLastName" runat="server"></asp:Label>
                        </td>
                        <td>
                            * <%=LocalResources.GetLabel("app_first_name_text")%> 
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_middle_name_text")%> 
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            * <%=LocalResources.GetLabel("app_user_status_text")%> 
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblUserStatus" runat="server"></asp:Label>
                        </td>
                        <td>
                            * <%=LocalResources.GetLabel("app_user_types_text")%> 
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblUserTypes" runat="server"></asp:Label>
                        </td>
                        <td>
                            * <%=LocalResources.GetLabel("app_user_domain_text")%> 
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblUserDomain" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="manage_user_header">
                <%=LocalResources.GetLabel("app_login_information_text")%> 
            </div>
            <br />
            <div class="add_edit_user_tab">
                <table>
                    <tr>
                        <td>
                            * <%=LocalResources.GetLabel("app_username_text")%> 
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        </td>
                        <td>
                            * <%=LocalResources.GetLabel("app_password_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblPassword" runat="server"></asp:Label>
                        </td>
                        <td>
                            
                        </td>
                        <td align="center">
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="manage_user_header">
               <%=LocalResources.GetLabel("app_contact_information_text")%>
            </div>
            <br />
            <div class="add_edit_user_tab">
                <table>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_email_address_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_work_phone_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblWorkPhone" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_work_extension_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblWorkExtension" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                         <%=LocalResources.GetLabel("app_mobile_number_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_mobile_type_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblMobileType" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_carrier_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCarrier" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_address_1_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_address_2_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                        </td>
                        <td>
                          <%=LocalResources.GetLabel("app_address_3_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblAddress3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_city_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_state_province_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblStateProvince" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_zip_postal_code_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblZipPostalCode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_country_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCountry" runat="server"></asp:Label>
                        </td>
                        <td>
                            * <%=LocalResources.GetLabel("app_locale_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblLocale" runat="server"></asp:Label>
                        </td>
                        <td>
                            * <%=LocalResources.GetLabel("app_timezone_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="manage_user_header">
               <%=LocalResources.GetLabel("app_security_roles_text")%>
            </div>
            <br />
            <div class="add_edit_user_tab">
                <table>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_is_employee_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsEmployee" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_is_manager_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsManager" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_is_compliance_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsCompliance" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_is_instructor_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsInstructor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_is_training_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsTraining" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_is_administrator_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsAdministrator" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_is_system_admin_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsSystemAdmin" runat="server"></asp:Label>
                        </td>
                        <td>
                            Is Compliance Approver
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsComplianceApprover" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="manage_user_header">
              <%=LocalResources.GetLabel("app_hris_information_text")%>
            </div>
            <br />
            <div class="hris_tab">
                <table>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_manager_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblManager" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_supervisor_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_mentor_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblMentor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_alt_manager_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblAltManager" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_alt_supervisor_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblAltSupervisor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_alt_mentor_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblAltMentor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_employee_id_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_employee_type_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblEmployeeType" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_company_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCompany" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_hire_date_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblHireDate" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_is_rehire_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblIsRehire" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_last_rehire_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblLastRehire" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <%=LocalResources.GetLabel("app_region_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblRegion" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_division_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblDivision" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_department_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_cost_center_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCostCenter" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_job_group_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblJobGroup" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_job_code_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblJobCode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_job_title_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_job_position_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblJobPostion" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_pay_grade_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblPayGrade" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="manage_user_header">
              <%=LocalResources.GetLabel("app_custom_fields_text")%>
            </div>
            <br />
            <div class="hris_tab">
                <table>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_custom_01_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom01" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_custom_02_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom02" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_custom_03_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom03" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_04_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom04" runat="server"></asp:Label>
                        </td>
                        <td>
                           <%=LocalResources.GetLabel("app_custom_05_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom05" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_custom_06_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom06" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_custom_07_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom07" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_08_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom08" runat="server"></asp:Label>
                        </td>
                        <td>
                             <%=LocalResources.GetLabel("app_custom_09_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom09" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_10_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom10" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_11_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom11" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%=LocalResources.GetLabel("app_custom_12_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom12" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <%=LocalResources.GetLabel("app_custom_13_text")%>
                        </td>
                        <td class="lable_td_width">
                            <asp:Label ID="lblCustom13" runat="server"></asp:Label>
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
            <div class="manage_user_header">
                <br />
            </div>
            <br />
            <div class="label_required_field">
                * <%=LocalResources.GetLabel("app_required_fields_text")%>
            </div>
            <br />
            <div class="add_edit_user_tab">
                <table class="button_div">
                    <tr>
                        <td class="btnsave_new_user_td">
                            <asp:Button ID="btnConfirm_footer" CssClass="cursor_hand"  Text="<%$ LabelResourceExpression: app_confirm_retire_button_text %>" runat="server" 
                                onclick="btnConfirm_footer_Click" />
                        </td>
                        <td class="btnreset_td">
                            &nbsp;
                        </td>
                        <td class="btncancel_td">
                            <asp:Button ID="btncancel_footer" CssClass="cursor_hand"  runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>"
                                onclick="btncancel_footer_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
