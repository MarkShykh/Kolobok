using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities 
{
    public static Quaternion CalculateAngle(float x, float y)
    {
        Vector3 circleToRectangle = new Vector3(x, y, -3) - new Vector3(0, 0, 0);

        // Calculate the angle of rotation in radians
        float angleRad = Mathf.Atan2(circleToRectangle.y, circleToRectangle.x);

        // Convert angle from radians to degrees
        float angleDeg = angleRad * Mathf.Rad2Deg;

        return Quaternion.Euler(0f, 0f, angleDeg - 90);
    }

    public static Vector3 CalculatePosition(float x, float y, float radius, float angle)
    {
        float angleToKnownPoint = Mathf.Atan2(y, x) + angle;

        // Step 3: Calculate coordinates of the point on the circle
        float newx = radius * Mathf.Cos(angleToKnownPoint);
        float newy = radius * Mathf.Sin(angleToKnownPoint);

        return new Vector3(newx, newy, -3);
    }


    public static Vector3 GetCanvasPositionFromWorldPosition(Camera camera,Canvas canvas, Vector3 worldPosition)
    {

        Vector3 viewportPos = camera.WorldToViewportPoint(worldPosition);

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;
        Vector3 canvasPos = new Vector3(viewportPos.x * canvasSize.x, viewportPos.y * canvasSize.y,-3);
        return canvasPos;
    }
}
