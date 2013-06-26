using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using Ionic.Zip;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;
using System.Text;
using System.Net;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Net.Mail;

namespace ComplicanceFactor.Compliance.MIRIS
{
    public partial class cvmv_01 : System.Web.UI.Page
    {
        string view;
        #region "Private Member Variables"
        private string _path = "~/Compliance/MIRIS/Upload/Witness/";
        private string _pathPolice = "~/Compliance/MIRIS/Upload/Police/";
        private string _pathPhoto = "~/Compliance/MIRIS/Upload/Photo/";
        private string _pathSceneSketch = "~/Compliance/MIRIS/Upload/sceneSketch/";
        private string _pathExtenuatingcondition = "~/Compliance/MIRIS/Upload/ExtenuatingCondtion/";
        private string _pathEmployeeInterview = "~/Compliance/MIRIS/Upload/EmployeeInterview/";
        private string _temppath = "~/Compliance/MIRIS/tempCaseFiles/";

        #endregion
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SessionWrapper.u_username))
            {
                if (!string.IsNullOrEmpty(SecurityCenter.DecryptText(Request.QueryString["View"])))
                {
                    view = SecurityCenter.DecryptText(Request.QueryString["View"]);
                }
                if (!IsPostBack)
                {
                    populatecase(view);
                }
            }
            else
            {
                Response.Redirect("~/glp-01.aspx");
            }
        }

        private void populatecase(string caseid)
        {
            ComplianceDAO miris = new ComplianceDAO();
            try
            {
                miris = ComplianceBLL.GetCaseMV(caseid);
                //ddlTimezone.SelectedValue = miris.c_timezoneId;
                lblCaseDate.Text = Convert.ToDateTime(miris.c_case_date).ToString("MM/dd/yyyy hh:mm tt");
                lblPageCaseNumber.Text = miris.c_case_number;
                lblCaseNumber.Text = miris.c_case_number;
                lblCaseTitle.Text = miris.c_case_title;
                lblCaseCategory.Text = miris.c_case_category_text;
                lblCaseTypes.Text = miris.c_case_type_text;
                lblCaseStatus.Text = miris.c_status_text;
                lblEmployeeName.Text = miris.c_employee_name;
                lblDateOfBirth.Text = Convert.ToDateTime(miris.c_employee_dob).ToShortDateString();
                lblEmployeeHireDate.Text = Convert.ToDateTime(miris.c_employee_hire_date).ToShortDateString();
                lblEmployeeId.Text = miris.c_employee_id;
                lblLastFourDigitOfSSN.Text = miris.c_ssn;
                lblSupervisor.Text = miris.c_supervisor;
                lblIncidentLocation.Text = miris.c_incident_location;
                lblIncidentDate.Text = Convert.ToDateTime(miris.c_incident_date).ToShortDateString();
                lblIncidentTime.Text = miris.incident_HH_text;
                lblEmployeeReportLocation.Text = miris.c_employee_report_location;
                lblNote.Text = miris.c_note_text;
                lblRootCauseAnalysisDetails.Text = miris.c_root_cause_analysic_info;
                lblCorrectiveActionDetails.Text = miris.c_corrective_action_info;
                //lblCaseOutCome.Text = miris.c_outcome_text;
                //lblDaysAwayFromWork.Text = miris.c_osha_300_days_away_from_work_text;
                //lblDateOfDeath.Text = miris.c_osha_300_date_of_death_text;
                //lblTypeofIllness.Text = miris.c_illness_type_text;
                //lblDaysOfRestrictions.Text = miris.c_osha_300_days_of_restriction_text;
                //lblOSHA300info.Text = miris.c_osha_300_info;
                //lblWorkerGender.Text = miris.c_osha_301_worker_gender;
                //lblWorkStartTime.Text = miris.workstart_HH_text;
                //lblPhysician.Text = miris.c_osha_301_physician;
                //lblTreatmentFacility.Text = miris.c_osha_301_treatment_facilities;
                //lblEmergencyRoom.Text = miris.c_osha_301_emergency_room_text;
                //lblHospitalized.Text = miris.c_osha_301_hospitalized_text;
                //chkEmergencyRoom.Checked = miris.c_osha_301_emergency_room;
                //chkHospitalized.Checked = miris.c_osha_301_hospitalized;
                //lblAddress1.Text = miris.c_osha_301_address1;
                //lblAddress2.Text = miris.c_osha_301_address2;
                //lblAddress3.Text = miris.c_osha_301_address3;
                //lblCity.Text = miris.c_osha_301_city;
                //lblState.Text = miris.c_osha_301_state;
                //lblZipCode.Text = miris.c_osha_301_zip;
                //lblOSHA301Info1.Text = miris.c_osha_301_info_1;
                //lblOSHA301Info2.Text = miris.c_osha_301_info_2;
                //lblOSHA301Info3.Text = miris.c_osha_301_info_3;
                //lblOSHA301Info4.Text = miris.c_osha_301_info_4;
                lblCustom01.Text = miris.c_custom_01;
                lblCustom02.Text = miris.c_custom_02;
                lblCustom03.Text = miris.c_custom_03;
                lblCustom04.Text = miris.c_custom_04;
                lblCustom05.Text = miris.c_custom_05;
                lblCustom06.Text = miris.c_custom_06;
                lblCustom07.Text = miris.c_custom_07;
                lblCustom08.Text = miris.c_custom_08;
                lblCustom09.Text = miris.c_custom_09;
                lblCustom10.Text = miris.c_custom_10;
                lblCustom11.Text = miris.c_custom_11;
                lblCustom12.Text = miris.c_custom_12;
                lblCustom13.Text = miris.c_custom_13;


                lblVehicle01.Text = miris.c_case_desc_vehicle_01_fk;
                lblVehicle02.Text = miris.c_case_desc_vehicle_02_fk;

                lblVehicleId.Text = miris.c_case_desc_vehicle_id;
                lblVIN.Text = miris.c_case_desc_vehicle_vin;
                lblLicenseNumber.Text = miris.c_case_desc_licence_number;
                lblVehicleMake.Text = miris.c_case_desc_vehicle_make;
                lblVehicleModel.Text = miris.c_case_desc_vehicle_model;
                lblVehicleType.Text = miris.c_case_desc_vehicle_type_fk;
                lblYear.Text = miris.c_case_desc_year;
                lblState.Text = miris.c_case_desc_state;

                lblVehicleId02.Text = miris.c_case_desc_vehicle_02_id;
                lblVIN02.Text = miris.c_case_desc_vehicle_02_vin;
                lblLicenceNumber02.Text = miris.c_case_desc_licence_02_number;
                lblMake02.Text = miris.c_case_desc_vehicle_02_make;
                lblModel02.Text = miris.c_case_desc_vehicle_02_model;
                lblVehicleType02.Text = miris.c_case_desc_vehicle_02_type_fk;
                lblYear02.Text = miris.c_case_desc_vehicle_02_year;
                lblState02.Text = miris.c_case_desc_vehicle_02_state;

                gvVehicle.DataSource = ComplianceBLL.GetVehicleValues(caseid);
                gvVehicle.DataBind();

                lblCompanyVehicleStruck.Text = miris.c_case_desc_company_vehicle_struck_fk;
                lblCompanyVehicleStruckby.Text = miris.c_case_desc_company_vehicle_struck_by_fk;
                if (miris.c_case_desc_non_collision == true)
                {
                    lblNonCollision.Text = "Yes";
                }
                else
                {
                    lblNonCollision.Text = "No";
                }
                lblNonCollisionText.Text = miris.c_case_desc_non_collision_text;

                lblDriversLic.Text = miris.c_case_detail_drivers_lic;
                lblStateandClass.Text = miris.c_case_detail_state_and_class;
                if (!string.IsNullOrEmpty(miris.c_case_detail_expire_date.ToString()))
                {
                    lblExpireDate.Text = Convert.ToDateTime(miris.c_case_detail_expire_date, culture).ToString("MM/dd/yyyy");
                }

                lblAddress.Text = miris.c_case_detail_address;
                lblCity.Text = miris.c_case_detail_city;
                lblState.Text = miris.c_case_detail_state;
                lblNearestCrossStreet.Text = miris.c_case_detail_nearest_cross_street;
                lblTypeofRoadway.Text = miris.c_case_detail_type_of_roadway;
                lblRoadCondition.Text = miris.c_case_detail_road_condition_fk;
                if (!string.IsNullOrEmpty(miris.c_case_detail_time_of_day.ToString()))
                {
                    lblTimeofDay.Text = Convert.ToDateTime(miris.c_case_detail_time_of_day).ToShortTimeString();
                }

                // here we need to add one column
                lblWeather.Text = miris.c_case_detail_weather_fk;
                lblTrafficCondition.Text = miris.c_case_detail_traffic_condition_fk;
                lblTrafficControls.Text = miris.c_case_detail_traffic_controls_fk;
                lblOperatingSpeed.Text = miris.c_case_detail_oprating_speed;  //doubt
                lblSpeedLimit.Text = miris.c_case_detail_speed_limit;
                lblVehicleStruck.Text = miris.c_case_detail_vehicle_struck_fk;
                lblVehicleStruckby.Text = miris.c_case_detail_vehicle_struck_by_fk;
                if (miris.c_case_detail_collision_type_fk == "0")
                {
                    lblCollisionType.Text = string.Empty;
                }
                else
                {
                    lblCollisionType.Text = miris.c_case_detail_collision_type_fk;
                }
                if (miris.c_case_detail_collision_location_fk == "0")
                {
                    lblCollisionLocation.Text = string.Empty;
                }
                else
                {
                    lblCollisionLocation.Text = miris.c_case_detail_collision_location_fk;
                }
                if (miris.c_case_detail_collision_direction_fk == "0")
                {
                    lblCollisionDirection.Text = string.Empty;
                }
                else
                {
                    lblCollisionDirection.Text = miris.c_case_detail_collision_direction_fk;
                }
                if (miris.c_case_detail_non_collision_type_fk == "0")
                {
                    lblNonCollisionType.Text = string.Empty;
                }
                else
                {
                    lblNonCollisionType.Text = miris.c_case_detail_non_collision_type_fk;
                }
                lblNumberofVehicleInvolved.Text = miris.c_case_detail_number_of_vehicle_involved;
                lblNumberofVehicletowed.Text = miris.c_case_detail_number_of_vehicle_towed;
                lblNoofPeopleInjured.Text = miris.c_case_detail_number_of_people_injured;
                lblNoofPeopleInjured.Text = miris.c_case_detail_number_of_people_killed;
                //lblFatality.Text = miris.c_case_desc_was_fatality;
                if (miris.c_case_detail_cituation_issued == true)
                {
                    lblCituationIssued.Text = "Yes";
                }
                else
                {
                    lblCituationIssued.Text = "No";
                }
                lblAtWhom.Text = miris.c_case_detail_at_whom;
                if (miris.c_case_detail_at_fault == true)
                {
                    lblAtfault.Text = "Yes";
                }
                else
                {
                    lblAtfault.Text = "No";
                }
                if (miris.c_case_detail_contributory == true)
                {
                    lblContributory.Text = "Yes";
                }
                else
                {
                    lblContributory.Text = "No";
                }

                lblGrossVehicleWeight.Text = miris.c_case_detail_gross_vehicle_weight;
                lblCombinedGrossVehicleWeight.Text = miris.c_case_detail_combined_gross_vehicle_weight;
                if (miris.c_case_detail_dot_vehicle == true)
                {
                    lblDotVehicle.Text = "Yes";

                }
                else
                {
                    lblDotVehicle.Text = "No";
                }
                if (miris.c_case_detail_dot_driver == true)
                {
                    lblDotDriver.Text = "Yes";
                }
                else
                {
                    lblDotDriver.Text = "No";
                }
                if (miris.c_case_detail_seat_belt_used == true)
                {
                    lblSeatBeltUsed.Text = "Yes";
                }
                else
                {
                    lblSeatBeltUsed.Text = "No";
                }
                if (miris.c_case_detail_air_bag_eqiupped == true)
                {
                    lblAirBagEquipped.Text = "Yes";
                }
                else
                {
                    lblAirBagEquipped.Text = "No";
                }
                if (miris.c_case_detail_air_bag_deployed == true)
                {
                    lblAirBagDeployed.Text = "Yes";
                }
                else
                {
                    lblAirBagDeployed.Text = "No";
                }
                if (miris.c_case_detail_cellphone_in_use == true)
                {
                    lblCellphoneinUse.Text = "Yes";
                }
                else
                {
                    lblCellphoneinUse.Text = "No";
                }
                if (miris.c_case_detail_computer_in_use == true)
                {
                    lblComputerInUse.Text = "Yes";
                }
                else
                {
                    lblComputerInUse.Text = "No";
                }
                if (miris.c_case_detail_special_equipment == true)
                {
                    lblSpecialEquipment.Text = "Yes";
                }
                else
                {
                    lblSpecialEquipment.Text = "No";
                }



                lblSpecialEquipment.Text = miris.c_case_detail_special_equipment_text;
                lblLocationofImpact.Text = miris.c_case_detail_location_of_impact_fk;
                if (miris.c_case_detail_driver_injured == true)    // need to add some fields
                {
                    lblDriverInjured.Text = "Yes";
                }
                else
                {
                    lblDriverInjured.Text = "No";
                }
                if (miris.c_case_detail_passenger_injured == true)    // need to add some fields
                {
                    lblPassengerInjured.Text = "Yes";
                }
                else
                {
                    lblPassengerInjured.Text = "No";
                }

                lblHeavyDamage.Text = miris.c_case_detail_damage_heavy;
                lblModerateDamage.Text = miris.c_case_detail_damage_moderate;
                lblLightDamage.Text = miris.c_case_detail_damage_light;


                lblDriverName.Text = miris.c_pub_vehicle_driver_name;
                lblDriverAddress.Text = miris.c_pub_vehicle_driver_address;
                lblDriverContact.Text = miris.c_pub_vehicle_driver_contact;
                lblOwnerName.Text = miris.c_pub_vehicle_owner_name;
                lblOwnerAddress.Text = miris.c_pub_vehicle_owner_address;
                lblOwnerContact.Text = miris.c_pub_vehicle_owner_contact;
                lblPublicVehicleId.Text = miris.c_pub_vehicle_vehicle_id;
                lblPublicVehicleVIN.Text = miris.c_pub_vehicle_vehicle_vin;
                lblPublicLicenseNumber.Text = miris.c_pub_vehicle_licence_number;
                lblPublicVehicleMake.Text = miris.c_pub_vehicle_vehicle_make;
                lblPublicVehicleModel.Text = miris.c_pub_vehicle_vehicle_model;
                lblPublicVehicleType.Text = miris.c_pub_vehicle_vehicle_type_fk;
                lblPublicYear.Text = miris.c_pub_vehicle_year;
                lblPublicState.Text = miris.c_pub_vehicle_state;
                lblPublicGrossVehicleWeight.Text = miris.c_pub_vehicle_gross_vehicle_weight;
                lblPublicCombinedVehicleWeight.Text = miris.c_pub_vehicle_combined_gross_vehicle_weight;
                if (miris.c_pub_vehicle_dot_vehicle == true)
                {
                    lblPublicDotVehicle.Text = "Yes";
                }
                else
                {
                    lblPublicDotVehicle.Text = "No";
                }
                if (miris.c_pub_vehicle_dot_driver == true)
                {
                    lblPublicDotDriver.Text = "Yes";
                }
                else
                {
                    lblPublicDotDriver.Text = "No";
                }
                if (miris.c_pub_vehicle_seat_belt_used == true)
                {

                    lblPublicSeatBeltUsed.Text = "Yes";
                }
                else
                {
                    lblPublicSeatBeltUsed.Text = "No";
                }
                if (miris.c_pub_vehicle_air_bag_eqiupped == true)
                {
                    lblPublicAirBagEquipped.Text = "Yes";
                }
                else
                {
                    lblPublicAirBagEquipped.Text = "No";
                }
                if (miris.c_pub_vehicle_air_bag_deployed == true)
                {
                    lblPublicAirBagDeployed.Text = "Yes";
                }
                else
                {
                    lblPublicAirBagDeployed.Text = "No";
                }
                if (miris.c_pub_vehicle_cellphone_in_use == true)
                {
                    lblPublicCellphoneinUse.Text = "Yes";
                }
                else
                {
                    lblPublicCellphoneinUse.Text = "No";
                }
                if (miris.c_pub_vehicle_computer_in_use == true)
                {
                    lblPublicComputerInUse.Text = "Yes";
                }
                else
                {
                    lblPublicComputerInUse.Text = "No";
                }
                if (miris.c_pub_vehicle_special_equipment == true)
                {
                    lblPublicSpecialEquipment.Text = "Yes";
                }
                else
                {
                    lblPublicSpecialEquipment.Text = "No";
                }

                lblPublicSpecialEquipment.Text = miris.c_pub_vehicle_special_equipment_text;
                lblPublicLocationofImpact.Text = miris.c_pub_vehicle_location_of_impact_fk;
                if (miris.c_pub_vehicle_driver_injured == true)// need to add some fields
                {
                    lblPublicDriverInjured.Text = "Yes";
                }
                else
                {
                    lblPublicDriverInjured.Text = "No";
                }
                if (miris.c_pub_vehicle_passenger_injured == true)// need to add some fields
                {
                    lblPublicPassengerInjured.Text = "Yes";
                }
                else
                {
                    lblPublicPassengerInjured.Text = "No";
                }
                lblPublicDriverInjuredText.Text = miris.c_pub_vehicle_driver_injured_text;
                lblPublicPassengerInjuredText.Text = miris.c_pub_vehicle_passenger_injured_text;

                lblTotalvehicleOccupant.Text = miris.c_pub_vehicle_number_of_total_vehicle_injured;
                lblPublicHeavyDamage.Text = miris.c_pub_vehicle_damage_heavy; //doubt
                lblPublicModerateDamage.Text = miris.c_pub_vehicle_damage_moderate;//doubt
                lblPublicLightDamage.Text = miris.c_pub_vehicle_damage_light;//doubt
                //Pedestrain Incident
                lblNameofPedestrian.Text = miris.c_pedestrain_name;
                lblPedestrianAddress.Text = miris.c_pedestrain_address;
                lblPedestrainPhone.Text = miris.c_pedestrain_phone;
                lblPedestrainSex.Text = miris.c_pedestrain_sex;
                lblPedestrainAge.Text = miris.c_pedestrain_age;
                lblPedestrainCollisionType.Text = miris.c_pedestrain_collision_type_fk;
                lblPedestrainDescription.Text = miris.c_pedestrain_description;
                //BICycle Incident
                lblBicycleNameofPerson.Text = miris.c_bicycle_person_name;
                lblBicyclePersonAddress.Text = miris.c_bicycle_person_address;
                lblBicyclePersonPhone.Text = miris.c_bicycle_person_phone;
                lblBicyclePersonSex.Text = miris.c_bicycle_person_sex;
                lblBicyclePersonAge.Text = miris.c_bicycle_person_age;
                lblBicycleCollisionType.Text = miris.c_bicycle_person_collision_type_fk;
                lblBicycleDescription.Text = miris.c_bicycle_person_description;
                //Animal Incident
                lblAnimalName.Text = miris.c_animal_name;
                lblPlace.Text = miris.c_animal_place;
                lblAnimalCollisionType.Text = miris.c_animal_collision_type_fk;
                lblAnimalDescription.Text = miris.c_animal_description;
                //Fixed Object Incident
                lblPropertyOwner.Text = miris.c_fixed_object_property_name;
                lblPropertyAddress.Text = miris.c_fixed_object_address;
                lblContactInformation.Text = miris.c_fixed_object_contact_info;
                lblPropertyCollisionType.Text = miris.c_fixed_object_collision_type_fk;
                lblPropertyDesc.Text = miris.c_fixed_object_description;
                lblPhysicalPropertyDesc.Text = miris.c_fixed_object_property_description;

                //if (miris.c_case_desc_public_vehicle_involved == true)// need to add some fields
                //{
                //    lblPublicVehicleInvolved.Text = "Yes";
                //}
                //else
                //{
                //    lblPublicVehicleInvolved.Text = "No";
                //}
                miris.c_case_id_pk = caseid;
                miris.s_locale_culture = SessionWrapper.CultureName;
                //witness
                DataTable dtGetWitness = new DataTable();
                dtGetWitness = ComplianceBLL.GetWitness(miris);
                this.gvAddWitness.DataSource = dtGetWitness;
                this.gvAddWitness.DataBind();
                //photo
                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.Getphoto(miris);
                this.gvPhoto.DataSource = dtGetPhoto;
                this.gvPhoto.DataBind();
                //police report
                DataTable dtGetPoliceReport = new DataTable();
                dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                this.gvPoliceReport.DataSource = dtGetPoliceReport;
                this.gvPoliceReport.DataBind();
                //SceneSketch
                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                this.gvSceneSketch.DataSource = dtGetSceneSketch;
                this.gvSceneSketch.DataBind();
                //Extenautingcondition
                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                this.gvExtenuatingcondition.DataSource = dtGetExtenautingCondition;
                this.gvExtenuatingcondition.DataBind();
                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                this.gvEmployeeInterview.DataSource = dtGetEmployeeInterview;
                this.gvEmployeeInterview.DataBind();

                lblTimeZone.Text = miris.u_time_zone_location;
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01", ex.Message);
                    }
                }
            }
        }
        protected void gvAddWitness_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string witnessFileId = gvAddWitness.DataKeys[rowIndex][0].ToString();
                string witnessFileName = gvAddWitness.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_path + witnessFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + witnessFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        protected void gvPoliceReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string policeFileId = gvPoliceReport.DataKeys[rowIndex][0].ToString();
                string policeFileName = gvPoliceReport.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPolice + policeFileId);

                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + policeFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        protected void gvPhoto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string PhotoFileId = gvPhoto.DataKeys[rowIndex][0].ToString();
                string photoFileName = gvPhoto.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathPhoto + PhotoFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + photoFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        protected void gvSceneSketch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string SceneSketchFileId = gvSceneSketch.DataKeys[rowIndex][0].ToString();
                string SceneSketchFileName = gvSceneSketch.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathSceneSketch + SceneSketchFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SceneSketchFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        protected void gvExtenuatingcondition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string ExtenuatingconditionFileId = gvExtenuatingcondition.DataKeys[rowIndex][0].ToString();
                string ExtenuatingConditionFileName = gvExtenuatingcondition.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathExtenuatingcondition + ExtenuatingconditionFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ExtenuatingConditionFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        protected void gvEmployeeInterview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string EmployeeInterviewFileId = gvEmployeeInterview.DataKeys[rowIndex][0].ToString();
                string EmployeeInterviewFileName = gvEmployeeInterview.DataKeys[rowIndex][1].ToString();
                string filePath = Server.MapPath(_pathEmployeeInterview + EmployeeInterviewFileId);
                if (System.IO.File.Exists(filePath))
                {
                    string strRequest = filePath;
                    if (!string.IsNullOrEmpty(strRequest))
                    {
                        FileInfo file = new System.IO.FileInfo(strRequest);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + EmployeeInterviewFileName + "\"");
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = ReturnExtension(file.Extension.ToLower());
                            Response.WriteFile(file.FullName);
                            Response.End();
                            //if file does not exist
                        }
                        else
                        {
                            Response.Write("This file does not exist.");
                        }
                        //nothing in the URL as HTTP GET
                    }
                    else
                    {
                        Response.Write("Please provide a file to download.");
                    }
                }
            }
        }
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":
                    return "image/png";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        protected void btnSendtoMyMobile_header_Click(object sender, EventArgs e)
        {
            SendToMyMobile();
        }
        protected void btnSendtoMyMobile_footer_Click(object sender, EventArgs e)
        {
            SendToMyMobile();
        }
        private void SendToMyMobile()
        {
            try
            {
                string PHONE = SessionWrapper.u_mobile_number;
                if (!string.IsNullOrEmpty(SessionWrapper.u_mobile_number))
                {
                    string MATRIXURL = "http://www.smsmatrix.com/matrix";
                    string USERNAME = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                    string PASSWORD = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);
                    StringBuilder sbSendCaseDetails = new StringBuilder();
                    string TXT = Server.UrlEncode("Case Number: " + lblCaseNumber.Text + ", " + "Case Title: " + lblCaseTitle.Text + ", " + "Case Date: " + lblCaseDate.Text + ", Case Category: " + lblCaseCategory.Text + ", Case Types: " + lblCaseTypes.Text + ", Case Status: " + lblCaseStatus.Text);
                    string q = "username=" + USERNAME +
                     "&password=" + PASSWORD +
                     "&phone=" + PHONE +
                     "&txt=" + TXT;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(MATRIXURL);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = q.Length;

                    StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                    streamOut.Write(q);
                    streamOut.Close();

                    StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                    string res = streamIn.ReadToEnd();
                    //Console.WriteLine("Matrix API Response:\n" + res);
                    streamIn.Close();
                    success_msg.Style.Add("display", "block");
                    error_msg.Style.Add("display", "none");
                    success_msg.InnerHtml = LocalResources.GetText("app_case_send_succ_text") + " " + PHONE;
                }
                else
                {
                    //Error message if mobile number is empty
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    error_msg.InnerHtml = LocalResources.GetText("app_mobile_number_not_registered_error_wrong");
                }
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = LocalResources.GetText("app_case_send_error_text");
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void btnSendtoMyEmail_footer_Click(object sender, EventArgs e)
        {

            SendToMyEmail();
        }

        protected void btnSendtoMyEmail_header_Click(object sender, EventArgs e)
        {

            SendToMyEmail();
        }
        private void SendToMyEmail()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessionWrapper.u_email_id))
                {
                    sendCaseDetails(SessionWrapper.u_email_id);
                }
                else
                {
                    //Error message if email id is empty
                    success_msg.Style.Add("display", "none");
                    error_msg.Style.Add("display", "block");
                    error_msg.InnerHtml = "Email ID was not registered";
                }
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01", ex.Message);
                    }
                }
            }
        }
        protected void btnSendMutiple_Click(object sender, EventArgs e)
        {
            try
            {
                sendCaseDetails(txtMultipeEmailAddress.Text);
                txtMultipeEmailAddress.Text = "";
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01", ex.Message);
                    }
                }
            }

        }

        private void sendCaseDetails(string toEmailAddress)
        {
            string toEmailid = toEmailAddress;
            //"compliancefactor.project@gmail.com";
            string[] toaddress = toEmailid.Split(',');
            List<MailAddress> mailAddresses = new List<MailAddress>();
            foreach (string recipient in toaddress)
            {
                if (recipient.Trim() != string.Empty)
                {
                    mailAddresses.Add(new MailAddress(recipient));
                }
            }
            try
            {

                // for email theme
                SystemThemes userTheme = new SystemThemes();
                userTheme = SystemThemeBLL.GetThemeForEmail(SessionWrapper.u_userid);

                //Daily Email Report
                string filePath = string.Empty;
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Compliance/MIRIS/MirisEmailTemplate/cvmv.htm");

                StringBuilder sbCaseDetails = new StringBuilder(Utility.GetHtmlTemplate(filePath));

                sbCaseDetails.Replace("@s_theme_head_logo_file_name", userTheme.s_theme_head_logo_file_name);
                sbCaseDetails.Replace("@s_theme_report_logo_file_name", userTheme.s_theme_report_logo_file_name);
                sbCaseDetails.Replace("@s_theme_notification_logo_file_name", Request.Url.Host.ToLower() + "/SystemHome/Configuration/Themes/Logo/" + userTheme.s_theme_notification_logo_file_name);
                sbCaseDetails.Replace("@s_theme_css_tag_section_head_hex_value", userTheme.s_theme_css_tag_section_head_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_section_head_text_hex_value", userTheme.s_theme_css_tag_section_head_text_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_section_head_border_hex_value", userTheme.s_theme_css_tag_section_head_border_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_body_text_hex_value", userTheme.s_theme_css_tag_body_text_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_main_background_hex_value", userTheme.s_theme_css_tag_main_background_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_foot_top_line_hex_value", userTheme.s_theme_css_tag_foot_top_line_hex_value);
                sbCaseDetails.Replace("@s_theme_css_tag_foot_bot_line_hex_value", userTheme.s_theme_css_tag_foot_bot_line_hex_value);

                sbCaseDetails.Replace("@app_case_page_title",LocalResources.GetLabel("app_case_details_text")+ lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_number_text",LocalResources.GetLabel("app_case_number_text"));
                sbCaseDetails.Replace("@lblCaseNumber", lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_title_text",LocalResources.GetLabel("app_case_title_text"));
                sbCaseDetails.Replace("@lblCaseTitle", lblCaseTitle.Text);
                sbCaseDetails.Replace("@app_case_date_text",LocalResources.GetLabel("app_case_date_text"));
                sbCaseDetails.Replace("@lblCaseDate", lblCaseDate.Text);
                sbCaseDetails.Replace("@app_case_category_text",LocalResources.GetLabel("app_case_category_text"));
                sbCaseDetails.Replace("@lblCaseCategory", lblCaseCategory.Text);
                sbCaseDetails.Replace("@app_case_types_text",LocalResources.GetLabel("app_case_types_text"));
                sbCaseDetails.Replace("@lblCaseTypes", lblCaseTypes.Text);
                sbCaseDetails.Replace("@app_case_status_text",LocalResources.GetLabel("app_case_status_text"));
                sbCaseDetails.Replace("@lblCaseStatus", lblCaseStatus.Text);
                sbCaseDetails.Replace("@app_case_description_text",LocalResources.GetLabel("app_case_description_text"));
                sbCaseDetails.Replace("@app_employee_name_text",LocalResources.GetLabel("app_employee_name_text"));
                sbCaseDetails.Replace("@lblEmployeeName", lblEmployeeName.Text);
                sbCaseDetails.Replace("@app_date_of_birth_text",LocalResources.GetLabel("app_date_of_birth_text"));
                sbCaseDetails.Replace("@lblDateOfBirth", lblDateOfBirth.Text);
                sbCaseDetails.Replace("@app_employee_hire_date_text",LocalResources.GetLabel("app_employee_hire_date_text"));
                sbCaseDetails.Replace("@lblEmployeeHireDate", lblEmployeeHireDate.Text);
                sbCaseDetails.Replace("@app_employee_id_text",LocalResources.GetLabel("app_employee_id_text"));
                sbCaseDetails.Replace("@lblEmployeeId", lblEmployeeId.Text);
                sbCaseDetails.Replace("@app_last_digit_of_ssn",LocalResources.GetLabel("app_last_digit_of_ssn#_text"));
                sbCaseDetails.Replace("@lblLastFourDigitOfSSN", lblLastFourDigitOfSSN.Text);
                sbCaseDetails.Replace("@app_supervisor_text",LocalResources.GetLabel("app_supervisor_text"));
                sbCaseDetails.Replace("@lblSupervisor", lblSupervisor.Text);
                sbCaseDetails.Replace("@app_incident_location_text",LocalResources.GetLabel("app_incident_location_text"));
                sbCaseDetails.Replace("@lblIncidentLocation", lblIncidentLocation.Text);
                sbCaseDetails.Replace("@app_incident_date_text",LocalResources.GetLabel("app_incident_date_text"));
                sbCaseDetails.Replace("@lblIncidentDate", lblIncidentDate.Text);
                sbCaseDetails.Replace("@app_incident_time_text", LocalResources.GetLabel("app_incident_time_text"));
                sbCaseDetails.Replace("@lblIncidentTime", lblIncidentTime.Text);
                sbCaseDetails.Replace("@app_employee_report_location_text",LocalResources.GetLabel("app_employee_report_location_text"));
                sbCaseDetails.Replace("@lblEmployeeReportLocation", lblEmployeeReportLocation.Text);
                sbCaseDetails.Replace("@app_timezone_text",LocalResources.GetLabel("app_timezone_text"));
                sbCaseDetails.Replace("@lblTimeZone", lblTimeZone.Text);
                sbCaseDetails.Replace("@app_note_text", LocalResources.GetLabel("app_note_text"));
                sbCaseDetails.Replace("@lblNote", lblNote.Text);
                sbCaseDetails.Replace("@app_additional_Information_text",LocalResources.GetLabel("app_additional_Information_text"));
                sbCaseDetails.Replace("@app_witness(es)_text",LocalResources.GetLabel("app_witness(es)_text"));
                sbCaseDetails.Replace("@app_police_reports(s)_text", LocalResources.GetLabel("app_police_reports(s)_text"));
                sbCaseDetails.Replace("@app_photo(s)_text",LocalResources.GetLabel("app_photo(s)_text"));
                sbCaseDetails.Replace("@app_scene_sketch(es)_text",LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbCaseDetails.Replace("@app_extenuating_condition(s)_text",LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbCaseDetails.Replace("@app_employee_interview(s)_text",LocalResources.GetLabel("app_employee_interview(s)_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_infornation_text", LocalResources.GetLabel("app_root_cause_analysis_infornation_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_details_text",LocalResources.GetLabel("app_root_cause_analysis_details_text"));
                sbCaseDetails.Replace("@lblRootCauseAnalysisDetails", lblRootCauseAnalysisDetails.Text);
                sbCaseDetails.Replace("@app_corrective_action_information_text",LocalResources.GetLabel("app_corrective_action_information_text"));
                sbCaseDetails.Replace("@app_corrective_action_details_text", LocalResources.GetLabel("app_corrective_action_details_text"));
                sbCaseDetails.Replace("@lblCorrectiveActionDetails", lblCorrectiveActionDetails.Text);
                sbCaseDetails.Replace("@app_vehicle_01_text", LocalResources.GetLabel("app_vehicle_text")+" 1");
                sbCaseDetails.Replace("@lblVehicle01", lblVehicle01.Text);
                sbCaseDetails.Replace("@app_vehicle_02_text", LocalResources.GetLabel("app_vehicle_text")+" 2");
                sbCaseDetails.Replace("@lblVehicle02", lblVehicle02.Text);
                sbCaseDetails.Replace("@app_vehicle_id_text", LocalResources.GetLabel("app_vehicle_id_text"));
                sbCaseDetails.Replace("@lblVehicleId", lblVehicleId.Text);
                sbCaseDetails.Replace("@app_vin_text",LocalResources.GetLabel("app_vin_text"));
                sbCaseDetails.Replace("@lblVIN", lblVIN.Text);
                sbCaseDetails.Replace("@app_license_number_text",LocalResources.GetLabel("app_license_number_text"));
                sbCaseDetails.Replace("@lblLicenseNumber", lblLicenseNumber.Text);
                sbCaseDetails.Replace("@app_vehicle_make_text",LocalResources.GetLabel("app_vehicle_make_text"));
                sbCaseDetails.Replace("@lblVehicleMake", lblVehicleMake.Text);
                sbCaseDetails.Replace("@app_vehicle_model_text",LocalResources.GetLabel("app_model_text"));
                sbCaseDetails.Replace("@lblVehicleModel", lblVehicleModel.Text);
                sbCaseDetails.Replace("@app_vehicle_type_text", LocalResources.GetLabel("app_type_text"));
                sbCaseDetails.Replace("@lblVehicleType", lblVehicleType.Text);
                sbCaseDetails.Replace("@app_year_text",LocalResources.GetLabel("app_year_text"));
                sbCaseDetails.Replace("@lblYear", lblYear.Text);
                sbCaseDetails.Replace("@app_state_text",LocalResources.GetLabel("app_state_text"));
                sbCaseDetails.Replace("@lblStateandClass", lblStateandClass.Text);
                sbCaseDetails.Replace("@lblState", lblState.Text);
                sbCaseDetails.Replace("@app_company_vehicle_struck_text", LocalResources.GetLabel("app_company_vehicle_struck_text"));
                sbCaseDetails.Replace("@lblCompanyVehicleStruckby", lblCompanyVehicleStruckby.Text);
                sbCaseDetails.Replace("@lblCompanyVehicleStruck", lblCompanyVehicleStruck.Text);
                sbCaseDetails.Replace("@app_company_vehicle_struck_by_text", LocalResources.GetLabel("app_company_vehicle_struck_by_text"));
                sbCaseDetails.Replace("@app_non_collision_text",LocalResources.GetLabel("app_non_collision_text"));
                sbCaseDetails.Replace("@lblNonCollisionText", lblNonCollisionText.Text);
                sbCaseDetails.Replace("@lblNonCollision", lblNonCollision.Text);
                //case details
                sbCaseDetails.Replace("@app_case_details_text",LocalResources.GetLabel("app_case_details_text"));
                sbCaseDetails.Replace("@app_drivers_lic_text",LocalResources.GetLabel("app_drivers_lic_text"));
                sbCaseDetails.Replace("@lblDriversLic", lblDriversLic.Text);
                sbCaseDetails.Replace("@app_state_and_class_text",LocalResources.GetLabel("app_state_and_class_text"));
                sbCaseDetails.Replace("@app_expire_date_text",LocalResources.GetLabel("app_expiry_state_text"));
                sbCaseDetails.Replace("@lblExpireDate", lblExpireDate.Text);
                sbCaseDetails.Replace("@app_address_text",LocalResources.GetLabel("app_address_text"));
                sbCaseDetails.Replace("@lblAddress", lblAddress.Text);
                sbCaseDetails.Replace("@app_city_text",LocalResources.GetLabel("app_city_text"));
                sbCaseDetails.Replace("@lblCity", lblCity.Text);
                sbCaseDetails.Replace("@lblDriverState", lblDriverState.Text);
                sbCaseDetails.Replace("@app_nearest_cross_street_text",LocalResources.GetLabel("app_nearest_cross_street_intersection_text"));
                sbCaseDetails.Replace("@lblNearestCrossStreet", lblNearestCrossStreet.Text);
                sbCaseDetails.Replace("@app_type_of_roadway_text",LocalResources.GetLabel("app_type_of_roadway_text"));
                sbCaseDetails.Replace("@lblTypeofRoadway", lblTypeofRoadway.Text);
                sbCaseDetails.Replace("@app_road_condition_text",LocalResources.GetLabel("app_road_condition_text"));
                sbCaseDetails.Replace("@lblRoadCondition", lblRoadCondition.Text);
                sbCaseDetails.Replace("@app_time_of_day_text",LocalResources.GetLabel("app_time_of_day_text"));
                sbCaseDetails.Replace("@lblTimeofDay", lblTimeofDay.Text);
                // here we need to add one column
                sbCaseDetails.Replace("@app_weather_text",LocalResources.GetLabel("app_weather_text"));
                sbCaseDetails.Replace("@lblWeather", lblWeather.Text);
                sbCaseDetails.Replace("@app_traffic_condition_text",LocalResources.GetLabel("app_traffic_condition_text"));
                sbCaseDetails.Replace("@lblTrafficCondition", lblTrafficCondition.Text);
                sbCaseDetails.Replace("@app_traffic_controls_text",LocalResources.GetLabel("app_traffic_controls_text"));
                sbCaseDetails.Replace("@lblTrafficControls", lblTrafficControls.Text);
                sbCaseDetails.Replace("@app_operating_speed_text",LocalResources.GetLabel("app_operating_speed_text"));
                sbCaseDetails.Replace("@lblOperatingSpeed", string.Empty);
                sbCaseDetails.Replace("@app_speed_limit_text", LocalResources.GetLabel("app_speed_limit_text"));
                sbCaseDetails.Replace("@lblSpeedLimit", string.Empty);

                //miris.c_case_detail_oprating_speed = string.Empty;  //doubt

                //miris.c_case_detail_speed_limit = string.Empty;   //doubt
                sbCaseDetails.Replace("@app_vehicle_struck_text",LocalResources.GetLabel("app_vehicle_struck_text"));
                sbCaseDetails.Replace("@lblVehicleStruckby", lblVehicleStruckby.Text);
                sbCaseDetails.Replace("@lblVehicleStruck", lblVehicleStruck.Text);
                sbCaseDetails.Replace("@app_vehicle_struck_by_text", LocalResources.GetLabel("app_vehicle_struck_by_text"));
                sbCaseDetails.Replace("@app_collision_type_text",LocalResources.GetLabel("app_collision_type_text"));
                sbCaseDetails.Replace("@lblNonCollisionType", lblNonCollisionType.Text);
                sbCaseDetails.Replace("@lblCollisionType", lblCollisionType.Text);
                sbCaseDetails.Replace("@app_collision_location_text",LocalResources.GetLabel("app_collision_location_text"));
                sbCaseDetails.Replace("@lblCollisionLocation", lblCollisionLocation.Text);
                sbCaseDetails.Replace("@app_collision_direction_text",LocalResources.GetLabel("app_collision_direction_text"));
                sbCaseDetails.Replace("@lblCollisionDirection", lblCollisionDirection.Text);
                sbCaseDetails.Replace("@app_non_collision_type_text",LocalResources.GetLabel("app_non_collision_type_text"));
                //sbCaseDetails.Replace("@lblNonCollisionType", lblNonCollisionType.Text);
                sbCaseDetails.Replace("@app_number_of_vehicle_involved_text",LocalResources.GetLabel("app_number_of_vehicles_involved_text"));
                sbCaseDetails.Replace("@lblNumberofVehicleInvolved", lblNumberofVehicleInvolved.Text);
                sbCaseDetails.Replace("@app_number_of_vehicle_towed_text",LocalResources.GetLabel("app_number_of_vehicles_towed_text"));
                sbCaseDetails.Replace("@lblNumberofVehicletowed", lblNumberofVehicletowed.Text);
                sbCaseDetails.Replace("@app_number_of_people_injured_text",LocalResources.GetLabel("app_number_of_people_injured_text"));
                sbCaseDetails.Replace("@lblNoofPeopleInjured", lblNoofPeopleInjured.Text);
                sbCaseDetails.Replace("@app_number_of_people_killed_text", "Number of People Killed");
                sbCaseDetails.Replace("@lblNoofPeopleKilled", lblNoofPeopleKilled.Text);
                sbCaseDetails.Replace("@app_cituation_issued_text",LocalResources.GetLabel("app_situation_issued_text"));
                sbCaseDetails.Replace("@lblCituationIssued", lblCituationIssued.Text);
                sbCaseDetails.Replace("@app_at_whom_text",LocalResources.GetLabel("app_at_home_text"));
                sbCaseDetails.Replace("@lblAtWhom", lblAtWhom.Text);
                sbCaseDetails.Replace("@app_at_fault_text",LocalResources.GetLabel("app_at_fault_text"));
                sbCaseDetails.Replace("@lblAtfault", lblAtfault.Text);
                sbCaseDetails.Replace("@app_contributory_text",LocalResources.GetLabel("app_contributory_text"));
                sbCaseDetails.Replace("@lblContributory", lblContributory.Text);
                sbCaseDetails.Replace("@app_gross_vehicle_weight_text",LocalResources.GetLabel("app_cross_vehicle_weight_text"));
                sbCaseDetails.Replace("@lblGrossVehicleWeight", lblGrossVehicleWeight.Text);
                sbCaseDetails.Replace("@app_combined_gross_vehicle_weight_text",LocalResources.GetLabel("app_combined_gross_vehicle_weight_text"));
                sbCaseDetails.Replace("@lblCombinedGrossVehicleWeight", lblCombinedGrossVehicleWeight.Text);
                sbCaseDetails.Replace("@app_dot_vehicle_text",LocalResources.GetLabel("app_dot_vehicle_text"));
                sbCaseDetails.Replace("@lblDotVehicle", lblDotVehicle.Text);
                sbCaseDetails.Replace("@app_dot_driver_text",LocalResources.GetLabel("app_dot_driver_text"));
                sbCaseDetails.Replace("@lblDotDriver", lblDotDriver.Text);
                sbCaseDetails.Replace("@app_seat_belt_used_text",LocalResources.GetLabel("app_seat_belt_used_text"));
                sbCaseDetails.Replace("@lblSeatBeltUsed", lblSeatBeltUsed.Text);
                sbCaseDetails.Replace("@app_air_bag_equipped_text",LocalResources.GetLabel("app_air_bag_equipped_text"));
                sbCaseDetails.Replace("@lblAirBagEquipped", lblAirBagEquipped.Text);
                sbCaseDetails.Replace("@app_air_bag_deployed_text",LocalResources.GetLabel("app_air_bag_deployed_text"));
                sbCaseDetails.Replace("@lblAirBagDeployed", lblAirBagDeployed.Text);
                sbCaseDetails.Replace("@app_cellphone_in_use_during_operation_text",LocalResources.GetLabel("app_cellphone_use_during_operation_text"));
                sbCaseDetails.Replace("@lblCellphoneinUse", lblCellphoneinUse.Text);
                sbCaseDetails.Replace("@app_computer_in_use_during_operation_text",LocalResources.GetLabel("app_computer_use_during_operation_text"));
                sbCaseDetails.Replace("@lblComputerInUse", lblComputerInUse.Text);
                sbCaseDetails.Replace("@app_special_equipment_text",LocalResources.GetLabel("app_special_equipment_text"));
                sbCaseDetails.Replace("@lblSpecialEquipment", lblSpecialEquipment.Text);
                sbCaseDetails.Replace("@lblSpecialEquipment", lblSpecialEquipment.Text);
                sbCaseDetails.Replace("@app_location_of_impact_text", LocalResources.GetLabel("app_location_of_impact_text"));
                sbCaseDetails.Replace("@lblLocationofImpact", lblLocationofImpact.Text);
                sbCaseDetails.Replace("@app_driver_injured_text",LocalResources.GetLabel("app_driver_injured_text"));
                sbCaseDetails.Replace("@lblDriverInjured", lblDriverInjured.Text);
                sbCaseDetails.Replace("@app_passenger_injured_text", LocalResources.GetLabel("app_passenger_injured_text"));
                sbCaseDetails.Replace("@lblPassengerInjured", lblPassengerInjured.Text);
                sbCaseDetails.Replace("@app_description_of_damage_text",LocalResources.GetLabel("app_description_of_damage_text"));
                sbCaseDetails.Replace("@lblHeavyDamage", lblHeavyDamage.Text);
                sbCaseDetails.Replace("@app_moderate_text",LocalResources.GetLabel("app_moderate_text"));
                sbCaseDetails.Replace("@lblModerateDamage", lblModerateDamage.Text);
                sbCaseDetails.Replace("@app_light_text",LocalResources.GetLabel("app_light_text"));
                sbCaseDetails.Replace("@lblLightDamage", lblLightDamage.Text);
                //Public Vehicle
                sbCaseDetails.Replace("@app_driver_name_text",LocalResources.GetLabel("app_driver_name_text"));
                sbCaseDetails.Replace("@lblDriverName", lblDriverName.Text);
                sbCaseDetails.Replace("@app_driver_address_text",LocalResources.GetLabel("app_driver_address_text"));
                sbCaseDetails.Replace("@lblDriverAddress", lblDriverAddress.Text);
                sbCaseDetails.Replace("@app_driver_contact_text",LocalResources.GetLabel("app_driver_contact_text"));
                sbCaseDetails.Replace("@lblDriverContact", lblDriverContact.Text);
                sbCaseDetails.Replace("@app_owner_name_text", LocalResources.GetLabel("app_owner_name_text"));
                sbCaseDetails.Replace("@lblOwnerName", lblOwnerName.Text);
                sbCaseDetails.Replace("@app_public_address_text",LocalResources.GetLabel("app_owner_address_text"));
                sbCaseDetails.Replace("@lblOwnerAddress", lblOwnerAddress.Text);
                sbCaseDetails.Replace("@app_public_contact_text", LocalResources.GetLabel("app_owner_contact_text"));
                sbCaseDetails.Replace("@lblOwnerContact", lblOwnerContact.Text);
                sbCaseDetails.Replace("@lblPublicVehicleId", lblPublicVehicleId.Text);
                sbCaseDetails.Replace("@lblPublicVehicleVIN", lblPublicVehicleVIN.Text);
                sbCaseDetails.Replace("@app_public_license_number_text",LocalResources.GetLabel("app_license_number_text"));
                sbCaseDetails.Replace("@lblPublicLicenseNumber", lblPublicLicenseNumber.Text);
                sbCaseDetails.Replace("@lblPublicVehicleMake", lblPublicVehicleMake.Text);
                sbCaseDetails.Replace("@lblPublicVehicleModel", lblPublicVehicleModel.Text);
                sbCaseDetails.Replace("@app_vehicle_type_text",LocalResources.GetLabel("app_type_text"));
                sbCaseDetails.Replace("@lblPublicVehicleType", lblPublicVehicleType.Text);
                sbCaseDetails.Replace("@lblPublicYear", lblPublicYear.Text);
                sbCaseDetails.Replace("@lblPublicState", lblPublicState.Text);
                sbCaseDetails.Replace("@app_public_gross_vehicle_weight_text",LocalResources.GetLabel("app_cross_vehicle_weight_text"));
                sbCaseDetails.Replace("@lblPublicGrossVehicleWeight", lblPublicGrossVehicleWeight.Text);
                sbCaseDetails.Replace("@app_public_combined_vehicle_weight_text",LocalResources.GetLabel("app_combined_gross_vehicle_weight_text"));
                sbCaseDetails.Replace("@lblPublicCombinedVehicleWeight", lblPublicCombinedVehicleWeight.Text);
                sbCaseDetails.Replace("@app_public_dot_vehicle_text", LocalResources.GetLabel("app_dot_vehicle_text"));
                sbCaseDetails.Replace("@lblPublicDotVehicle", lblPublicDotVehicle.Text);
                sbCaseDetails.Replace("@app_public_dot_driver_text",LocalResources.GetLabel("app_dot_driver_text"));
                sbCaseDetails.Replace("@lblPublicDotDriver", lblPublicDotDriver.Text);
                sbCaseDetails.Replace("@app_public_seat_belt_used_text", LocalResources.GetLabel("app_seat_belt_used_text"));
                sbCaseDetails.Replace("@lblPublicSeatBeltUsed", lblPublicSeatBeltUsed.Text);
                sbCaseDetails.Replace("@app_public_air_bag_equipped_text",LocalResources.GetLabel("app_air_bag_equipped_text"));
                sbCaseDetails.Replace("@lblPublicAirBagEquipped", lblPublicAirBagEquipped.Text);
                sbCaseDetails.Replace("@app_public_air_bag_deployed_text",LocalResources.GetLabel("app_air_bag_deployed_text"));
                sbCaseDetails.Replace("@lblPublicAirBagDeployed", lblPublicAirBagDeployed.Text);
                sbCaseDetails.Replace("@app_public_cellphone_in_use_text",LocalResources.GetLabel("app_cellphone_use_during_operation_text"));
                sbCaseDetails.Replace("@lblPublicCellphoneinUse", lblPublicCellphoneinUse.Text);
                sbCaseDetails.Replace("@app_public_computer_in_use_text",LocalResources.GetLabel("app_computer_use_during_operation_text"));
                sbCaseDetails.Replace("@lblPublicComputerInUse", lblPublicComputerInUse.Text);
                sbCaseDetails.Replace("@lblPublicSpecialEquipmentText", lblPublicSpecialEquipmentText.Text);
                sbCaseDetails.Replace("@app_public_special_equipment_text",LocalResources.GetLabel("app_special_equipment_text"));
                sbCaseDetails.Replace("@lblPublicSpecialEquipment", lblPublicSpecialEquipment.Text);
                sbCaseDetails.Replace("@app_public_location_of_impact_text",LocalResources.GetLabel("app_location_of_impact_text"));
                sbCaseDetails.Replace("@lblPublicLocationofImpact", lblPublicLocationofImpact.Text);
                sbCaseDetails.Replace("@app_public_driver_injured_text",LocalResources.GetLabel("app_driver_injured_text"));
                sbCaseDetails.Replace("@lblPublicDriverInjured", lblPublicDriverInjured.Text);
                sbCaseDetails.Replace("@app_public_passenger_injured_text",LocalResources.GetLabel("app_passenger_injured_text"));
                sbCaseDetails.Replace("@lblPublicPassengerInjured", lblPublicPassengerInjured.Text);
                sbCaseDetails.Replace("@app_total_vehicle_occupant",LocalResources.GetLabel("app_number_total_vehicle_occupant_injuries_text"));
                sbCaseDetails.Replace("@lblTotalvehicleOccupant", lblTotalvehicleOccupant.Text);
                sbCaseDetails.Replace("@app_description_of_public_vehicle_damage_text",LocalResources.GetLabel("app_description_public_vehicle_damage_text"));
                sbCaseDetails.Replace("@app_heavy_text",LocalResources.GetLabel("app_heavy_text"));
                sbCaseDetails.Replace("@lblPublicHeavyDamage", lblPublicHeavyDamage.Text);
                sbCaseDetails.Replace("@lblPublicModerateDamage", lblPublicModerateDamage.Text);
                sbCaseDetails.Replace("@lblPublicLightDamage", lblPublicLightDamage.Text);
                //Pedestrain Incident
                sbCaseDetails.Replace("@app_name_of_pedestrain_text",LocalResources.GetLabel("app_name_of_the_pedestrain_involved_text"));
                sbCaseDetails.Replace("@lblNameofPedestrain", lblNameofPedestrian.Text);
                
                sbCaseDetails.Replace("@lblPedestrainAddress", lblPedestrianAddress.Text);
                sbCaseDetails.Replace("@lblPedestrainPhone", lblPedestrainPhone.Text);
                sbCaseDetails.Replace("@app_sex_text",LocalResources.GetLabel("app_sex_text"));
                sbCaseDetails.Replace("@lblPedestrainSex", lblPedestrainSex.Text);
                sbCaseDetails.Replace("@app_age_text",LocalResources.GetLabel("app_age_text"));
                sbCaseDetails.Replace("@lblPedestrainAge", lblPedestrainAge.Text);
                sbCaseDetails.Replace("@app_pedestrain_collision_type_text",LocalResources.GetLabel("app_collision_type_text"));
                sbCaseDetails.Replace("@lblPedestrainCollisionType", lblPedestrainCollisionType.Text);
                sbCaseDetails.Replace("@app_pedestrain_description_text",LocalResources.GetLabel("app_description_text"));
                sbCaseDetails.Replace("@lblPedestrainDescription", lblPedestrainDescription.Text);
                //BICycle Incident
                sbCaseDetails.Replace("@app_bicycle_incident_text",LocalResources.GetLabel("app_bicycle_incident_text"));

                sbCaseDetails.Replace("@app_bicycle_person_name_text",LocalResources.GetLabel("app_name_person_involved_text"));
                sbCaseDetails.Replace("@lblBicycleNameofPerson", lblBicycleNameofPerson.Text);
                
                sbCaseDetails.Replace("@lblBicyclePersonAddress", lblBicyclePersonAddress.Text);
                sbCaseDetails.Replace("@app_phone_text", LocalResources.GetLabel("app_phone_text"));
                sbCaseDetails.Replace("@lblBicyclePersonPhone", lblBicyclePersonPhone.Text);
                sbCaseDetails.Replace("@lblBicyclePersonSex", lblBicyclePersonSex.Text);
                sbCaseDetails.Replace("@lblBicyclePersonAge", lblBicyclePersonAge.Text);
                sbCaseDetails.Replace("@app_bicycle_collision_type_text",LocalResources.GetLabel("app_collision_type_text"));
                sbCaseDetails.Replace("@lblBicycleCollisionType", lblBicycleCollisionType.Text);
                sbCaseDetails.Replace("@app_bicycle_description_text", LocalResources.GetLabel("app_description_text"));
                sbCaseDetails.Replace("@lblBicycleDescription", lblBicycleDescription.Text);
                //Animal Incident
                sbCaseDetails.Replace("@app_animal_incident_text",LocalResources.GetLabel("app_animal_incident_text"));

                sbCaseDetails.Replace("@app_animal_name_text",LocalResources.GetLabel("app_name_of_animal_involved_text"));
                sbCaseDetails.Replace("@lblAnimalName", lblAnimalName.Text);
                sbCaseDetails.Replace("@app_place_text",LocalResources.GetLabel("app_place_text"));
                sbCaseDetails.Replace("@lblPlace", lblPlace.Text);
                sbCaseDetails.Replace("@app_animal_collision_type_text",LocalResources.GetLabel("app_collision_type_text"));
                sbCaseDetails.Replace("@lblAnimalCollisionType", lblAnimalCollisionType.Text);
                sbCaseDetails.Replace("@app_animal_description_text",LocalResources.GetLabel("app_description_text"));
                sbCaseDetails.Replace("@lblAnimalDescription", lblAnimalDescription.Text);
                //Fixed Object Incident
                sbCaseDetails.Replace("@app_property_incident_text", LocalResources.GetLabel("app_fixed_object_incident_text"));

                sbCaseDetails.Replace("@app_property_owner_text", LocalResources.GetLabel("app_property_owner_text"));
                sbCaseDetails.Replace("@lblPropertyOwner", lblPropertyOwner.Text);
                sbCaseDetails.Replace("@lblPropertyAddress", lblPropertyAddress.Text);
                sbCaseDetails.Replace("@app_contact_information_text",LocalResources.GetLabel("app_contact_information_text"));
                sbCaseDetails.Replace("@lblContactInformation", lblContactInformation.Text);
                sbCaseDetails.Replace("@app_property_collision_type_text", LocalResources.GetLabel("app_collision_type_text"));
                sbCaseDetails.Replace("@lblPropertyCollisionType", lblPropertyCollisionType.Text);
                sbCaseDetails.Replace("@app_property_description_text",LocalResources.GetLabel("app_description_text"));
                sbCaseDetails.Replace("@lblPropertyDesc", lblPropertyDesc.Text);
                sbCaseDetails.Replace("@app_property_physical_desc_text",LocalResources.GetLabel("app_physical_description_of_property_text"));
                sbCaseDetails.Replace("@lblPhysicalPropertyDesc", lblPhysicalPropertyDesc.Text);
                sbCaseDetails.Replace("@lblVehicle_Type02Value", lblVehicleType02.Text);
                sbCaseDetails.Replace("@lblVehicleId02", lblVehicleId02.Text);
                sbCaseDetails.Replace("@lblVIN02", lblVIN02.Text);
                sbCaseDetails.Replace("@lblLicenceNumber02", lblLicenceNumber02.Text);
                sbCaseDetails.Replace("@lblState02", lblState02.Text);
                sbCaseDetails.Replace("@lblMake02", lblMake02.Text);
                sbCaseDetails.Replace("@lblModel02", lblModel02.Text);
                sbCaseDetails.Replace("@lblYear02", lblYear02.Text);

                // sbCaseDetails.Replace("@app_osha_300_information_text", LocalResources.GetLabel("app_osha_300_information_text"));
                // sbCaseDetails.Replace("@app_user_case_outcome_text", LocalResources.GetLabel("app_case_outcome_text"));
                //sbCaseDetails.Replace("@lblCaseOutCome", lblCaseOutCome.Text);
                //sbCaseDetails.Replace("@app_user_days_away_from_work_text", LocalResources.GetLabel("app_days_away_from_work_text"));
                //sbCaseDetails.Replace("@lblDaysAwayFromWork", lblDaysAwayFromWork.Text);
                //sbCaseDetails.Replace("@app_user_days_of_restrictions_text", LocalResources.GetLabel("app_days_of_restrictions_text"));
                //sbCaseDetails.Replace("@lblDaysOfRestrictions", lblDaysOfRestrictions.Text);
                //sbCaseDetails.Replace("@app_user_data_of_death_text", LocalResources.GetLabel("app_data_of_death_text"));
                //sbCaseDetails.Replace("@lblDateOfDeath", lblDateOfDeath.Text);
                //sbCaseDetails.Replace("@app_user_type_of_illness_text", LocalResources.GetLabel("app_type_of_illness_text"));
                //sbCaseDetails.Replace("@lblTypeofIllness", lblTypeofIllness.Text);
                //sbCaseDetails.Replace("@app_user_describe_injury_or_illness_text", LocalResources.GetLabel("app_describe_injury_or_illness_text"));
                //sbCaseDetails.Replace("@lblOSHA300info", lblOSHA300info.Text);
                //sbCaseDetails.Replace("@app_user_oosha_301_information_text", LocalResources.GetLabel("app_oosha_301_information_text"));
                //sbCaseDetails.Replace("@app_user_worker_gender_text", LocalResources.GetLabel("app_worker_gender_text"));
                //sbCaseDetails.Replace("@lblWorkerGender", lblWorkerGender.Text);
                //sbCaseDetails.Replace("@app_user_works_start_time_text", LocalResources.GetLabel("app_works_start_time_text"));
                //sbCaseDetails.Replace("@lblWorkStartTime", lblWorkStartTime.Text);
                //sbCaseDetails.Replace("@app_user_physician_text", LocalResources.GetLabel("app_physician_text"));
                //sbCaseDetails.Replace("@lblPhysician", lblPhysician.Text);
                //sbCaseDetails.Replace("@app_user_treatment_facility_text", LocalResources.GetLabel("app_treatment_facility_text"));
                //sbCaseDetails.Replace("@lblTreatmentFacility", lblTreatmentFacility.Text);
                //sbCaseDetails.Replace("@app_user_emergency_room_text", LocalResources.GetLabel("app_emergency_room_text"));
                //sbCaseDetails.Replace("@lblEmergencyRoom", lblEmergencyRoom.Text);
                //sbCaseDetails.Replace("@app_user_hospitalized_text", LocalResources.GetLabel("app_hospitalized_text"));
                //sbCaseDetails.Replace("@lblHospitalized", lblHospitalized.Text);
                //sbCaseDetails.Replace("@app_user_address_1_text", LocalResources.GetLabel("app_address_1_text"));
                //sbCaseDetails.Replace("@lblAddress1", lblAddress1.Text);
                //sbCaseDetails.Replace("@app_user_address_2_text", LocalResources.GetLabel("app_address_2_text"));
                //sbCaseDetails.Replace("@lblAddress2", lblAddress2.Text);
                //sbCaseDetails.Replace("@app_user_address_3_text", LocalResources.GetLabel("app_address_3_text"));
                //sbCaseDetails.Replace("@lblAddress3", lblAddress3.Text);
                //sbCaseDetails.Replace("@app_city_text", LocalResources.GetLabel("app_city_text"));
                //sbCaseDetails.Replace("@lblCity", lblCity.Text);
                //sbCaseDetails.Replace("@app_state_text", LocalResources.GetLabel("app_state_text"));
                //sbCaseDetails.Replace("@lblState", lblState.Text);
                //sbCaseDetails.Replace("@app_user_zip_text", LocalResources.GetLabel("app_zip_text"));
                //sbCaseDetails.Replace("@lblZipCode", lblZipCode.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_employee_text", LocalResources.GetLabel("app_what_was_the_employee_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info1", lblOSHA301Info1.Text);
                //sbCaseDetails.Replace("@app_user_what_happened_tell_text", LocalResources.GetLabel("app_what_happened_tell_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info2", lblOSHA301Info2.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_injury_text", LocalResources.GetLabel("app_what_was_the_injury_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info3", lblOSHA301Info3.Text);
                //sbCaseDetails.Replace("@app_user_object_or_substance_text", LocalResources.GetLabel("app_what_object_or_substance_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info4", lblOSHA301Info4.Text);
                sbCaseDetails.Replace("@app_custom_fields_text", LocalResources.GetLabel("app_custom_fields_text"));
                sbCaseDetails.Replace("@app_custom_01_text", LocalResources.GetLabel("app_custom_01_text"));
                sbCaseDetails.Replace("@app_custom_02_text", LocalResources.GetLabel("app_custom_02_text"));
                sbCaseDetails.Replace("@app_custom_03_text", LocalResources.GetLabel("app_custom_03_text"));
                sbCaseDetails.Replace("@app_custom_04_text", LocalResources.GetLabel("app_custom_04_text"));
                sbCaseDetails.Replace("@app_custom_05_text", LocalResources.GetLabel("app_custom_05_text"));
                sbCaseDetails.Replace("@app_custom_06_text", LocalResources.GetLabel("app_custom_06_text"));
                sbCaseDetails.Replace("@app_custom_07_text", LocalResources.GetLabel("app_custom_07_text"));
                sbCaseDetails.Replace("@app_custom_08_text", LocalResources.GetLabel("app_custom_08_text"));
                sbCaseDetails.Replace("@app_custom_09_text", LocalResources.GetLabel("app_custom_09_text"));
                sbCaseDetails.Replace("@app_custom_10_text", LocalResources.GetLabel("app_custom_10_text"));
                sbCaseDetails.Replace("@app_custom_11_text", LocalResources.GetLabel("app_custom_11_text"));
                sbCaseDetails.Replace("@app_custom_12_text", LocalResources.GetLabel("app_custom_12_text"));
                sbCaseDetails.Replace("@app_custom_13_text", LocalResources.GetLabel("app_custom_13_text"));
                sbCaseDetails.Replace("@wp_app_release_number",LocalResources.GetText("wp_app_release_number"));
                sbCaseDetails.Replace("@lblCustom01", lblCustom01.Text);
                sbCaseDetails.Replace("@lblCustom02", lblCustom02.Text);
                sbCaseDetails.Replace("@lblCustom03", lblCustom03.Text);
                sbCaseDetails.Replace("@lblCustom04", lblCustom04.Text);
                sbCaseDetails.Replace("@lblCustom05", lblCustom05.Text);
                sbCaseDetails.Replace("@lblCustom06", lblCustom06.Text);
                sbCaseDetails.Replace("@lblCustom07", lblCustom07.Text);
                sbCaseDetails.Replace("@lblCustom08", lblCustom08.Text);
                sbCaseDetails.Replace("@lblCustom09", lblCustom09.Text);
                sbCaseDetails.Replace("@lblCustom10", lblCustom10.Text);
                sbCaseDetails.Replace("@lblCustom11", lblCustom11.Text);
                sbCaseDetails.Replace("@lblCustom12", lblCustom12.Text);
                sbCaseDetails.Replace("@lblCustom13", lblCustom13.Text);
                sbCaseDetails.Replace("@app_required_fields_text", LocalResources.GetLabel("app_required_fields_text"));

                ComplianceDAO miris = new ComplianceDAO();
                miris.c_case_id_pk = view;
                miris.s_locale_culture = SessionWrapper.CultureName;

                //Get Vehicle Values from Vehicle 03-10
                DataTable dtGetVehicleValues = new DataTable();
                dtGetVehicleValues = ComplianceBLL.GetVehicleValues(view);
                StringBuilder sbVehicleValues = new StringBuilder();
                if (dtGetVehicleValues.Rows.Count > 0)
                {
                    sbVehicleValues.Append("<table>");
                    for (int i = 0; i <= dtGetVehicleValues.Rows.Count - 1; i++)
                    {
                        //First row
                        sbVehicleValues.Append("<tr>");
                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_vehicle_text")+" "+(i+3));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_fk"].ToString());
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_type_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_type"].ToString());
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_vehicle_id_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_id"].ToString());
                        sbVehicleValues.Append("</td>");
                        sbVehicleValues.Append("</tr>");

                        //Second Row

                        sbVehicleValues.Append("<tr>");
                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_vin_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_vin"].ToString());
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_license_number_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_number"].ToString());
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_state_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_state"].ToString());
                        sbVehicleValues.Append("</td>");
                        sbVehicleValues.Append("</tr>");

                        //Third Row

                        sbVehicleValues.Append("<tr>");
                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_vehicle_make_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;>'");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_make"].ToString());
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_model_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_model"].ToString());
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='font-weight: normal; width: 110px; text-align: right; border-collapse: collapse;padding: 5px 5px 5px 0;'>");
                        sbVehicleValues.Append(LocalResources.GetLabel("app_year_text"));
                        sbVehicleValues.Append("</td>");

                        sbVehicleValues.Append("<td style='width: 190px; text-align: left; padding: 0 0 0 8px;'>");
                        sbVehicleValues.Append(dtGetVehicleValues.Rows[i]["vehicle_year"].ToString());
                        sbVehicleValues.Append("</td>");
                        sbVehicleValues.Append("</tr>");

                    }
                    sbVehicleValues.Append("</table>");
                }
                sbCaseDetails.Replace("@gvAddVehicleValues", sbVehicleValues.ToString());

                //witness
                DataTable dtGetWitness = new DataTable();
                dtGetWitness = ComplianceBLL.GetWitness(miris);
                StringBuilder sbWitness = new StringBuilder();
                if (dtGetWitness.Rows.Count > 0)
                {
                    sbWitness.Append("<table>");
                    for (int i = 0; i <= dtGetWitness.Rows.Count - 1; i++)
                    {
                        sbWitness.Append("<tr>");
                        sbWitness.Append("<td valign=top style=width:256px>");
                        sbWitness.Append(dtGetWitness.Rows[i]["c_file_name"].ToString());
                        sbWitness.Append("</td>");

                        sbWitness.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbWitness.Append(dtGetWitness.Rows[i]["witness_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetWitness.Rows[i]["c_name"].ToString() + "</b>");
                        sbWitness.Append("</td>");

                        sbWitness.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbWitness.Append(dtGetWitness.Rows[i]["witness_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetWitness.Rows[i]["c_contact_info"].ToString() + "</b>");
                        sbWitness.Append("</td>");
                        sbWitness.Append("</tr>");
                    }
                    sbWitness.Append("</table>");
                }
                sbCaseDetails.Replace("@gvAddWitness", sbWitness.ToString());
                //photo
                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.Getphoto(miris);
                StringBuilder sbPhoto = new StringBuilder();
                if (dtGetPhoto.Rows.Count > 0)
                {
                    sbPhoto.Append("<table>");
                    for (int i = 0; i <= dtGetPhoto.Rows.Count - 1; i++)
                    {
                        sbPhoto.Append("<tr>");
                        sbPhoto.Append("<td>");
                        sbPhoto.Append(dtGetPhoto.Rows[i]["c_file_name"].ToString());
                        sbPhoto.Append("</td>");
                        sbPhoto.Append("</tr>");
                    }
                    sbPhoto.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPhoto", sbPhoto.ToString());
                //police report
                DataTable dtGetPoliceReport = new DataTable();
                dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                StringBuilder sbPoliceReport = new StringBuilder();
                if (dtGetPoliceReport.Rows.Count > 0)
                {
                    sbPoliceReport.Append("<table>");
                    for (int i = 0; i <= dtGetPoliceReport.Rows.Count - 1; i++)
                    {
                        sbPoliceReport.Append("<tr>");
                        sbPoliceReport.Append("<td>");
                        sbPoliceReport.Append(dtGetPoliceReport.Rows[i]["c_file_name"].ToString());
                        sbPoliceReport.Append("</td>");
                        sbPoliceReport.Append("</tr>");
                    }
                    sbPoliceReport.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPoliceReport", sbPoliceReport.ToString());
                //SceneSketch
                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                StringBuilder sbSceneSketch = new StringBuilder();
                if (dtGetSceneSketch.Rows.Count > 0)
                {
                    sbSceneSketch.Append("<table>");
                    for (int i = 0; i <= dtGetSceneSketch.Rows.Count - 1; i++)
                    {
                        sbSceneSketch.Append("<tr>");
                        sbSceneSketch.Append("<td>");
                        sbSceneSketch.Append(dtGetSceneSketch.Rows[i]["c_file_name"].ToString());
                        sbSceneSketch.Append("</td>");
                        sbSceneSketch.Append("</tr>");
                    }
                    sbSceneSketch.Append("</table>");
                }
                sbCaseDetails.Replace("@gvSceneSketch", sbSceneSketch.ToString());
                //Extenautingcondition
                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                StringBuilder sbExtenautingCondition = new StringBuilder();
                if (dtGetExtenautingCondition.Rows.Count > 0)
                {
                    sbExtenautingCondition.Append("<table>");
                    for (int i = 0; i <= dtGetExtenautingCondition.Rows.Count - 1; i++)
                    {
                        sbExtenautingCondition.Append("<tr>");
                        sbExtenautingCondition.Append("<td valign=top style=width:256px;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["c_file_name"].ToString());
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["extenauting_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetExtenautingCondition.Rows[i]["c_name"].ToString() + "</b>");
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["extenauting_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetExtenautingCondition.Rows[i]["c_contact_info"].ToString() + "</b>");
                        sbExtenautingCondition.Append("</td>");

                        sbExtenautingCondition.Append("</tr>");
                    }
                    sbExtenautingCondition.Append("</table>");
                }
                sbCaseDetails.Replace("@gvExtenuatingcondition", sbExtenautingCondition.ToString());
                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                StringBuilder sbEmployeeInterview = new StringBuilder();
                if (dtGetEmployeeInterview.Rows.Count > 0)
                {
                    sbEmployeeInterview.Append("<table>");
                    for (int i = 0; i <= dtGetEmployeeInterview.Rows.Count - 1; i++)
                    {
                        sbEmployeeInterview.Append("<tr>");
                        sbEmployeeInterview.Append("<td style=width:256px; valign=top>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["c_file_name"].ToString());
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("<td valign=top  style=width:240px;font-weight:normal;>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_name_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["c_name"].ToString() + "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("<td valign=top  style=width:250px;font-weight:normal;>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["employee_contact_info_label"].ToString() + ":&nbsp;&nbsp;&nbsp;" + "<b>" + dtGetEmployeeInterview.Rows[i]["c_contact_info"].ToString() + "</b>");
                        sbEmployeeInterview.Append("</td>");

                        sbEmployeeInterview.Append("</tr>");
                    }
                    sbEmployeeInterview.Append("</table>");
                }
                sbCaseDetails.Replace("@gvEmployeeInterview", sbEmployeeInterview.ToString());
                Utility.SendEMailMessage(mailAddresses, "ComplianceFactors - CaseDetails", sbCaseDetails.ToString());
                success_msg.Style.Add("display", "block");
                error_msg.Style.Add("display", "none");
                //success_msg.InnerHtml = LocalResources.GetLabel("app_miris_success_msg_email_mobile");
                success_msg.InnerHtml = "SendSuccessfully" + " " + toEmailAddress;
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                //error_msg.InnerHtml = LocalResources.GetLabel("app_miris_error_msg_email_mobile");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01.htm", ex.Message);
                    }
                }
            }
            txtMultipeEmailAddress.Text = "";
        }
        protected void btnPrintPdf_footer_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        protected void btnPrintPdf_header_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
        private void PrintPdf()
        {
            rvMIRIS.LocalReport.DataSources.Clear();
            DataSet dsPdf = new DataSet();
            ComplianceDAO miris = new ComplianceDAO();
            miris.c_case_id_pk = view;
            miris.s_locale_culture = SessionWrapper.CultureName;

            //witness
            DataSet dsWitness = new DataSet();
            DataTable dtWitness = ComplianceBLL.GetWitness(miris);
            dsWitness.Tables.Add(dtWitness.Copy());

            //police report
            DataSet dsPoliceReport = new DataSet();
            DataTable dtPoliceReport = ComplianceBLL.GetPoliceReport(miris);
            dsPoliceReport.Tables.Add(dtPoliceReport.Copy());

            //Police
            DataSet dsPhoto = new DataSet();
            DataTable dtPhoto = ComplianceBLL.Getphoto(miris);
            dsPhoto.Tables.Add(dtPhoto.Copy());

            //SceneSketch
            DataSet dsSceneSketch = new DataSet();
            DataTable dtSceneSketch = ComplianceBLL.GetSceneSketch(miris);
            dsSceneSketch.Tables.Add(dtSceneSketch.Copy());

            //Extenuating Condition
            DataSet dsExtenuatingCondition = new DataSet();
            DataTable dtExtenuatingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
            dsExtenuatingCondition.Tables.Add(dtExtenuatingCondition.Copy());

            //Employee Interview
            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());

            //Vehicle
            DataSet dsVehicle = new DataSet();
            DataTable dtVehicle = ComplianceBLL.GetVehicleValues(view);
            dsVehicle.Tables.Add(dtVehicle.Copy());

            try
            {
                dsPdf = ComplianceBLL.createMIRISMVPDF(miris);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message);
                    }
                }

            }
            string s = LanguageManager.CurrentCulture.Name;
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvMIRIS.ProcessingMode = ProcessingMode.Local;
            rvMIRIS.LocalReport.EnableExternalImages = true;
            rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.MirisPdfTemplate.MIRISMVReport.rdlc";
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MVDataset", dsPdf.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISWitness", dsWitness.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPoliceReport", dsPoliceReport.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPhoto", dsPhoto.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISSceneSketch", dsSceneSketch.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISExtenuatingCondition", dsExtenuatingCondition.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISEmployeeInterview", dsEmployeeInterview.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISVehicle", dsVehicle.Tables[0]));


            byte[] bytes = rvMIRIS.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"" + lblCaseNumber.Text + ".pdf" + "\"");
            Response.BinaryWrite(bytes); // create the file     
            Response.Flush(); // send it to the client to download  
            Response.End();
            Response.Close();
        }
        private void SavePdf(string filepath)
        {
            rvMIRIS.LocalReport.DataSources.Clear();
            DataSet dsPdf = new DataSet();
            ComplianceDAO miris = new ComplianceDAO();
            miris.c_case_id_pk = view;
            miris.s_locale_culture = SessionWrapper.CultureName;

            //witness
            DataSet dsWitness = new DataSet();
            DataTable dtWitness = ComplianceBLL.GetWitness(miris);
            dsWitness.Tables.Add(dtWitness.Copy());

            //police report
            DataSet dsPoliceReport = new DataSet();
            DataTable dtPoliceReport = ComplianceBLL.GetPoliceReport(miris);
            dsPoliceReport.Tables.Add(dtPoliceReport.Copy());

            //Police
            DataSet dsPhoto = new DataSet();
            DataTable dtPhoto = ComplianceBLL.Getphoto(miris);
            dsPhoto.Tables.Add(dtPhoto.Copy());

            //SceneSketch
            DataSet dsSceneSketch = new DataSet();
            DataTable dtSceneSketch = ComplianceBLL.GetSceneSketch(miris);
            dsSceneSketch.Tables.Add(dtSceneSketch.Copy());

            //Extenuating Condition
            DataSet dsExtenuatingCondition = new DataSet();
            DataTable dtExtenuatingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
            dsExtenuatingCondition.Tables.Add(dtExtenuatingCondition.Copy());

            //Employee Interview
            DataSet dsEmployeeInterview = new DataSet();
            DataTable dtEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
            dsEmployeeInterview.Tables.Add(dtEmployeeInterview.Copy());

            //Vehicle
            DataSet dsVehicle = new DataSet();
            DataTable dtVehicle = ComplianceBLL.GetVehicleValues(view);
            dsVehicle.Tables.Add(dtVehicle.Copy());

            try
            {
                dsPdf = ComplianceBLL.createMIRISMVPDF(miris);
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message);
                    }
                }
            }
            string s = LanguageManager.CurrentCulture.Name;
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            rvMIRIS.ProcessingMode = ProcessingMode.Local;
            rvMIRIS.LocalReport.EnableExternalImages = true;
            rvMIRIS.LocalReport.ReportEmbeddedResource = "ComplicanceFactor.Compliance.MIRIS.MirisPdfTemplate.MIRISMVReport.rdlc";
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MVDataset", dsPdf.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISWitness", dsWitness.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPoliceReport", dsPoliceReport.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISPhoto", dsPhoto.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISSceneSketch", dsSceneSketch.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISExtenuatingCondition", dsExtenuatingCondition.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISEmployeeInterview", dsEmployeeInterview.Tables[0]));
            rvMIRIS.LocalReport.DataSources.Add(new ReportDataSource("MIRISVehicle", dsVehicle.Tables[0]));

            byte[] bytes = rvMIRIS.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            using (FileStream fs = File.Create(filepath + lblCaseNumber.Text + ".pdf"))
            {
                fs.Write(bytes, 0, (int)bytes.Length);
            }
        }

        private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sb.ToString();
        }

        protected void btnSendMultipleMobile_Click(object sender, EventArgs e)
        {
            try
            {
                string MATRIXURL = "http://www.smsmatrix.com/matrix";
                // david phone = 15712138210

                string toPhone = txtMultipeEmailAddress.Text;
                //"compliancefactor.project@gmail.com";
                string[] toPhoneNumber = toPhone.Split(',');
                foreach (string phone in toPhoneNumber)
                {
                    if (phone.Trim() != string.Empty)
                    {
                        string PHONE = phone;
                        string USERNAME = Server.UrlEncode(ConfigurationManager.AppSettings["mobileusername"]);
                        string PASSWORD = Server.UrlEncode(ConfigurationManager.AppSettings["mobilepwd"]);
                        StringBuilder sbSendCaseDetails = new StringBuilder();
                        string TXT = Server.UrlEncode("Case Number: " + lblCaseNumber.Text + ", " + "Case Title: " + lblCaseTitle.Text + ", " + "Case Date: " + lblCaseDate.Text + ", Case Category: " + lblCaseCategory.Text + ", Case Types: " + lblCaseTypes.Text + ", Case Status: " + lblCaseStatus.Text);
                        string q = "username=" + USERNAME +
                         "&password=" + PASSWORD +
                         "&phone=" + PHONE +
                         "&txt=" + TXT;

                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(MATRIXURL);
                        req.Method = "POST";
                        req.ContentType = "application/x-www-form-urlencoded";
                        req.ContentLength = q.Length;
                        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                        streamOut.Write(q);
                        streamOut.Close();
                        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                        string res = streamIn.ReadToEnd();
                        //Console.WriteLine("Matrix API Response:\n" + res);
                        streamIn.Close();
                        success_msg.Style.Add("display", "block");
                        error_msg.Style.Add("display", "none");
                        success_msg.InnerHtml = "Send Successfully" + " " + toPhone;
                    }
                }
            }
            catch (Exception ex)
            {
                success_msg.Style.Add("display", "none");
                error_msg.Style.Add("display", "block");
                error_msg.InnerHtml = "Sending Failed";
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("cvmv-01.aspx", ex.Message);
                    }
                }

            }
            txtMultipeEmailAddress.Text = "";
        }

        public string CreateCaseDetailPdf()
        {
            string strCaseDetails = string.Empty;
            try
            {
                //Daily Email Report
                string filePath = string.Empty;
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Compliance/MIRIS/MirisPdfTemplate/ccvmiris.htm");
                StringBuilder sbCaseDetails = new StringBuilder(Utility.GetHtmlTemplate(filePath));
                sbCaseDetails.Replace("@app_case_page_title", LocalResources.GetLabel("app_case_page_title") + lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_number_text", LocalResources.GetLabel("app_case_number_text"));
                sbCaseDetails.Replace("@lblCaseNumber", lblCaseNumber.Text);
                sbCaseDetails.Replace("@app_case_title_text", LocalResources.GetLabel("app_case_title_text"));
                sbCaseDetails.Replace("@lblCaseTitle", lblCaseTitle.Text);
                sbCaseDetails.Replace("@app_case_date_text", LocalResources.GetLabel("app_case_date_text"));
                sbCaseDetails.Replace("@lblCaseDate", lblCaseDate.Text);
                sbCaseDetails.Replace("@app_case_category_text", LocalResources.GetLabel("app_case_category_text"));
                sbCaseDetails.Replace("@lblCaseCategory", lblCaseCategory.Text);
                sbCaseDetails.Replace("@app_case_types_text", LocalResources.GetLabel("app_case_types_text"));
                sbCaseDetails.Replace("@lblCaseTypes", lblCaseTypes.Text);
                sbCaseDetails.Replace("@app_case_status_text", LocalResources.GetLabel("app_case_status_text"));
                sbCaseDetails.Replace("@lblCaseStatus", lblCaseStatus.Text);
                sbCaseDetails.Replace("@app_case_description_text", LocalResources.GetLabel("app_case_description_text"));
                sbCaseDetails.Replace("@app_employee_name_text", LocalResources.GetLabel("app_employee_name_text"));
                sbCaseDetails.Replace("@lblEmployeeName", lblEmployeeName.Text);
                sbCaseDetails.Replace("@app_date_of_birth_text", LocalResources.GetLabel("app_date_of_birth_text"));
                sbCaseDetails.Replace("@lblDateOfBirth", lblDateOfBirth.Text);
                sbCaseDetails.Replace("@app_employee_hire_date_text", LocalResources.GetLabel("app_employee_hire_date_text"));
                sbCaseDetails.Replace("@lblEmployeeHireDate", lblEmployeeHireDate.Text);
                sbCaseDetails.Replace("@app_employee_id_text", LocalResources.GetLabel("app_employee_id_text"));
                sbCaseDetails.Replace("@lblEmployeeId", lblEmployeeId.Text);
                sbCaseDetails.Replace("@app_last_digit_of_ssn", LocalResources.GetLabel("app_last_digit_of_ssn#_text"));
                sbCaseDetails.Replace("@lblLastFourDigitOfSSN", lblLastFourDigitOfSSN.Text);
                sbCaseDetails.Replace("@app_supervisor_text", LocalResources.GetLabel("app_supervisor_text"));
                sbCaseDetails.Replace("@lblSupervisor", lblSupervisor.Text);
                sbCaseDetails.Replace("@app_incident_location_text", LocalResources.GetLabel("app_incident_location_text"));
                sbCaseDetails.Replace("@lblIncidentLocation", lblIncidentLocation.Text);
                sbCaseDetails.Replace("@app_incident_date_text", LocalResources.GetLabel("app_incident_date_text"));
                sbCaseDetails.Replace("@lblIncidentDate", lblIncidentDate.Text);
                sbCaseDetails.Replace("@app_incident_time_text", LocalResources.GetLabel("app_incident_time_text"));
                sbCaseDetails.Replace("@lblIncidentTime", lblIncidentTime.Text);
                sbCaseDetails.Replace("@app_employee_report_location_text", LocalResources.GetLabel("app_employee_report_location_text"));
                sbCaseDetails.Replace("@lblEmployeeReportLocation", lblEmployeeReportLocation.Text);
                sbCaseDetails.Replace("@app_timezone_text", LocalResources.GetLabel("app_timezone_text"));
                sbCaseDetails.Replace("@lblTimeZone", lblTimeZone.Text);
                sbCaseDetails.Replace("@app_note_text", LocalResources.GetLabel("app_note_text"));
                sbCaseDetails.Replace("@lblNote", lblNote.Text);
                sbCaseDetails.Replace("@app_additional_Information_text", LocalResources.GetLabel("app_additional_Information_text"));
                sbCaseDetails.Replace("@app_witness(es)_text", LocalResources.GetLabel("app_witness(es)_text"));
                sbCaseDetails.Replace("@app_police_reports(s)_text", LocalResources.GetLabel("app_police_reports(s)_text"));
                sbCaseDetails.Replace("@app_photo(s)_text", LocalResources.GetLabel("app_photo(s)_text"));
                sbCaseDetails.Replace("@app_scene_sketch(es)_text", LocalResources.GetLabel("app_scene_sketch(es)_text"));
                sbCaseDetails.Replace("@app_extenuating_condition(s)_text", LocalResources.GetLabel("app_extenuating_condition(s)_text"));
                sbCaseDetails.Replace("@app_employee_interview(s)_text", LocalResources.GetLabel("app_employee_interview(s)_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_infornation_text", LocalResources.GetLabel("app_root_cause_analysis_infornation_text"));
                sbCaseDetails.Replace("@app_root_cause_analysis_details_text", LocalResources.GetLabel("app_root_cause_analysis_details_text"));
                sbCaseDetails.Replace("@lblRootCauseAnalysisDetails", lblRootCauseAnalysisDetails.Text);
                sbCaseDetails.Replace("@app_corrective_action_information_text", LocalResources.GetLabel("app_corrective_action_information_text"));
                sbCaseDetails.Replace("@app_corrective_action_details_text", LocalResources.GetLabel("app_corrective_action_details_text"));
                sbCaseDetails.Replace("@lblCorrectiveActionDetails", lblCorrectiveActionDetails.Text);
                //sbCaseDetails.Replace("@app_user_osha_300_information_text", LocalResources.GetLabel("app_user_osha_300_information_text"));
                //sbCaseDetails.Replace("@app_user_case_outcome_text", LocalResources.GetLabel("app_user_case_outcome_text"));
                //sbCaseDetails.Replace("@lblCaseOutCome", lblCaseOutCome.Text);
                //sbCaseDetails.Replace("@app_user_days_away_from_work_text", LocalResources.GetLabel("app_user_days_away_from_work_text"));
                //sbCaseDetails.Replace("@lblDaysAwayFromWork", lblDaysAwayFromWork.Text);
                //sbCaseDetails.Replace("@app_user_days_of_restrictions_text", LocalResources.GetLabel("app_user_days_of_restrictions_text"));
                //sbCaseDetails.Replace("@lblDaysOfRestrictions", lblDaysOfRestrictions.Text);
                //sbCaseDetails.Replace("@app_user_data_of_death_text", LocalResources.GetLabel("app_user_data_of_death_text"));
                //sbCaseDetails.Replace("@lblDateOfDeath", lblDateOfDeath.Text);
                //sbCaseDetails.Replace("@app_user_type_of_illness_text", LocalResources.GetLabel("app_user_type_of_illness_text"));
                //sbCaseDetails.Replace("@lblTypeofIllness", lblTypeofIllness.Text);
                //sbCaseDetails.Replace("@app_user_describe_injury_or_illness_text", LocalResources.GetLabel("app_user_describe_injury_or_illness_text"));
                //sbCaseDetails.Replace("@lblOSHA300info", lblOSHA300info.Text);
                //sbCaseDetails.Replace("@app_user_oosha_301_information_text", LocalResources.GetLabel("app_user_oosha_301_information_text"));
                //sbCaseDetails.Replace("@app_user_worker_gender_text", LocalResources.GetLabel("app_user_worker_gender_text"));
                //sbCaseDetails.Replace("@lblWorkerGender", lblWorkerGender.Text);
                //sbCaseDetails.Replace("@app_user_works_start_time_text", LocalResources.GetLabel("app_user_works_start_time_text"));
                //sbCaseDetails.Replace("@lblWorkStartTime", lblWorkStartTime.Text);
                //sbCaseDetails.Replace("@app_user_physician_text", LocalResources.GetLabel("app_user_physician_text"));
                //sbCaseDetails.Replace("@lblPhysician", lblPhysician.Text);
                //sbCaseDetails.Replace("@app_user_treatment_facility_text", LocalResources.GetLabel("app_user_treatment_facility_text"));
                //sbCaseDetails.Replace("@lblTreatmentFacility", lblTreatmentFacility.Text);
                //sbCaseDetails.Replace("@app_user_emergency_room_text", LocalResources.GetLabel("app_user_emergency_room_text"));
                //sbCaseDetails.Replace("@lblEmergencyRoom", lblEmergencyRoom.Text);
                //sbCaseDetails.Replace("@app_user_hospitalized_text", LocalResources.GetLabel("app_user_hospitalized_text"));
                //sbCaseDetails.Replace("@lblHospitalized", lblHospitalized.Text);
                //sbCaseDetails.Replace("@app_user_address_1_text", LocalResources.GetLabel("app_user_address_1_text"));
                //sbCaseDetails.Replace("@lblAddress1", lblAddress1.Text);
                //sbCaseDetails.Replace("@app_user_address_2_text", LocalResources.GetLabel("app_user_address_2_text"));
                //sbCaseDetails.Replace("@lblAddress2", lblAddress2.Text);
                //sbCaseDetails.Replace("@app_user_address_3_text", LocalResources.GetLabel("app_user_address_3_text"));
                //sbCaseDetails.Replace("@lblAddress3", lblAddress3.Text);
                //sbCaseDetails.Replace("@app_city_text", LocalResources.GetLabel("app_city_text"));
                //sbCaseDetails.Replace("@lblCity", lblCity.Text);
                //sbCaseDetails.Replace("@app_state_text", LocalResources.GetLabel("app_state_text"));
                //sbCaseDetails.Replace("@lblState", lblState.Text);
                //sbCaseDetails.Replace("@app_user_zip_text", LocalResources.GetLabel("app_user_zip_text"));
                //sbCaseDetails.Replace("@lblZipCode", lblZipCode.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_employee_text", LocalResources.GetLabel("app_user_what_was_the_employee_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info1", lblOSHA301Info1.Text);
                //sbCaseDetails.Replace("@app_user_what_happened_tell_text", LocalResources.GetLabel("app_user_what_happened_tell_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info2", lblOSHA301Info2.Text);
                //sbCaseDetails.Replace("@app_user_what_was_the_injury_text", LocalResources.GetLabel("app_user_what_was_the_injury_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info3", lblOSHA301Info3.Text);
                //sbCaseDetails.Replace("@app_user_object_or_substance_text", LocalResources.GetLabel("app_user_object_or_substance_text"));
                //sbCaseDetails.Replace("@lblOSHA301Info4", lblOSHA301Info4.Text);
                sbCaseDetails.Replace("@app_custom_fields_text", LocalResources.GetLabel("app_custom_fields_text"));
                sbCaseDetails.Replace("@app_custom_01_text", LocalResources.GetLabel("app_custom_01_text"));
                sbCaseDetails.Replace("@app_custom_02_text", LocalResources.GetLabel("app_custom_02_text"));
                sbCaseDetails.Replace("@app_custom_03_text", LocalResources.GetLabel("app_custom_03_text"));
                sbCaseDetails.Replace("@app_custom_04_text", LocalResources.GetLabel("app_custom_04_text"));
                sbCaseDetails.Replace("@app_custom_05_text", LocalResources.GetLabel("app_custom_05_text"));
                sbCaseDetails.Replace("@app_custom_06_text", LocalResources.GetLabel("app_custom_06_text"));
                sbCaseDetails.Replace("@app_custom_07_text", LocalResources.GetLabel("app_custom_07_text"));
                sbCaseDetails.Replace("@app_custom_08_text", LocalResources.GetLabel("app_custom_08_text"));
                sbCaseDetails.Replace("@app_custom_09_text", LocalResources.GetLabel("app_custom_09_text"));
                sbCaseDetails.Replace("@app_custom_10_text", LocalResources.GetLabel("app_custom_10_text"));
                sbCaseDetails.Replace("@app_custom_11_text", LocalResources.GetLabel("app_custom_11_text"));
                sbCaseDetails.Replace("@app_custom_12_text", LocalResources.GetLabel("app_custom_12_text"));
                sbCaseDetails.Replace("@app_custom_13_text", LocalResources.GetLabel("app_custom_13_text"));
                sbCaseDetails.Replace("@wp_app_release_number", LocalResources.GetLabel("wp_app_release_number"));
                sbCaseDetails.Replace("@lblCustom01", lblCustom01.Text);
                sbCaseDetails.Replace("@lblCustom02", lblCustom02.Text);
                sbCaseDetails.Replace("@lblCustom03", lblCustom03.Text);
                sbCaseDetails.Replace("@lblCustom04", lblCustom04.Text);
                sbCaseDetails.Replace("@lblCustom05", lblCustom05.Text);
                sbCaseDetails.Replace("@lblCustom06", lblCustom06.Text);
                sbCaseDetails.Replace("@lblCustom07", lblCustom07.Text);
                sbCaseDetails.Replace("@lblCustom08", lblCustom08.Text);
                sbCaseDetails.Replace("@lblCustom09", lblCustom09.Text);
                sbCaseDetails.Replace("@lblCustom10", lblCustom10.Text);
                sbCaseDetails.Replace("@lblCustom11", lblCustom11.Text);
                sbCaseDetails.Replace("@lblCustom12", lblCustom12.Text);
                sbCaseDetails.Replace("@lblCustom13", lblCustom13.Text);
                sbCaseDetails.Replace("@app_required_fields_text", LocalResources.GetLabel("app_required_fields_text"));

                ComplianceDAO miris = new ComplianceDAO();
                miris.c_case_id_pk = view;
                //witness
                DataTable dtGetWitness = new DataTable();
                dtGetWitness = ComplianceBLL.GetWitness(miris);
                StringBuilder sbWitness = new StringBuilder();
                if (dtGetWitness.Rows.Count > 0)
                {
                    sbWitness.Append("<table>");
                    for (int i = 0; i <= dtGetWitness.Rows.Count - 1; i++)
                    {
                        sbWitness.Append("<tr>");
                        sbWitness.Append("<td>");
                        sbWitness.Append(dtGetWitness.Rows[i]["c_file_name"].ToString());
                        sbWitness.Append("</td>");
                        sbWitness.Append("</tr>");
                    }
                    sbWitness.Append("</table>");
                }
                sbCaseDetails.Replace("@gvAddWitness", sbWitness.ToString());
                //photo
                DataTable dtGetPhoto = new DataTable();
                dtGetPhoto = ComplianceBLL.Getphoto(miris);
                StringBuilder sbPhoto = new StringBuilder();
                if (dtGetPhoto.Rows.Count > 0)
                {
                    sbPhoto.Append("<table>");
                    for (int i = 0; i <= dtGetPhoto.Rows.Count - 1; i++)
                    {
                        sbPhoto.Append("<tr>");
                        sbPhoto.Append("<td>");
                        sbPhoto.Append(dtGetPhoto.Rows[i]["c_file_name"].ToString());
                        sbPhoto.Append("</td>");
                        sbPhoto.Append("</tr>");
                    }
                    sbPhoto.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPhoto", sbPhoto.ToString());
                //police report
                DataTable dtGetPoliceReport = new DataTable();
                dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
                StringBuilder sbPoliceReport = new StringBuilder();
                if (dtGetPoliceReport.Rows.Count > 0)
                {
                    sbPoliceReport.Append("<table>");
                    for (int i = 0; i <= dtGetPoliceReport.Rows.Count - 1; i++)
                    {
                        sbPoliceReport.Append("<tr>");
                        sbPoliceReport.Append("<td>");
                        sbPoliceReport.Append(dtGetPoliceReport.Rows[i]["c_file_name"].ToString());
                        sbPoliceReport.Append("</td>");
                        sbPoliceReport.Append("</tr>");
                    }
                    sbPoliceReport.Append("</table>");
                }
                sbCaseDetails.Replace("@gvPoliceReport", sbPoliceReport.ToString());
                //SceneSketch
                DataTable dtGetSceneSketch = new DataTable();
                dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
                StringBuilder sbSceneSketch = new StringBuilder();
                if (dtGetSceneSketch.Rows.Count > 0)
                {
                    sbSceneSketch.Append("<table>");
                    for (int i = 0; i <= dtGetSceneSketch.Rows.Count - 1; i++)
                    {
                        sbSceneSketch.Append("<tr>");
                        sbSceneSketch.Append("<td>");
                        sbSceneSketch.Append(dtGetSceneSketch.Rows[i]["c_file_name"].ToString());
                        sbSceneSketch.Append("</td>");
                        sbSceneSketch.Append("</tr>");
                    }
                    sbSceneSketch.Append("</table>");
                }
                sbCaseDetails.Replace("@gvSceneSketch", sbSceneSketch.ToString());
                //Extenautingcondition
                DataTable dtGetExtenautingCondition = new DataTable();
                dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
                StringBuilder sbExtenautingCondition = new StringBuilder();
                if (dtGetExtenautingCondition.Rows.Count > 0)
                {
                    sbExtenautingCondition.Append("<table>");
                    for (int i = 0; i <= dtGetExtenautingCondition.Rows.Count - 1; i++)
                    {
                        sbExtenautingCondition.Append("<tr>");
                        sbExtenautingCondition.Append("<td>");
                        sbExtenautingCondition.Append(dtGetExtenautingCondition.Rows[i]["c_file_name"].ToString());
                        sbExtenautingCondition.Append("</td>");
                        sbExtenautingCondition.Append("</tr>");
                    }
                    sbExtenautingCondition.Append("</table>");
                }
                sbCaseDetails.Replace("@gvExtenuatingcondition", sbExtenautingCondition.ToString());
                //EmployeeInterview
                DataTable dtGetEmployeeInterview = new DataTable();
                dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
                StringBuilder sbEmployeeInterview = new StringBuilder();
                if (dtGetEmployeeInterview.Rows.Count > 0)
                {
                    sbEmployeeInterview.Append("<table>");
                    for (int i = 0; i <= dtGetEmployeeInterview.Rows.Count - 1; i++)
                    {
                        sbEmployeeInterview.Append("<tr>");
                        sbEmployeeInterview.Append("<td>");
                        sbEmployeeInterview.Append(dtGetEmployeeInterview.Rows[i]["c_file_name"].ToString());
                        sbEmployeeInterview.Append("</td>");
                        sbEmployeeInterview.Append("</tr>");
                    }
                    sbEmployeeInterview.Append("</table>");
                }
                sbCaseDetails.Replace("@gvEmployeeInterview", sbEmployeeInterview.ToString());
                strCaseDetails = sbCaseDetails.ToString();
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.htm", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("ccvmiris-01.htm", ex.Message);
                    }
                }
            }
            return strCaseDetails;
        }

        protected void btnDownloadZip_header_Click(object sender, EventArgs e)
        {
            DownloadZip();
        }
        protected void btnDownload_footer_Click(object sender, EventArgs e)
        {
            DownloadZip();
        }

        //Download zip 
        private void DownloadZip()
        {
            string fldGuid = Guid.NewGuid().ToString();
            string filePath = Server.MapPath(_temppath + fldGuid + "/");
            if (!Directory.Exists(filePath))  // if it doesn't exist, create
                Directory.CreateDirectory(filePath);

            //witness
            ComplianceDAO miris = new ComplianceDAO();
            miris.c_case_id_pk = view;
            miris.s_locale_culture = SessionWrapper.CultureName;
            DataTable dtGetWitness = new DataTable();
            dtGetWitness = ComplianceBLL.GetWitness(miris);
            if (dtGetWitness.Rows.Count > 0)
            {
                string destinationfilePathWitness = Server.MapPath(_temppath + fldGuid + "/Witness_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathWitness))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathWitness);

                foreach (DataRow dr in dtGetWitness.Rows)
                {
                    string sourcefilePathWitness = Server.MapPath(_path);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathWitness, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathWitness, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //photo
            DataTable dtGetPhoto = new DataTable();
            dtGetPhoto = ComplianceBLL.Getphoto(miris);
            if (dtGetPhoto.Rows.Count > 0)
            {
                string destinationfilePathphoto = Server.MapPath(_temppath + fldGuid + "/Photo_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathphoto))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathphoto);
                foreach (DataRow dr in dtGetPhoto.Rows)
                {
                    string sourcefilePathphoto = Server.MapPath(_pathPhoto);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathphoto, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathphoto, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //police report
            DataTable dtGetPoliceReport = new DataTable();
            dtGetPoliceReport = ComplianceBLL.GetPoliceReport(miris);
            if (dtGetPoliceReport.Rows.Count > 0)
            {
                string destinationfilePathPoliceReport = Server.MapPath(_temppath + fldGuid + "/PoliceReport_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathPoliceReport))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathPoliceReport);
                foreach (DataRow dr in dtGetPoliceReport.Rows)
                {
                    string sourcefilePathPoliceReport = Server.MapPath(_pathPolice);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathPoliceReport, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathPoliceReport, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //SceneSketch
            DataTable dtGetSceneSketch = new DataTable();
            dtGetSceneSketch = ComplianceBLL.GetSceneSketch(miris);
            if (dtGetSceneSketch.Rows.Count > 0)
            {
                string destinationfilePathsceneSketch = Server.MapPath(_temppath + fldGuid + "/sceneSketch_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathsceneSketch))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathsceneSketch);
                foreach (DataRow dr in dtGetSceneSketch.Rows)
                {
                    string sourcefilePathsceneSketch = Server.MapPath(_pathSceneSketch);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathsceneSketch, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathsceneSketch, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //Extenautingcondition
            DataTable dtGetExtenautingCondition = new DataTable();
            dtGetExtenautingCondition = ComplianceBLL.GetExtenuatingCondition(miris);
            if (dtGetExtenautingCondition.Rows.Count > 0)
            {
                string destinationfilePathExtenautingCondtion = Server.MapPath(_temppath + fldGuid + "/ExtenautingCondtion_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathExtenautingCondtion))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathExtenautingCondtion);
                foreach (DataRow dr in dtGetExtenautingCondition.Rows)
                {
                    string sourcefilePathExtenautingCondtion = Server.MapPath(_pathExtenuatingcondition);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathExtenautingCondtion, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathExtenautingCondtion, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }
            //EmployeeInterview
            DataTable dtGetEmployeeInterview = new DataTable();
            dtGetEmployeeInterview = ComplianceBLL.GetEmployeeInterview(miris);
            if (dtGetEmployeeInterview.Rows.Count > 0)
            {
                string destinationfilePathEmployeeInterview = Server.MapPath(_temppath + fldGuid + "/EmployeeInterview_" + lblCaseNumber.Text);
                if (!Directory.Exists(destinationfilePathEmployeeInterview))  // if it doesn't exist, create
                    Directory.CreateDirectory(destinationfilePathEmployeeInterview);
                foreach (DataRow dr in dtGetEmployeeInterview.Rows)
                {
                    string sourcefilePathEmployeeInterview = Server.MapPath(_pathEmployeeInterview);
                    string sourceFile = System.IO.Path.Combine(sourcefilePathEmployeeInterview, dr["c_file_guid"].ToString());
                    string destFile = System.IO.Path.Combine(destinationfilePathEmployeeInterview, dr["c_file_guid"].ToString());
                    File.Copy(sourceFile, destFile, true);
                }
            }

            SavePdf(filePath);

            // download in zip format
            Response.Clear();
            Response.BufferOutput = false;
            HttpContext c = HttpContext.Current;
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "block; filename=\"" + lblCaseNumber.Text + ".zip" + "\"");
            using (ZipFile zipFile = new ZipFile())
            {
                zipFile.AddDirectory(filePath);
                zipFile.Save(Response.OutputStream);
                Response.Close();
            }
            //DirectoryInfo deleteDirectory = new DirectoryInfo(filePath);
            Directory.Delete(filePath, true);
        }

        
    }
}