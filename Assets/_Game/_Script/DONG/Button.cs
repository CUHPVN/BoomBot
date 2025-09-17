using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour,IBombInteractable, IPlayerInteractable
{
    [SerializeField] private Elevator elevator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnBombInteract()
    {
        elevator.Trigger();
    }

    public void OnPlayerInteract()
    {
        
    }
}
