using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundEvent
{
    public float time;
    public SoundType clip;
    public Vector3 pos;
    public SoundEvent(float time, SoundType clip, Vector3 pos)
    {
        this.time = time;
        this.clip = clip;
        this.pos = pos;
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
    public void AddSound(SoundType soundType,Vector3 pos)
    {
        soundEvents.Add(new SoundEvent(deltaTime, soundType,pos));
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
            yield return new WaitForSeconds(Mathf.Min(e.time, 0.5f));
            AudioManager.Instance.PlaySFX(e.clip);
            SimplePool.Spawn<VFXPrefab>(PoolType.VFX,e.pos,Quaternion.identity);
        }
    }
}