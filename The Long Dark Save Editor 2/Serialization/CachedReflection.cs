using System;
using System.Collections.Generic;
using System.Reflection;

namespace The_Long_Dark_Save_Editor_2.Serialization
{
    static class MemberCustomAttributeCache<T>
    {
        public static Dictionary<MemberInfo, T> cache = new Dictionary<MemberInfo, T>();
        public static Dictionary<MemberInfo, T> cacheNoInherit = new Dictionary<MemberInfo, T>();
    }

    static class CachedReflection
    {

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
