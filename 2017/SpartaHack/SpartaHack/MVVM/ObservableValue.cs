﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace SpartaHack
{
    
    public class ObservableValue<T> : INotifyPropertyChanged
    {
        private T _Value;
        public T Value
        {
            get
            {
                return _Value;
            }

            set
            {
                if (!(value == null|| value.Equals( _Value)))
                {
                    _Value = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}