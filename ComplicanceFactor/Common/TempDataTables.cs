using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ComplicanceFactor.Common
{
    public class TempDataTables
    {
        public static DataTable TempLocale()
        {
            DataTable dtTempLocale = new DataTable();
            DataColumn dtTempLocaleColumn;
            //s_resource_locale_sort column
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.Int32");
            dtTempLocaleColumn.ColumnName = "s_locale_sort";
            dtTempLocaleColumn.AutoIncrement = true;
            dtTempLocaleColumn.AutoIncrementSeed = 1;
            dtTempLocaleColumn.AutoIncrementStep = 1;
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_resource_locales_system_id_pk column
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_system_id_pk";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_locale_id_fk
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_id_fk";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_resource_locale_name
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_name";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_resource_locale_description
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_description";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_resource_locale_text
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_text";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_course_locale_abstract
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_abstract";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_locale_aicc_url
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_aicc_url";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_locale_scorm_url
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_scorm_url";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_delivery_system_id_fk
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_delivery_system_id_fk";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            //s_locale_airport_code
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_airport_code";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);

            //s_locale_file_guid
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_file_guid";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);

            //s_locale_file_name
            dtTempLocaleColumn = new DataColumn();
            dtTempLocaleColumn.DataType = Type.GetType("System.String");
            dtTempLocaleColumn.ColumnName = "s_locale_file_name";
            dtTempLocale.Columns.Add(dtTempLocaleColumn);
            return dtTempLocale;
        }
        /// <summary>
        /// Temp table structure for resources
        /// </summary>
        /// <returns></returns>
        public static DataTable TempResource()
        {
            DataTable dtTempDeliveryResource = new DataTable();
            DataColumn dtTempDeliveryResourceColumn;
            //s_resource_locale_sort column
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_sort";
            dtTempDeliveryResourceColumn.AutoIncrement = true;
            dtTempDeliveryResourceColumn.AutoIncrementSeed = 1;
            dtTempDeliveryResourceColumn.AutoIncrementStep = 1;
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            /// <summary>
            /// s_resource_system_id_pk
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_system_id_pk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            /// <summary>
            /// s_resource_id_pk
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_id_pk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            /// <summary>
            /// s_resource_name
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_name";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            /// <summary>
            ///s_resource_description
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_description";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            /// <summary>
            /// s_resource_serial_number
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_serial_number";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            //s_facility_room_resource_id_fk
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "s_facility_room_id_fk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            //s_resource_confirm
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliveryResourceColumn.ColumnName = "s_resource_confirm";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);
            return dtTempDeliveryResource;

        }
        /// <summary>
        /// Room
        /// </summary>
        /// <returns></returns>
        public static DataTable TempRoom()
        {
            DataTable dtTempRoom = new DataTable();
            DataColumn dtTempRoomColumn;

            //s_room_sort column
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.Int32");
            dtTempRoomColumn.ColumnName = "s_room_sort";
            dtTempRoomColumn.AutoIncrement = true;
            dtTempRoomColumn.AutoIncrementSeed = 1;
            dtTempRoomColumn.AutoIncrementStep = 1;
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_system_id_pk
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_system_id_pk";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_id_pk
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_id_pk";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_name
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_name";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_description
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_description";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_status_id_fk
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_status_id_fk";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_type_id_fk
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_type_id_fk";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_facility_room_id_fk
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_facility_room_id_fk";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            //s_room_type_text
            dtTempRoomColumn = new DataColumn();
            dtTempRoomColumn.DataType = Type.GetType("System.String");
            dtTempRoomColumn.ColumnName = "s_room_type_text";
            dtTempRoom.Columns.Add(dtTempRoomColumn);
            return dtTempRoom;
        }
        /// <summary>
        /// Temp table structure for delivery resources
        /// </summary>
        /// <returns></returns>
        public static DataTable TempDeliveryResource()
        {
            DataTable dtTempDeliveryResource = new DataTable();
            DataColumn dtTempDeliveryResourceColumn;

            /// <summary>
            /// c_resource_system_id_pk

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_system_id_pk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);




            /// <summary>
            /// c_resource_id_pk

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_id_pk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            /// <summary>
            /// c_resource_name

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_name";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            /// <summary>
            /// c_resource_description

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_description";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            /// <summary>
            /// c_resource_serial_number

            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_serial_number";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);


            //c_delivery_id_fk
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryResourceColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            //c_resource_confirm
            dtTempDeliveryResourceColumn = new DataColumn();
            dtTempDeliveryResourceColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliveryResourceColumn.ColumnName = "c_resource_confirm";
            dtTempDeliveryResource.Columns.Add(dtTempDeliveryResourceColumn);

            return dtTempDeliveryResource;

        }
        /// <summary>
        /// Temp table structure for delivery instructors
        /// </summary>
        /// <returns></returns>
        public static DataTable TempDeliveryInstructors()
        {
            DataTable dtTempDeliveryInstructors = new DataTable();
            DataColumn dtTempDeliveryInstructorsColumn;

            /// <summary>
            /// temp c_instructor_system_id_pk 
            /// <value>auto generate guid.</value>

            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_instructor_system_id_pk";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);

            /// <summary>
            /// c_user_id_fk
            /// <value>c_user_id_fk column</value>

            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_user_id_fk";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);

            /// <summary>
            /// c_instructor_name
            /// <value>concatenate user first and last name column</value>

            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_instructor_name";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);

            //c_session_id_fk
            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_session_id_fk";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);


            //c_delivery_id_fk
            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);


            //c_instructor_confirm
            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_instructor_confirm";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);

            //
            dtTempDeliveryInstructorsColumn = new DataColumn();
            dtTempDeliveryInstructorsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryInstructorsColumn.ColumnName = "c_instructor_type_id_fk";
            dtTempDeliveryInstructors.Columns.Add(dtTempDeliveryInstructorsColumn);

            return dtTempDeliveryInstructors;

        }
        /// <summary>
        /// Add temp columns for materials
        /// </summary>
        /// <returns></returns>
        public static DataTable TempDeliveryMaterials()
        {
            DataTable dtTempDeliveryMaterials = new DataTable();
            DataColumn dtTempDeliveryMaterialsColumn;

            /// <summary>
            /// temp c_material_system_id_pk 


            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_system_id_pk";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            /// <summary>
            /// c_material_id_pk


            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_id_pk";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            /// <summary>
            /// c_material_nam


            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_name";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            /// <summary>
            /// c_material_description

            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_description";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);


            //c_delivery_id_fk
            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);

            //c_material_confirm
            dtTempDeliveryMaterialsColumn = new DataColumn();
            dtTempDeliveryMaterialsColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliveryMaterialsColumn.ColumnName = "c_material_confirm";
            dtTempDeliveryMaterials.Columns.Add(dtTempDeliveryMaterialsColumn);



            return dtTempDeliveryMaterials;

        }
        /// <summary>
        /// TempDeliverySessions
        /// </summary>
        /// <returns></returns>
        public static DataTable TempDeliverySessions()
        {

            DataTable dtTempDeliverySessions = new DataTable();
            DataColumn dtTempDeliverySessionsColumn;

            //c_session_system_id_pk
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_system_id_pk";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_id_pk
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_id_pk";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_delivery_id_fk
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_title
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_title";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_sessions_desc
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_sessions_desc";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_start_date
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_start_date";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_end_date
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_end_date";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_start_time
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_start_time";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_sessions_end_time
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_sessions_end_time";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_duration
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_duration";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_location_id_fk
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_location_id_fk";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_session_facility_id_fk
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_facility_id_fk";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_sessions_room_id_fk
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_sessions_room_id_fk";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //
            //c_location_name
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_location_name";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_facility_name
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_facility_name";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            //c_room_name
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_room_name";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);


            //session date and time
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.String");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_date";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);


            //c_session_confirm
            dtTempDeliverySessionsColumn = new DataColumn();
            dtTempDeliverySessionsColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverySessionsColumn.ColumnName = "c_session_confirm";
            dtTempDeliverySessions.Columns.Add(dtTempDeliverySessionsColumn);

            return dtTempDeliverySessions;

        }
        /// <summary>
        /// TempDeliveries
        /// </summary>
        /// <returns></returns>
        public static DataTable TempDeliveries()
        {

            DataTable dtTempDeliverys = new DataTable();
            DataColumn dtTempDeliverysColumn;

            //c_delivery_system_id_pk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_system_id_pk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_course_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_course_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_id_pk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_id_pk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_type_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_type_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_title
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_title";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_desc
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_desc";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_abstract
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_abstract";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_approval_req
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverysColumn.ColumnName = "c_delivery_approval_req";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_approval_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_approval_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_credit_hours
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliverysColumn.ColumnName = "c_delivery_credit_hours";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_credit_units
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliverysColumn.ColumnName = "c_delivery_credit_units";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_session_facility_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_session_facility_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_owner_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_owner_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_coordinator_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_coordinator_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_active_flag
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverysColumn.ColumnName = "c_delivery_active_flag";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_active_type_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_active_type_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_visible_flag
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverysColumn.ColumnName = "c_delivery_visible_flag";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);


            //c_delivery_min_enroll
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliverysColumn.ColumnName = "c_delivery_min_enroll";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_max_enroll
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliverysColumn.ColumnName = "c_delivery_max_enroll";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_enroll_threshold
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliverysColumn.ColumnName = "c_delivery_enroll_threshold";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_waitlist_flag
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverysColumn.ColumnName = "c_delivery_waitlist_flag";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_max_waitlist
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Int32");
            dtTempDeliverysColumn.ColumnName = "c_delivery_max_waitlist";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_vlt_launch_url
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_vlt_launch_url";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_olt_launch_url
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_olt_launch_url";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_olt_launch_param
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_olt_launch_param";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_survey_scoring_scheme_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_survey_scoring_scheme_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);


            //c_delivery_custom_01
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_01";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_02
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_02";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_03
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_03";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_04
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_04";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_05
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_05";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_06
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_06";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_07
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_07";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_08
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_08";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_09
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_09";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_10
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_10";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_11
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_11";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_custom_12
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_12";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);


            //c_delivery_custom_13
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_custom_13";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);


            //c_delivery_type_text
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_type_text";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_owner_name
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_owner_name";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_coordinator_name
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_delivery_coordinator_name";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            //c_delivery_confirm
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverysColumn.ColumnName = "c_delivery_confirm";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);
            //c_nc_olt_launch_url
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_nc_olt_launch_url";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);
            //c_nc_olt_launch_param
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_nc_olt_launch_param";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);
            //c_nc_olt_waitlist_flag,
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliverysColumn.ColumnName = "c_nc_olt_waitlist_flag";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);
            //c_nc_olt_wrapper_id_fk
            dtTempDeliverysColumn = new DataColumn();
            dtTempDeliverysColumn.DataType = Type.GetType("System.String");
            dtTempDeliverysColumn.ColumnName = "c_nc_olt_wrapper_id_fk";
            dtTempDeliverys.Columns.Add(dtTempDeliverysColumn);

            return dtTempDeliverys;

        }
        //Temp Delivery attachments column
        public static DataTable TempDeliveryattachments()
        {
            DataTable dtTempDeliveryattachments = new DataTable();
            DataColumn dtTempDeliveryattachmentsColumn;
            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_attachment_id_pk";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_id_fk";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_attachment_file_guid";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_delivery_attachment_file_name";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);

            dtTempDeliveryattachmentsColumn = new DataColumn();
            dtTempDeliveryattachmentsColumn.DataType = Type.GetType("System.Boolean");
            dtTempDeliveryattachmentsColumn.ColumnName = "c_attachment_confirm";
            dtTempDeliveryattachments.Columns.Add(dtTempDeliveryattachmentsColumn);
            return dtTempDeliveryattachments;
        }
        public static DataTable TempDomain()
        {
            DataTable dtTempDomain = new DataTable();
            DataColumn dtTempDomainColumn;

            /// <summary>
            /// temp u_domain_system_id_pk 


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "c_related_domain_id_fk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            //u_domain_id_pk


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "u_domain_id_pk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            /// u_domain_name


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "u_domain_name";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            ///// <summary>
            ///// u_domain_desc

            //dtTempDomainColumn = new DataColumn();
            //dtTempDomainColumn.DataType = Type.GetType("System.String");
            //dtTempDomainColumn.ColumnName = "u_domain_desc";
            //dtTempDomain.Columns.Add(dtTempDomainColumn);

            //c_course_id_pk
            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "c_course_id_fk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            return dtTempDomain;

        }
        public static DataTable TempCategory()
        {
            DataTable dtTempCategory = new DataTable();
            DataColumn dtTempCategoryColumn;

            /// <summary>
            /// temp s_category_system_id_pk 


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "CategoryID";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_id


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_category_id";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_name


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_category_name";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);



            //c_course_id_pk
            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "Program_Curriculum_CourseID";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_description

            //dtTempCategoryColumn = new DataColumn();
            //dtTempCategoryColumn.DataType = Type.GetType("System.String");
            //dtTempCategoryColumn.ColumnName = "s_category_description";
            //dtTempCategory.Columns.Add(dtTempCategoryColumn);


            return dtTempCategory;

        }
        public static DataTable TempInstructorCourse()
        {
            DataTable dtTempInstructorCourse = new DataTable();
            DataColumn dtTepInstructorCourseColumn;
            //c_instructor_id_fk
            dtTepInstructorCourseColumn = new DataColumn();
            dtTepInstructorCourseColumn.DataType = Type.GetType("System.String");
            dtTepInstructorCourseColumn.ColumnName = "c_instructor_id_fk";
            dtTempInstructorCourse.Columns.Add(dtTepInstructorCourseColumn);
            //c_course_system_id_fk
            dtTepInstructorCourseColumn = new DataColumn();
            dtTepInstructorCourseColumn.DataType = Type.GetType("System.String");
            dtTepInstructorCourseColumn.ColumnName = "c_course_id_fk";
            dtTempInstructorCourse.Columns.Add(dtTepInstructorCourseColumn);
            //c_course_id
            dtTepInstructorCourseColumn = new DataColumn();
            dtTepInstructorCourseColumn.DataType = Type.GetType("System.String");
            dtTepInstructorCourseColumn.ColumnName = "c_course_id_pk";
            dtTempInstructorCourse.Columns.Add(dtTepInstructorCourseColumn);
            //c_course_title
            dtTepInstructorCourseColumn = new DataColumn();
            dtTepInstructorCourseColumn.DataType = Type.GetType("System.String");
            dtTepInstructorCourseColumn.ColumnName = "c_course_title";
            dtTempInstructorCourse.Columns.Add(dtTepInstructorCourseColumn);
            //c_delivery_type_name
            dtTepInstructorCourseColumn = new DataColumn();
            dtTepInstructorCourseColumn.DataType = Type.GetType("System.String");
            dtTepInstructorCourseColumn.ColumnName = "c_delivery_type_name";
            dtTempInstructorCourse.Columns.Add(dtTepInstructorCourseColumn);
            return dtTempInstructorCourse;

        }
        /// <summary>
        /// Temp Curriculum Domain
        /// </summary>
        /// <returns></returns>
        public static DataTable TempCurriculumDomain()
        {
            DataTable dtTempDomain = new DataTable();
            DataColumn dtTempDomainColumn;

            /// <summary>
            /// temp u_domain_system_id_pk 


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "c_related_domain_id_fk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            //u_domain_id_pk


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "u_domain_id_pk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            /// <summary>
            /// u_domain_name


            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "u_domain_name";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            ///// <summary>
            ///// u_domain_desc

            //dtTempDomainColumn = new DataColumn();
            //dtTempDomainColumn.DataType = Type.GetType("System.String");
            //dtTempDomainColumn.ColumnName = "u_domain_desc";
            //dtTempDomain.Columns.Add(dtTempDomainColumn);

            //c_course_id_pk
            dtTempDomainColumn = new DataColumn();
            dtTempDomainColumn.DataType = Type.GetType("System.String");
            dtTempDomainColumn.ColumnName = "c_curriculum_id_fk";
            dtTempDomain.Columns.Add(dtTempDomainColumn);

            return dtTempDomain;

        }
        public static DataTable TempCurriculumCategory()
        {
            DataTable dtTempCategory = new DataTable();
            DataColumn dtTempCategoryColumn;

            /// <summary>
            /// temp s_category_system_id_pk 


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "c_related_category_id_fk";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);


            /// <summary>
            /// s_category_id


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_category_id";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);

            /// <summary>
            /// s_category_name


            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_category_name";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);



            //c_course_id_pk
            dtTempCategoryColumn = new DataColumn();
            dtTempCategoryColumn.DataType = Type.GetType("System.String");
            dtTempCategoryColumn.ColumnName = "s_curriculum_id_fk";
            dtTempCategory.Columns.Add(dtTempCategoryColumn);



            return dtTempCategory;

        }
        //Temp Curriculum attachments column
        public static DataTable TempCurriculumattachments()
        {
            DataTable dtTempCurriculumattachments = new DataTable();
            DataColumn dtTempCurriculumattachmentsColumn;
            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_attchments_system_id_pk";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_id_fk";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_attachment_file_guid";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.String");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_curriculum_attachment_file_name";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);

            dtTempCurriculumattachmentsColumn = new DataColumn();
            dtTempCurriculumattachmentsColumn.DataType = Type.GetType("System.Boolean");
            dtTempCurriculumattachmentsColumn.ColumnName = "c_attachment_confirm";
            dtTempCurriculumattachments.Columns.Add(dtTempCurriculumattachmentsColumn);
            return dtTempCurriculumattachments;
        }
        //curriculum
        public static DataTable TempPathSection()
        {
            DataTable dtTempPathSection = new DataTable();
            DataColumn dtTempPathSectionColumn;
            //c_path_sort column
            dtTempPathSectionColumn = new DataColumn();
            dtTempPathSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempPathSectionColumn.ColumnName = "c_curricula_path_section_seq_number";
            dtTempPathSectionColumn.AutoIncrement = true;
            dtTempPathSectionColumn.AutoIncrementSeed = 1;
            dtTempPathSectionColumn.AutoIncrementStep = 1;
            dtTempPathSection.Columns.Add(dtTempPathSectionColumn);
            //c_curricula_path_section_id_pk
            dtTempPathSectionColumn = new DataColumn();
            dtTempPathSectionColumn.DataType = Type.GetType("System.String");
            dtTempPathSectionColumn.ColumnName = "c_curricula_path_section_id_pk";
            dtTempPathSection.Columns.Add(dtTempPathSectionColumn);
            //c_curricula_path_section_enforce_seq_flag
            dtTempPathSectionColumn = new DataColumn();
            dtTempPathSectionColumn.DataType = Type.GetType("System.Boolean");
            dtTempPathSectionColumn.ColumnName = "c_curricula_path_section_enforce_seq_flag";
            dtTempPathSection.Columns.Add(dtTempPathSectionColumn);
            //c_curricula_path_section_complete
            dtTempPathSectionColumn = new DataColumn();
            dtTempPathSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempPathSectionColumn.ColumnName = "c_curricula_path_section_complete";
            dtTempPathSection.Columns.Add(dtTempPathSectionColumn);
            //c_curricula_path_section_courses
            dtTempPathSectionColumn = new DataColumn();
            dtTempPathSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempPathSectionColumn.ColumnName = "c_curricula_path_section_courses";
            dtTempPathSection.Columns.Add(dtTempPathSectionColumn);


            return dtTempPathSection;
        }
        public static DataTable TempPathCourse()
        {
            DataTable dtTempCourseSection = new DataTable();
            DataColumn dtTempCourseSectionColumn;
            //c_Course_sort column
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempCourseSectionColumn.ColumnName = "c_course_sort";
            dtTempCourseSectionColumn.AutoIncrement = true;
            dtTempCourseSectionColumn.AutoIncrementSeed = 1;
            dtTempCourseSectionColumn.AutoIncrementStep = 1;
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_curricula_path_course_system_id_pk
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempCourseSectionColumn.ColumnName = "c_curricula_path_course_system_id_pk";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_course_name
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempCourseSectionColumn.ColumnName = "c_course_name";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_course_id
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempCourseSectionColumn.ColumnName = "c_course_id";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_curricula_path_section_id_fk
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempCourseSectionColumn.ColumnName = "c_curricula_path_section_id_fk";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_curricula_path_course_id_fk
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempCourseSectionColumn.ColumnName = "c_curricula_path_course_id_fk";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_curricula_path_required
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempCourseSectionColumn.ColumnName = "c_curricula_path_required";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            //c_curricula_path_course_seq_number
            dtTempCourseSectionColumn = new DataColumn();
            dtTempCourseSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempCourseSectionColumn.ColumnName = "c_curricula_path_course_seq_number";
            dtTempCourseSection.Columns.Add(dtTempCourseSectionColumn);
            return dtTempCourseSection;
        }

        //Curriculum Recert Path
        public static DataTable TempRecertPathSection()
        {
            DataTable dtTempRecertPathSection = new DataTable();
            DataColumn dtTempRecertPathSectionColumn;
            //c_path_sort column
            dtTempRecertPathSectionColumn = new DataColumn();
            dtTempRecertPathSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempRecertPathSectionColumn.ColumnName = "c_curricula_recert_path_section_seq_number";
            dtTempRecertPathSectionColumn.AutoIncrement = true;
            dtTempRecertPathSectionColumn.AutoIncrementSeed = 1;
            dtTempRecertPathSectionColumn.AutoIncrementStep = 1;
            dtTempRecertPathSection.Columns.Add(dtTempRecertPathSectionColumn);
            //c_curricula_path_section_id_pk
            dtTempRecertPathSectionColumn = new DataColumn();
            dtTempRecertPathSectionColumn.DataType = Type.GetType("System.String");
            dtTempRecertPathSectionColumn.ColumnName = "c_curricula_recert_path_section_id_pk";
            dtTempRecertPathSection.Columns.Add(dtTempRecertPathSectionColumn);
            //c_curricula_path_section_enforce_seq_flag
            dtTempRecertPathSectionColumn = new DataColumn();
            dtTempRecertPathSectionColumn.DataType = Type.GetType("System.Boolean");
            dtTempRecertPathSectionColumn.ColumnName = "c_curricula_recert_path_section_enforce_seq_flag";
            dtTempRecertPathSection.Columns.Add(dtTempRecertPathSectionColumn);
            //c_curricula_path_section_complete
            dtTempRecertPathSectionColumn = new DataColumn();
            dtTempRecertPathSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempRecertPathSectionColumn.ColumnName = "c_curricula_recert_path_section_complete";
            dtTempRecertPathSection.Columns.Add(dtTempRecertPathSectionColumn);
            //c_curricula_path_section_courses
            dtTempRecertPathSectionColumn = new DataColumn();
            dtTempRecertPathSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempRecertPathSectionColumn.ColumnName = "c_curricula_recert_path_section_courses";
            dtTempRecertPathSection.Columns.Add(dtTempRecertPathSectionColumn);


            return dtTempRecertPathSection;
        }
        public static DataTable TempRecertPathCourse()
        {
            DataTable dtTempRecertCourseSection = new DataTable();
            DataColumn dtTempRecertCourseSectionColumn;
            //c_Course_sort column
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempRecertCourseSectionColumn.ColumnName = "c_course_sort";
            dtTempRecertCourseSectionColumn.AutoIncrement = true;
            dtTempRecertCourseSectionColumn.AutoIncrementSeed = 1;
            dtTempRecertCourseSectionColumn.AutoIncrementStep = 1;
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_curricula_path_course_system_id_pk
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempRecertCourseSectionColumn.ColumnName = "c_curricula_recert_path_course_system_id_pk";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_course_name
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempRecertCourseSectionColumn.ColumnName = "c_course_name";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_course_id
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempRecertCourseSectionColumn.ColumnName = "c_course_id";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_curricula_path_section_id_fk
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempRecertCourseSectionColumn.ColumnName = "c_curricula_recert_path_section_id_fk";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_curricula_path_course_id_fk
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.String");
            dtTempRecertCourseSectionColumn.ColumnName = "c_curricula_recert_path_course_id_fk";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_curricula_path_required
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempRecertCourseSectionColumn.ColumnName = "c_curricula_recert_path_required";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            //c_curricula_path_course_seq_number
            dtTempRecertCourseSectionColumn = new DataColumn();
            dtTempRecertCourseSectionColumn.DataType = Type.GetType("System.Int32");
            dtTempRecertCourseSectionColumn.ColumnName = "c_curricula_recert_path_course_seq_number";
            dtTempRecertCourseSection.Columns.Add(dtTempRecertCourseSectionColumn);
            return dtTempRecertCourseSection;
        }
        public DataTable TempEmployee()
        {
            DataTable dtTempEmployee = new DataTable();
            DataColumn dtTempEmployeeColumn;
            //u_user_id_pk
            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_user_id_fk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            //c_course_id_fk or c_curriculum_id_fk
            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "id";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            //c_delivery_id_fk
            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "c_delivery_id_fk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            //u_first_name
            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_first_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            //u_last_name
            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_last_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            //u_employee_number
            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_employee_number";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            return dtTempEmployee;

        }
        public static DataTable GradingSchemeValues()
        {
            DataTable dtGradingSchemeValues = new DataTable();
            DataColumn dtGradingSchemeValuesColumn;

           
            /// temp s_grading_scheme_system_value_id_pk 
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_system_value_id_pk";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            
            //s_grading_scheme_value_id
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_id";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            
            /// s_grading_scheme_system_id_fk
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_system_id_fk";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);



            //s_grading_scheme_value_name
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_name";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);


            //s_grading_scheme_value_description
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_description";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            
            //s_grading_scheme_value_min_score
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_min_score";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);


            /// s_grading_scheme_value_max_score
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_max_score";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            //s_grading_scheme_value_grade
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_grade";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            //s_grading_scheme_value_min_num
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_min_num";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);


            //s_grading_scheme_value_max_num
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_max_num";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            
            /// s_grading_scheme_value_gpa
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_gpa";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);



            //s_grading_scheme_value_descriptior
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_descriptior";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);


            //s_grading_scheme_value_qualification
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_qualification";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            //s_grading_scheme_value_pass_status_id_fk
            dtGradingSchemeValuesColumn = new DataColumn();
            dtGradingSchemeValuesColumn.DataType = Type.GetType("System.String");
            dtGradingSchemeValuesColumn.ColumnName = "s_grading_scheme_value_pass_status_id_fk";
            dtGradingSchemeValues.Columns.Add(dtGradingSchemeValuesColumn);

            return dtGradingSchemeValues;

        }


        public static DataTable Employee()
        {
            DataTable dtTempEmployee = new DataTable();
            DataColumn dtTempEmployeeColumn;

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_user_id_pk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_first_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_last_name";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "u_hris_employee_id";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "t_transcript_attendance_id_fk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "t_transcript_passing_status_id_fk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "t_transcript_grade_id_fk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.Boolean");
            dtTempEmployeeColumn.ColumnName = "isSaved";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);

            dtTempEmployeeColumn = new DataColumn();
            dtTempEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempEmployeeColumn.ColumnName = "t_transcript_id_pk";
            dtTempEmployee.Columns.Add(dtTempEmployeeColumn);
            return dtTempEmployee;

        }

        public static DataTable TempCompletionCourse()
        {
            DataTable dtTempCompletionCourse = new DataTable();
            DataColumn dtTempCompletionCourseColumn;           
          
            //c_course_system_id_fk
            dtTempCompletionCourseColumn = new DataColumn();
            dtTempCompletionCourseColumn.DataType = Type.GetType("System.String");
            dtTempCompletionCourseColumn.ColumnName = "c_course_system_id_pk";
            dtTempCompletionCourse.Columns.Add(dtTempCompletionCourseColumn);
            //c_course_id
            dtTempCompletionCourseColumn = new DataColumn();
            dtTempCompletionCourseColumn.DataType = Type.GetType("System.String");
            dtTempCompletionCourseColumn.ColumnName = "c_course_id_pk";
            dtTempCompletionCourse.Columns.Add(dtTempCompletionCourseColumn);
            //c_course_title
            dtTempCompletionCourseColumn = new DataColumn();
            dtTempCompletionCourseColumn.DataType = Type.GetType("System.String");
            dtTempCompletionCourseColumn.ColumnName = "c_course_title";
            dtTempCompletionCourse.Columns.Add(dtTempCompletionCourseColumn);

            //c_delivery_id
            dtTempCompletionCourseColumn = new DataColumn();
            dtTempCompletionCourseColumn.DataType = Type.GetType("System.String");
            dtTempCompletionCourseColumn.ColumnName = "c_delivery_system_id_pk";
            dtTempCompletionCourse.Columns.Add(dtTempCompletionCourseColumn);
            return dtTempCompletionCourse;

        }

        public static DataTable TempCompletionEmployee()
        {
            DataTable dtTempCompletionEmployee = new DataTable();
            DataColumn dtTempCompletionEmployeeColumn;

            //c_course_system_id_fk
            dtTempCompletionEmployeeColumn = new DataColumn();
            dtTempCompletionEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempCompletionEmployeeColumn.ColumnName = "u_user_id_pk";
            dtTempCompletionEmployee.Columns.Add(dtTempCompletionEmployeeColumn);
            //c_course_id
            dtTempCompletionEmployeeColumn = new DataColumn();
            dtTempCompletionEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempCompletionEmployeeColumn.ColumnName = "u_username";
            dtTempCompletionEmployee.Columns.Add(dtTempCompletionEmployeeColumn);
            //c_course_title
            dtTempCompletionEmployeeColumn = new DataColumn();
            dtTempCompletionEmployeeColumn.DataType = Type.GetType("System.String");
            dtTempCompletionEmployeeColumn.ColumnName = "u_hris_employee_id";
            dtTempCompletionEmployee.Columns.Add(dtTempCompletionEmployeeColumn);
            //c_course_title
            dtTempCompletionEmployeeColumn = new DataColumn();
            dtTempCompletionEmployeeColumn.DataType = Type.GetType("System.Boolean");
            dtTempCompletionEmployeeColumn.ColumnName = "is_completed";
            dtTempCompletionEmployee.Columns.Add(dtTempCompletionEmployeeColumn);
            return dtTempCompletionEmployee;

        }

        public static DataTable TempEnrollmentCourseCurriculum()
        {
            DataTable dtTempEnrollmentCourseCurriculum = new DataTable();
            DataColumn dtTempEnrollmentCourseCurriculumColumn;

            //c_course_system_id_fk
            dtTempEnrollmentCourseCurriculumColumn = new DataColumn();
            dtTempEnrollmentCourseCurriculumColumn.DataType = Type.GetType("System.String");
            dtTempEnrollmentCourseCurriculumColumn.ColumnName = "sysId";
            dtTempEnrollmentCourseCurriculum.Columns.Add(dtTempEnrollmentCourseCurriculumColumn);
            //c_course_id
            dtTempEnrollmentCourseCurriculumColumn = new DataColumn();
            dtTempEnrollmentCourseCurriculumColumn.DataType = Type.GetType("System.String");
            dtTempEnrollmentCourseCurriculumColumn.ColumnName = "Id";
            dtTempEnrollmentCourseCurriculum.Columns.Add(dtTempEnrollmentCourseCurriculumColumn);
            //c_course_title
            dtTempEnrollmentCourseCurriculumColumn = new DataColumn();
            dtTempEnrollmentCourseCurriculumColumn.DataType = Type.GetType("System.String");
            dtTempEnrollmentCourseCurriculumColumn.ColumnName = "title";
            dtTempEnrollmentCourseCurriculum.Columns.Add(dtTempEnrollmentCourseCurriculumColumn);

            //c_delivery_id
            dtTempEnrollmentCourseCurriculumColumn = new DataColumn();
            dtTempEnrollmentCourseCurriculumColumn.DataType = Type.GetType("System.String");
            dtTempEnrollmentCourseCurriculumColumn.ColumnName = "type";
            dtTempEnrollmentCourseCurriculum.Columns.Add(dtTempEnrollmentCourseCurriculumColumn);
            return dtTempEnrollmentCourseCurriculum;

        }

        public static DataTable TempAssignmentRuleCatalogItem()
        {
            DataTable dtTempTempAssignmentRuleCatalogItem = new DataTable();
            DataColumn dtTempTempAssignmentRuleCatalogItemColumn;

            //c_course_system_id_fk
            dtTempTempAssignmentRuleCatalogItemColumn = new DataColumn();
            dtTempTempAssignmentRuleCatalogItemColumn.DataType = Type.GetType("System.String");
            dtTempTempAssignmentRuleCatalogItemColumn.ColumnName = "u_assignment_rule_item_system_id_pk";
            dtTempTempAssignmentRuleCatalogItem.Columns.Add(dtTempTempAssignmentRuleCatalogItemColumn);
            //c_course_id
            dtTempTempAssignmentRuleCatalogItemColumn = new DataColumn();
            dtTempTempAssignmentRuleCatalogItemColumn.DataType = Type.GetType("System.String");
            dtTempTempAssignmentRuleCatalogItemColumn.ColumnName = "u_assignment_rule_item_id_fk";
            dtTempTempAssignmentRuleCatalogItem.Columns.Add(dtTempTempAssignmentRuleCatalogItemColumn);
            //c_course_title
            dtTempTempAssignmentRuleCatalogItemColumn = new DataColumn();
            dtTempTempAssignmentRuleCatalogItemColumn.DataType = Type.GetType("System.String");
            dtTempTempAssignmentRuleCatalogItemColumn.ColumnName = "u_assignment_rule_id_fk";
            dtTempTempAssignmentRuleCatalogItem.Columns.Add(dtTempTempAssignmentRuleCatalogItemColumn);


            //c_course_id
            dtTempTempAssignmentRuleCatalogItemColumn = new DataColumn();
            dtTempTempAssignmentRuleCatalogItemColumn.DataType = Type.GetType("System.String");
            dtTempTempAssignmentRuleCatalogItemColumn.ColumnName = "Id";
            dtTempTempAssignmentRuleCatalogItem.Columns.Add(dtTempTempAssignmentRuleCatalogItemColumn);
            //c_course_title
            dtTempTempAssignmentRuleCatalogItemColumn = new DataColumn();
            dtTempTempAssignmentRuleCatalogItemColumn.DataType = Type.GetType("System.String");
            dtTempTempAssignmentRuleCatalogItemColumn.ColumnName = "title";
            dtTempTempAssignmentRuleCatalogItem.Columns.Add(dtTempTempAssignmentRuleCatalogItemColumn);

            //c_delivery_id
            dtTempTempAssignmentRuleCatalogItemColumn = new DataColumn();
            dtTempTempAssignmentRuleCatalogItemColumn.DataType = Type.GetType("System.String");
            dtTempTempAssignmentRuleCatalogItemColumn.ColumnName = "type";
            dtTempTempAssignmentRuleCatalogItem.Columns.Add(dtTempTempAssignmentRuleCatalogItemColumn);

            return dtTempTempAssignmentRuleCatalogItem;
        }
    }
}