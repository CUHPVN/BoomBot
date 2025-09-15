using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimplePool
{
    private static Dictionary<PoolType, Pool> poolInstance = new();
    public static void PreLoad(GameUnit unit, int amount, Transform parent)
    {
        if(unit == null)
        {
            Debug.LogError("Unit = Null");
            return;
        }
        if(!poolInstance.ContainsKey(unit.PoolType)||poolInstance[unit.PoolType] == null)
        {
            Pool pool = new();
            pool.PreLoad(unit, amount, parent);
            poolInstance[unit.PoolType]=pool;
        }
    }
    public static T Spawn<T>(PoolType poolType,Vector3 pos,Quaternion rot) where T : GameUnit
    {
        if(!poolInstance.ContainsKey(poolType)) {
            Debug.LogError($"No Contain {poolType}");
            return null;
        }
        return poolInstance[poolType].Spawn(pos, rot) as T;
    }
    public static void Despawn(GameUnit unit)
    {
        if(!poolInstance.ContainsKey(unit.PoolType))
        {
            Debug.LogError($"Is Not PreLoad: "+unit.PoolType);
            return;
        }
        poolInstance[unit.PoolType].Despawn(unit); 
    }
    public static void ClearPool()
    {
        poolInstance.Clear();
    }
    public static void Collect(PoolType poolType)
    {
        if (!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError($"Is Not PreLoad: " + poolType);
            return;
        }
        poolInstance[poolType].Collect();
    }
    public static void CollectAll()
    {
        foreach(var unit in poolInstance.Values)
        {
            unit.Collect();
        }
    }
    public static void Release(PoolType poolType)
    {
        if (!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError($"Is Not PreLoad: " + poolType);
            return;
        }
        poolInstance[poolType].Release();
    }
    public static void ReleaseAll()
    {
        foreach (var unit in poolInstance.Values)
        {
            unit.Release();
        }
    }
}
public class Pool
{
    Transform parent;
    GameUnit prefab;
    Queue<GameUnit> inactives = new Queue<GameUnit>();
    List<GameUnit> actives = new List<GameUnit>();
    public void PreLoad(GameUnit prefab,int amount, Transform parent)
    {
        this.parent = parent;
        this.prefab = prefab;
        List<GameUnit> preLoad= new List<GameUnit>();
        for(int i = 0; i < amount; i++)
        {
            preLoad.Add(Spawn(Vector3.zero, Quaternion.identity));
        }
        foreach(var unit in preLoad)
        {
            Despawn(unit);
        }
    }
    public GameUnit Spawn(Vector3 position, Quaternion rotation)
    {
        GameUnit unit;
        if (inactives.Count <= 0) unit = GameObject.Instantiate(prefab, parent);
        else unit = inactives.Dequeue();
        actives.Add(unit);
        unit.gameObject.SetActive(true);
        unit.TF.SetPositionAndRotation(position, rotation);
        return unit;
    }
    public void Despawn(GameUnit unit)
    {
        if(unit != null && unit.gameObject.activeSelf)
        {
            actives.Remove(unit);
            inactives.Enqueue(unit);
            unit.gameObject.SetActive(false);
        }
    }
    public void Collect()
    {
        while(actives.Count > 0)
        {
            Despawn(actives[0]);
        }
    }
    public void Release()
    {
        Collect();
        Debug.Log("Release");
        while(inactives.Count > 0)
        {
            GameObject.Destroy(inactives.Dequeue().gameObject);
        }
        inactives.Clear();
    }
}
