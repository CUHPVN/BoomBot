using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSettings : UICanvas
{
    public void OpenMainMenu()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    public void OpenGamePlay()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }
}
