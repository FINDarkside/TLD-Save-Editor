using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class EnumWrapper<T> : BindableBase where T : Enum
    {
        static class EnumValues<T2> where T2 : Enum
        {
            public static ObservableCollection<string> values = new ObservableCollection<string>(Enum.GetNames(typeof(T2)));
        }

        public EnumWrapper(string s)
        {
            Value = s;
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (!EnumValues<T>.values.Contains(value))
                {
                    EnumValues<T>.values.Add(value);
                }
                SetProperty(ref _value, value);
            }
        }

        public void SetValue(T val)
        {
            Value = val.ToString();
        }

        public override string ToString()
        {
            return _value;
        }

        public List<string> GetValues()
        {
            return EnumValues<T>.values;
        }

    }
}
