using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    
    void Start()
    {
        GameObject foundObject = GameObject.FindGameObjectWithTag("GameController");

        if (foundObject != null)
        {
            GameManager gameManager = foundObject.GetComponent<GameManager>();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = gameManager.selectedCar;
        }
    }

    void Update()
    {
        
    }
}
