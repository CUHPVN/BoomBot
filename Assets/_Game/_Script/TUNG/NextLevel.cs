using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject thisPlayer;
    [SerializeField] private Vector3 startPoint;

    private void Start()
    {
        startPoint = new Vector3(thisPlayer.transform.position.x, thisPlayer.transform.position.y, thisPlayer.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //TO DO
            collision.gameObject.SetActive(false);
            thisPlayer = collision.gameObject;
            RhythmManager.Instance.StartPlayQueue();
        }
    }

    public void Respawn()
    {
        thisPlayer.SetActive(true);
        thisPlayer.transform.position = startPoint;
    }
}
