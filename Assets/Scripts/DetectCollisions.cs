using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int scoreToAdd;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Ground"))
      {
        Destroy(gameObject);
      }
      if(other.gameObject.CompareTag("Player"))
      {
        gameManager.UpdateScore(scoreToAdd);
        Destroy(gameObject);
      }

    }






}
