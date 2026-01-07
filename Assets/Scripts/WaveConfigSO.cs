using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandomFactor = 0f;
    [SerializeField] float minimumSpawnDelay = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoint()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = timeBetweenSpawns + Random.Range(-spawnRandomFactor, spawnRandomFactor);
        return Mathf.Clamp(spawnTime, minimumSpawnDelay, float.MaxValue);
    }
}
