using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
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
    private Collider2D cl;
    public Vector3 forceVec;
    [SerializeField] private float force=5f;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<CircleCollider2D>();
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
            angleSpined += 1f;
            if (angleSpined >= maxAngle) { rsw.DetachFromRope(); cl.enabled = false; exitRope(); }

        }
    }

    void Spin()
    {
        angleSpined = 0f;
    }

    void exitRope()
    {
        forceVec = (Vector3)transform.position - (Vector3)pivot.position;
        float t = forceVec.x;
        forceVec.x = -forceVec.y;
        forceVec.y = t;
        player.AddForce(forceVec * force);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spin();
            rsw = collision.GetComponent<PlayerController>().leftHand;
            player = collision.GetComponent<Rigidbody2D>();
            rsw.ropeAnchor = transform;
            rsw.AttachToRope();
        }
    }
}
