using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float height = 10f;
    [SerializeField] private float upped = 999f;
    [SerializeField] private float speed = 1;
    private int dir = -1;
    private Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        upped = 0;
        endPoint = transform.position + new Vector3(0, height, 0);
        speed *= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (upped < height && upped > 0)
        {
            transform.Translate(new Vector3(0, speed*dir, 0));
            upped+=speed*dir;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,endPoint);
    }
    public void Trigger()
    {
        dir = -dir;
        if (upped <= 0f) upped = 0.01f;
        else if (upped >= height) upped = height - 0.01f;
    }
}
