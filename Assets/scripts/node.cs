
using System;
using System.Resources;
using UnityEngine;

public class node : MonoBehaviour
{
    private GameObject turret;
    public Vector3 positionoffset;
    public Color hovercolor;
    private Renderer rend;
    private Color startcolor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret!=null)
        {
            Debug.Log("Can't build there");
            return;
        }
        //build turret
        GameObject turretToBuild = BuildManager.instance.gettturettobuild();
        turret=(GameObject)Instantiate(turretToBuild, transform.position+positionoffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hovercolor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
