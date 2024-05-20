using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PauseTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PauseTestSimplePasses()
    {
        SceneManager.LoadScene(1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PauseTestWithEnumeratorPasses()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("PauseBtnLogic").GetComponent<Button>().onClick.Invoke();
        var isPlaying = GameObject.Find("GameState").GetComponent<GameState>().IsPlaying;
        Assert.IsFalse(isPlaying);
        yield return new WaitForSeconds(3f);
        GameObject.Find("ResumeBtnLogic").GetComponent<Button>().onClick.Invoke();
        isPlaying = GameObject.Find("GameState").GetComponent<GameState>().IsPlaying;
        Assert.IsTrue(isPlaying);
        yield return null;

    }
}
