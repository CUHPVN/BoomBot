using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPrefab : GameUnit
{
    private void OnEnable()
    {
        Invoke(nameof(Despawn), 2f);
    }
    private void Despawn()
    {
        SimplePool.Despawn(this);
    }
}
