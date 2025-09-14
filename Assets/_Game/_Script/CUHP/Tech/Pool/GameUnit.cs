using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour {

    public PoolType PoolType;
    private Transform tf;
    public Transform TF { 
        get
        {
            if (this == null || gameObject == null) return null;
            if (tf == null) tf = transform;
            return tf;
        }  
    }
}
