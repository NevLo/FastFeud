using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;
    public float StartDelay;
    public float ActiveDelay;
    public float RecoveryDelay;

    private float StartTimer;
    private float ActiveTimer;
    private float RecoveryTimer;

    void Start()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartTimer >= StartDelay)
        {
            this.gameObject.SetActive(true);
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            ActiveTimer++;
        }

        if (ActiveTimer >= ActiveDelay)
        {
            this.gameObject.SetActive(true);
            RecoveryTimer++;
        }

        if(RecoveryTimer >= RecoveryDelay)
        {
            StartTimer = 0;
            ActiveTimer = 0;
            RecoveryTimer = 0;
            this.gameObject.SetActive(false);
            
        }

        StartTimer++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Mechanics>() != null)
        {
            collision.gameObject.GetComponent<Player_Mechanics>().PlayerHealth -= damage;
        }
    }
}
