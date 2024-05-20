using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class LooseScreenTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void LooseScreenTestSimplePasses()
    {
        SceneManager.LoadScene(1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LooseScreenTestWithEnumeratorPasses()
    {
        PlayerPrefs.SetInt("HighScore",100000);
        yield return new WaitForSeconds(5f);
        GameObject.Find("GameState").GetComponent<GameState>().IsOver = true;
        yield return null;
        Assert.NotNull(GameObject.Find("LosePopup(Clone)"));
        GameObject.Find("PauseBtnLogic").GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);
        GameObject.Find("ResumeBtnLogic").GetComponent<Button>().onClick.Invoke();
        var isPlaying = GameObject.Find("GameState").GetComponent<GameState>().IsPlaying;
        Assert.IsFalse(isPlaying,"Game starts after loose!");
    }
}
