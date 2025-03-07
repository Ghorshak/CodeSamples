using System;
using System.Collections.Generic;
using SettingsSystem.Settings;
using UnityEngine;

namespace SettingsSystem
{
    [CreateAssetMenu(menuName = "Settings/Data", fileName = "Settings Data", order = 100)]
    public class SettingsData : ScriptableObject
    {
        [field: SerializeField] public List<Setting> AudioSettings { get; private set; } = new();
        [field: SerializeField] public List<Setting> GraphicsSettings { get; private set; } = new();

        public List<Setting> GetAllSettings()
		{
			var allSettings = new List<Setting>();

			allSettings.AddRange(AudioSettings);
			allSettings.AddRange(GraphicsSettings);

			return allSettings;
		}

        public void ResetAllSettingsToDefault()
        {
            foreach (var setting in AudioSettings)
                setting.SetToDefault();
            foreach (var setting in GraphicsSettings)
                setting.SetToDefault();
        }
    }
}