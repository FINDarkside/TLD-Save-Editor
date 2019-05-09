using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class EnumWrapper<T> : BindableBase where T : Enum
    {
        static class EnumValues<T2> where T2 : Enum
        {
            public static List<string> values = Enum.GetNames(typeof(T2)).ToList();
        }

        public EnumWrapper(string s)
        {
            CurrentValue = s;
        }

        private string currentValue;
        public string CurrentValue
        {
            get { return currentValue; }
            set
            {
                if (!EnumValues<T>.values.Contains(value))
                {
                    EnumValues<T>.values.Add(value);
                }
                SetProperty(ref currentValue, value);
            }
        }

        public override string ToString()
        {
            return currentValue;
        }

        public List<string> GetValues()
        {
            return EnumValues<T>.values;
        }

    }
}
