
using UnityEngine;

public class nodeUI : MonoBehaviour
{

    private node target;
    public GameObject ui;

    public void settarget(node _target)
    {
       target = _target;
       transform.position = target.getbuildposition();
       ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void upgrade()
    {
        target.upgradeturret();
        BuildManager.instance.deselectNode();
    }
}
