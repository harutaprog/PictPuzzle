using UnityEngine;

public class LineGenerate : MonoBehaviour
{

    [SerializeField] private Vector2 startpos, endpos;
    public GameObject Ball;
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            startpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(startpos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(endpos);
            if (Mathf.Abs(startpos.x - endpos.x) < 0.5f && Mathf.Abs(startpos.y - endpos.y) < 0.5f)
            {
                Debug.Log("BallMake!!");
                Instantiate(Ball, new Vector3(startpos.x, startpos.y, 0), Quaternion.identity);

            }
            else
            {
                Debug.Log(Vector2.Distance(startpos, endpos));
                lineRenderer.SetPosition(0, startpos);
                lineRenderer.SetPosition(1, endpos);
            }
        }
    }
}