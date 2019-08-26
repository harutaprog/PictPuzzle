using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Click : MonoBehaviour
{
    [SerializeField] CursorController cursorController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        cursorController.CursorTrue();
        cursorController.StartCheckSet(true);
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
