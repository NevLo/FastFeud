using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;
    private Character p1 = CharacterSelect.player1;
    private Character p2 = CharacterSelect.player2;
    [SerializeField]
    private bool activeCharIsP1;

    public Player_Mechanics blocking;

    public bool isHeavyAttack;

    void Start()
    {

        //realistically, this doesnt need to exist.
        switch (gameObject.tag)
        {
            case "HAP1":
                damage = p1.heavyAttackDamage;
                isHeavyAttack = true;
                break;
            case "HAP2":
                damage = p2.heavyAttackDamage;
                isHeavyAttack = true;
                break;
            case "LAP1":
                damage = p1.lightAttackDamage;
                isHeavyAttack = false;
                break;
            case "LAP2":
                damage = p2.lightAttackDamage;
                isHeavyAttack = false;
                break;
            case "SAP1":
                damage = p1.superAttackDamage;
                isHeavyAttack = false;
                break;
            case "SAP2":
                damage = p2.superAttackDamage;
                isHeavyAttack = false;
                break;
            default:
                Debug.LogError("An instance of Attack_Mechanics has been attached to an invalid gameobject");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(blocking != null)
        {
            if (blocking.HitStun || blocking.BlockStun)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherPlayer = collision.gameObject.GetComponent<Player_Mechanics>();

        if(otherPlayer != null)
        {
            if ((!otherPlayer.IsBlocking) | (otherPlayer.IsBlockingLow && isHeavyAttack) | (!otherPlayer.IsBlockingLow && !isHeavyAttack))
            {
                var LPunchHit = GameObject.Find("Light_punch").GetComponent<AudioSource>();
                var HPunchHit = GameObject.Find("Heavy_punch").GetComponent<AudioSource>();
                
                if(isHeavyAttack){
                    HPunchHit.Play();
                }
                else{
                    LPunchHit.Play();
                }
                otherPlayer.PlayerHealth -= damage;
                otherPlayer.HitStun = true;
                blocking.Meter = Mathf.Min(blocking.Meter + damage, 100);

            }
            else
            {
                otherPlayer.BlockStun = true;
            }
        }
    }
}
