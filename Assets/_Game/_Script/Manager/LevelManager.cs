using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private int coin = 0;
    public void Start()
    {
        LoadLevel();
    }
    public void LoadLevel()
    {
        CameraMovement.Instance.SetPlayer(FindAnyObjectByType<PlayerController>().gameObject);
    }
    public void AddCoin()
    {
        coin++;
        Debug.Log("Coin : " + coin);
    }

}
