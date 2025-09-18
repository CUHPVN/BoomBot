using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Singleton<CameraMovement>
{
    private const float playerSpeed = 45f;
    private const float vfxSpeed = 60f;
    public float speed = 45f;
    private Vector3 offset = new Vector3(0, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void SetPlayer(GameObject player)
    {
        speed = playerSpeed;
        this.player = player;
    }
    public void SetVFX(GameObject vfx)
    {
        speed = vfxSpeed;
        this.player = vfx;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if(player!=null)
        {
            Vector3 target = player.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, speed / 100);
        }
    }
}