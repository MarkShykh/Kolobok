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

    public static float Outerradius = 1.19f;
    public static float InnerRadius = 0.93f;

    public bool IsOnOuterCircle
    {
        set { isOnOuterCircle = value; }
        get { return isOnOuterCircle; }
    }
    // Update is called once per frame
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
