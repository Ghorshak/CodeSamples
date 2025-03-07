using UnityEngine;

namespace SettingsSystem.Settings
{
    [CreateAssetMenu(menuName = "Settings/Audio/Sfx Volume", fileName = "SETTING_Audio_SfxVolume", order = 3)]
    public class SettingAudioSfxVolume : SettingRangeOfValues
    {
        public override SettingKey Key => SettingKey.AUDIO_SFX_VOLUME;

        public override void ExecuteChange()
        {
            // here you need to put an instruction to execute your changes like:
            // FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SfxVolume", CurrentValue / MaxValue);

            Debug.Log($"Executing changes for setting {Key}");
        }
    }
}
