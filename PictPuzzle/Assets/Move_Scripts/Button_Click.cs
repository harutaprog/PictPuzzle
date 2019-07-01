using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Click : MonoBehaviour
{
    [SerializeField] PuzzleManager PuzzleManager;
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
        PuzzleManager.ButtonClick();
        this.gameObject.SetActive(false);
    }
}
