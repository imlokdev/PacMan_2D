using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Transform target;
    private Vector3 movement, posInicial;
    public static float speed = 0.075f;
    private bool player;
    public bool blockMove = true;
    public string ultimaDirecao;
    public bool enableToDie, dead;
    private Sprite spriteSave;

    private void Start()
    {
        movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);

        posInicial = transform.position;
    }

    private void Update()
    {
        if (dead)
        {
            ChangeSpriteToDie(false);
            transform.position = posInicial;
            Spawner.ghostsFila.Enqueue(this.gameObject);
        }
        
        try
        {
            target = GameObject.Find("Pacman").GetComponent<Transform>();
            player = true;
        }
        catch
        {
            player = false;
        }
    }

    public void LateUpdate()
    {
        if (player && !blockMove && !dead) transform.Translate(movement);
    }

    public void Spawn()
    {
        transform.position = new Vector3(-0.03f, 1.4f, 0f);
        blockMove = false;
    }

    public void ChangeSpriteToDie(bool state)
    {
        if (state)
        {
            spriteSave = GetComponent<SpriteRenderer>().sprite;
            GetComponent<BoxCollider2D>().isTrigger = false;

            foreach (var item in Resources.LoadAll<Sprite>("Pacman - Copia"))
                if (item.name == "GhostDie")
                {
                    GetComponent<SpriteRenderer>().sprite = item;
                    enableToDie = true;
                }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = spriteSave;
            GetComponent<BoxCollider2D>().isTrigger = true;
            enableToDie = false;
            dead = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.collider.CompareTag("parede"))
        {
            if (enableToDie) MoveOutTarget();
            else MoveToTarget();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("parede") && !dead)
        {
            if (enableToDie) MoveOutTarget();
            else MoveToTarget();
        }

        if (collision.gameObject.CompareTag("limiteD")) transform.position = new Vector3(-4.55f, 0.2f, 0f);
        else if (collision.gameObject.CompareTag("limiteE")) transform.position = new Vector3(4.55f, 0.2f, 0f);
    }

    private void MoveOutTarget()
    {
        float distanciaX, distanciaY;

        distanciaX = transform.position.x - target.position.x;
        distanciaY = transform.position.y - target.position.y;

        float absX, absY;
        absX = Mathf.Abs(distanciaX);
        absY= Mathf.Abs(distanciaY);

        if (absX > absY)
        {
            if (distanciaX < 0)
            {
                if (ultimaDirecao == "esquerda")
                {
                    if (distanciaY < 0)
                    {
                        movement = new Vector3(0f, -(speed) * Time.deltaTime, 0f);
                        ultimaDirecao = "abaixo";
                    }
                    else
                    {
                        movement = new Vector3(0f, speed * Time.deltaTime, 0f);
                        ultimaDirecao = "acima";
                    }
                }
                else
                {
                    movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);
                    ultimaDirecao = "esquerda";
                }
            }
            else
            {
                if (ultimaDirecao == "direita")
                {
                    if (distanciaY < 0)
                    {
                        movement = new Vector3(0f, -(speed) * Time.deltaTime, 0f);
                        ultimaDirecao = "abaixo";
                    }
                    else
                    {
                        movement = new Vector3(0f, speed * Time.deltaTime, 0f);
                        ultimaDirecao = "acima";
                    }
                }
                else
                {
                    movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
                    ultimaDirecao = "direita";
                }
            }
        }
        else
        {
            if (distanciaY < 0)
            {
                if (ultimaDirecao == "abaixo")
                {
                    if (distanciaX < 0)
                    {
                        movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "esquerda";
                    }
                    else
                    {
                        movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "direita";
                    }
                }
                else
                {
                    movement = new Vector3(0f, -(speed) * Time.deltaTime, 0f);
                    ultimaDirecao = "abaixo";
                }
            }
            else
            {
                if (ultimaDirecao == "acima")
                {
                    if (distanciaX < 0)
                    {
                        movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "esquerda";
                    }
                    else
                    {
                        movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "direita";
                    }
                }
                else
                {
                    movement = new Vector3(0f, speed * Time.deltaTime, 0f);
                    ultimaDirecao = "acima";
                }
            }
        }
    }

    private void MoveToTarget()
    {
        float distanciaX, distanciaY;

        distanciaX = target.position.x - transform.position.x;
        distanciaY = target.position.y - transform.position.y;

        float absX, absY;
        absX = Mathf.Abs(distanciaX);
        absY= Mathf.Abs(distanciaY);

        if (absX > absY)
        {
            if (distanciaX < 0)
            {
                if (ultimaDirecao == "esquerda")
                {
                    if (distanciaY < 0)
                    {
                        movement = new Vector3(0f, -(speed) * Time.deltaTime, 0f);
                        ultimaDirecao = "abaixo";
                    }
                    else
                    {
                        movement = new Vector3(0f, speed * Time.deltaTime, 0f);
                        ultimaDirecao = "acima";
                    }
                }
                else
                {
                    movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);
                    ultimaDirecao = "esquerda";
                }
            }
            else
            {
                if (ultimaDirecao == "direita")
                {
                    if (distanciaY < 0)
                    {
                        movement = new Vector3(0f, -(speed) * Time.deltaTime, 0f);
                        ultimaDirecao = "abaixo";
                    }
                    else
                    {
                        movement = new Vector3(0f, speed * Time.deltaTime, 0f);
                        ultimaDirecao = "acima";
                    }
                }
                else
                {
                    movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
                    ultimaDirecao = "direita";
                }
            }
        }
        else
        {
            if (distanciaY < 0)
            {
                if (ultimaDirecao == "abaixo")
                {
                    if (distanciaX < 0)
                    {
                        movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "esquerda";
                    }
                    else
                    {
                        movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "direita";
                    }
                }
                else
                {
                    movement = new Vector3(0f, -(speed) * Time.deltaTime, 0f);
                    ultimaDirecao = "abaixo";
                }
            }
            else
            {
                if (ultimaDirecao == "acima")
                {
                    if (distanciaX < 0)
                    {
                        movement = new Vector3(-(speed) * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "esquerda";
                    }
                    else
                    {
                        movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
                        ultimaDirecao = "direita";
                    }
                }
                else
                {
                    movement = new Vector3(0f, speed * Time.deltaTime, 0f);
                    ultimaDirecao = "acima";
                }
            }
        }
    }

    // Inutilizavel
    float laserLenght = 0.125f, distance = 0.15f;
    private void Raycast()
    {
        // Cima
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, distance, 0f), Vector2.up, laserLenght);
            Debug.DrawRay(transform.position + new Vector3(0f, distance, 0f), Vector2.up * laserLenght);

            if (hit.collider != null)
                if (hit.collider.CompareTag("parede")) MoveToTarget();
        }

        // Baixo
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -distance, 0f), Vector2.down, laserLenght);
            Debug.DrawRay(transform.position + new Vector3(0f, -distance, 0f), Vector2.down * laserLenght);

            if (hit.collider != null)
                if (hit.collider.CompareTag("parede")) MoveToTarget();
        }

        // Direita
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(distance, 0f, 0f), Vector2.up, laserLenght);
            Debug.DrawRay(transform.position + new Vector3(distance, 0f, 0f), Vector2.right * laserLenght);

            if (hit.collider != null)
                if (hit.collider.CompareTag("parede")) MoveToTarget();
        }

        // Esquerda
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-distance, 0f, 0f), Vector2.down, laserLenght);
            Debug.DrawRay(transform.position + new Vector3(-distance, 0f, 0f), Vector2.left * laserLenght);

            if (hit.collider != null)
                if (hit.collider.CompareTag("parede")) MoveToTarget();
        }
    }
}
