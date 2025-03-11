using SettingsSystem.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsSystem.View
{
    public class SettingViewSlider : SettingViewBase<SettingRangeOfValues, float>
    {
        [field: SerializeField] private Slider Slider { get; set; }
        [field: SerializeField] protected TMP_Text DisplayValue { get; set; }

        protected override void OnEnable()
        {
            Slider.onValueChanged.AddListener(UpdateSettingCurrentValue);

            base.OnEnable();
        }

        protected override void UpdateSettingCurrentValue(float newValue)
        {
            Setting.CurrentValue = (int)newValue;
            DisplayValueUpdate();
        }

        protected virtual void DisplayValueUpdate()
        {
            DisplayValue.text = Setting.CurrentValue.ToString();
        }

        // will not trigger OnSliderValueChanged thus it will not trigger setting change
        protected override void UpdateVisualState(int newValue)
        {
            Slider.SetValueWithoutNotify(newValue);
            DisplayValueUpdate();
        }

        protected override void OnDisable()
        {
            Slider.onValueChanged.RemoveListener(UpdateSettingCurrentValue);

            base.OnDisable();
        }
    }
}