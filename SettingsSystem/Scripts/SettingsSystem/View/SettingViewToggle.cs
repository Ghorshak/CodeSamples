using SettingsSystem.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsSystem.View
{
    public class SettingViewToggle : SettingViewBase<SettingRangeOfValues, bool>
    {
        [field: SerializeField] private Toggle Toggle { get; set; }

        protected override void OnEnable()
        {
            Toggle.onValueChanged.AddListener(UpdateSettingCurrentValue);

            base.OnEnable();
        }

        protected override void UpdateSettingCurrentValue(bool state)
        {
            if (ConvertToBool(Setting.CurrentValue) == state)
                return;
            
            Setting.CurrentValue = state ? 1 : 0;
        }

        protected override void UpdateVisualState(int value)
        {
            Toggle.isOn = ConvertToBool(value);
        }

        private bool ConvertToBool(int value)
        {
            return value <= 0 ? false : true;
        }

        protected override void OnDisable()
        {
            Toggle.onValueChanged.RemoveListener(UpdateSettingCurrentValue);

            base.OnDisable();
        }
    }
}
