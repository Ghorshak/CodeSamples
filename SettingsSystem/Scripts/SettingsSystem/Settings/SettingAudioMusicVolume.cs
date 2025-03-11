using UnityEngine;

namespace SettingsSystem.Settings
{
    [CreateAssetMenu(menuName = "Settings/Audio/Music Volume", fileName = "SETTING_Audio_MusicVolume", order = 1)]
    public class SettingAudioMusicVolume : SettingRangeOfValues
    {
        public override SettingKey Key => SettingKey.AUDIO_MUSIC_VOLUME;

        public override void ExecuteChange()
        {
            // here you need to put an instruction to execute your changes like:
            // FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicVolume", CurrentValue / MaxValue);

            Debug.Log($"Executing changes for setting {Key}");
        }
    }
}
