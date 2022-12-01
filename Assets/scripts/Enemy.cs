using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
   [HideInInspector]//unityde sagda cıkmamasını sagliyor.

   public float startspeed = 10f;
  
   public float speed = 10f;
 
   public float health = 100;
 
   [FormerlySerializedAs("value")] public int worth= 50;
   public GameObject deatheffect;

   private void Start()
   {
      speed = startspeed;
   }

   public void TakeDamage(float amount)
   {
      health -= amount;
      if (health<=0)
      {
         Die();
      }
   }

   public void Slow(float pct)
   {
      speed = startspeed * (1f - pct);
   }

   void Die()
   {
      PlayerStats.money += worth;
      GameObject effect=(GameObject)Instantiate(deatheffect, transform.position, Quaternion.identity);
      Destroy(effect,5f);
      
      Destroy(gameObject);
   }
   

   

}
