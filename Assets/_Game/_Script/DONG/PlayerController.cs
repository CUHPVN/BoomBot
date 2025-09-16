using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
