using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSettings : UICanvas
{
    [SerializeField] private Slider bmgVolume;
    [SerializeField] private Slider sfxVolume;
    public void Exit()
    {
        Close(0);
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        Time.timeScale = 1.0f;
    }
    public (float bmg, float sfx) GetVolume()
    {
        return (bmgVolume.value, sfxVolume.value);
    }
    public void FullScreen()
    {
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        Screen.fullScreen = !Screen.fullScreen;
    }
    
}
