using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeController : MonoBehaviour
{
    private Image background;

    // Start is called before the first frame update
    void Start()
    {
        background = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (background.rectTransform.sizeDelta.x != Screen.width || background.rectTransform.sizeDelta.y != Screen.height)
        {
            background.rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);
        }
        
    }
}
