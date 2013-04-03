using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent;
using System.Data;

namespace ComplianceFactors.MyTeam
{
    public class MyTeamDataAccess
    {
        public MyTeamDataAccess()
        {

        }
        public MyTeam_Dataset GetData(string userId)
        {
            MyTeam_Dataset ds = new MyTeam_Dataset();
            ds.EnforceConstraints = false;

            MyTeam_Dataset.e_sp_get_team_dataRow row = null;


            DataSet dsManager = new DataSet();
            dsManager = EnrollmentBLL.GetToDos(userId);

            DataTable dtTeam = new DataTable();
            dtTeam = dsManager.Tables[1];

            for (int i = 0; i < dtTeam.Rows.Count; i++)
            {
                row = ds.e_sp_get_team_data.Newe_sp_get_team_dataRow();
                row.userId = dtTeam.Rows[i]["userId"].ToString();
                row.FirstName = dtTeam.Rows[i]["FirstName"].ToString();
                row.JobTitle = dtTeam.Rows[i]["JobTitle"].ToString();
                row.ManagerId = dtTeam.Rows[i]["ManagerId"].ToString();
                row.LevelPos = Convert.ToInt32(dtTeam.Rows[i]["LevelPos"]);
                row.isExpanded = false;
                ds.e_sp_get_team_data.Rows.Add(row);
            }

            //ds.EnforceConstraints = true;

            return ds;
        }
    }
}
