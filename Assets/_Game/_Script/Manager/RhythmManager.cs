using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundEvent
{
    public float time;
    public SoundType clip;
    public SoundEvent(float time, SoundType clip)
    {
        this.time = time;
        this.clip = clip;
    }
}

public class RhythmManager : Singleton<RhythmManager>
{
    public List<SoundEvent> soundEvents = new List<SoundEvent>();
    public float deltaTime = 0;
    public void StartPlayQueue()
    {
        StartCoroutine(ReplayCoroutine());
    }
    private void Update()
    {
        if(soundEvents.Count > 0)
        {
            deltaTime += Time.deltaTime;
        }   
    }
    public void Clear()
    {
        soundEvents.Clear();
    }
    public void AddSound(SoundType soundType)
    {
        soundEvents.Add(new SoundEvent(deltaTime, soundType));
        deltaTime = 0;
    }
    private IEnumerator ReplayCoroutine()
    {
        if (soundEvents.Count == 0) yield break;

        float startTime = Time.time;
        List<SoundEvent> se=new (soundEvents);
        soundEvents.Clear();
        foreach (var e in se)
        {
            yield return new WaitForSeconds(Mathf.Min(e.time, 2.5f));
            AudioManager.Instance.PlaySFX(e.clip);
        }
    }
}