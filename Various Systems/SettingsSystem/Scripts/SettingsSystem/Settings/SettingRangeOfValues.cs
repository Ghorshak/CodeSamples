using UnityEngine;

namespace SettingsSystem.Settings
{
	public abstract class SettingRangeOfValues : Setting
	{
		[field: SerializeField, Space] public int minValue = 0;
		[field: SerializeField] public int maxValue { get; set; } = 1;

		public override int MinValue => minValue;
		public override int MaxValue => maxValue;
	}
}