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

    private float enemySpawnTimeout = 2f;

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
                // Select a random sprite once
                int randomSpriteIndex = Random.Range(0, sprites.Length);
                Sprite randomSprite = sprites[randomSpriteIndex];

                float randomAngle = Random.Range(3f, 6f);
                Vector3 currentPosition = kolobok.transform.position;

                var isOnOuter = Random.Range(0, 2) == 1;
                var spawnRadius = isOnOuter ? KolobokMovement.Outerradius : KolobokMovement.InnerRadius;
                // Calculate enemy positions based on radius
                Vector3 enemyVector = Utilities.CalculatePosition(currentPosition.x, currentPosition.y, spawnRadius, Mathf.PI / randomAngle);

                // Spawn enemies with the same random sprite and set IsOnOuter based on first calculation
                var enemy1 = Instantiate(enemyPrefab, enemyVector, Utilities.CalculateAngle(enemyVector.x, enemyVector.y));
                enemy1.transform.GetComponent<SpriteRenderer>().sprite = randomSprite;
                enemy1.transform.GetComponent<EnemyManager>().IsOnOuter = isOnOuter;

                timer = 0.0f;
                enemySpawnTimeout = Random.Range(2 / kolobok.speed, 4 / kolobok.speed);
            }
        }
    }


}
