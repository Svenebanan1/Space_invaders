using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerboss : MonoBehaviour
{
    public static GameManagerboss Instance { get; private set; }

    private Player player;
    private Boss boss;
    private Bunker[] bunkers;


    //Anv�nds ej just nu, men ni kan anv�nda de senare
    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();
        bunkers = FindObjectsOfType<Bunker>();

        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return))
        {
            NewGame();
        }
    }

    private void NewGame()
    {

        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        
        boss.gameObject.SetActive(true);

        for (int i = 0; i < bunkers.Length; i++)
        {
            bunkers[i].ResetBunker();
        }

        Respawn();
    }

    private void Respawn()
    {
        Vector3 position = player.transform.position;
        position.x = 0f;
        player.transform.position = position;
        player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        boss.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {

    }

    private void SetLives(int lives)
    {

    }

    public void OnPlayerKilled(Player player)
    {

        player.gameObject.SetActive(false);

    }

    public void OnBossKilled(Boss boss)
    {
        boss.gameObject.SetActive(false);

        

        if (boss.GetBossCount() == 0)
        {
            SceneManager.LoadSceneAsync(4);
        }
    }

    public void OnMysteryShipKilled(MysteryShip mysteryShip)
    {
        mysteryShip.gameObject.SetActive(false);
    }

 
}
