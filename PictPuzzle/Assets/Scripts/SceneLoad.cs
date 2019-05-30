using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    private AsyncOperation async;
    [SerializeField]
    private GameObject loadUI;

    IEnumerator Load(string sceneName)
    {
        loadUI.SetActive(true);
        async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            var proressVal = Mathf.Clamp01(async.progress / 0.9f);
//            slider.value = proressVal;
            yield return null;
        }

    }

}
