using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Type : BaseModel
    {
        private long typeId;
        private string name;

        public Type()
        {
        }

        public Type(long typeId, string name)
        {
            this.typeId = typeId;
            this.name = name;
        }

        public long TypeId { get => typeId; set => typeId = value; }
        public string Name { get => name; set => name = value; }
    }
}