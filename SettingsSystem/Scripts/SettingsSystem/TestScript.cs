using SettingsSystem.Settings;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void TestSettingReference()
    {
        Debug.Log($"AUDIO_MUSIC_VOLUME.DisplayName = {SettingsController.Settings[SettingsSystem.SettingKey.AUDIO_MUSIC_VOLUME].DisplayName}");
        Debug.Log($"AUDIO_MUSIC_VOLUME.CurrentValue = {SettingsController.Settings[SettingsSystem.SettingKey.AUDIO_MUSIC_VOLUME].CurrentValue}");
        Debug.Log($"AUDIO_MUSIC_VOLUME.Key = {SettingsController.Settings[SettingsSystem.SettingKey.AUDIO_MUSIC_VOLUME].Key}");

        Debug.Log($"AUDIO_SFX_MUTE.DisplayName = {SettingsController.Settings[SettingsSystem.SettingKey.AUDIO_SFX_MUTE].DisplayName}");
        Debug.Log($"AUDIO_SFX_MUTE.CurrentValue = {SettingsController.Settings[SettingsSystem.SettingKey.AUDIO_SFX_MUTE].CurrentValue}");
        Debug.Log($"AUDIO_SFX_MUTE.Key = {SettingsController.Settings[SettingsSystem.SettingKey.AUDIO_SFX_MUTE].Key}");
    }
}
