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
    public List<string> words = new List<string>()
    {
        "Rock", "Obstacle", "Danger","Squid"
    };

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //check si une hitbox constante marche, ou si y<yplayer
        //check déplacement aussi à la place de parallax
        //check si non active, reset mot
    }

    public void SetObstacle(Sprite destroyed, Sprite image, int health, List<string> words, Player player, Obstacle_Manager manager)
    {
        this.destroyedSprite = destroyed;
        this.sprite = image;
        this.health = health;
        this.words = words;
        this.player = player;
        this.typer.wordbank = manager.wordbank;
        this.typer.SetCurrentWord();
        this.manager = manager;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DestroyObstacle();
        }
    }

    private void DestroyObstacle()
    {
        isActive = false;
        GetComponent<SpriteRenderer>().sprite = destroyedSprite;
        typer.SetInactive();
        typer.GetDestroyed();
        manager.update_obstacles();
        //player.AddScore(1);
    }

    private void OnTriggerEnter2D(Collider2D collision) //essayons ça pour la collision
    {
        if(collision.gameObject.tag == "Player" && isActive)
        {
            isActive = false;
            player.GettingHit();
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
        typer.SetInactive();
        GetComponent<SpriteRenderer>().sprite = destroyedSprite;
    }

}
