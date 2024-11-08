using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int count = 0;
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        count++;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            GameOverOutGame();
            GameWinOutGame();
        }
        else if (SceneManager.GetActiveScene().name == "Game" && count > 0)
        {
            GameObject.Find("Main Camera").GetComponent<Spawner>().ResetarGhosts();
            GameObject.Find("Main Camera").GetComponent<Score>().ZerarScore();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PacMan>().moedasColetadas = 0;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game") GameWinAndOverInGame();
    }

    public void Sair() => Application.Quit();

    void GameWinAndOverInGame()
    {
        if (PacMan.vidas <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (Score.score >= 99999) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GameOverOutGame()
    {
        string scoreText = $"Infelizmente,\r\nvoce nao atingiu o recorde!\r\n\r\nScore: {Score.score}\r\nHighscore: {PlayerPrefs.GetInt("highscore")}",
        novoRecorde = $"Parabens,\r\nvoce atingiu um novo recorde!\r\n\r\nScore: {Score.score}\r\nHighscore: {PlayerPrefs.GetInt("highscore")}";

        if (PacMan.vidas <= 0)
        {
            if ((Score.score > PlayerPrefs.GetInt("highscore")) || (PlayerPrefs.GetInt("highscore")) == 0)
                GameObject.Find("Feedback").GetComponent<Text>().text = novoRecorde;
            else
                GameObject.Find("Feedback").GetComponent<Text>().text = scoreText;
        } 
    }

    public void ButaoGameOver()
    {
        Score.score = 0;
        Moedas.block = false;
        PacMan.vidas = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }

    void GameWinOutGame()
    {
        string limitePontos = $"Parabens,\r\nvoce atingiu o limite de pontos!\r\n\r\nVoce e um deus gamer!!!!\r\n\r\nScore: {Score.score}\r\nHighscore: {PlayerPrefs.GetInt("highscore")}";
        if (Score.score >= 99999) GameObject.Find("Feedback").GetComponent<Text>().text = limitePontos;
    }
}
