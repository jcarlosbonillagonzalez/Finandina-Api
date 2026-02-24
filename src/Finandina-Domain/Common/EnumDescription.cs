using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finandina_Domain.Common
{
    public static class EnumDescription
    {
        public static string GetDescription(this Enum value)
        {
            var attr = value.GetType()
                            .GetField(value.ToString())?
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;
            return attr?.Description ?? value.ToString();
        }
    }
}
