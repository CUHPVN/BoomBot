using UnityEngine;
public class Rope : MonoBehaviour
{
    public Transform pivot;
    [SerializeField][Range(-180,180)] private float startAngle = -30f;
    [SerializeField][Range(-180,180)] private float endAngle = 60f;
    [SerializeField] private float spinSpeed = 50f;
    [SerializeField] private float angleSpined = 999f;
    [SerializeField] private float spinAngle = 0f;
    [SerializeField] private int rounds = 1;
    public RopeSwing rsw;
    private Collider2D cl;
    public Vector3 forceVec;
    [SerializeField] private float force=5f;
    private Rigidbody2D player;
    private bool spinable = false;
    private float stringLen = 5f;
    private bool swinged = false;

    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(pivot.transform.position, GetPointByAngle(pivot.position, endAngle, stringLen));
    }
    void FixedUpdate()
    {
        if (spinable && !swinged)
        {
            float spin = spinSpeed * Time.deltaTime;
            pivot.transform.Rotate(new Vector3(0f, 0f, spin));
            if (angleSpined >= spinAngle)
            {
                rsw.DetachFromRope();
                cl.enabled = false;
                exitRope();
            }
            angleSpined += spin;
        }
    }
    void OnValidate()
    {
        pivot.transform.rotation = Quaternion.Euler(0, 0, startAngle+90f);
    }


    Vector3 GetPointByAngle(Vector3 pivot, float angleDeg, float radius)
    {
        // angleDeg: góc tính bằng độ
        float rad = angleDeg * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * radius;
        float y = Mathf.Sin(rad) * radius;

        return pivot + new Vector3(x, y, 0);
    }

    void Spin()
    {
        spinAngle = endAngle - startAngle + rounds * 360f;
        angleSpined = 0f;
    }
    void exitRope()
    {
        forceVec = (Vector3)transform.position - (Vector3)pivot.position;
        float t = forceVec.x;
        forceVec.x = -forceVec.y;
        forceVec.y = t;
        player.AddForce(forceVec * force);
        spinable = false;
        swinged = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!swinged && collision.CompareTag("Player"))
        {
            Spin();
            spinable = true;
            rsw = collision.GetComponent<PlayerController>().ropeSwing;
            player = collision.GetComponent<Rigidbody2D>();
            rsw.ropeAnchor = transform;
            rsw.AttachToRope();
        }
    }
}
