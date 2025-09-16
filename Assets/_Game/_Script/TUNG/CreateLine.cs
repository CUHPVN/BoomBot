using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private PlayerController _playerControler;
    private InputManager _inputManager;
    [SerializeField] private float MaxForce = 2.0f;
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
            if (_inputManager.GetDistance() > 0.1f)
            {
                if(!_lineRenderer.gameObject.activeSelf) _lineRenderer.gameObject.SetActive(true);
                Vector2 currentPoint = _inputManager._currentPoint;
                if (_inputManager.GetDistance() > MaxForce)
                {
                    currentPoint = (currentPoint-_inputManager._startPoint).normalized * MaxForce + _inputManager._startPoint;
                }
                _lineRenderer.SetPosition(0, _inputManager._startPoint);
                _lineRenderer.SetPosition(1, currentPoint);
            }
        }

        if (_inputManager.inputState == InputManager.InputState.EndClick)
        {
            _lineRenderer.gameObject.SetActive(false);
        }
    }
}
