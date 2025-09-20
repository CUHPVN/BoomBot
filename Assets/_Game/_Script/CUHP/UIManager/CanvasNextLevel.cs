using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasNextLevel : UICanvas
{
    [SerializeField] private TMP_Text text;
    private void OnEnable()
    {
        text.text = "Bomb Use: " + LevelManager.Instance.GetBomb().ToString();   
    }
    public void Next()
    {
        Time.timeScale = 1;
        Close(0);
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        LevelManager.Instance.NextLevel();
    }

}
