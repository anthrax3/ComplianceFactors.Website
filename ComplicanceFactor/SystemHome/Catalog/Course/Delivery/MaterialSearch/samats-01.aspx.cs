﻿using System;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.DeliveryPopup
{
    public partial class samats_01 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGosearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "sand" || !string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/MaterialSearch/samatsr-01.aspx?page="+ Request.QueryString["page"] +"&id=" + SecurityCenter.EncryptText(txtMaterialId.Text) + "&name=" + SecurityCenter.EncryptText(txtMaterialName.Text));
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["page"]) && Request.QueryString["page"] == "saed-02")
            {
                Response.Redirect("~/SystemHome/Catalog/Course/Delivery/MaterialSearch/samatsr-01.aspx?editdelivery=" + Request.QueryString["editdelivery"] + "&page=" + Request.QueryString["page"] + "&id=" + SecurityCenter.EncryptText(txtMaterialId.Text) + "&name=" + SecurityCenter.EncryptText(txtMaterialName.Text));
            }
           
        }
    }
}