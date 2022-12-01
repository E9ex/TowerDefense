
using System;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;

    [HideInInspector] 
    public turretblueprint Turretblueprint;

    [HideInInspector] 
    public bool isupgraded = false;
    
    
    public Vector3 positionoffset;
    public Color hovercolor;
    public Color notenoughmoneycolor;
    private Renderer rend;
    private Color startcolor;
    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 getbuildposition()
    {
        return transform.position + positionoffset;

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret!=null)
        {
            buildManager.selectNode(this);
            return;
        }
        if (!buildManager.canbuild)
        {
            return;
        }
        //build turret
        buildturret(buildManager.getturrettobuild());
    }

    public void buildturret(turretblueprint blueprint)
    {
        if (PlayerStats.money<blueprint.cost)
        { 
            Debug.Log("not enough money to build that!!");
            return;
        }

        PlayerStats.money -= blueprint.cost;
        GameObject _turret=(GameObject) Instantiate(blueprint.prefab, getbuildposition(),Quaternion.identity);
        turret = _turret;
        Turretblueprint = blueprint;
        GameObject effect =(GameObject)Instantiate(buildManager.buildeffect, getbuildposition(), Quaternion.identity);
        Destroy(effect,5f);
        Debug.Log("turret build:"+PlayerStats.money);
        
    }

    public void upgradeturret()
    {
        if (PlayerStats.money<Turretblueprint.upgradecost)
        { 
            Debug.Log("not enough money to upgrade that!!");
            return;
        }

        PlayerStats.money -= Turretblueprint.upgradecost;
        //by old one
        Destroy(turret);
        //hi new one
        GameObject _turret=(GameObject) Instantiate(Turretblueprint.upgradedPrefab, getbuildposition(),Quaternion.identity);
        turret = _turret;
        GameObject effect =(GameObject)Instantiate(buildManager.buildeffect, getbuildposition(), Quaternion.identity);
        Destroy(effect,5f);
        isupgraded = true;
        Debug.Log("turret upgraded!:"+PlayerStats.money);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.canbuild) 
            return;
        if (buildManager.hasmoney)
        {
            rend.material.color = hovercolor;

        }
        else
        {
            rend.material.color = notenoughmoneycolor;

        }
       
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
