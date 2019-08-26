using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{

    public const float skinWidth = .015f; //Size宣言
    [HideInInspector]
    public int horizontalRayCount = 8; //横のrayの本数
    [HideInInspector]
    public int verticalRayCount = 6; //縦のrayの本数

    [HideInInspector]
    public float horizontalRaySpacing;　//rayを飛ばす際の間隔調整用(横)
    [HideInInspector]
    public float verticalRaySpacing;        //rayを飛ばす際の間隔調整用(縦)

    [HideInInspector]
    public new BoxCollider2D collider;      //BoxColliderの取得
    public RaycastOrigins raycastOrigins; //四角の各頂点の宣言
                                         
    public virtual void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
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

    public void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 6, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 6, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
