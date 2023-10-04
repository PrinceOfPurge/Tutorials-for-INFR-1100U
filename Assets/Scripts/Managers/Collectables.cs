using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Collectables : MonoBehaviour
{
    public int Coin=0;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        //attached transform to player 
        if (other.transform.tag == "Player") 
        {
            Coin++;
            coinText.text = "Coins: " + Coin.ToString();
            Debug.Log("collided");
            Destroy(gameObject);
            
        }
    }
    
}
