using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    public float minVelocity = 0.1f;
    private Rigidbody2D rb;
    private Vector3 LastMousePosition;
    private Vector3 MouseVelocity;
    private Collider2D col;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        col.enabled = IsMouseMoving();
        SetBladeToMouse();
        
    }

    private void SetBladeToMouse()
    {
        var MousePos = Input.mousePosition;
        MousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(MousePos);
    }

    private bool IsMouseMoving()
    {
        Vector3 CurrentMousePosition = transform.position;
        float traveled = (LastMousePosition - CurrentMousePosition).magnitude;
        LastMousePosition = CurrentMousePosition;

        if (traveled > minVelocity)
        {
            return true;
        }
        else
            return false;
    }
}


