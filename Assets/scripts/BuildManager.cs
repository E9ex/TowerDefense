
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


        private void Start()
        {
            turrettobuild = stantdarturretprefab;
        }


        private GameObject turrettobuild;

    public GameObject gettturettobuild()
    {
        return turrettobuild;
    }



}
