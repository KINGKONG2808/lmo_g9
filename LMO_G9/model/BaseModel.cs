using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class BaseModel
    {
        private DateTime createDate;
        private int createBy;
        private DateTime updateDate;
        private int updateBy;

        public BaseModel()
        {
        }

        public BaseModel(DateTime createDate, int createBy, DateTime updateDate, int updateBy)
        {
            this.createDate = createDate;
            this.createBy = createBy;
            this.updateDate = updateDate;
            this.updateBy = updateBy;
        }

        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public int CreateBy { get => createBy; set => createBy = value; }
        public DateTime UpdateDate { get => updateDate; set => updateDate = value; }
        public int UpdateBy { get => updateBy; set => updateBy = value; }
    }
}