using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathing : MonoBehaviour
{
    waveConfig waveConfigScript;
    List<Transform> wayPoints;

    int wayPointIndex = 0;

    private void Start()
    {
        wayPoints = waveConfigScript.GetWaypoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void SetWaveConfig(waveConfig waveConfig)
    {
        this.waveConfigScript = waveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = waveConfigScript.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
