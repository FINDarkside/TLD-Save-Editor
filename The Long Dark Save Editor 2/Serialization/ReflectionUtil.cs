using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace The_Long_Dark_Save_Editor_2.Serialization
{
    public static class ReflectionUtil
    {
        public static object ConvertArray(Array arr, Type t)
        {
            if (t.IsArray)
            {
                return Convert.ChangeType(arr, t);
            }
            else if ((typeof(IList).IsAssignableFrom(t)))
            {
                var list = (IList)Activator.CreateInstance(t);
                foreach (var item in arr)
                {
                    list.Add(item);
                }
                return list;
            }
            else if (t.IsGenericType && typeof(HashSet<>).IsAssignableFrom(t.GetGenericTypeDefinition()))
            {
                var set = Activator.CreateInstance(t);
                MethodInfo method = set.GetType().GetMethod("Add", new Type[] { t.GetGenericArguments()[0] });
                foreach (var item in arr)
                {
                    method.Invoke(set, new object[] { item });
                }
                return set;
            }
            throw new Exception("Unsupported collection type " + t);
        }

        public static bool IsBoxed<T>(T value)
        {
            return
                (typeof(T).IsInterface || typeof(T) == typeof(object)) &&
                value != null &&
                value.GetType().IsValueType;
        }

        public static bool ImplementsGenericInterface(Type t, Type t2)
        {
            return t.GetInterfaces().Any(i =>
               i.IsGenericType &&
               i.GetGenericTypeDefinition() == t2);
        }

    }
}
