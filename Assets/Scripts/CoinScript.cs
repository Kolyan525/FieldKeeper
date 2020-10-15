using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    int score = 0;
    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
        Destroy (gameObject);
        score += 1;
        Debug.Log($"Score: {score}");
    }
}
