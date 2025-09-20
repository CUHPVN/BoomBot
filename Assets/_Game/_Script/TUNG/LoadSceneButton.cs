using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour, IInteractByButton
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonCall()
    {
        StartButton();
    }
    public void StartButton()
    {
        AudioManager.Instance.PlaySFX(SoundType.ButtonClick);
        Trans.Instance.TransIn();
        Invoke(nameof(LoadScene), 1f);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Start");
    }
}
