using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] private GameObject iceBreakVFXPrefab;

    public void Break()
    {
        // Spawn hiệu ứng vỡ
        if (iceBreakVFXPrefab != null)
        {
            GameObject vfx = Instantiate(iceBreakVFXPrefab, transform.position, Quaternion.identity);

            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(vfx, ps.main.duration + ps.main.startLifetime.constantMax);
            }
        }
    }
}
