// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 1/29/2013 2:05:33 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Loads/Saves configuration in local machine for individual person
    /// </summary>
    public static class MySettingsManager
    {
        private static string _settingsFolder;
        private static Dictionary<string, object> _settingsDic = new Dictionary<string, object>();

        public static string SettingsFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_settingsFolder))
                {
                    _settingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CoinSniffer");
                }
                return _settingsFolder;
            }
            set
            {
                _settingsFolder = value;
            }
        }

        public static T GetSettings<T>(string module = null)
            where T : ISettings, new()
        {
            string partialPath = null;
            if (string.IsNullOrEmpty(module))
            {
                partialPath = string.Format(@"{0}.xml", typeof(T).FullName);
            }
            else
            {
                partialPath = string.Format(@"{0}\{1}.xml", module, typeof(T).FullName);
            }

            var fullPath = Path.Combine(SettingsFolder, partialPath);

            if (!_settingsDic.Keys.Contains(fullPath))
            {
                var settings = LoadSettings<T>(fullPath);
                try
                {
                    _settingsDic.Add(fullPath, settings);
                }
                catch (ArgumentException)
                {
                    // Do nothing. The Try logic is to make sure thread safe.
                }
            }
            return (T)_settingsDic[fullPath];
        }

        public static void SaveAll()
        {
            foreach (var item in _settingsDic)
            {
                Write(item.Key, item.Value as ISettings);
            }
        }

        public static void SaveSingle(ISettings settings)
        {
            if (settings == null)
            {
                return;
            }

            foreach (var item in _settingsDic)
            {
                if (settings.Equals(item.Value))
                {
                    Write(item.Key, item.Value as ISettings);
                }
            }
        }

        private static T LoadSettings<T>(string fullPath)
            where T : ISettings, new()
        {
            T settings;
            if (!File.Exists(fullPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                settings = new T();
                settings.Initialize();
                Write(fullPath, settings);
            }
            else
            {
                settings = Read<T>(fullPath);
            }
            return settings;
        }

        /// <summary>
        /// Writes settings to file.
        /// </summary>
        private static void Write(string fullPath, ISettings settings)
        {
            using (var writer = new StreamWriter(fullPath))
            {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        /// <summary>
        /// Reads settings from file
        /// </summary>
        /// <returns>Instance of type T</returns>
        private static T Read<T>(string fullPath)
            where T : ISettings, new()
        {
            T settings;
            using (var fs = new FileStream(fullPath, FileMode.Open))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(T));
                    settings = (T)serializer.Deserialize(fs);
                }
                catch (Exception)
                {
                    var t = new T();
                    t.Initialize();
                    return t;
                }
            }
            return settings;
        }
    }
}
