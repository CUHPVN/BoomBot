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
        StartCoroutine(Next());
    }
    public void ReloadLevel()
    {
        StartCoroutine(Reload());
    }
    private IEnumerator Next() 
    {
        CameraMovement.Instance.Remove();
        yield return new WaitForSeconds(1);//anim
        Destroy(currentLevel.gameObject);
        level++;
        if (level >= levelPrefabs.Count) yield break;
        yield return new WaitForSeconds(1);
        LoadLevel();
    }
    public IEnumerator Reload()
    {
        CameraMovement.Instance.Remove();
        yield return new WaitForSeconds(1);//trans
        Destroy(currentLevel.gameObject);
        yield return new WaitForSeconds(1);
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
