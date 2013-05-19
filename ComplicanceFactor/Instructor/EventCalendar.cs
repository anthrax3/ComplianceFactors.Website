using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ComplicanceFactor.Instructor
{
    public class EventCalendar : System.Web.UI.WebControls.Calendar
    {
        // **********************************************************
        // Gets or Sets the Name of source DataTable  
        /// <summary>
        /// If this is specified, then EventDate and EventHeader are mandatory
        /// </summary>
        public DataTable EventSource
        {
            get
            {
                if (ViewState["EventSource"] == null)
                    return null;
                else
                    return ((DataTable)ViewState["EventSource"]);
            }
            set { ViewState["EventSource"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Date Column in the DataTable
        public string EventDateColumnName
        {
            get
            {
                if (ViewState["DateColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["DateColumnName"].ToString());
            }
            set { ViewState["DateColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Header Column Name in the DataTable
        public string EventHeaderColumnName
        {
            get
            {
                if (ViewState["EventHeaderColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EventHeaderColumnName"].ToString());
            }
            set { ViewState["EventHeaderColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Description Column Name in the DataTable
        public string EventDescriptionColumnName
        {
            get
            {
                if (ViewState["EventDescriptionColumnName"] == null)
                    return string.Empty;
                else
                    return (ViewState["EventDescriptionColumnName"].ToString());
            }
            set { ViewState["EventDescriptionColumnName"] = value; }
        }
        // **********************************************************

        // **********************************************************
        // Gets or sets the Event Description Column Name in the DataTable
        public bool ShowDescriptionAsToolTip
        {
            get
            {
                if (ViewState["EventDescriptionColumnName"] == null)
                    return true;
                else
                    return (Convert.ToBoolean(ViewState["ShowDescriptionAsToolTip"].ToString()));
            }
            set { ViewState["ShowDescriptionAsToolTip"] = value; }
        }
        // **********************************************************

        public EventCalendar()
            : base()
        {
            DayRender += new DayRenderEventHandler(EventCalendarDayRender);
        }

        protected void EventCalendarDayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = ((DayRenderEventArgs)e).Day;
            TableCell c = ((DayRenderEventArgs)e).Cell;

            // If there is nothing to bind
            if (this.EventSource == null)
                return;

            DataTable dt = this.EventSource;

            foreach (DataRow dr in dt.Rows)
            {
                if (EventDateColumnName == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventDateColumnName property when EventSource is specified");
                if (EventHeaderColumnName == string.Empty)
                    throw new ApplicationException("Must set EventCalendar's EventHeaderColumnName property when EventSource is specified");


                if (EventDateColumnName != string.Empty
                    && !d.IsOtherMonth
                    && Convert.ToDateTime(dr[this.EventDateColumnName]).ToShortDateString() == d.Date.ToShortDateString())
                {
                    if (this.ShowDescriptionAsToolTip)
                    {
                        LinkButton link = new LinkButton();
                        string strID = dr[EventHeaderColumnName].ToString();
                        link.ID = strID;
                        link.CommandName = "ViewEvent";
                        link.CommandArgument = dr[EventHeaderColumnName].ToString();
                        link.Text = "- " + dr[EventHeaderColumnName].ToString().Trim();
                        link.ToolTip = dr[EventHeaderColumnName].ToString().Trim();
                        link.CssClass = "baselink";
                        //link.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Handle_EventLink);

                        c.Controls.Add(link); 


                    }
                    else
                        c.Controls.Add(new LiteralControl("<br> " + dr[EventHeaderColumnName].ToString()));

                }
            }
        }
    }
}