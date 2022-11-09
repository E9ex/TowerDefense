using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class moneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneytext;

    // Update is called once per frame
    void Update()
    {
        moneytext.text = "$"+PlayerStats.money.ToString();
    }
}
