using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject thisPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //TO DO
            collision.gameObject.SetActive(false);
            thisPlayer = collision.gameObject;
            Invoke(nameof(Respawn), 0.01f);
        }
    }

    private void Respawn()
    {
        thisPlayer.SetActive(true);
        thisPlayer.transform.position = Vector3.zero;
    }
}
