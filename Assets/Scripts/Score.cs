using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Stack<GameObject> pilha = new Stack<GameObject>();
    private int highScore, goal = 10000;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        HighScore();
    }

    private void Update()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (i == 5 && score >= 50000 && GameObject.Find($"star{i}") == null)
                foreach (var item in Resources.LoadAll<Sprite>("PacmanBlack"))
                    if (item.name == "star")
                    {
                        var temp = new GameObject($"star{i}");
                        temp.AddComponent<SpriteRenderer>().sprite = item;
                        temp.transform.position = new Vector3(5.9f, SwitchPos(i), 0f);
                        pilha.Push(temp);
                    }
            
            if (i != 5)
                if (score >= Mathf.Pow(10, i) && GameObject.Find($"star{i}") == null)
                    foreach (var item2 in Resources.LoadAll<Sprite>("PacmanBlack"))
                        if (item2.name == "star")
                        {
                            var temp = new GameObject($"star{i}");
                            temp.AddComponent<SpriteRenderer>().sprite = item2;
                            temp.transform.position = new Vector3(5.65f, SwitchPos(i), 0f);
                            pilha.Push(temp);
                        }
        }

        Score2();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            highScore = score;
            HighScore();
        }

        GanhaVida();
    }

    void GanhaVida()
    {
        if (score >= goal)
        {
            goal += 10000;
            if (PacMan.vidas < 3) PacMan.vidas++;
        }
    }

    void Score2()
    {
        var temp2 = score.ToString().Length - 1;

        foreach (var a in score.ToString())
            foreach (var b in Resources.LoadAll<Sprite>("PacmanBlack"))
                if (b.name.Equals(a.ToString()))
                    GameObject.Find($"{temp2--} - score").GetComponent<SpriteRenderer>().sprite = b;

    }

    void HighScore()
    {
        var temp = highScore.ToString().Length - 1;

        foreach (var a in highScore.ToString())
            foreach (var b in Resources.LoadAll<Sprite>("PacmanBlack"))
                if (b.name.Equals(a.ToString()))
                    GameObject.Find($"{temp--} - highscore").GetComponent<SpriteRenderer>().sprite = b;
    }

    public void ZerarScore()
    {
        for (int i = 0; i < 5; i++)
            foreach (var item in Resources.LoadAll<Sprite>("PacmanBlack"))
                if (item.name == "0")
                    GameObject.Find($"{i} - score").GetComponent<SpriteRenderer>().sprite = item;
    }

    float SwitchPos(int id)
    {
        switch (id)
        {
            case 1: return -4f;
            case 2: return -3.45f;
            case 3: return -2.9f;
            case 4: return -2.35f;
            case 5: return -1.8f;
        }

        return float.NaN;
    }
}