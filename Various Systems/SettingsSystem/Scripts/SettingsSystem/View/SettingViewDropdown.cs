using SettingsSystem.Settings;
using SettingsSystem.View;
using TMPro;
using UnityEngine;

public class SettingViewDropdown : SettingViewBase<SettingNamedValues, int>
{
    [field: SerializeField] private TMP_Dropdown Dropdown { get; set; }

    protected override void Awake()
    {
        base.Awake();

        Dropdown.ClearOptions();
        Dropdown.AddOptions(Setting.NamedValues);
    }

    protected override void OnEnable()
    {
        Dropdown.onValueChanged.AddListener(UpdateSettingCurrentValue);

        base.OnEnable();
    }

    protected override void UpdateSettingCurrentValue(int newValue)
    {
        Setting.CurrentValue = newValue;
    }

    protected override void UpdateVisualState(int newValue)
    {
        Dropdown.SetValueWithoutNotify(newValue);
    }

    protected override void OnDisable()
        {
            Dropdown.onValueChanged.RemoveListener(UpdateSettingCurrentValue);

            base.OnDisable();
        }
}
