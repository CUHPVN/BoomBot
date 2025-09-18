using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private int coin = 0;
    void Start()
    {
        
    }
    public void LoadLevel()
    {
        RhythmManager.Instance.Clear();
    }
    public void AddCoin()
    {
        coin++;
        Debug.Log("Coin : " + coin);
    }

}
