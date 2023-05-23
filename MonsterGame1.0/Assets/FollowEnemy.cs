using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float speed;
    


    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Vector2 relativePoint;
    SpriteRenderer sprite;
    

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        
        
        player = GameObject.Find("Player");
        latestDirectionChangeTime = 0f;
        
        calcuateNewMovementVector();
    }

     void calcuateNewMovementVector()
     {
    //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
     movementDirection = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1).normalized);
     movementPerSecond = movementDirection * characterVelocity;
     
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position-transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance<4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
            if(player.transform.position.x>transform.position.x)
            {
                sprite.flipX=false;
            }
            else
            {
                sprite.flipX=true;
            }
           
            
        }

        if(distance>4)
        { 
            if (Time.time - latestDirectionChangeTime > directionChangeTime){
         latestDirectionChangeTime = Time.time;
         calcuateNewMovementVector();
         
        }
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        
        }
       
    }
}

 // Make xombie flipx to whichever direction its moving in (if sprite.velocity or something = -1 for left and 1 for right idk figure it out.)
 
