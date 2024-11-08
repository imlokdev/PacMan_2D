using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    private void Start() => CreateBoxes();

    void CreateBoxes()
    {
        // ### MUROS ###

            // ~~~ CIMA ~~~

                // Muro de Cima
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(0.02299976f, 4.892298f);
                        temp.size = new Vector2(8.584047f, 0.1007476f);
                    }
                // Muro Esquerda Cima
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(-4.21173f, 3.156528f);
                        temp.size = new Vector2(0.1094809f, 3.581681f);
                    }
                // Muro Direita Cima
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(4.263091f, 3.156528f);
                        temp.size = new Vector2(0.1052837f, 3.581681f);
                    }

            // ~~~ BAIXO ~~~

                // Muro de Baixo
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(0.02299976f, -4.892298f);
                        temp.size = new Vector2(8.584047f, 0.1007476f);
                    }
                // Muro Esquerda Baixo
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(-4.21173f, -3.000483f);
                        temp.size = new Vector2(0.1094809f, 3.893771f);
                    }
                // Muro Direita Baixo
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(4.263091f, -3.000483f);
                        temp.size = new Vector2(0.1052837f, 3.893771f);
                    }

        // ### PAREDES ###
            
            // ~~~ CIMA ~~~
                
                // Parede Esquerda Esquerda
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(-2.947474f, 3.737267f);
                        temp.size = new Vector2(0.946557f, 0.5269639f);
                    }
                // Parede Esquerda Direita
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(-1.2635f, 3.737267f);
                        temp.size = new Vector2(0.946557f, 0.5269639f);
                    }
                // Parede Esquerda Baixo
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(-2.947474f, 2.4732f);
                        temp.size = new Vector2(0.946557f, 0.5269639f);
                    }
                // Parede Direita Direita
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(2.947474f, 3.737267f);
                        temp.size = new Vector2(0.946557f, 0.5269639f);
                    }
                // Parede Direita Esquerda
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(1.2635f, 3.737267f);
                        temp.size = new Vector2(0.946557f, 0.5269639f);
                    }
                // Parede Direita Baixo
                    {
                        var temp = gameObject.AddComponent<BoxCollider2D>();
                        temp.offset = new Vector2(2.947474f, 2.4732f);
                        temp.size = new Vector2(0.946557f, 0.5269639f);
                    }
    }
}
