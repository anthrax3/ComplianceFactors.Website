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
        public static DataSet  GetApprovalsQueue(string e_enroll_approval_system_id_pk,string e_enroll_user_id_fk)
        {
            Hashtable htGetApprovalsQueue = new Hashtable();
            SystemApproval approval = new SystemApproval();
            htGetApprovalsQueue.Add("@e_enroll_approval_system_id_pk", e_enroll_approval_system_id_pk);
            htGetApprovalsQueue.Add("@e_enroll_user_id_fk", e_enroll_user_id_fk);
            return DataProxy.FetchDataSet("s_sp_get_approval_queue_info", htGetApprovalsQueue);
            //approval.ApprovalID = dtApprovalQueueInfo.Rows[0]["ApprovalId"].ToString();
            //approval.ApprovalWorkflowName = dtApprovalQueueInfo.Rows[0]["ApprovalWorkflowName"].ToString();
            //approval.EmployeeId = dtApprovalQueueInfo.Rows[0]["EmployeeId"].ToString();
            //approval.EmployeeName = dtApprovalQueueInfo.Rows[0]["EmployeeName"].ToString();
            //approval.TrainingId = dtApprovalQueueInfo.Rows[0]["TrainingId"].ToString();
            //approval.TrainingTitle = dtApprovalQueueInfo.Rows[0]["TrainingTitle"].ToString();
            //approval.RequestDate = dtApprovalQueueInfo.Rows[0]["RequestDate"].ToString();
            //approval.RequiredType = dtApprovalQueueInfo.Rows[0]["RequiredType"].ToString();
            //approval.Status = dtApprovalQueueInfo.Rows[0]["Status"].ToString();
            //approval.Approver1Name = dtApprovalQueueInfo.Rows[0]["Approver1Name"].ToString();
            //approval.Approval1Status = dtApprovalQueueInfo.Rows[0]["Approval1Status"].ToString();
            //approval.Approver2Name = dtApprovalQueueInfo.Rows[0]["Approver2Name"].ToString();
            //approval.Approval2Status = dtApprovalQueueInfo.Rows[0]["Approval2Status"].ToString();
            //approval.Approver3Name = dtApprovalQueueInfo.Rows[0]["Approver3Name"].ToString();
            //approval.Approval3Status = dtApprovalQueueInfo.Rows[0]["Approval3Status"].ToString();
         

            
        }

        /// <summary>
        /// Deny for Manage approval Queue
        /// </summary>
        /// <param name="e_enroll_approval_system_id_pk"></param>
        /// <param name="s_todo_system_id_pk"></param>
        /// <returns></returns>
        public static int DenyEnrollment(string e_enroll_approval_system_id_pk, string s_todo_system_id_pk)
        {
            try
            {
                Hashtable htDeny = new Hashtable();
                htDeny.Add("@e_enroll_approval_system_id_pk", e_enroll_approval_system_id_pk);
                htDeny.Add("@s_todo_system_id_pk", s_todo_system_id_pk);

                return DataProxy.FetchSPOutput("s_sp_deny_todo_approval_queue", htDeny);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        ///// <summary>
        ///// Approve for Manage approval queue
        ///// </summary>
        ///// <param name="e_enroll_approval_system_id_pk"></param>
        ///// <param name="s_todo_system_id_pk"></param>
        ///// <returns></returns>
        //public static int UpdateApprovalsTodos(string e_enroll_approval_system_id_pk, string s_todo_system_id_pk)
        //{
        //    try
        //    {
        //        Hashtable htApprovalsTodos = new Hashtable();
        //        htApprovalsTodos.Add("@e_enroll_approval_system_id_pk", e_enroll_approval_system_id_pk);
        //        htApprovalsTodos.Add("@s_todo_system_id_pk", s_todo_system_id_pk);

        //        return DataProxy.FetchSPOutput("e_sp_update_todo_enrollment_approvals", htApprovalsTodos);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
