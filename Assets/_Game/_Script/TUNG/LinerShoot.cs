using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerShoot : MonoBehaviour
{
    [SerializeField] Transform Linears;
    private PlayerController _playerControler;
    private InputManager _inputManager;

    private void Awake()
    {
        _playerControler = GetComponent<PlayerController>();
    }
    void Start()
    {
        Linears.gameObject.SetActive(false);
        _inputManager = _playerControler.inputManager;
    }
    void Update()
    {
        Create();
    }

    public void Create()
    {
        if (_inputManager.inputState == InputManager.InputState.OnClick)
        {
            if (_inputManager.GetDistance() > 0.1f)
            {
                if(!Linears.gameObject.activeSelf) Linears.gameObject.SetActive(true);  
                RotateToDirection(_inputManager._currentPoint - _inputManager._startPoint);
                
            }
        }
        if (_inputManager.inputState == InputManager.InputState.EndClick)
        {
            Linears.gameObject.SetActive(false);
        }
    }
    public void RotateToDirection(Vector2 dir)
    {
        if (dir == Vector2.zero) return; // tránh lỗi khi vector = (0,0)

        // Tính góc theo radian → độ
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Gán rotation quanh trục Z
        Linears.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

}
