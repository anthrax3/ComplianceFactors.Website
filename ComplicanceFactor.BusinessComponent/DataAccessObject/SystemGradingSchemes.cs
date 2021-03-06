﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplicanceFactor.BusinessComponent.DataAccessObject
{
    public class SystemGradingSchemes
    {
        public string s_grading_scheme_system_id_pk { get; set; }
        public string s_grading_scheme_id { get; set; }
        public string s_grading_scheme_status_id_fk { get; set; }
        public string s_grading_scheme_type_id_fk { get; set; }
        public string s_grading_scheme_name_us_english { get; set; }
        public string s_grading_scheme_desc_us_english { get; set; }
        public string s_grading_scheme_name_uk_english { get; set; }
        public string s_grading_scheme_desc_uk_english { get; set; }
        public string s_grading_scheme_name_ca_france { get; set; }
        public string s_grading_scheme_desc_ca_france { get; set; }
        public string s_grading_scheme_name_fr_french { get; set; }
        public string s_grading_scheme_desc_fr_french { get; set; }
        public string s_grading_scheme_name_mx_spanish { get; set; }
        public string s_grading_scheme_desc_mx_spanish { get; set; }
        public string s_grading_scheme_name_sp_spanish { get; set; }
        public string s_grading_scheme_desc_sp_spanish { get; set; }
        public string s_grading_scheme_name_portuguse { get; set; }
        public string s_grading_scheme_desc_portuguse { get; set; }
        public string s_grading_scheme_name_chinese { get; set; }
        public string s_grading_scheme_desc_chinese { get; set; }
        public string s_grading_scheme_name_german { get; set; }
        public string s_grading_scheme_desc_german { get; set; }
        public string s_grading_scheme_name_japanese { get; set; }
        public string s_grading_scheme_desc_japanese { get; set; }
        public string s_grading_scheme_name_russian { get; set; }
        public string s_grading_scheme_desc_russian { get; set; }
        public string s_grading_scheme_name_danish { get; set; }
        public string s_grading_scheme_desc_danish { get; set; }
        public string s_grading_scheme_name_polish { get; set; }
        public string s_grading_scheme_desc_polish { get; set; }
        public string s_grading_scheme_name_swedish { get; set; }
        public string s_grading_scheme_desc_swedish { get; set; }
        public string s_grading_scheme_name_finnish { get; set; }
        public string s_grading_scheme_desc_finnish { get; set; }
        public string s_grading_scheme_name_korean { get; set; }
        public string s_grading_scheme_desc_korean { get; set; }
        public string s_grading_scheme_name_italian { get; set; }
        public string s_grading_scheme_desc_italian { get; set; }
        public string s_grading_scheme_name_dutch { get; set; }
        public string s_grading_scheme_desc_dutch { get; set; }
        public string s_grading_scheme_name_indonesian { get; set; }
        public string s_grading_scheme_desc_indonesian { get; set; }
        public string s_grading_scheme_name_greek { get; set; }
        public string s_grading_scheme_desc_greek { get; set; }
        public string s_grading_scheme_name_hungarian { get; set; }
        public string s_grading_scheme_desc_hungarian { get; set; }
        public string s_grading_scheme_name_norwegian { get; set; }
        public string s_grading_scheme_desc_norwegian { get; set; }
        public string s_grading_scheme_name_turkish { get; set; }
        public string s_grading_scheme_desc_turkish { get; set; }
        public string s_grading_scheme_name_arabic { get; set; }
        public string s_grading_scheme_desc_arabic { get; set; }
        public string s_grading_scheme_name_custom_01 { get; set; }
        public string s_grading_scheme_desc_custom_01 { get; set; }
        public string s_grading_scheme_name_custom_02 { get; set; }
        public string s_grading_scheme_desc_custom_02 { get; set; }
        public string s_grading_scheme_name_custom_03 { get; set; }
        public string s_grading_scheme_desc_custom_03 { get; set; }
        public string s_grading_scheme_name_custom_04 { get; set; }
        public string s_grading_scheme_desc_custom_04 { get; set; }
        public string s_grading_scheme_name_custom_05 { get; set; }
        public string s_grading_scheme_desc_custom_05 { get; set; }
        public string s_grading_scheme_name_custom_06 { get; set; }
        public string s_grading_scheme_desc_custom_06 { get; set; }
        public string s_grading_scheme_name_custom_07 { get; set; }
        public string s_grading_scheme_desc_custom_07 { get; set; }
        public string s_grading_scheme_name_custom_08 { get; set; }
        public string s_grading_scheme_desc_custom_08 { get; set; }
        public string s_grading_scheme_name_custom_09 { get; set; }
        public string s_grading_scheme_desc_custom_09 { get; set; }
        public string s_grading_scheme_name_custom_10 { get; set; }
        public string s_grading_scheme_desc_custom_10 { get; set; }
        public string s_grading_scheme_name_custom_11 { get; set; }
        public string s_grading_scheme_desc_custom_11 { get; set; }
        public string s_grading_scheme_name_custom_12 { get; set; }
        public string s_grading_scheme_desc_custom_12 { get; set; }
        public string s_grading_scheme_name_custom_13 { get; set; }
        public string s_grading_scheme_desc_custom_13 { get; set; }
        public string s_grading_scheme_values { get; set; }

        //Grading Schemes Values
        public string s_grading_scheme_system_value_id_pk { get; set; }
        public string s_grading_scheme_value_id { get; set; }
        public string s_grading_scheme_system_id_fk { get; set; }
        public string s_grading_scheme_value_name { get; set; }
        public string s_grading_scheme_value_description { get; set; }
        public Int16 s_grading_scheme_value_min_score { get; set; }
        public Int16 s_grading_scheme_value_max_score { get; set; }
        public string s_grading_scheme_value_grade { get; set; }
        public Int16 s_grading_scheme_value_min_num { get; set; }
        public Int16 s_grading_scheme_value_max_num { get; set; }
        public string s_grading_scheme_value_gpa { get; set; }
        public string s_grading_scheme_value_descriptior { get; set; }
        public string s_grading_scheme_value_qualification { get; set; }
        public string s_grading_scheme_value_pass_status_id_fk { get; set; }
    }
}
