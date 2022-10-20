
using UnityEngine;

public class turret : MonoBehaviour
{
    
    private Transform target;

    [Header("attributes")]
    public float range = 15f;
    public float fireRate = 2f;
    private float fireCoundown = 0f;
    
    [Header("unity setup fields")]
    public string enemyTag = "enemy";
    public Transform PartToRotate;
    public float turnspeed=10f;
    public GameObject bulletprefab;
    public Transform firepoint;

    private void Start()
    {
       InvokeRepeating("UpdateTarget",0f,0.5f); 
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity;//* en yakın olan uniteyi saklamak için.
        GameObject nearestEnemy = null;//*
        foreach (GameObject enemy in enemies)
        {
            float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToenemy < shortestdistance)
            {
                shortestdistance = distanceToenemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy!=null&& shortestdistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        
    }

    private void Update()
    {
        if (target==null)
        {
            return;
            
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation=Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
        if (fireCoundown <= 0f)
        {
            Shoot();
            fireCoundown = 1f/fireRate; // timucin abiye sor. saniye de 2 bullet atiyor eger fireratemizi 2 seçersek
            
        }

        fireCoundown -= Time.deltaTime;


    }

    void Shoot()
    {
        GameObject bulletGO= (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        if (bullet!=null)
        {
            bullet.seek(target);
        }
    } 
    private void OnDrawGizmosSelected()//turret ın rangeni belirlemek için
    
    {
        Gizmos.color=Color.red;
        
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
