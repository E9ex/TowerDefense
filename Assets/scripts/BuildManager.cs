
using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
        //singleton pattern

        public static BuildManager instance;

        private void Awake()
        {
            if (instance!=null)
            {
                Debug.LogError("more than one buildmanager in scene");
                return;  
            }

            instance = this;
        }

        public GameObject stantdarturretprefab;


        public GameObject missilelauncherprefab;


        private GameObject turrettobuild;

    public GameObject gettturettobuild()
    {
        return turrettobuild;
    }

    public void setturrettobuild(GameObject turret)
    {
        turrettobuild = turret;
    }



}
