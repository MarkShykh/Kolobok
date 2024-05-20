using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    public IEnumerator LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
        yield return null;
    }
}
