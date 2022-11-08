using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Name : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlayer1;
    public Text name;
    void Start()
    {
        if (CharacterSelect.player1 == null || CharacterSelect.player2 == null)
        {
            name.text = "Test.Sprite.Entity";
            return;
        }

        if (isPlayer1)
            name.text = CharacterSelect.player1.ToString();
        else
            name.text = CharacterSelect.player2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
