
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

        
        public GameObject buildeffect;

        private turretblueprint turrettobuild;

        public void buildturreton(node node)
        {
            if (PlayerStats.money<turrettobuild.cost)
            { 
                Debug.Log("not enough money to build that!!");
                return;
            }

            PlayerStats.money -= turrettobuild.cost;
           GameObject turret=(GameObject) Instantiate(turrettobuild.prefab, node.getbuildposition(),Quaternion.identity);
           node.turret = turret;
           GameObject effect =(GameObject)Instantiate(buildeffect, node.getbuildposition(), Quaternion.identity);
           Destroy(effect,5f);
           Debug.Log("turret build money left:"+PlayerStats.money);
        }

        public bool canbuild { get { return turrettobuild != null; } }// buna property deniyor. sadece get yapabilir set yapamaz.
        public bool hasmoney { get { return PlayerStats.money >=turrettobuild.cost; } }
        public void Selectturrettobuild(turretblueprint turret)
    {
        turrettobuild = turret;
    }




}
