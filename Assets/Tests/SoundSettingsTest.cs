using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class ChangeSettingsScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void ChangeSettingsScriptSimplePasses()
    {
        SceneManager.LoadScene(0);
    }
    [UnityTest]
    public IEnumerator ChangeSettingsScriptWithEnumeratorPasses()
    {

        GameObject.Find("SettingsButton").GetComponent<Button>().onClick.Invoke();

        GameObject.Find("SoundOn").GetComponent<Button>().onClick.Invoke();
        var settingValue = PlayerPrefs.GetInt("Sound");
        Assert.AreEqual(1, settingValue, "Sound didn't turn on");

        GameObject.Find("SoundOff").GetComponent<Button>().onClick.Invoke();
        settingValue = PlayerPrefs.GetInt("Sound");
        Assert.AreEqual(0, settingValue, "Sound didn't turn off");

        GameObject.Find("MusicOn").GetComponent<Button>().onClick.Invoke();
        settingValue = PlayerPrefs.GetInt("Music");
        Assert.AreEqual(1, settingValue, "Music didn't turn on");

        GameObject.Find("MusicOff").GetComponent<Button>().onClick.Invoke();
        settingValue = PlayerPrefs.GetInt("Music");
        Assert.AreEqual(0, settingValue, "Music didn't turn off");
        yield return null;
    }
}
