using UnityEngine;

public class ShootPro : MonoBehaviour
{
    [SerializeField] private BoomPro bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float power = 10f;
    [SerializeField] private Rigidbody2D playerRb;  
    [SerializeField] private Transform playerTf;
    private PlayerController _playerControler;
    private InputManager _inputManager ;
    [SerializeField] private LinerShoot _linerShoot;
    
    private float max = 2.0f;

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
                BoomPro boom = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                // Bắn boom đi
                boom.SetPlayerRB(playerRb);
                boom.SetPlayerTF(playerTf);
                Rigidbody2D boomRb = boom.GetBoomRb();
                if (direction.magnitude > max)
                    direction = direction.normalized * max;
                boomRb.AddForce(direction * power, ForceMode2D.Impulse);
            }
        }

        // if (inputManager.inputState == InputManager.InputState.OnClick)
        // {
        //     _linerShoot.RotateToDirection(inputManager._currentPoint - inputManager._startPoint);
        // }
    }
}