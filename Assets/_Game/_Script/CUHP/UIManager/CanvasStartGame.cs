using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasStartGame : UICanvas
{
    public void SettingsButton()
    {
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void StartButton()
    {
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        Trans.Instance.TransIn();
        Invoke(nameof(LoadScene),1f);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
