using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bomb bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float power = 10f;
    [SerializeField] private Rigidbody2D playerRb;  
    [SerializeField] private Transform playerTf;
    private PlayerController _playerControler;
    private InputManager _inputManager ;
    [SerializeField] private LinerShoot _linerShoot;

    [SerializeField] private float maxLine = 3f;

    private void Awake()
    {
        _playerControler = GetComponent<PlayerController>();
    }
    private void Start()
    {
        _inputManager = _playerControler.inputManager;
    }

    private void Update()
    {
        
        if (_inputManager.inputState == InputManager.InputState.EndClick)
            {
                Vector2 direction = _inputManager._endPoint - _inputManager._startPoint;
            if (direction.magnitude > 0.3f)
            {
               
                    Bomb boom = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                    // Bắn boom đi
                    boom.SetPlayerRB(playerRb);
                    boom.SetPlayerTF(playerTf);
                    Rigidbody2D boomRb = boom.GetBoomRb();
                    if (direction.magnitude > maxLine)
                        direction = direction.normalized * maxLine;
                    boomRb.AddForce(direction / maxLine * power, ForceMode2D.Impulse);
                }
                
            }

        // if (inputManager.inputState == InputManager.InputState.OnClick)
        // {
        //     _linerShoot.RotateToDirection(inputManager._currentPoint - inputManager._startPoint);
        // }
    }
}