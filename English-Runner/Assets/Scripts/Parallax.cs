using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public float depth = 1;
    public float Ydespawn = -7f;
    public float Yspawn = 7f;

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if(pos.x <= Ydespawn)
        {
            pos.x = Yspawn-Mathf.Abs(Ydespawn-pos.x);
        }


        transform.position = pos;
    }
}
