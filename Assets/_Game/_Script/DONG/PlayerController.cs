using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;
    public RopeSwing ropeSwing;
    void Awake()
    {
        inputManager = FindFirstObjectByType<InputManager>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Interact"))
        {
            col.GetComponent<IPlayerInteractable>().OnPlayerInteract();
        }
    }
}
