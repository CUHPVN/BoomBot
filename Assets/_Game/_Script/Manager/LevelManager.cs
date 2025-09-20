using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int level = 0;
    [SerializeField] private LevelConfig config;
    [SerializeField] private Transform currentLevel;
    [SerializeField] private GameObject parent;
    [SerializeField] private int BombUse = 0;
    private bool onReload = false;

    private int coin = 0;
    public void Awake()
    {
        config = Resources.Load<LevelConfig>("SO/LevelConfig");
        LoadLevel();
    }
    public void Start()
    {
        UIManager.Instance.OpenUI<CanvasGamePlay>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(Time.timeScale==1)
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
        RhythmManager.Instance.StopCRT();
        StartCoroutine(Next());
    }
    public void ReloadLevel()
    {
        if (onReload) return;
        onReload = true;
        RhythmManager.Instance.StopCRT();
        StartCoroutine(Reload());
    }
    private IEnumerator Next() 
    {
        //CameraMovement.Instance.Remove();
        Trans.Instance.TransIn();
        yield return new WaitForSeconds(0.75f);//anim
        Destroy(currentLevel.gameObject);
        level++;
        if (level >=  config.levelPrefabs.Count) yield break;
        yield return new WaitForSeconds(0.5f);
        LoadLevel();
    }
    public IEnumerator Reload()
    {
        //CameraMovement.Instance.Remove();
        Trans.Instance.TransIn();
        yield return new WaitForSeconds(0.75f);//trans
        Destroy(currentLevel.gameObject);
        yield return new WaitForSeconds(0.5f);
        LoadLevel();
    }
    private void SpawnLevel()
    {
        BombUse = 0;
        currentLevel = Instantiate(config.levelPrefabs[level],parent.transform);
        Trans.Instance.TransOut();
        Invoke(nameof(TurnOff), 0.5f);
    }
    public void TurnOff()
    {
        onReload = false;
    }
    public void AddBomb()
    {
        BombUse++;
    }
    public int GetBomb()
    {
        return BombUse;
    }
    public void AddCoin()
    {
        coin++;
    }

}
