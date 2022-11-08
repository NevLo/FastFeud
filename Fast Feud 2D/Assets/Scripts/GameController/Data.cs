using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data")]
public class Data : ScriptableObject
{
    public int PlayerWin;
    public bool HasSomeoneWon;
    public bool HasSomeoneWonTwice;
    public bool HasFightStarted;
    public int Player1Wins;
    public int Player2Wins;


    // Could also implement some methods to set/read data,
    // do stuff with the data like parsing between types, fileIO etc

    // Especially ScriptableObjects also implement OnEnable and Awake
    // so you could still fill them with permanent data via FileIO at the beginning of your app and store the data via FileIO in OnDestroy !!
}

// If you want the data to be stored permanently in the editor
// and e.g. set it via the Inspector
// your types need to be Serializable!
//
// I intentionally used a non-serializable class here to show that also 
// non Serializable types can be passed between scenes 

