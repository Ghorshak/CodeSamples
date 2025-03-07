using System.Collections.Generic;
using UnityEngine;

namespace SettingsSystem.Settings
{
    public abstract class SettingNamedValues : Setting
    {
        [field: SerializeField, Space] public List<string> NamedValues { get; private set; } = new();
        
        public override int MinValue { get; } = 0;
        public override int MaxValue => NamedValues.Count - 1;
    }
}
