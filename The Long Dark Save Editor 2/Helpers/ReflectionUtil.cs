using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public static class ReflectionUtil
    {
        public static object ConvertArray(Array arr, Type t)
        {
            if (t.IsArray)
            {
                return Convert.ChangeType(arr, t);
            }else if((typeof(IList).IsAssignableFrom(t)))
            {
                var list = (IList)Activator.CreateInstance(t);
                foreach(var item in arr)
                {
                    list.Add(item);
                }
                return list;
            }
            throw new Exception();
        }
    }
}
