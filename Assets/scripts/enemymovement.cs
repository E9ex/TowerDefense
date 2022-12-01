using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class enemymovement : MonoBehaviour
{
    private int wavepointIndex = 0;
    private Transform target;

    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = waypoints.points[0];
      
    }
    public void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*enemy.speed*Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position,target.position)<=0.2f)
        {
            GetNextwaypoint();
        }

        enemy.speed = enemy.startspeed;

    }

    void GetNextwaypoint()
    {
        if (wavepointIndex >=waypoints.points.Length-1)
        {
            endpath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }

    void endpath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }

    
}
