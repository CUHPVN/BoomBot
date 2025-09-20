using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public CameraBound cameraBound;
    public InputManager inputManager;
    public RopeSwing ropeSwing;
    public void Init()
    {
        inputManager = FindFirstObjectByType<InputManager>();
        cameraBound = FindFirstObjectByType<CameraBound>();
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
