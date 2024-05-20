using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class StartGameTest
{
    [Test]
    public void StartGameTestSimplePasses()
    {
        SceneManager.LoadScene(0);
    }


    [UnityTest]
    public IEnumerator StartGameTestWithEnumeratorPasses()
    {
        GameObject.Find("StartButtonLogic").GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(5.0f);
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex, "Scene did not load correctly");
        yield return null;
    }
}
