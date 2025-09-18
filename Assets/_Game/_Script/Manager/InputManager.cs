using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 _startPoint;
    public Vector2 _endPoint;
    public Vector2 _currentPoint;
    public InputState inputState = InputState.None;
    private Camera cam;
    
    private void Awake()
    {
        cam = Camera.main;
        Input.multiTouchEnabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            inputState = InputState.StartClick;
        else if (Input.GetMouseButton(0))
            inputState = InputState.OnClick;
        else if(Input.GetMouseButtonUp(0))
            inputState = InputState.EndClick;
        else
            inputState = InputState.None;
        SetPoint();
    }

    void SetPoint()
    {
        if (inputState == InputState.StartClick)
            _startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        if(inputState == InputState.OnClick)
            _currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        if(inputState == InputState.EndClick)
            _endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public float GetDistance() => Vector2.Distance(_startPoint, _currentPoint);

    public enum InputState
    {
        None = 0, // Không Ấn
        StartClick = 1, // Có Ấn
        OnClick = 2, // Đang Nhấn
        EndClick = 3, // Dừng Ấn
    }
    
    
}
