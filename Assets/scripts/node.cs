
using System;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    private GameObject turret;
    public Vector3 positionoffset;
    public Color hovercolor;
    private Renderer rend;
    private Color startcolor;
    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.gettturettobuild()==null)
        {
            return;
        }
        if (turret!=null)
        {
            Debug.Log("Can't build there");
            return;
        }
        //build turret
        GameObject turretToBuild = buildManager.gettturettobuild();
        
        turret=(GameObject)Instantiate(turretToBuild, transform.position+positionoffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        GetComponent<Renderer>().material.color = hovercolor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
