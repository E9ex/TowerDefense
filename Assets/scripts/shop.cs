
using System;
using UnityEngine;

public class shop : MonoBehaviour
{
    public turretblueprint standardturret;
    public turretblueprint missilelauncher;
    public turretblueprint laserbeamer;
    
    private BuildManager BuildManager;

    private void Start()
    {
        BuildManager = BuildManager.instance;
    }

    public void Selectedstandartturret()
    {
        Debug.Log("standard turret purchased.");
        BuildManager.Selectturrettobuild(standardturret);
    }

    public void Selectedmissilelauncher()
    {
        Debug.Log("missile launcher purchased.");
        BuildManager.Selectturrettobuild(missilelauncher);
    }
    public void Selectedlaserbeamer()
    {
        Debug.Log("laser beamer purchased.");
        BuildManager.Selectturrettobuild(laserbeamer);
    }

    
}
