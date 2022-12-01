using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurungTerbang : MonoBehaviour
{
    public GameMaster gameMaster;
    private Rigidbody2D burungBody;  
    public float force = 3;
    public float FallingThreshold = -10f; 
    public bool Falling = false;
    public bool playing = false;
    public bool dead = false;
    public AudioSource wingAudio;
    public AudioSource hitAudio;
    public AudioSource dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        burungBody = GetComponent<Rigidbody2D>();
        burungBody.transform.eulerAngles = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                burungBody.velocity = Vector2.up * force;
                burungBody.transform.eulerAngles = new Vector3(0, 0, 20); 
                if (!dead)
                {
                    wingAudio.Play();
                }
            }
            if (burungBody.velocity.y < FallingThreshold)
            {
                Falling = true;
            }
            else
            {
                Falling = false;
            }
            
            if (Falling)
            {
                birdDown();
            }
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameMaster.GameStart();
                Time.timeScale = 1;
                playing = true;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        hitAudio.Play();
        dieAudio.Play();
        gameMaster.GameOver();
        dead = true;
    }

    private void birdDown(){
        burungBody.transform.eulerAngles = new Vector3(0, 0, -20);
    }
}
