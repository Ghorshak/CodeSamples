using System;

namespace SettingsSystem.Settings
{
    public interface ISetting
    {
        public event Action<int> OnChanged;

        public string DisplayName { get; }
        public int CurrentValue { get; }
        // public abstract int MinValue { get; }
        // public abstract int MaxValue { get; }
        public abstract SettingKey Key { get; }

        public void ExecuteChange();
        public void SetToDefault();
    }

    public interface ISettings
    {
        ISetting this[SettingKey key] { get; }
    }
}