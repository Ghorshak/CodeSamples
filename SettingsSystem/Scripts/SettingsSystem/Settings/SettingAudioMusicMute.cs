using UnityEngine;

namespace SettingsSystem.Settings
{
    [CreateAssetMenu(menuName = "Settings/Audio/Music Mute", fileName = "SETTING_Audio_MusicMute", order = 0)]
    public class SettingAudioMusicMute : SettingRangeOfValues
    {
        public override SettingKey Key => SettingKey.AUDIO_MUSIC_MUTE;

        public override void ExecuteChange()
        {
            // here you need to put an instruction to execute your changes like:
            // FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicMute", CurrentValue);

            Debug.Log($"Executing changes for setting {Key}");
        }
    }
}
