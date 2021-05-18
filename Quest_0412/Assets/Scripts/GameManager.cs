using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject playerGameObject;
    public Text hpText;
    public Text scoreText;
    int score;
    public bool isGameover;

    MovementProvider_ moveProvider;
    AudioSource musicSource;
    public GameObject Yellow;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameover = false;
        moveProvider = GetComponent<MovementProvider_>();
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            hpText.text = "HP :" + (int)playerGameObject.GetComponent<PlayerController>().hp;
            scoreText.text = "Score :" + (int)score;
        }
    }

    public void StartGame()
    {
        Yellow.SetActive(false);

        moveProvider.StartMove();
        musicSource.Play();
        

    }

    public void GetScored(int value)
    {
        score += value;
    }

    public void EndGame()
    {
        isGameover = true;
        gameOverText.SetActive(true);
    }

    public void RestarGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
