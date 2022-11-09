
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform targett;
    public int damage = 50;
    
    public float speed = 70f;
    public GameObject bulletimpacteffect;
    public float explosionradius = 0f;
    public void seek(Transform _target)
    {
        targett = _target; // referans yaptı aslında?
    }

    
    void Update()
    {
       if (targett==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = targett.position - transform.position;
        float distancethisframe = speed * Time.deltaTime;
        if (dir.magnitude<=distancethisframe)
        {
            hitTarget();
            return;
        }
       transform.Translate(dir.normalized*distancethisframe,Space.World);//cokomelli
        transform.LookAt(targett);
    }

    void hitTarget()
    {

        
        GameObject effectins=(GameObject)Instantiate(bulletimpacteffect, transform.position, transform.rotation);
        Destroy(effectins, 5f);
        if (explosionradius>0)
        {
            explode();
        }
        else
        {
            Damage(targett);
        }
        Destroy(targett.gameObject );
        Destroy(gameObject);
    }

    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionradius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    

    void Damage(Transform enemy)
    {
        Enemy e =enemy.GetComponent<Enemy>();
        if (e!=null)
        {
            e.TakeDamage(damage);
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionradius);
    }
}
