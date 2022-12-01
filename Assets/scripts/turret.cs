
using UnityEngine;

public class turret : MonoBehaviour
{
    
    private Transform target;
    private Enemy targetenemy;
        

    [Header("general")]
    public float range = 15f;

    [Header("use bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float fireCoundown = 0f;
    
    
    [Header("use laser")] 
    public bool uselaser = false;

    public int damageovertime=30;
    public float slowpct = 0.5f;

    public LineRenderer LineRenderer;
    public ParticleSystem laserimpacteffect;
    public Light impactlight;
    
    
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
            targetenemy = nearestEnemy.GetComponent<Enemy>();
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
            if (uselaser)
            {
                if (LineRenderer.enabled)
                    LineRenderer.enabled = false;
                    laserimpacteffect.Stop();
                    impactlight.enabled = false;
            }
            return;
            
        }

       lockontarget();
       if (uselaser)
       {
           laser();
       }
       else
       {
           if (fireCoundown <= 0f)
           {
               Shoot();
               fireCoundown = 1f/fireRate; // timucin abiye sor. saniye de 2 bullet atiyor eger fireratemizi 2 seçersek
            
           }

           fireCoundown -= Time.deltaTime;
       }
       


    }

    void lockontarget()
    {


        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void laser()
    {
        target.GetComponent<Enemy>().TakeDamage(damageovertime*Time.deltaTime);
        targetenemy.Slow(slowpct);
        
        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            laserimpacteffect.Play();
            impactlight.enabled = true;
        }

   
        LineRenderer.SetPosition(0,firepoint.position);
        LineRenderer.SetPosition(1,target.position);

        Vector3 dir = firepoint.position -target.position;
        laserimpacteffect.transform.position = target.position+dir.normalized;

        laserimpacteffect.transform.rotation = Quaternion.LookRotation(dir);
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
