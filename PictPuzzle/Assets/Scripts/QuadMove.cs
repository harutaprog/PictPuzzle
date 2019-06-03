using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMove : MonoBehaviour
{

    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    Vector3 mousepos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Input.mousePosition;
        gameObject.transform.position = new Vector3(
           Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).x),bounds.xMin,bounds.xMax),
           Mathf.Clamp(Mathf.Round(Camera.main.ScreenToWorldPoint(mousepos).y),bounds.yMin,bounds.yMax),
           0);
    }
}
