using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform pivot;
    [SerializeField] private float angleSpined = 200f;
    [SerializeField] private float maxAngle = 200f;
    [SerializeField] private float spinSpeed = 50f;
    public RopeSwing rsw;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (angleSpined < maxAngle)
        {
            pivot.transform.Rotate(new Vector3(0f, 0f, spinSpeed * Time.deltaTime));
            //if (angleSpined >= maxAngle) { rsw.DetachFromRope(); }
            angleSpined += 1f;
        }
    }

    void Spin()
    {
        angleSpined = 0f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Spin();
            rsw = collision.GetComponent<PlayerController>().leftHand;
            rsw.ropeAnchor = transform;
            rsw.AttachToRope();
        }
    }
}
