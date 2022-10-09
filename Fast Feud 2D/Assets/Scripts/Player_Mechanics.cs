using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public float PlayerHealth;
    static public int PlayerWin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(PlayerHealth <= 0)
        {
            Destroy(this.gameObject);

            if(this.gameObject.tag == "Player 1")
            {
                PlayerWin = 2;
            }
            else if(this.gameObject.tag == "Player 2")
            {
                PlayerWin = 1;
            }
        }
    }
}
