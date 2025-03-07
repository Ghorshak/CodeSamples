using UnityEngine;

namespace SettingsSystem.Settings
{
    [CreateAssetMenu(menuName = "Settings/Audio/Sfx Mute", fileName = "SETTING_Audio_SfxMute", order = 2)]
    public class SettingAudioSfxMute : SettingRangeOfValues
    {
        public override SettingKey Key => SettingKey.AUDIO_SFX_MUTE;

        public override void ExecuteChange()
        {
            // here you need to put an instruction to execute your changes like:
            // FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SfxMute", CurrentValue);

            Debug.Log($"Executing changes for setting {Key}");
        }
    }
}
