using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolobokMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float radius = 1.19f;
    public float angle = 0f;
    private bool isOnOuterCircle = true;
    
    public bool Invincible = false;

    public static float Outerradius = 1.19f;
    public static float InnerRadius = 0.93f;

    public bool IsOnOuterCircle
    {
        set { isOnOuterCircle = value; }
        get { return isOnOuterCircle; }
    }

    public void SuperPowerStart()
    {
        StartCoroutine(IncreaseAndDecreaseSpeed());
    }
    private IEnumerator IncreaseAndDecreaseSpeed()
    {
        var maxSpeed = 50f;
        Invincible = true;

        float elapsedTime = 0f;
        while (elapsedTime < 2)
        {
            speed = Mathf.Lerp(1f, maxSpeed, elapsedTime / 2);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < 1.5f)
        {
            speed = Mathf.Lerp(maxSpeed, 1f, elapsedTime / 1.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        speed = 1f;
        Invincible = false;
    }
    // Update is called once per frame
    void Start()
    {
        // Initialize angle based on the current position relative to the target
        Vector3 direction = transform.position - target.position;
        angle = Mathf.Atan2(direction.y, direction.x);
    }
    void Update()
    {
        if (FindObjectOfType<GameState>().IsPlaying)
        {
            float x = target.position.x + Mathf.Cos(angle) * radius;
            float y = target.position.y + Mathf.Sin(angle) * radius;

            transform.position = new Vector3(x, y, -3);

            angle -= (IsOnOuterCircle ? speed : speed + 0.5f) * Time.deltaTime;
            transform.rotation = CalculateAngle(x, y);
        }
    }


    private Quaternion CalculateAngle(float x, float y)
    {
        Vector3 circleToRectangle = new Vector3(x, y, -3) - new Vector3(0, 0, 0);

        // Calculate the angle of rotation in radians
        float angleRad = Mathf.Atan2(circleToRectangle.y, circleToRectangle.x);

        // Convert angle from radians to degrees
        float angleDeg = angleRad * Mathf.Rad2Deg;

        return Quaternion.Euler(0f, 0f, angleDeg - 90);
    }
}
