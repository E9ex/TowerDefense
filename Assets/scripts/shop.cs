
using System;
using UnityEngine;

public class shop : MonoBehaviour
{
    private BuildManager BuildManager;

    private void Start()
    {
        BuildManager = BuildManager.instance;
    }

    public void purchasestandartturret()
    {
        Debug.Log("standard turret purchased.");
        BuildManager.setturrettobuild(BuildManager.stantdarturretprefab);
    }

    public void purchasemissilelauncher()
    {
        Debug.Log("another turret purchased.");
        BuildManager.setturrettobuild(BuildManager.missilelauncherprefab);
    }
}
