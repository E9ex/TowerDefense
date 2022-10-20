
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform targett;
    public float speed = 70f;
    public GameObject bulletimpacteffect;
    public void seek(Transform _target)
    {
        targett = _target; // referans yaptı aslında?
    }

    
    void Update()
    {
       /* if (target==null)
        {
            Destroy(gameObject);
            return;
        }*/

        Vector3 dir = targett.position - transform.position;
        float distancethisframe = speed * Time.deltaTime;
        if (dir.magnitude<=distancethisframe)
        {
            hitTarget();
            return;
        }
       transform.Translate(dir.normalized*distancethisframe,Space.World);//cokomelli
        
    }

    void hitTarget()
    {

        
        GameObject effectins=(GameObject)Instantiate(bulletimpacteffect, transform.position, transform.rotation);
        Destroy(effectins, 2f);
        Destroy(targett.gameObject );
        Destroy(gameObject);
    }
}
