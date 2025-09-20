using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : Singleton<CameraMovement>
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [SerializeField] CinemachineTargetGroup _targetGroup;
    CinemachineFramingTransposer framingTransposer;
    CinemachineConfiner2D confiner2D;
    private const float playerSpeed = 45f;
    private const float vfxSpeed = 60f;
    private Vector3 offset = new Vector3(0, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    Transform player;
    void Awake()
    {
        framingTransposer = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        confiner2D = _virtualCamera.GetComponent<CinemachineConfiner2D>();
    }
    public void SetPlayer(Transform player)
    {
        this.player = player;
        _virtualCamera.Follow = (player.transform);
        _targetGroup.AddMember(player.transform,1,1);
        Invoke(nameof(SetBound), 0.01f);
    }
    public void SetBound()
    {
        framingTransposer.m_ScreenX = 0.3f;
        framingTransposer.m_ScreenY = 0.6f;
        framingTransposer.m_SoftZoneWidth = 0.5f;
        framingTransposer.m_SoftZoneHeight = 0.3f;
        CameraBound bound = player.GetComponent<PlayerController>().cameraBound;
        if (bound == null) return;
        PolygonCollider2D polygonCollider2D = bound.m_PolygonCollider;
        if (polygonCollider2D == null) return;
        confiner2D.m_BoundingShape2D = polygonCollider2D;
    }
    public void Remove()
    {
        _targetGroup.RemoveMember(player);
        Debug.Log(player);
    }
    public void AddNewPos(Transform pos)
    {
        _targetGroup.AddMember(pos,1,2);
    }
    public void RemovePos(Transform pos)
    {
        _targetGroup.RemoveMember(pos);
    }
    public void StartReplay()
    {
        framingTransposer.m_ScreenX = 0.5f;
        framingTransposer.m_ScreenY = 0.5f;
        framingTransposer.m_SoftZoneWidth = 0.5f;
        framingTransposer.m_SoftZoneHeight = 0.5f;
        _virtualCamera.Follow=(_targetGroup.transform);
        Remove();
    }
    void Update()
    {
        //Move();
    }
    void Move()
    {
    }
}