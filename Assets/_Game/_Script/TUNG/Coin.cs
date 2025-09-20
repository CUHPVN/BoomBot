using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IBombInteractable, IPlayerInteractable
{
    [Header("Floating Effect")]
    [SerializeField] private float floatAmplitude = 0.25f; // biên độ dao động (cao bao nhiêu)
    [SerializeField] private float floatFrequency = 2f;   // tốc độ dao động

    private Vector3 startPos;

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
        RhythmManager.Instance.AddSound(SoundType.CoinPickup, transform.position);
        gameObject.SetActive(false);
    }

    void Start()
    {
        startPos = transform.position; // lưu vị trí gốc
    }

    void Update()
    {
        // hiệu ứng trôi nổi
        float offsetY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0, offsetY, 0);
    }
}
