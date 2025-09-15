using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    Dictionary<System.Type, UICanvas> canvasActive = new();
    Dictionary<System.Type, UICanvas> canvasPrefabs = new();

    [SerializeField] Transform parent;
    private void Awake()
    {
        UICanvas[] prefabs = Resources.LoadAll<UICanvas>("UI/");
        for(int i=0; i<prefabs.Length; i++)
        {
            canvasPrefabs.Add(prefabs[i].GetType(), prefabs[i]);
        }
    }
    public T OpenUI<T>() where T : UICanvas
    {
        T canvas = GetUI<T>();
        canvas.SetUp();
        canvas.Open();
        return canvas;
    }
    public void CloseUI<T>(float time) where T : UICanvas
    {
        if (IsUIOpen<T>())
        {
            canvasActive[typeof(T)].Close(time);
        }
    }
    public void CloseUIDirectly<T>() where T : UICanvas
    {
        if (IsUIOpen<T>())
        {
            canvasActive[typeof(T)].CloseDirectly();
        }
    }
    public bool IsUILoad<T>() where T : UICanvas
    {
        return canvasActive.ContainsKey(typeof(T)) && canvasActive[typeof(T)]!=null;
    }
    public bool IsUIOpen<T>() where T : UICanvas
    {
        return IsUILoad<T>() && canvasActive[typeof(T)].gameObject.activeSelf;
    }
    public T GetUI<T>() where T : UICanvas
    {
        if (!IsUILoad<T>())
        {
            T prefab = GetUIPrefab<T>();
            T canvas = Instantiate(prefab,parent);
            canvasActive[typeof(T)] = canvas;
        }
        return canvasActive[typeof (T)] as T;
    }
    private T GetUIPrefab<T>() where T : UICanvas
    {
        return canvasPrefabs[typeof (T)] as T;
    }
    public void CloseAll()
    {
        foreach(var t in canvasActive)
        {
            if(t.Value !=null && t.Value.gameObject.activeSelf){
                t.Value.Close(0);
            }
        }
    }
}
