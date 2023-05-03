using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float gameSpeed =1f;
    [SerializeField] float restartAfter =2f;
    [SerializeField] float score = 0;
    [SerializeField] float timeAcceleration = 0.005f;
    [SerializeField] bool gameActive = true;

    float startingSpeed;
    

    public static GameManager Instance{get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        startingSpeed = gameSpeed;
        if(Instance && Instance !=this)
            GameObject.Destroy(this.gameObject); 
        else
            Instance= this;

    }
    // Update is called once per frame
    void Update()
    {
        TickTime();
        
    }

    public void TickTime()
    {
        if(!GameManager.Instance.IsGameActive()) return;
        score += gameSpeed*Time.deltaTime;
        gameSpeed += (Time.deltaTime* timeAcceleration);
    }
    private void OnDestroy() {
        Instance = null;
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }
      public bool IsGameActive()
    {
        return gameActive;
    }

    public void GameOver()
    {
        gameActive =false;
        Debug.Log("Game Over");
        Debug.Log("Player score: "+ ((int)score));
        
        //Time.timeScale = 0;
        StartCoroutine(RestartAfterSecs(restartAfter));
    }
    private IEnumerator RestartAfterSecs(float secs=2f){
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public float speedRatio()
    {
        return gameSpeed/startingSpeed;
    }
  
}
