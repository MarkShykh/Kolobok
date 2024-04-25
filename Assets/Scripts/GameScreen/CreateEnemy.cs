using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CreateEnemy : MonoBehaviour
{
    public Sprite[] sprites;

    public GameObject enemyPrefab;

    private float enemySpawnTimeout = 3f;

    private KolobokMovement kolobok;

    private float timer = 0.0f;

    private void Start()
    {
        kolobok = FindObjectOfType<KolobokMovement>();

    }
    void Update()
    {
        if (FindObjectOfType<GameState>().IsPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= enemySpawnTimeout && kolobok != null)
            {
                float randomAngle = Random.Range(3f, 6f);
                Vector3 currentPosition = kolobok.transform.position;
                Vector3 enemyVector = CalculateEnemyPosition(currentPosition.x, currentPosition.y, kolobok.radius, Mathf.PI / randomAngle);

                Vector3 enemyVector2 = CalculateEnemyPosition(currentPosition.x, currentPosition.y, kolobok.IsOnOuterCircle ? KolobokMovement.InnerRadius : KolobokMovement.Outerradius, Mathf.PI / 0.3f);

                var enemy = enemyPrefab.gameObject;
                enemy.transform.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
                enemy.transform.GetComponent<EnemyManager>().IsOnOuter = kolobok.IsOnOuterCircle;
                Instantiate(enemy, enemyVector, CalculateAngle(enemyVector.x, enemyVector.y));

                enemy.transform.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
                enemy.transform.GetComponent<EnemyManager>().IsOnOuter = !kolobok.IsOnOuterCircle;

                Instantiate(enemy, enemyVector2, CalculateAngle(enemyVector2.x, enemyVector2.y));

                timer = 0.0f;
                enemySpawnTimeout = Random.Range(4 / kolobok.speed, 8 / kolobok.speed);
            }
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

    private Vector3 CalculateEnemyPosition(float x, float y,float radius,float angle)
    {
        float angleToKnownPoint = Mathf.Atan2(y, x) + angle;

        // Step 3: Calculate coordinates of the point on the circle
        float newx = radius * Mathf.Cos(angleToKnownPoint);
        float newy = radius * Mathf.Sin(angleToKnownPoint);

        return new Vector3(newx, newy, -3);
    }
}
