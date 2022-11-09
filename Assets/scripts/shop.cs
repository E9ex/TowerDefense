
using System;
using UnityEngine;

public class shop : MonoBehaviour
{
    public turretblueprint standardturret;
    public turretblueprint missilelauncher;
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
        Debug.Log("another turret purchased.");
        BuildManager.Selectturrettobuild(missilelauncher);
    }
}
