using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    public void PlayButton()
    {
        Close(0);
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }
    public void SettingsButton()
    {
        Close(0);
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
}
