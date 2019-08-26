using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayControll : RayCastController
{

    public LayerMask mask;
    RaycastHit2D hit2D;
    public new BoxCollider2D collider;      //BoxColliderの取得

    Ray ray;
    /*
    public  void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
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
        }

    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 6, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 6, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    public void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
    */
}


