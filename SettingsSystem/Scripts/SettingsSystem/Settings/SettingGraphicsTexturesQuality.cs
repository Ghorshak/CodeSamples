using UnityEngine;

namespace SettingsSystem.Settings
{
    [CreateAssetMenu(menuName = "Settings/Graphics/Texture Quality", fileName = "SETTING_Graphics_TextureQuality", order = 10)]
    public class SettingGraphicsTextureQuality : SettingNamedValues
    {
        public override SettingKey Key => SettingKey.GRAPHICS_TEXTURE_QUALITY;

        public override void ExecuteChange()
        {
            // here you need to put an instruction to execute your changes
            Debug.Log($"Executing changes for setting {Key}");
        }
    }
}
