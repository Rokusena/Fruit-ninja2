using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Transform cursor;
    
    private Camera mainCamera;
    private bool isTouching;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursor.gameObject.SetActive(true);
            isTouching = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursor.gameObject.SetActive(false);
            isTouching = false;
        }
        
        //if not touching the screen - leave
        if (!isTouching) return;
        
        //clean out z coordinate
        var mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        
        //convert screen coordinates to world coordinates
        var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        cursor.position = worldPosition;
    }
}
