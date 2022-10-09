using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Mechanics>() != null)
        {
            collision.gameObject.GetComponent<Player_Mechanics>().PlayerHealth -= damage;
        }
    }
}
