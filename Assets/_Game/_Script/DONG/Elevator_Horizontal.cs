using UnityEngine;

public class Elevator_Horizontal : MonoBehaviour,IInteractByButton
{
    [SerializeField] private float height = 10f; //height dương nếu đi sang phải, âm nếu đi sang trái (lần Trigger đầu)
    [SerializeField] private float speed = 2f;   // tốc độ thật (unit/second)

    private float moved = 0f;   // đã đi được bao xa
    private int dir = 0;        // hướng (0 = đứng yên, 1 = lên, -1 = xuống)

    private Rigidbody2D rb;
    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPoint = transform.position;
        endPoint = transform.position + new Vector3(height, 0, 0);
        moved = (height > 0) ? 0 : -height;
        height = Mathf.Abs(height);
    }

    void Update()
    {
        // Nếu đang di chuyển
        if (dir != 0)
        {
            rb.velocity = new Vector2(dir * speed, 0);

            moved += Time.deltaTime * speed * dir;

            // Giới hạn trong [0, height]
            if (moved >= height)
            {
                moved = height;
                rb.velocity = Vector2.zero;
                dir = 0;
            }
            else if (moved <= 0)
            {
                moved = 0;
                rb.velocity = Vector2.zero;
                dir = 0;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Trigger()
    {
        if (moved <= 0f) dir = 1;        // đi lên
        else if (moved >= height) dir = -1; // đi xuống
    }
    private void OnDrawGizmos() {
        
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(height,0,0));
    }

    public void ButtonCall()
    {
        Trigger();
    }
}
