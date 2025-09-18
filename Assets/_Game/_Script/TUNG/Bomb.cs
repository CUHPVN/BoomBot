using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Bomb : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] private float explosionForce = 20f;   // lực đẩy
    [SerializeField] private float explosionRadius = 5f;   // bán kính nổ
    [SerializeField] private LayerMask layerName;
    bool isExplo = false;
    //[SerializeField] private string wallTag = "Wall";
    //[SerializeField] private string slideFloor = "SlideFloor";
 
    
    private Rigidbody2D rb;         // RB của chính Boom
    private Rigidbody2D playerRb;   // RB của Player (tìm theo tag)
    private Transform playerTf;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Collider của Boom nên là Trigger để xài OnTriggerEnter2D
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
        
    }

    public void SetPlayerTF(Transform playerTf)
    {
        this.playerTf = playerTf;
    }
    public void SetPlayerRB(Rigidbody2D playerRb)
    {
       this.playerRb = playerRb;
    }
    
    public Rigidbody2D GetBoomRb() => rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Boom chạm tường -> nổ
        if (other.CompareTag("Wall") || other.CompareTag("Bomb") || (other.CompareTag("Interact")) || other.CompareTag("DontHaveRig") || other.CompareTag("HaveRig"))
        {
            CallExplode();
        }
    }
    public void CallExplode()
    {
        if (isExplo) return;
        Explode();
    }


    private void Explode()
    {
        isExplo = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerName);
        //Debug.Log("BOOOM!!!");
        //int targetLayer = LayerMask.NameToLayer(layerName);

        foreach (Collider2D col in colliders)
        {
            if(col.CompareTag("DontHaveRig"))
            {
                col.gameObject.SetActive(false);
                continue;
            }
            if (col.CompareTag("Bomb"))
            {
                Bomb b = col.GetComponent<Bomb>();
                if (b != null) b.CallExplode();
                continue;
            }
            if (col.CompareTag("Interact"))
            {
                col.GetComponent<IBombInteractable>().OnBombInteract();
                continue;
            }
            Rigidbody2D colRb = col.GetComponent<Rigidbody2D>();
            if (colRb != null)
            {
                Vector2 dir = (colRb.worldCenterOfMass - (Vector2)transform.position);
                float dist = dir.magnitude;

                // Chỉ đẩy nếu Player trong bán kính nổ
                if (dist <= explosionRadius)
                {
                    // Giảm lực theo khoảng cách (gần nổ mạnh hơn)
                    float atten = 1f - (dist / Mathf.Max(0.0001f, explosionRadius));
                    colRb.AddForce(dir.normalized * explosionForce * (atten * 0.7f + 0.3f), ForceMode2D.Impulse);
                }
            }
        }
        SimplePool.Spawn<VFXPrefab>(PoolType.VFX, transform.position, Quaternion.identity);
        // TODO: spawn hiệu ứng nổ (particle, sound) nếu muốn
        AudioManager.Instance.PlaySFX(SoundType.Explosion);
        RhythmManager.Instance.AddSound(SoundType.Explosion,transform.position);
        ScreenShake.Instance.StartShake();
        Destroy(gameObject);
    }

    // Vẽ radius để debug trong Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}