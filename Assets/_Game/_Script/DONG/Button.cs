using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour,IInteractable
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
    public void OnInteract()
    {
        elevator.Trigger();
    }
}
