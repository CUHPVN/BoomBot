using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
public class SoundEvent
{
    public float time;
    public SoundType clip;
    public Vector3 pos;
    public Transform tran;
    public SoundEvent(float time, SoundType clip, Vector3 pos,Transform tran)
    {
        this.time = time;
        this.clip = clip;
        this.pos = pos;
        this.tran = tran;
    }
}

public class RhythmManager : Singleton<RhythmManager>
{
    public List<SoundEvent> soundEvents = new List<SoundEvent>();
    public float deltaTime = 0;
    [SerializeField] private Transform invisible;
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
        Transform newTF= CreateNewTF(pos);
        soundEvents.Add(new SoundEvent(deltaTime, soundType,pos,newTF));
        CameraMovement.Instance.AddNewPos(newTF);
        newTF.SetParent(transform);
        deltaTime = 0;
    }
    public Transform CreateNewTF(Vector3 pos)
    {
        Transform tf = Instantiate(invisible,pos,Quaternion.identity);
        return tf;
    }
    private IEnumerator ReplayCoroutine()
    {

        float startTime = Time.time;
        List<SoundEvent> se=new (soundEvents);
        soundEvents.Clear();
        CameraMovement.Instance.StartReplay();
        foreach (var e in se)
        {
            yield return new WaitForSeconds(Mathf.Min(e.time, 0.5f));
            AudioManager.Instance.PlaySFX(e.clip);
            VFXPrefab vFXPrefab= SimplePool.Spawn<VFXPrefab>(PoolType.VFX,e.pos,Quaternion.identity);
            CameraMovement.Instance.RemovePos(e.tran);
            Destroy(e.tran.gameObject);
            //CameraMovement.Instance.SetVFX(vFXPrefab.transform);
        }
        LevelManager.Instance.NextLevel();
        if (soundEvents.Count == 0) yield break;
    }
}