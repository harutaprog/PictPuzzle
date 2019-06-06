using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Click : MonoBehaviour
{
    [SerializeField] PazzleManager PazzleManager;
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
        PazzleManager.ButtonClick();
        this.gameObject.SetActive(false);
    }
}
