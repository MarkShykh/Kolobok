using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUpPrefabs;
    // Start is called before the first frame update
    private float powerUpSpawnTimeout = 6f;

    private KolobokMovement kolobok;

    private float timer = 0.0f;

    // Update is called once per frame
    private void Start()
    {
        kolobok = FindObjectOfType<KolobokMovement>();

    }
    void Update()
    {
        if (FindObjectOfType<GameState>().IsPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= powerUpSpawnTimeout && kolobok != null)
            {
                float randomAngle = Random.Range(3f, 6f);
                Vector3 currentPosition = kolobok.transform.position;
                bool isOnOuter = Random.Range(0, 2) == 0;
                float spawnRadius = isOnOuter ? KolobokMovement.Outerradius: KolobokMovement.InnerRadius;
                Vector3 powerUpVector = Utilities.CalculatePosition(currentPosition.x, currentPosition.y, spawnRadius, Mathf.PI / randomAngle);

                var powerUp = powerUpPrefabs[Random.Range(0,powerUpPrefabs.Length)];

                powerUp = Instantiate(powerUp, powerUpVector, Utilities.CalculateAngle(powerUpVector.x, powerUpVector.y));

                powerUp.AddComponent<IsOnOuter>().isOnOuter = isOnOuter;


                timer = 0.0f;
                powerUpSpawnTimeout = Random.Range(8, 16);
            }
        }
    }
}
