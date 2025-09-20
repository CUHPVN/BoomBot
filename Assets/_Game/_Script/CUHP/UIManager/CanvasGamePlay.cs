using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGamePlay : UICanvas
{
    private void Update()
    {
    }
    public void SettingsButton()
    {
        Time.timeScale = 0;
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void ReloadButton()
    {
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        LevelManager.Instance.ReloadLevel();
    }
}
