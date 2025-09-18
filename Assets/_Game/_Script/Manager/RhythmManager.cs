using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : Singleton<RhythmManager>
{
    public Queue<SoundType> soundQueue = new();
    public void StartPlayQueue()
    {
        StartCoroutine(PlayQueue());
    }
    private IEnumerator PlayQueue()
    {
        float count = soundQueue.Count;
        while(soundQueue.Count > 0)
        {
            SoundType sound= soundQueue.Dequeue();
            AudioManager.Instance.PlaySFX(sound);
            yield return new WaitForSeconds(Mathf.Lerp(0.3f,1,soundQueue.Count/count));
        }
        yield return null;
    }
}
