using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waffle_Attacks : MonoBehaviour
{
    public GameObject HeavyBullet, LightBullet;
    public GameObject Waffle;
    public Transform WafflePosition;
    public float speed;

    private void Start()
    {

    }

    private void OnEnable()
    {
        //GameObject heavyBullet = Instantiate(HeavyBullet, transform.position, Quaternion.identity);
        Waffle = gameObject.transform.parent.gameObject;
        WafflePosition = gameObject.transform.parent.transform;

        if (gameObject.tag == "SAP1" && Waffle.tag == "Player 1" && Waffle.GetComponent<Player_Mechanics>().Meter >= 100 
            || gameObject.tag == "SAP2" && Waffle.tag == "Player 2" && Waffle.GetComponent<Player_Mechanics>().Meter >= 100)

        {
            //GameObject heavyBullet = Instantiate(HeavyBullet, transform.position, Quaternion.identity);
            Waffle.GetComponent<Player_Mechanics>().Meter = 0;
            Waffle.GetComponentInChildren<Attack_Mechanics>().damage *= 2;
        }
    }
}
