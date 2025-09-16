using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hingeJoint2D;

    public Transform ropeAnchor; // đầu trên của dây
    private Rigidbody2D rb2;
    public float ropeLength = 3f; // chiều dài dây (có thể tùy chỉnh)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hingeJoint2D = GetComponent<HingeJoint2D>();
        hingeJoint2D.enabled = false;
    }

    void Update()
    {
       // if (hingeJoint2D != null) hingeJoint2D.connectedBody = rb2;
    }

    public void AttachToRope()
    {
        if (hingeJoint2D != null)
        {
            hingeJoint2D.enabled = true;
            hingeJoint2D.connectedBody = ropeAnchor.GetComponent<Rigidbody2D>();
            hingeJoint2D.autoConfigureConnectedAnchor = false; // để anchor tự khớp với Rigidbody2D kia

            hingeJoint2D.connectedAnchor = Vector2.zero; // điểm neo trên world
            hingeJoint2D.anchor = Vector2.zero; // điểm bám trên Player (cánh tay)
            hingeJoint2D.enableCollision = false; // không va chạm với anchor
           // rb.gravityScale = 1f; // Player vẫn chịu trọng lực
        }
    }

    public void DetachFromRope()
    {
        if (hingeJoint2D != null)
        {
            hingeJoint2D.enabled = false;
        }
    }

    
}
