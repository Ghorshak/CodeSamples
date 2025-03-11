using System;
using System.Collections.Generic;
using UnityEngine;

namespace SettingsSystem.Settings
{
    // This classes are just to wrap things up and to show how the whole system work.
    // It's goal is to initialize all settings and the setting picker so you can get their
    // reference from other places in your code.
    // Depanding on your project's architecture it can be implemented in many ways, i.e. as
    // a singleton SettingsManager or any other creation that will do the job
    public class SettingsController : MonoBehaviour
    {
        public static SettingPicker Settings = new();

        [field: SerializeField] private SettingsData SettingsData { get; set; }

        private void Awake()
        {
            var allSettings = SettingsData.GetAllSettings();
            Settings.Initialize(allSettings);
        }

        public void ResetAllSettingsToDefault()
        {
            SettingsData.ResetAllSettingsToDefault();
        }
    }

    [Serializable]
    public class SettingPicker : ISettings
    {
        public ISetting this [SettingKey key] => SettingByKey[key];

        private Dictionary<SettingKey, Setting> SettingByKey { get; set; } = new();

        public void Initialize(List<Setting> settings)
        {
            foreach (var setting in settings)
			{
				SettingByKey.Add(setting.Key, setting);
				setting.Initialize();
			}
        }
    }
}
