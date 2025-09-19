using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Singleton<CameraMovement>
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    private const float playerSpeed = 45f;
    private const float vfxSpeed = 60f;
    private Vector3 offset = new Vector3(0, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SetPlayer(Transform player)
    {
        this.player = player;
        _virtualCamera.Follow = (player.transform);
        CameraBound bound =player.GetComponent<PlayerController>().cameraBound;
        if (bound == null) return;
        PolygonCollider2D polygonCollider2D = bound.m_PolygonCollider;
        if (polygonCollider2D == null) return;
        _virtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = polygonCollider2D;
    }
    public void SetVFX(Transform vfx)
    {
        this.player = vfx;
        //_virtualCamera.Follow = (player.transform);
    }
    void Update()
    {
        //Move();
    }
    void Move()
    {
    }
}