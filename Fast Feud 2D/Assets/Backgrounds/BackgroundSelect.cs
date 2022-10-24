using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelect : MonoBehaviour
{
    //wendy,jack,waffle,burger
    public GameObject wendy;
    public GameObject jack;
    public GameObject waffle;
    public GameObject burger;

    public GameObject[] backgrounds = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        backgrounds[0] = wendy;
        backgrounds[1] = jack;
        backgrounds[2] = waffle;
        backgrounds[3] = burger;

        int backGround = CharacterSelect.currentlySelectedStage;
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(false);
        }
        backgrounds[backGround].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
