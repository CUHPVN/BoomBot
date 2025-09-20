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
            //TODO:
            collision.gameObject.SetActive(false);
            thisPlayer = collision.gameObject;
            AudioManager.Instance.PlaySFX(SoundType.Win);
            float time = RhythmManager.Instance.CheckTime();
            RhythmManager.Instance.StartPlayQueue();
            Invoke(nameof(OpenPanel), Mathf.Min(time , 5f));
        }
    }

    public void OpenPanel()
    {
        Time.timeScale = 0;
        UIManager.Instance.OpenUI<CanvasNextLevel>();
    }
    public void Respawn()
    {
        thisPlayer.SetActive(true);
        thisPlayer.transform.position = startPoint;
    }
}
