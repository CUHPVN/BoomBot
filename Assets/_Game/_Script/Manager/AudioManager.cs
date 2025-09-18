using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField, Range(0, 1)] private float bgmVolume = 0.5f;
    [SerializeField, Range(0, 1)] private float sfxVolume = 0.5f;
    void Start()
    {

    }

    void Update()
    {
        //CheckMusic();
        //GetVolume();
        UpdateVolume();
    }
    private void FixedUpdate()
    {

    }
    private void CheckMusic()
    {
        if (!Application.isFocused) return;
        if (!BGM.isPlaying)
        {
            int ran = Random.Range(0, bgmClips.Length);
            PlayBGM(ran);
        }
    }
    //public void GetVolume()
    //{
    //    if (mainMenuUIManager != null)
    //    {
    //        if (!mainMenuUIManager.GetSetting())
    //        {
    //            if (!saved)
    //            {
    //                saved = true;
    //                SaveSystem.Save();
    //            }
    //            mainMenuUIManager.SetVomume(bgmVolume, sfxVolume);
    //        }
    //        else
    //        {
    //            (float bgm, float sfx) = mainMenuUIManager.GetVolume();
    //            saved = false;
    //            bgmVolume = bgm;
    //            sfxVolume = sfx;
    //        }
    //    }
    //    else
    //    {
    //        mainMenuUIManager = FindFirstObjectByType<MainMenuUIManager>();
    //    }
    //    if (uiManager != null)
    //    {
    //        if (!uiManager.GetSetting())
    //        {
    //            if (!saved)
    //            {
    //                saved = true;
    //                SaveSystem.Save();
    //            }
    //            uiManager.SetVomume(bgmVolume, sfxVolume);
    //        }
    //        else
    //        {
    //            (float bgm, float sfx) = uiManager.GetVolume();
    //            saved = false;
    //            bgmVolume = bgm;
    //            sfxVolume = sfx;
    //        }
    //    }
    //    else
    //    {
    //        uiManager = FindFirstObjectByType<UIManager>();
    //    }
    //}
    public void UpdateVolume()
    {
        if (BGM.volume != bgmVolume)
            BGM.volume = bgmVolume;
        if (SFX.volume != sfxVolume)
            SFX.volume = sfxVolume;
    }
    public void PlayBGM(int index)
    {
        if (index < 0 || index >= bgmClips.Length)
        {
            Debug.LogError("Invalid BGM index");
            return;
        }
        BGM.clip = bgmClips[index];
        BGM.Play();
    }
    public void PlaySFX(SoundType type)
    {

            SFX.pitch = Random.Range(0.75f, 1.25f);
            SFX.PlayOneShot(sfxClips[(int)type]);
        
    }
    
    public void Save(ref SoundSaveData data)
    {
        data.bgmVolume = bgmVolume;
        data.sfxVolume = sfxVolume;
    }
    public void Create(ref SoundSaveData data)
    {
        bgmVolume = 0.5f;
        sfxVolume = 0.5f;
        data.bgmVolume = 0.5f;
        data.sfxVolume = 0.5f;
    }
    public void Load(SoundSaveData data)
    {
        bgmVolume = data.bgmVolume;
        sfxVolume = data.sfxVolume;

    }
}

[System.Serializable]
public struct SoundSaveData
{
    public float bgmVolume;
    public float sfxVolume;
}
public enum SoundType
{
    Explosion = 0,
    CoinPickup = 1,
    ButtonClick = 2,
}
