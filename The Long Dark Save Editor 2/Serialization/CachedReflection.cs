using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace The_Long_Dark_Save_Editor_2.Serialization
{
    static class PropertyCustomAttributeCache<T>
    {
        public static Dictionary<PropertyInfo, T> cache = new Dictionary<PropertyInfo, T>();
        public static Dictionary<PropertyInfo, T> cacheNoInherit = new Dictionary<PropertyInfo, T>();
    }
    static class MemberCustomAttributeCache<T>
    {
        public static Dictionary<MemberInfo, T> cache = new Dictionary<MemberInfo, T>();
        public static Dictionary<MemberInfo, T> cacheNoInherit = new Dictionary<MemberInfo, T>();
    }

    static class CachedReflection
    {

        public static T GetCustomAttributeCached<T>(this PropertyInfo propInfo, bool inherit) where T : Attribute
        {
            var cache = inherit ? PropertyCustomAttributeCache<T>.cache : PropertyCustomAttributeCache<T>.cacheNoInherit;
            if (cache.ContainsKey(propInfo))
            {
                return cache[propInfo];
            }
            var attr = propInfo.GetCustomAttribute<T>(false);
            cache.Add(propInfo, attr);
            return attr;
        }

        public static T GetCustomAttributeCached<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
        {
            var cache = inherit ? MemberCustomAttributeCache<T>.cache : MemberCustomAttributeCache<T>.cacheNoInherit;
            if (cache.ContainsKey(memberInfo))
            {
                return cache[memberInfo];
            }
            var attr = memberInfo.GetCustomAttribute<T>(false);
            cache.Add(memberInfo, attr);
            return attr;
        }
    }
}
