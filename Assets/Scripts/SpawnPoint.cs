using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _target;

    public void Spawn()
    {
        Enemy spawnedEnemy = Instantiate(_prefab, transform.position, Quaternion.identity);

        spawnedEnemy.SetTarget(_target);
    }
}