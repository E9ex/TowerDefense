
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
        private node selectedNode;
        public nodeUI NodeUI;

        

        public bool canbuild { get { return turrettobuild != null; } }// buna property deniyor. sadece get yapabilir set yapamaz.
        public bool hasmoney { get { return PlayerStats.money >=turrettobuild.cost; } }


        public void selectNode(node node)
        {
            if (selectedNode==node)
            {
                deselectNode();
                return;
            }
            selectedNode = node;
            turrettobuild = null;
            NodeUI.settarget(node);
        }

        public void deselectNode()
        {
            selectedNode = null;
            NodeUI.hide();

        }

        public void Selectturrettobuild(turretblueprint turret)
    {
        turrettobuild = turret;
        deselectNode();
    }

        public turretblueprint getturrettobuild()
        {
            return turrettobuild;
        }


}
