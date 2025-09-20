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
            collision.gameObject.SetActive(false);
            LevelManager.Instance.ReloadLevel();
        }

    }
}
