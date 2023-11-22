using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnPoint[] _spawnPoints;

    private float _delay = 2f;
    private WaitForSeconds _delaySpawn;
    private Coroutine _coroutineSpawn;

    private void Awake()
    {
        UpdateSpawnDelay();
    }

    private void OnEnable()
    {
        _coroutineSpawn = StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutineSpawn);
    }

    private IEnumerator SpawnEnemy()
    {
        bool isWorking = true;
        
        while (isWorking)
        {
            SpawnPoint spawnPoint = GetRandomPoint();

            spawnPoint.Spawn();

            yield return _delaySpawn;
        }
    }

    private void UpdateSpawnDelay()
    {
        _delaySpawn = new WaitForSeconds(_delay);
    }

    private SpawnPoint GetRandomPoint() => _spawnPoints[Random.Range(0, _spawnPoints.Length)];
}