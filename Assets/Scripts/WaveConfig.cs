using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOFEnemies = 5;
    [SerializeField] float enemySpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    
    public List<Transform> GetWavePoints() 
    {
        var waveWavePoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWavePoints.Add(child);
        }
        return waveWavePoints; 
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnsRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOFEnemies; }

    public float GetEnemySpeed() { return enemySpeed; }
}
