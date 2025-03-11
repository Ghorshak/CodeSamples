using System;
using UnityEngine;

namespace SettingsSystem.Settings
{
    public abstract class Setting : ScriptableObject, ISetting
    {
        public event Action<int> OnChanged = delegate { };

        [SerializeField] private int currentValue;

        [field: SerializeField] protected int DefaultValue { get; set; }
        [field: SerializeField, Space] public string DisplayName { get; private set; }
        [field: SerializeField, Space] private bool AutoExecuteChanges { get; set; } = true;

        public abstract int MinValue { get; }
		public abstract int MaxValue { get; }

        public abstract SettingKey Key { get; }
        protected string SettingId => $"SETTING_{Key}";

        private bool initialized = false;

        public int CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = Math.Clamp(value, MinValue, MaxValue);
                Save();
                OnChanged?.Invoke(currentValue);
                if (AutoExecuteChanges || initialized == false)
                {
                    ExecuteChange();
                }
            }
        }

        public void Initialize()
        {
            if (PlayerPrefs.HasKey(SettingId))
            {
                CurrentValue = Load();
            }
            else
            {
                SetToDefault();
            }

            initialized = true;
        }

        public void SetToDefault()
        {
            CurrentValue = DefaultValue;
        }

        private void Save()
        {
            PlayerPrefs.SetInt(SettingId, currentValue);
            PlayerPrefs.Save();
        }

        private int Load()
        {
            return PlayerPrefs.GetInt(SettingId);
        }

        public abstract void ExecuteChange();
    }
}