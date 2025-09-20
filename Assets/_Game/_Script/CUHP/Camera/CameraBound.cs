using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class CameraBound : MonoBehaviour
{
    public PolygonCollider2D m_PolygonCollider;
    void Start()
    {
        m_PolygonCollider = GetComponent<PolygonCollider2D>();
        m_PolygonCollider.isTrigger = true;
    }

    void Update()
    {
        
    }
}
