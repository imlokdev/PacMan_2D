using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private float speed = 1.7f, gtX, gtY, horizontal, vertical;
    private float trade = 1f, move;
    private bool moving;
    public static int vidas = 3;
    private Vector3 posInicial;
    public static bool blockMove;
    [SerializeField] GameObject[] coracoes = new GameObject[3], temp, temp2;
    public int moedasColetadas;

    private void Start()
    {
        posInicial = transform.position;
        temp = GameObject.FindGameObjectsWithTag("coins");
        temp2 = GameObject.FindGameObjectsWithTag("coins2");
        blockMove = true;
    }
    
    private void Move()
    {
        move = speed * trade * Time.deltaTime;
        gtX = Input.GetAxis("Horizontal");
        gtY = Input.GetAxis("Vertical");

        if (gtX != 0)
        {
            if (gtX > 0f) horizontal = 1f;
            else if (gtX < 0f) horizontal = -1f;

            moving = true;
            vertical = 0f;
        }

        else if (gtY != 0)
        {
            if (gtY > 0f) vertical = 1f;
            else if (gtY < 0f) vertical = -1f;

            moving = true;
            horizontal = 0f;
        }
    }

    private IEnumerator Coins2()
    {
        for (int i = 0; i < Spawner.ghosts.Length; i++)
            Spawner.ghosts[i].GetComponent<Ghost>().ChangeSpriteToDie(true);

        yield return new WaitForSeconds(8f);

        for (int i = 0; i < Spawner.ghosts.Length; i++)
            Spawner.ghosts[i].GetComponent<Ghost>().ChangeSpriteToDie(false);
    }

    private void PerdeVida()
    {
        moving = false;

        transform.position = posInicial;

        GameObject.Find("Main Camera").GetComponent<Spawner>().ResetarGhosts();
        blockMove = true;

        vidas--;
    }

    private void PassarFase()
    {
        if (moedasColetadas >= temp.Length + temp2.Length)
        {
            moedasColetadas = 0;
            moving = false;
            blockMove = true;
            transform.position = posInicial;
            
            Moedas.block = false;

            GameObject.Find("Main Camera").GetComponent<Spawner>().timeFree += 1f;
            GameObject.Find("Main Camera").GetComponent<Spawner>().ResetarGhosts();
            Ghost.speed += 0.25f;
            speed += 0.1f;
        }
    }

    private void LateUpdate()
    {
        if (moving) transform.Translate(move * horizontal, move * vertical, 0f);
    }

    private void Update()
    {
        if (!blockMove) Move();
        PassarFase();
        switch (vidas)
        {
            case 3: foreach (var item in coracoes) item.SetActive(true); break;
            case 2: coracoes[2].SetActive(false); break;
            case 1: coracoes[1].SetActive(false); break;
            case 0: foreach (var item in coracoes) item.SetActive(false); break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("parede")) moving = false;
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (collision.gameObject.GetComponent<Ghost>().enableToDie)
            {
                collision.gameObject.GetComponent<Ghost>().blockMove = true;
                collision.gameObject.GetComponent<Ghost>().dead = true;
                Score.score += 200;
            }
            else PerdeVida();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coins"))
        {
            Moedas.ArmazenarMoeda(collision.gameObject);
            collision.gameObject.SetActive(false);
            Score.score += 10;
            moedasColetadas++;
        }
        else if (collision.gameObject.CompareTag("coins2"))
        {
            Moedas.ArmazenarMoeda(collision.gameObject);
            collision.gameObject.SetActive(false);
            StartCoroutine(Coins2());
            Score.score += 50;
            moedasColetadas++;
        }

        if (collision.gameObject.CompareTag("limiteD")) transform.position = new Vector3(-4.55f, 0.2f,0f);
        else if (collision.gameObject.CompareTag("limiteE")) transform.position = new Vector3(4.55f, 0.2f, 0f);

        if (collision.gameObject.CompareTag("enemy"))
            if (!collision.gameObject.GetComponent<Ghost>().enableToDie) PerdeVida();
    }
}