using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private PlayerController _playerControler;
    private InputManager _inputManager;
    [SerializeField] private float MaxForce = 3.0f;
    private void Awake()
    {
        _playerControler = GetComponent<PlayerController>();
    }
    void Start()
    {
        _lineRenderer.gameObject.SetActive(false);
        _inputManager = _playerControler.inputManager;
    }

    // Update is called once per frame
    void Update()
    {
        Create();
    }

    void Create()
    {
        if (_inputManager.inputState == InputManager.InputState.OnClick)
        {
                Vector2 currentPoint = _inputManager.GetWorldPoint(_inputManager._currentScreenPoint);
                Vector2 startPoint = _inputManager.GetWorldPoint(_inputManager._startScreenPoint);
            if (Vector2.Distance(currentPoint,startPoint) > 0.1f)
            {
                if(!_lineRenderer.gameObject.activeSelf) _lineRenderer.gameObject.SetActive(true);
                if (Vector2.Distance(currentPoint,startPoint) > MaxForce)
                {
                    currentPoint = (currentPoint- startPoint).normalized * MaxForce + startPoint;
                }
                _lineRenderer.SetPosition(0, startPoint);
                _lineRenderer.SetPosition(1, currentPoint);
            }
        }

        if (_inputManager.inputState == InputManager.InputState.EndClick)
        {
            _lineRenderer.gameObject.SetActive(false);
        }
    }
}
