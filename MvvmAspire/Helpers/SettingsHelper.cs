using System;
using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace MvvmAspire.Helpers
{
    public class SettingsHelper
    {
        //Default Values for Save Data
        private static readonly string DefaultString = string.Empty;
        private static readonly int DefaultInt = 0;
        private static readonly float DefaultFloat = 0f;
        private static readonly double DefaultDouble = 0d;
        private static readonly bool DefaultBoolean = false;
        private static readonly DateTime DefaultDateTime = DateTime.MinValue;

        //Save any type of value to local storage.
        public static void SaveSettings(string key, bool value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

        public static void SaveSettings(string key, int value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

        public static void SaveSettings(string key, string value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

        public static void SaveSettings(string key, float value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

        public static void SaveSettings(string key, double value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

        public static void SaveSettings(string key, DateTime value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }


        /* 	Get Current Settings Per Platform.
                Android: SharedPreferences
                iOS: NSUserDefault
                Windows: Setting
         */
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

       
        public static string GetSettingsString(string key)
        {
            return AppSettings.GetValueOrDefault(key, DefaultString);
        }

        public static void RemoveKey(string key)
        {
            AppSettings.Remove(key);
        }

        public static DateTime? GetSettingsDatetime(string key)
        {
            return AppSettings.GetValueOrDefault(key, DefaultDateTime);
        }


        public static int GetSettingsInt(string key)
        {
            return AppSettings.GetValueOrDefault(key, DefaultInt);
        }


        public static float GetSettingsFloat(string key)
        {
            return AppSettings.GetValueOrDefault(key, DefaultFloat);
        }


        public static double GetSettingsDouble(string key)
        {
            return AppSettings.GetValueOrDefault(key, DefaultDouble);
        }

        public static bool GetSettingsBoolean(string key)
        {
            return AppSettings.GetValueOrDefault(key, DefaultBoolean);
        }
    }
}