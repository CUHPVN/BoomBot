using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance != this)
        {
            Debug.LogWarning($"[Singleton] Duplicate {typeof(T)} destroyed on {gameObject.name}");
            Destroy(gameObject); 
        }
    }
}
