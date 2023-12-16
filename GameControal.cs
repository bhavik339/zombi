using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControal : MonoBehaviour
{

    public GameObject[] Zombies;
    public GameObject[] Harts;
    public bool isRising = false;
    public bool isFalling = false;
    private int activeZombiesIndex = 0;
    private Vector2 startPosition;  
    private int ZombiesSmaashad;
    private int LivesRemaining ;
    private bool gameOver ;
    public Image life01;
    public Image life02;
    public Image life03;
    public Text scoreText;
    public Button gameOverButton ;


   public int riseSpeed = 1 ;
   public int scoreThreshold = 5;

    void Start()
    {
        gameOver = false;
        ZombiesSmaashad = 0;
        scoreText.text = ZombiesSmaashad.ToString();
        LivesRemaining = 3 ;
        pickNewZombie();
    }

     private void pickNewZombie()
    {
        isRising = true;
        isFalling = false;
        activeZombiesIndex = UnityEngine.Random.Range(0, Zombies.Length);
        Debug.Log(activeZombiesIndex);
        startPosition = Zombies[activeZombiesIndex].transform.position;
    } 

    void Update()
    {

        if(!gameOver){
            if(isRising)
        {
            if (Zombies[activeZombiesIndex].transform.position.y - startPosition.y >= 3f)
            {
                isRising = false;
                isFalling = true;
            }else
            {
                Zombies[activeZombiesIndex].transform.Translate(Vector2.up * Time.deltaTime * riseSpeed);
            }
        }else if(isFalling)
        {
            
            if(Zombies[activeZombiesIndex].transform.position.y - startPosition.y <= 0f)
            {
                isFalling=false;
                isRising=false;
                LivesRemaining--;
                UpdateLifrUi();
            }
            else
            {
                Zombies[activeZombiesIndex].transform.Translate(Vector2.down * Time.deltaTime * riseSpeed);
            }
        }
        else
        {
            Zombies[activeZombiesIndex].transform.position = startPosition;
            pickNewZombie();

        }
        }

    }


  private void UpdateLifrUi(){
    if(LivesRemaining == 3){
        life01.gameObject.SetActive(true);
        life02.gameObject.SetActive(true);
        life03.gameObject.SetActive(true);
    }
    if(LivesRemaining == 2){
         life01.gameObject.SetActive(true);
        life02.gameObject.SetActive(true);
        life03.gameObject.SetActive(false);
    }
    if(LivesRemaining == 1){
         life01.gameObject.SetActive(true);
        life02.gameObject.SetActive(false);
        life03.gameObject.SetActive(false);
    }
    if(LivesRemaining == 0){
          life01.gameObject.SetActive(false);
        life02.gameObject.SetActive(false);
        life03.gameObject.SetActive(false);
        gameOver = true;
        gameOverButton.gameObject.SetActive(true);
    }
  }

    public void KillEnemy(){
        Zombies[activeZombiesIndex].transform.position = startPosition;
        ZombiesSmaashad++;
        scoreText.text = ZombiesSmaashad.ToString();
        pickNewZombie();
        IncreaseSpawnSpeed();
    }

    private void IncreaseSpawnSpeed () {
        if(ZombiesSmaashad >= scoreThreshold){
            riseSpeed++;
            scoreThreshold *=2;
        }
    }
    
    public void RestartGame () {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void MainMenu () {

        SceneManager.LoadScene(0);
    }


    public void AddClick () {
        Debug.Log("click");
    }
    
}
 