using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(BaseEntity);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(BaseEntity);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }
    }
}
