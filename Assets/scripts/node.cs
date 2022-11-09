
using System;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    [Header("Optional")]
    public GameObject turret;
    
    
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
        if (!buildManager.canbuild)
        {
            return;
        }
        if (turret!=null)
        {
            Debug.Log("Can't build there");
            return;
        }
        //build turret
        buildManager.buildturreton(this);
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
