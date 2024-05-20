using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class WinScreenTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void WinScreenTestSimplePasses()
    {
        SceneManager.LoadScene(1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WinScreenTestWithEnumeratorPasses()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        yield return new WaitForSeconds(5f);
        GameObject.Find("GameState").GetComponent<GameState>().IsOver = true;
        yield return null;
        Assert.NotNull(GameObject.Find("WinPopup(Clone)"));
        GameObject.Find("PauseBtnLogic").GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);
        GameObject.Find("ResumeBtnLogic").GetComponent<Button>().onClick.Invoke();
        var isPlaying = GameObject.Find("GameState").GetComponent<GameState>().IsPlaying;
        Assert.IsFalse(isPlaying, "Game starts after loose!");
    }
}
