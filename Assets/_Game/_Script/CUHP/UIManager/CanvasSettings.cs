using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSettings : UICanvas
{
    public void Exit()
    {
        Close(0);
        Time.timeScale = 1.0f;
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    
}
