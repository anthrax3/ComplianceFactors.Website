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
        /// <summary>
        /// Get approval queue information
        /// </summary>
        /// <param name="e_enroll_approval_system_id_pk"></param>
        /// <returns></returns>
        public static SystemApproval GetApprovalsQueue(string e_enroll_approval_system_id_pk)
        {
            Hashtable htGetApprovalsQueue = new Hashtable();
            SystemApproval approval = new SystemApproval();
            htGetApprovalsQueue.Add("@e_enroll_approval_system_id_pk", e_enroll_approval_system_id_pk);
            DataTable dtApprovalQueueInfo =  DataProxy.FetchDataTable("s_sp_get_approval_queue_info", htGetApprovalsQueue);
            approval.ApprovalID = dtApprovalQueueInfo.Rows[0]["approvalId"].ToString();
            approval.ApprovalWorkflowName = dtApprovalQueueInfo.Rows[0]["ApprovalWorkflowName"].ToString();
            approval.EmployeeId = dtApprovalQueueInfo.Rows[0]["EmployeeId"].ToString();
            approval.EmployeeName = dtApprovalQueueInfo.Rows[0]["EmployeeName"].ToString();
            approval.TrainingId = dtApprovalQueueInfo.Rows[0]["TrainingId"].ToString();
            approval.TrainingTitle = dtApprovalQueueInfo.Rows[0]["TrainingTitle"].ToString();
            return approval;

            
        }
    }
}
