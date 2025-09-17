using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPrefab : GameUnit
{
    [SerializeField] private GameObject[] texts;
    private void OnEnable()
    {
        ChooseOne();
        Invoke(nameof(Despawn), 2f);
    }
    private void ChooseOne()
    {
        for(int i=0; i<texts.Length; i++)
        {
            texts[i].SetActive(false);
        }
        int ran = Random.Range(0, texts.Length);
        texts[ran].SetActive(true);
    }
    private void Despawn()
    {
        SimplePool.Despawn(this);
    }
}
