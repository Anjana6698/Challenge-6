using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Assignment6.BAL
{
    public class DesignationBAL
    {
        DAL.DesignationDAL objdept = new DAL.DesignationDAL();
        private int _desigid;
        private string _designame;
        private int _departid;
    public int desigid
    {
            get
            {
                return _desigid;
            }
            set
            {
            _desigid = value;
            }
        }
        public string designame
        {
            get
            {
                return _designame;
            }
            set
            {
                _designame= value;
            }
        }
        public int departmentid
        {
            get
            {
                return _departid;
            }
            set
            {
                _departid = value;
            }
        }
        public DataTable Designation_values()
        {
            return objdept.Designation_list();
        }
        public int Designation_insert()
        {
            return objdept.Designation_insert(this);
        }
        public int update_Designation()
        {
            return objdept.update_Designation(this);
        }
        public DataTable view_Designation()
        {
            return objdept.view_Designation(this);
        }
        public int delete_Designation()
        {
            return objdept.delete_Designation(this);
        }

    }
}