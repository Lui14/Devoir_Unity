using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnKillCounter : MonoBehaviour
{
    public Text counterText;
    int kills;

    public GameObject youWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
    }

    public void ShowKills()
    {
        counterText.text = kills.ToString() + "/8";
    }

    public void Addkill()
    {
        kills++;

        if (kills == 8)
        {
            youWin.SetActive(true);
        }
    }


}
