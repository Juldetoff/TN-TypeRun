using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    Player player = null;
    public WordBank wordbank = null;
    public List<Obstacle> obstacles = new List<Obstacle>();
    //List<Decoration> decorations = new List<Decoration>();
    //List<Bonus> bonuses = new List<Bonus>();
    public Obstacle PrefabObs;
    //public Decoration PrefabDeco;
    //public Bonus PrefabBonus;

    public List<Sprite> spriteList = new List<Sprite>();
    public List<Sprite> destroyedSpriteList = new List<Sprite>();




    float Xspawn = 17f;
    float Xdespawn = -13.5f;

    int score = 0;
    float timer = 0;
    float obsCooldown = 9; //temps avant prochain spawn d'obstacle (en secondes)
    float bonusChance = 0.1f; //chance d'avoir un bonus qui apparaît
    float bonusCooldown = 17; //temps min avant prochain spawn possible de bonus (en secondes)
    float decoCooldown = 5; //temps avant prochain spawn de déco (en secondes)
    float decoChance = 0.5f; //chance d'avoir une déco qui apparaît

    // Start is called before the first frame update
    void Start()
    {
        //on lance la coroutine gérant le spawn d'obstacles (parce qu'elle s'autorappelle après le cooldown)
        StartCoroutine(SpawnObs());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //modif distance
        //modif score

                

        //gestion main obstacle
        for(int i=0;i<obstacles.Count;i++){
            if(obstacles[i].transform.position.x <= Xdespawn){
                Destroy(obstacles[i]);
                obstacles.RemoveAt(i);
            }
            if(i==0){
                obstacles[i].isActive = true;
            }
            else{
                obstacles[i].isActive = false;
            }
        }
    }

    IEnumerator SpawnObs(){ 
        Obstacle obs = Instantiate(PrefabObs, new Vector2(Xspawn, -2.4f), Quaternion.identity);
        if(obstacles.Count > 0){
            obs.SetInactive();
        }
        obstacles.Add(obs);
        int i = Random.Range(0, spriteList.Count);
        int vies = 1;
        //List<string> words = new List<string>(){"Rock", "Obstacle", "Danger", "Squid"};
        obs.SetObstacle(destroyedSpriteList[i], spriteList[i], vies, player, this, 1);
        //yield return null;
        yield return new WaitForSeconds(obsCooldown);
        StartCoroutine(SpawnObs());
    }

    public void update_obstacles(){
        obstacles.RemoveAt(0);
        if(obstacles.Count > 0){
            obstacles[0].SetActive();
        }
    }
}
