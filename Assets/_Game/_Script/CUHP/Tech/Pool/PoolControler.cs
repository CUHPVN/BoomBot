using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControler : Singleton<PoolControler>
{
    [SerializeField] PoolAmount[] poolAmounts;
    private void Awake()
    {
        SimplePool.ClearPool();
        for(int i = 0; i < poolAmounts.Length; i++)
        {
            SimplePool.PreLoad(poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].parent);
        }
    }
}
[System.Serializable]
public class PoolAmount
{
    public GameUnit prefab;
    public Transform parent;
    public int amount;
}
public enum PoolType
{
    None=0,
    VFX=1,
    Bomb=2,
    SFX=3,
}
