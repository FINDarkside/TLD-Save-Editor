
using System;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DeserializeAttribute : Attribute
    {
        public string From { get; private set; }
        public Boolean Json { get; private set; }

        public DeserializeAttribute(string from, bool json = false)
        {
            From = from;
            Json = json;
        }
    }

}
