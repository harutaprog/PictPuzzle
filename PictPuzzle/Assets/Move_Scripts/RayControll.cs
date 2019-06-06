using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControll : RayCastController
{
   
    public override void Start()
    {
       
    }

    public void Move(Vector2 moveAmount)
    {
        HorizontalRay(moveAmount);
    }

    private void Update()
    {
        UpdateRaycastOrigins();

    }

    void HorizontalRay(Vector2 moveAmount)
    {
        //float directionX = 1.0f;
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
        {
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.bottomRight;

            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            Debug.DrawRay(transform.position, Vector2.right * 1, Color.red);
        }

    }
}
