using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Test");
    }

    // Update is called once per frame
    void Update()
    {


    }

    private IEnumerator Test()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Mathf.RoundToInt(transform.position.x + 1), transform.position.y), Time.deltaTime);
            if (transform.position.x % 0.5 == 0) Debug.Log("int");
            yield return StartCoroutine("Stop");
        }
    }

    private IEnumerator Stop() {
        yield return new WaitForSeconds(1.0f);
    }
}
