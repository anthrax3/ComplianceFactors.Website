using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ComplicanceFactor.Compliance.HARM
{
    public   class TempHarmDataTable
    {
        /// <summary>
        /// TempAddNewControlMeasure
        /// </summary>
        /// <returns></returns>
        public static DataTable TempAddNewControlMeasure()
        {
            DataTable dtTempControlMeasure = new DataTable();
            DataColumn dtColControlMeasure;
            //h_control_measure_id_pk
            dtColControlMeasure = new DataColumn();
            dtColControlMeasure.DataType = Type.GetType("System.String");
            dtColControlMeasure.ColumnName = "h_control_measure_id_pk";
            dtTempControlMeasure.Columns.Add(dtColControlMeasure);
            //h_control_measure_id_fk
            dtColControlMeasure = new DataColumn();
            dtColControlMeasure.DataType = Type.GetType("System.String");
            dtColControlMeasure.ColumnName = "h_control_measure_id_fk";
            dtTempControlMeasure.Columns.Add(dtColControlMeasure);
            //h_control_measure_text
            dtColControlMeasure = new DataColumn();
            dtColControlMeasure.DataType = Type.GetType("System.String");
            dtColControlMeasure.ColumnName = "h_control_measure_text";
            dtTempControlMeasure.Columns.Add(dtColControlMeasure);

            //h_control_measure_summary
            dtColControlMeasure = new DataColumn();
            dtColControlMeasure.DataType = Type.GetType("System.String");
            dtColControlMeasure.ColumnName = "h_control_measure_summary";
            dtTempControlMeasure.Columns.Add(dtColControlMeasure);
            return dtTempControlMeasure;

            


        }

        public static DataTable tempHazard()
        {
            DataTable dtTempHazard = new DataTable();

            DataColumn dtTempHazardColumn;

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_hazard_id_pk";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_hazard_description";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_hazard_name";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_inactive";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_harm_id_fk";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_program_compliance_value";
            dtTempHazard.Columns.Add(dtTempHazardColumn);

            dtTempHazardColumn = new DataColumn();
            dtTempHazardColumn.DataType = Type.GetType("System.String");
            dtTempHazardColumn.ColumnName = "h_permit_compliance_value";
            dtTempHazard.Columns.Add(dtTempHazardColumn);



            return dtTempHazard;
        }
        public static DataTable tempControlMeasure()
        {
            DataTable dtControlMeasure = new DataTable();
            DataColumn dtControlMeasureColumn;
            dtControlMeasureColumn = new DataColumn();
            dtControlMeasureColumn.DataType = Type.GetType("System.String");
            dtControlMeasureColumn.ColumnName = "h_hazard_control_meausre_id_pk";
            dtControlMeasure.Columns.Add(dtControlMeasureColumn);

            dtControlMeasureColumn = new DataColumn();
            dtControlMeasureColumn.DataType = Type.GetType("System.String");
            dtControlMeasureColumn.ColumnName = "h_hazard_id_fk";
            dtControlMeasure.Columns.Add(dtControlMeasureColumn);

            dtControlMeasureColumn = new DataColumn();
            dtControlMeasureColumn.DataType = Type.GetType("System.String");
            dtControlMeasureColumn.ColumnName = "h_control_measure_summary";
            dtControlMeasure.Columns.Add(dtControlMeasureColumn);

            //h_control_measure_id_fk
            dtControlMeasureColumn = new DataColumn();
            dtControlMeasureColumn.DataType = Type.GetType("System.String");
            dtControlMeasureColumn.ColumnName = "h_control_measure_id_fk";
            dtControlMeasure.Columns.Add(dtControlMeasureColumn);

            //h_control_measure_text
            dtControlMeasureColumn = new DataColumn();
            dtControlMeasureColumn.DataType = Type.GetType("System.String");
            dtControlMeasureColumn.ColumnName = "h_control_measure_text";
            dtControlMeasure.Columns.Add(dtControlMeasureColumn);

            return dtControlMeasure;
        }
    }
}