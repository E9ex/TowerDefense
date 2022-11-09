
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class livesui : MonoBehaviour
{
    public TextMeshProUGUI livestext;

    // Update is called once per frame
    void Update()
    {
        livestext.text = PlayerStats.lives+" lives";
    }
}
