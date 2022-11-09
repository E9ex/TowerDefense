using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed = 10f;
   private Transform target;
   public int health = 100;
   private int wavepointIndex = 0;
   public int value= 50;
   public GameObject deatheffect;

   private void Start()
   {
      target = waypoints.points[0];
      
   }

   public void TakeDamage(int amount)
   {
      health -= amount;
      if (health<=0)
      {
         Die();
      }
   }

   void Die()
   {
      PlayerStats.money += value;
      GameObject effect=(GameObject)Instantiate(deatheffect, transform.position, Quaternion.identity);
      Destroy(effect,5f);
      
      Destroy(gameObject);
   }
   

   public void Update()
   {
      Vector3 dir = target.position - transform.position;
      transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
      if (Vector3.Distance(transform.position,target.position)<=0.2f)
      {
         GetNextwaypoint();
      }
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
