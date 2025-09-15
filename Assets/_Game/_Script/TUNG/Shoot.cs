using UnityEngine;

public class DragShoot : MonoBehaviour
{
    [SerializeField] private Boom bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float power = 10f;
    [SerializeField] private Rigidbody2D playerRb;  
    [SerializeField] private Transform playerTf;
    [SerializeField] private InputManager inputManager ;
    [SerializeField] private LinerShoot _linerShoot;
    
    private float max = 2.0f;
    
    private void Awake()
    {
        
    }

    private void Update()
    {

        if (inputManager.inputState == InputManager.InputState.EndClick)
        {
            Vector2 direction = inputManager._endPoint - inputManager._startPoint;
            if (direction.magnitude > 0.3f)
            {
                Boom boom = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
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