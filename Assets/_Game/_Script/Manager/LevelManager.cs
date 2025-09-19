using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int level = 0;
    [SerializeField] private List<Transform> levelPrefabs = new();
    [SerializeField] private Transform currentLevel;
    [SerializeField] private GameObject parent;

    private int coin = 0;
    public void Awake()
    {
        LoadLevel();
    }
    public void LoadLevel()
    {
        SpawnLevel();
        PlayerController playerController = FindAnyObjectByType<PlayerController>();
        if (playerController != null)
            playerController.Init();
        CameraMovement.Instance.SetPlayer(playerController.transform);


    }
    public void NextLevel()
    {
        Destroy(currentLevel.gameObject);
        level++;
        if (level >= levelPrefabs.Count) return;
        LoadLevel();
    }
    public void ReloadLevel()
    {
        Destroy(currentLevel.gameObject);
        LoadLevel();
    }
    private void SpawnLevel()
    {
        currentLevel = Instantiate<Transform>(levelPrefabs[level],parent.transform);
    }
    public void AddCoin()
    {
        coin++;
        Debug.Log("Coin : " + coin);
    }

}
