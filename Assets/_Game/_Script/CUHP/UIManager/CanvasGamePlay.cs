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
        Close(0);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void ReloadButton()
    {
        LevelManager.Instance.ReloadLevel();
    }
}
