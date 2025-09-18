using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IBombInteractable, IPlayerInteractable
{
    public void OnPlayerInteract()
    {
        Interact();
    }

    public void OnBombInteract()
    {
        Interact();
    }

    void Interact()
    {
        LevelManager.Instance.AddCoin();
        AudioManager.Instance.PlaySFX(SoundType.CoinPickup);
        RhythmManager.Instance.AddSound(SoundType.CoinPickup);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
