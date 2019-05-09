using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class EnumWrapper<T> : INotifyPropertyChanged where T : Enum
    {
        static class EnumValues<T> where T : Enum
        {
            public static List<string> values = Enum.GetNames(typeof(T)).ToList();
        }

        private string currentValue;
        public string CurrentValue
        {
            get { return CurrentValue; }
            set
            {
                if (!EnumValues<T>.values.Contains(value)){
                    EnumValues<T>.values.Add(value);
                }
                SetPropertyField(ref currentValue, value);
            }
        }

        public List<string> GetValues()
        {
            return EnumValues<T>.values;
        }

        protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
