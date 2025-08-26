using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    private Dictionary<string, Enemy> idEnemy;

    [SerializeField] private Transform _container;

    [SerializeField] private float _enemySpawnTime = 0f;
    private float _restartSpawnTime = 0f;

    private void Awake()
    {
        idEnemy = new Dictionary<string, Enemy>();

        foreach (Enemy enemy in enemies)
        {
            idEnemy.Add(enemy.idName, enemy);
        }
    }

    private void Start()
    {
        _restartSpawnTime = _enemySpawnTime;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        _enemySpawnTime -= Time.deltaTime;

        if (_enemySpawnTime < 0f )
        {
            CreateEnemy(RandomEnemy());
            _enemySpawnTime = _restartSpawnTime;
        }
    }

    private string RandomEnemy()
    {
        string idName = "";
        int randomValue = Random.Range( 0, enemies.Length );

        switch(randomValue)
        {
            case 0:
                idName = enemies[0].idName;
                Debug.Log($"Enemy picked: {idName}");
                break;
            case 1:
                idName = enemies[1].idName;
                Debug.Log($"Enemy picked: {idName}");
                break;
            case 2:
                idName = enemies[2].idName;
                Debug.Log($"Enemy picked: {idName}");
                break;
            default:
                Debug.Log("Given value is not valid");
                break;
        }

        return idName;
    }

    public Enemy CreateEnemy(string id)
    {
        if (!idEnemy.TryGetValue(id, out Enemy enemy))
            return null;

        Debug.Log($"Enemy instantiated {enemy.name}");
        return Instantiate(enemy, _container);
    }
}
