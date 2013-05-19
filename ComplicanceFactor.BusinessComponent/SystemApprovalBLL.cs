using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ComplicanceFactor.DataAccessLayer;
using System.Collections;
using ComplicanceFactor.BusinessComponent.DataAccessObject;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemApprovalBLL
    {
        /// <summary>
        /// Get Status
        /// </summary>
        /// <returns></returns>
        public static DataTable Getstatus()
        {
            try
            {
                return DataProxy.FetchDataTable("e_sp_get_enrollment_approval_status");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Search Result
        /// </summary>
        /// <param name="approval"></param>
        /// <returns></returns>
        public static DataTable SearchApprovals(SystemApproval approval)
        {
            Hashtable htSearchApprovals = new Hashtable();
            htSearchApprovals.Add("@EmployeeId", approval.EmployeeId);
            htSearchApprovals.Add("@EmployeeName", approval.EmployeeName);
            htSearchApprovals.Add("@Status", approval.Status);
            htSearchApprovals.Add("@ApproverID", approval.ApproverID);
            htSearchApprovals.Add("@ApproverName", approval.ApproverName);
            htSearchApprovals.Add("@ApprovalID", approval.ApprovalID);
            try
            {
                return DataProxy.FetchDataTable("s_sp_search_approvals", htSearchApprovals);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
