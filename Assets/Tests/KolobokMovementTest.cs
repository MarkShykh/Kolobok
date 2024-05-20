using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class KolobokMovementTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void KolobokMovementTestSimplePasses()
    {
        SceneManager.LoadScene(1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator KolobokMovementTestWithEnumeratorPasses()
    {
        yield return new WaitForSeconds(5f);
        var touchscreen = InputSystem.AddDevice<Touchscreen>();

        // Define the touch state (pressing down at a specific position)
        var touchState = new TouchState
        {
            phase = UnityEngine.InputSystem.TouchPhase.Began,
            position = new Vector2(0, 0), // Example touch position
            touchId = 0
        };
        var kolobok = GameObject.Find("KolobokPrefab");
        var kolobokMovement = kolobok.GetComponent<KolobokMovement>();
        var startPosition = kolobokMovement.radius;
        // Queue the touch press event
        yield return null;

        InputSystem.QueueStateEvent(touchscreen, touchState);
        InputSystem.Update();
        touchState.phase = UnityEngine.InputSystem.TouchPhase.Ended;

        // Queue the touch release event
        InputSystem.QueueStateEvent(touchscreen, touchState);
        InputSystem.Update();
        yield return null;
        var endPosition = kolobokMovement.radius;
        // Wait for a frame to allow input processing
        Assert.AreNotEqual(startPosition, endPosition);

        yield return null;
    }
}
