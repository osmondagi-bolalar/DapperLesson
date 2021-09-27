using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperLesson.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class TableAttribute : Attribute
    {
        public string Schema { get; set; }
        public string Name { get; set; }
    }
}
