using UnityEngine;

public class MänniskaSpawn : MonoBehaviour
{
    public GameObject humanPrefab;  // square asså 
    public int healthyCount = 10;
    public Vector2 spawnArea = new Vector2(8f, 4f);

    void Start()
    {
        // Spawna alla friska
        for (int i = 0; i < healthyCount; i++)
        {
            Spawn(Maniska.HealthState.Healthy);
        }

        // Spawna 1 infekterad
        Spawn(Maniska.HealthState.Infected);
    }

    void Spawn(Maniska.HealthState startState)
    {
        Vector2 pos = new Vector2(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y)
        );

        GameObject obj = Instantiate(humanPrefab, pos, Quaternion.identity);
        Maniska m = obj.GetComponent<Maniska>();
        m.state = startState;
        m.direction = Random.insideUnitCircle.normalized;
    }
}