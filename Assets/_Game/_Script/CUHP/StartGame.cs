using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        Trans.Instance.TransOut();
        UIManager.Instance.OpenUI<CanvasStartGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
