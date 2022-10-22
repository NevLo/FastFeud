using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Name : MonoBehaviour
{
    // Start is called before the first frame update

    public Player_Mechanics PName;
    public Text name;
    void Start()
    {
        name.text = PName.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
