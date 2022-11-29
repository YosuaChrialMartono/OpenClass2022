using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurungTerbang : MonoBehaviour
{
    public GameMaster gameMaster;
    private Rigidbody2D burungBody;  
    public float force = 3;
    // Start is called before the first frame update
    void Start()
    {
        burungBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            burungBody.velocity = Vector2.up * force;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        gameMaster.GameOver();
    }
}
