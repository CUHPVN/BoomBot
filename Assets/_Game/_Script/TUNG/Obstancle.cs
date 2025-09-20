using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstancle : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SimplePool.Spawn<VFXPrefab1>(PoolType.VFX2, collision.transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            AudioManager.Instance.PlaySFX(SoundType.Death);

            LevelManager.Instance.ReloadLevel();
        }

    }
}
