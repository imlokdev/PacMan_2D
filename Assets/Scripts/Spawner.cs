using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*
        Clyde (fantasma laranja) persegue Pac-Man quando est� longe dele, mas geralmente se afasta quando ele se aproxima; 
        Inky (fantasma �azul�) � programado para tentar cercar o jogador entre ele e 
        Blinky (fantasma vermelho) que, por sua vez, persegue o protagonista de forma obstinada, ao passo que 
        Pinky (fantasma rosa), flutua paralelamente ao jogador.
     */

    [SerializeField] private GameObject[] preFabs = new GameObject[4];
    public static GameObject[] ghosts = new GameObject[4];
    public static Queue<GameObject> ghostsFila = new Queue<GameObject>();
    private bool block1, block2;
    public float timeFree = 7f;

    private void Start()
    {
        ghostsFila.Clear();
        ghosts = new GameObject[4];
        if (!block2) StartCoroutine(Spawn());
    }

    private void LateUpdate()
    {
        if (ghostsFila.Count > 0 && !block1) StartCoroutine(FreeGhosts());
    }

    IEnumerator Spawn()
    {
        PacMan.blockMove = true;
        block2 = true;

        for (int i = 0; i < ghosts.Length; i++)
        {
            var temp = Instantiate(preFabs[i], SwitchPos(preFabs[i].name), Quaternion.identity);

            ghosts[i] = temp;
            ghostsFila.Enqueue(temp);
            yield return new WaitForSeconds(0.5f);
        }

        PacMan.blockMove = false;
        block2 = false;
    }

    IEnumerator FreeGhosts()
    {
        block1 = true;

        yield return new WaitForSeconds(timeFree);
        ghostsFila.Dequeue().GetComponent<Ghost>().Spawn();

        block1 = false;
    }

    Vector3 SwitchPos(string name)
    {
        switch (name)
        {
            case "Clyde": return new Vector3(-0.4f, 0.6f, 0f);
            case "Inky": return new Vector3(0.3f, 0.6f, 0f);
            case "Blinky": return new Vector3(-0.4f, 0.1f, 0f);
            case "Pinky": return new Vector3(0.3f, 0.1f, 0f);
            default: return Vector3.zero;
        }
    }

    public void ResetarGhosts()
    {
        foreach (var ghost in ghosts)
            Destroy(ghost);
        ghosts = new GameObject[4];
        ghostsFila.Clear();
        StartCoroutine(Spawn());
        PacMan.blockMove = false;
    }
}
