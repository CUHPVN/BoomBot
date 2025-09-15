using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private TMP_Text fps;
    private float fpsIndex;
    public void AddPoint()
    {
        fpsIndex = 1f/Time.deltaTime;
        fps.text = ((int)fpsIndex).ToString();     
    }
    private void Update()
    {
        AddPoint();
    }
    public void SettingsButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasSettings>();
    }
    public void ReloadSceneButton()
    {
        SceneManager.LoadScene("Game");
    }
}
