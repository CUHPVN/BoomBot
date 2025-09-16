using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float height = 10f;
    [SerializeField] private float upped = 9999f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (upped < height)
        {
            transform.Translate(new Vector3(0, 1, 0));
            upped++;
        }
    }
    public void Trigger()
    {
        upped = 0f;
    }
}
