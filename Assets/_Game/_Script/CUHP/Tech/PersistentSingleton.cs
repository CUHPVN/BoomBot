using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
