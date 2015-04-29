using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool playing = true;
    public static int coins = 0;
    public static string powerUp;
    public Text coinText;
    public Text boostText;

    void Update()
    {
        if (!playing)
        {
            Application.LoadLevel(0);//will change to end screen if I have time
            playing = true;
        }
        else
        {
            coinText.text = "Collected: " + coins;
            if (powerUp != null)
            {
                boostText.text = "Current PowerUp: " + powerUp;
            }
        }
    }
    //will deal with winning and loosing etc (possibly pausing)
}
