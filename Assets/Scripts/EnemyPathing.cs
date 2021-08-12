using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;                     // waveConfig here is a global variable 
    List<Transform> wavepoints;
    int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        wavepoints = waveConfig.GetWavePoints();
        transform.position = wavepoints[wavepointIndex].transform.position;    
    }

    public void SetWaveConfig(WaveConfig waveConfig)    // waveConfig here is a local variable
    {
        this.waveConfig = waveConfig;
    }

    // Update is called once per frame
    void Update()
    {
        if (wavepointIndex <= wavepoints.Count - 1)
        {
            var targetPosition = wavepoints[wavepointIndex].transform.position;
            var movementSpeed = waveConfig.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed);

            if (transform.position == targetPosition)
            {
                wavepointIndex++;
            } 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
