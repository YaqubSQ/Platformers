using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    public Image[] heartArray;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthDisplay(3);
    }


    public void UpdateHealthDisplay(int health)
    {
        switch (health)
        {
            case 3:
                heartArray[0].color = Color.white;
                heartArray[1].color = Color.white;
                heartArray[2].color = Color.white;
                break;
            case 2:
                heartArray[0].color = Color.white;
                heartArray[1].color = Color.white;
                heartArray[2].color = Color.black;
                break;
            case 1:
                heartArray[0].color = Color.white;
                heartArray[1].color = Color.black;
                heartArray[2].color = Color.black;
                break;

            default:
                heartArray[0].color = Color.black;
                heartArray[1].color = Color.black;
                heartArray[2].color = Color.black;
                break;
        }
       
    }
}
