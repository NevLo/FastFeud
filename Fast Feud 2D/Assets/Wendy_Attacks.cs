using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wendy_Attacks : MonoBehaviour
{
    public GameObject HeavyBullet, LightBullet;
    public GameObject Wendy;
    public Transform WendyPosition;
    public float speed;

    private void Start()
    {

    }

    private void OnEnable()
    {
        Wendy = gameObject.transform.parent.gameObject;
        WendyPosition = gameObject.transform.parent.transform;

        if (gameObject.tag == "HAP1" && Wendy.tag == "Player 1"|| gameObject.tag == "HAP2" && Wendy.tag == "Player 2")
        {
            GameObject heavyBullet = Instantiate(HeavyBullet, transform.position, Quaternion.identity);
            if(gameObject.tag == "HAP2")
            {
                heavyBullet.GetComponent<SpriteRenderer>().flipX = !heavyBullet.GetComponent<SpriteRenderer>().flipX;
            }

            if (WendyPosition.transform.localScale.x > 0)
            {
                heavyBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * speed * 10);
            }

            else if (WendyPosition.transform.localScale.x < 0)
            {
                heavyBullet.GetComponent<SpriteRenderer>().flipX = !heavyBullet.GetComponent<SpriteRenderer>().flipX;
                heavyBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * speed * 10);
            }
        }

        /*if (gameObject.tag == "LAP1" && Wendy.tag == "Player 1" || gameObject.tag == "LAP2" && Wendy.tag == "Player 2")
        {
            GameObject lightBullet = Instantiate(lightBullet, transform.position, Quaternion.identity);
            if (gameObject.tag == "LAP2")
            {
                lightBullet.GetComponent<SpriteRenderer>().flipX = true; ;
            }

            if (WendyPosition.transform.localScale.x > 0)
            {
                lightBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * speed * 10);
            }

            else if (WendyPosition.transform.localScale.x < 0)
            {
                heavyBullet.GetComponent<SpriteRenderer>().flipX = true; ;
                lightBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * speed * 10);
            }
        }*/ //Incase we want the wendy light to also be ranged
    }
}
