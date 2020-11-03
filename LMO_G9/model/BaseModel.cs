using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class BaseModel
    {
        private DateTime createDate;
        private long createBy;
        private DateTime updateDate;
        private long updateBy;

        public BaseModel()
        {
        }

        public BaseModel(DateTime createDate, long createBy, DateTime updateDate, long updateBy)
        {
            this.createDate = createDate;
            this.createBy = createBy;
            this.updateDate = updateDate;
            this.updateBy = updateBy;
        }

        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public long CreateBy { get => createBy; set => createBy = value; }
        public DateTime UpdateDate { get => updateDate; set => updateDate = value; }
        public long UpdateBy { get => updateBy; set => updateBy = value; }
    }
}