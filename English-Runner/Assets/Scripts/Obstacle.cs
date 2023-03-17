using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player player = null;
    public Typer typer = null;
    Obstacle_Manager manager = null;
    public Sprite destroyedSprite = null;
    public Sprite sprite = null;
    public int health = 1;
    public bool isActive = false;

    public float Ydespawn = -13.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x;
        Vector2 pos = transform.position;

        if(player.lives>0){pos.x -= realVelocity * Time.fixedDeltaTime;}

        if(pos.x <= Ydespawn)
        {
            if(isActive){this.DestroyObstacle();}
            Destroy(gameObject);
        }
        transform.position = pos;
    }

    public void SetObstacle(Sprite destroyed, Sprite image, int health, Player player, Obstacle_Manager manager, int skip)
    {
        this.destroyedSprite = destroyed;
        this.sprite = image;
        GetComponent<SpriteRenderer>().sprite = sprite;
        this.health = health;
        this.player = player;
        this.typer.wordbank = manager.wordbank;
        this.typer.SetCurrentWord();
        this.manager = manager;
        this.typer.skipNumber = skip;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DestroyObstacle();
            manager.AddScore();
        }
    }

    private void DestroyObstacle()
    {
        StartCoroutine(manager.SpawnParticles(transform.position.x, transform.position.y));
        isActive = false;
        GetComponent<SpriteRenderer>().sprite = destroyedSprite;
        if(typer){typer.SetInactive();
        typer.GetDestroyed();}
        manager.update_obstacles();
    }

    private void OnTriggerEnter2D(Collider2D collision) //essayons ça pour la collision
    {
        if(collision.gameObject.tag == "Player" && isActive)
        {
            isActive = false;
            player.GettingHit();
            manager.UpdateLife();
            if(player.lives<=0){
                manager.GameOver();
            }
            DestroyObstacle();
        }
    }

    public void SetActive()
    {
        isActive = true;
        typer = GetComponentInChildren<Typer>();
        typer.SetActive();
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void SetInactive()
    {
        isActive = false;
        if(typer){
            typer.SetInactive();}
    }

}
