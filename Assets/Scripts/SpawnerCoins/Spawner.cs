using System.Collections.Generic;
using System.Linq;
using Item;
using SpawnerCoins;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    private List<Vector3> _spawnPositions;

    private void Awake()
    {
        _spawnPositions=GetComponentsInChildren<SpawnerPoint>()
            .Select(spawnerPosition => spawnerPosition.transform.position)
            .ToList();
        _spawnPositions.ForEach(vector3=>Spawn(vector3));
        
    }
    
    private void Spawn(Vector3 vector3) => 
        Instantiate(_coin, vector3,Quaternion.identity);
}
