using SettingsSystem.Settings;
using TMPro;
using UnityEngine;

namespace SettingsSystem.View
{
    public abstract class SettingViewBase<S, T> : MonoBehaviour where S : Setting
    {
        [field: SerializeField] protected S Setting { get; set; }

        [field: SerializeField, Space] private TMP_Text DisplayName { get; set; }

        protected abstract void UpdateSettingCurrentValue(T newValue);
        protected abstract void UpdateVisualState(int newValue);

        protected virtual void Awake()
        {
            DisplayName.text = Setting.DisplayName;
        }

        protected virtual void OnEnable()
        {
            Setting.OnChanged += UpdateVisualState;

            UpdateVisualState(Setting.CurrentValue);
        }

        protected virtual void OnDisable()
        {
            Setting.OnChanged -= UpdateVisualState;
        }
    }
}
