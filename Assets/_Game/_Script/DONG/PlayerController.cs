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
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public void Init()
    {
        inputManager = FindFirstObjectByType<InputManager>();
        cameraBound = FindFirstObjectByType<CameraBound>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.velocity.x > 0.01f) sr.flipX = false;
        if (rb.velocity.x < -0.01f) sr.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Interact"))
        {
            col.GetComponent<IPlayerInteractable>().OnPlayerInteract();
        }
    }
}
