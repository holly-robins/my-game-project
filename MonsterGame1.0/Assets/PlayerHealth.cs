using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
     currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
