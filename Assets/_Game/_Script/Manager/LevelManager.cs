using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public Transform level;
    public int bombCount;
}
public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int level = 0;
    [SerializeField] private List<Level> levelPrefabs = new();
    [SerializeField] private Transform currentLevel;
    [SerializeField] private GameObject parent;
    [SerializeField] private Trans trans;
    private bool onReload = false;

    private int coin = 0;
    public void Awake()
    {
        LoadLevel();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
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
        if (onReload) return;
        onReload = true;
        StartCoroutine(Next());
    }
    public void ReloadLevel()
    {
        if (onReload) return;
        onReload = true;
        StartCoroutine(Reload());
    }
    private IEnumerator Next() 
    {
        //CameraMovement.Instance.Remove();
        trans.TransIn();
        yield return new WaitForSeconds(0.75f);//anim
        Destroy(currentLevel.gameObject);
        level++;
        if (level >= levelPrefabs.Count) yield break;
        yield return new WaitForSeconds(0.5f);
        LoadLevel();
    }
    public IEnumerator Reload()
    {
        //CameraMovement.Instance.Remove();
        trans.TransIn();
        yield return new WaitForSeconds(0.75f);//trans
        Destroy(currentLevel.gameObject);
        yield return new WaitForSeconds(0.5f);
        LoadLevel();
    }
    private void SpawnLevel()
    {
        currentLevel = Instantiate<Transform>(levelPrefabs[level].level,parent.transform);
        trans.gameObject.SetActive(true);
        trans.TransOut();
        Invoke(nameof(TurnOff), 0.5f);
    }
    public void TurnOff()
    {
        onReload = false;
    }
    public void AddCoin()
    {
        coin++;
        Debug.Log("Coin : " + coin);
    }

}
