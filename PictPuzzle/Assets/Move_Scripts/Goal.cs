using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] PazzleManager pazzle;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Player")
        {
            Debug.Log("ステージクリア");
            pazzle.StageClear();
        }
    }
}
