using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class DynamicSerializable<T> where T : new()
    {

        private Dictionary<object, List<KeyValuePair<string, JToken>>> extraFields = new Dictionary<object, List<KeyValuePair<string, JToken>>>();
        public T Obj { get; private set; }

        public DynamicSerializable(string json)
        {
            Obj = Parse(JObject.Parse(json), typeof(T));
        }

        private dynamic Parse(JToken token, Type t, bool deserialize = false)
        {
            if (token.Type == JTokenType.Object)
            {
                return ParseObject((JObject)token, t);
            }
            else if (token.Type == JTokenType.Array)
            {
                return ParseArray((JArray)token, t);
            }
            else if (token.Type == JTokenType.Boolean || token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                return token.ToObject(t);
            }
            else if (token.Type == JTokenType.String)
            {
                string s = token.ToObject<string>();
                if (!deserialize)
                    return s;
                return Parse(JToken.Parse(s), t);
            }
            else if (token.Type == JTokenType.Null)
            {
                return null;
            }
            else
            {
                throw new Exception("Invalid token type " + t);
            }
        }

        public string Serialize()
        {
            var res = ReconstructObject(Obj);
            return JsonConvert.SerializeObject(res);
        }

        public object Reconstruct(object o, DeserializeAttribute attr = null)
        {
            object result = null;
            if (o == null)
                result = null;
            else
            {
                Type t = o.GetType();
                if (IsBoxed(o) || o is string)
                {
                    result = o;
                }
                else if (o is ICollection)
                {
                    result = ReconstructCollection((ICollection)o);
                }
                else
                {
                    result = ReconstructObject(o);
                }
            }

            if (attr != null && attr.Json)
                return JsonConvert.SerializeObject(result);
            return result;
        }

        public object ReconstructObject(object o)
        {
            var res = new Dictionary<string, dynamic>();
            var t = o.GetType();
            PropertyInfo[] props = t.GetProperties().Where(p => p.GetCustomAttribute<NonSerializedAttribute>() == null).ToArray();
            FieldInfo[] fields = t.GetFields().Where(p => p.GetCustomAttribute<NonSerializedAttribute>() == null).ToArray();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<DeserializeAttribute>();
                var name = attr?.From ?? prop.Name;
                res.Add(name, Reconstruct(prop.GetValue(o), attr));
            }
            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<DeserializeAttribute>();
                var name = attr?.From ?? field.Name;
                res.Add(name, Reconstruct(field.GetValue(o), attr));
            }
            if (extraFields.ContainsKey(o))
            {
                foreach (var kvp in extraFields[o])
                {
                    res.Add(kvp.Key, kvp.Value);
                }
            }
            return res;
        }

        public List<object> ReconstructCollection(ICollection col)
        {
            List<object> result = new List<object>();
            foreach (var item in col)
            {
                result.Add(Reconstruct(item));
            }
            return result;
        }

        private object ParseObject(JObject obj, Type t)
        {
            var result = Activator.CreateInstance(t);
            Dictionary<string, PropertyInfo> props = t.GetProperties().ToDictionary(p => MemberToName(p));
            Dictionary<string, FieldInfo> fields = t.GetFields().ToDictionary(p => MemberToName(p));

            foreach (var child in obj)
            {
                if (props.ContainsKey(child.Key))
                {
                    var prop = props[child.Key];
                    var attr = prop.GetCustomAttribute<DeserializeAttribute>();
                    var childType = prop.PropertyType;
                    var childVal = Parse(child.Value, childType, attr != null && attr.Json);
                    prop.SetValue(result, childVal);
                }
                else if (fields.ContainsKey(child.Key))
                {
                    var field = fields[child.Key];
                    var attr = field.GetCustomAttribute<DeserializeAttribute>();
                    var childType = field.FieldType;
                    var childVal = Parse(child.Value, childType, field.GetCustomAttribute<DeserializeAttribute>() != null);
                    field.SetValue(result, childVal);
                }
                else
                {
                    if (!extraFields.ContainsKey(result))
                        extraFields.Add(result, new List<KeyValuePair<string, JToken>>());
                    extraFields[result].Add(child);
                }
            }
            return result;
        }

        private object ParseArray(JArray obj, Type t)
        {
            Type elemType = t.GetElementType();
            if (!t.IsArray)
                elemType = t.GetGenericArguments().Single();
            Array result = Array.CreateInstance(elemType, obj.Count);
            int i = 0;
            foreach (var child in obj)
            {
                result.SetValue(Parse(child, elemType), i++);
            }
            return ReflectionUtil.ConvertArray(result, t);
        }

        private string MemberToName(MemberInfo m)
        {
            var attr = m.GetCustomAttribute<DeserializeAttribute>();
            if (attr != null)
                return attr.From;
            return m.Name;
        }

        public static bool IsBoxed<T>(T value)
        {
            return
                (typeof(T).IsInterface || typeof(T) == typeof(object)) &&
                value != null &&
                value.GetType().IsValueType;
        }

    }
}
