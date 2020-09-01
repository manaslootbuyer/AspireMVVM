using System;
using System.Collections.Generic;
using System.Reflection;

namespace MvvmAspire
{
    public class ReflectionHelper
    {
        public static Dictionary<string, object> ToFlatDictionary(object obj)         {             Dictionary<string, object> ret = new Dictionary<string, object>();              foreach (PropertyInfo prop in obj.GetType().GetProperties())             {                 string propName = prop.Name;                 var val = obj.GetType().GetProperty(propName).GetValue(obj, null);                 if (val != null)                 {                     ret.Add(propName, val);                 }                 else                 {                     ret.Add(propName, null);                 }             }              return ret;         } 
    }
}
