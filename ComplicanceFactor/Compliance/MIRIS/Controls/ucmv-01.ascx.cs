using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplicanceFactor.Compliance.MIRIS.Controls
{
    public partial class ucmv_01 : System.Web.UI.UserControl
    {
        public event EventHandler RemoveVehicleUserControl;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string _ddlVehicle;
        public string ddlVehicle
        {
            get { return ddlVehicle01.SelectedValue; }
            set { ddlVehicle01.SelectedValue = value; }
        }

        public string _ddlType;
        public string ddlType
        {
            get { return ddlVehicleType.SelectedValue; }
            set { ddlVehicleType.SelectedValue = value; }
        }

        public string _VechicleId;
        public string VechicleId
        {
            get { return txtVehicleId.Text; }
            set { txtVehicleId.Text = value; }
        }
        public string _VIN;
        public string VIN
        {
            get { return txtVIN.Text; }
            set { txtVIN.Text = value; }
        }

        public string _LicenseNumber;
        public string LicenseNumber
        {
            get { return txtLicenseNumber.Text; }
            set { txtLicenseNumber.Text = value; }
        }
        public string _State;
        public string State
        {
            get { return txtState.Text; }
            set { txtState.Text = value; }
        }

        public string _VehicleMake;
        public string VehicleMake
        {
            get { return txtVehicleMake.Text; }
            set { txtVehicleMake.Text = value; }
        }

        public string _VehicleModel;
        public string VehicleModel
        {
            get { return txtVehicleModel.Text; }
            set { txtVehicleModel.Text = value; }
        }

        public string _Year;
        public string  Year
        {
            get { return txtYear.Text; }
            set { txtYear.Text = value; }
        }

        public string  lblVechicle
        {
            get { return lblVehicle.Text; }
            set { lblVehicle.Text = value; }
        }        

        protected void btnVechicleRemove_Click(object sender, EventArgs e)
        {
            //Raise this event so the parent page can handle it
            if (RemoveVehicleUserControl != null)
            {
                RemoveVehicleUserControl(sender, e);
            }
        }
    }
}