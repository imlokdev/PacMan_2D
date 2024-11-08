using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    public static Stack<GameObject> coins = new Stack<GameObject>();
    public static bool block = true;
    [SerializeField] GameObject[] preFabs = new GameObject[2];

    private void Awake() => GerarMoedas();
    private void Start() => block = true;
    public static void ArmazenarMoeda(GameObject coin) => coins.Push(coin);

    private void Update()
    {
        if (!block) StartCoroutine(RecolocarMoedas());
    }

    private IEnumerator RecolocarMoedas()
    {
        block = true;

        foreach (var item in coins)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        coins.Clear();
        PacMan.blockMove = false;
    }

    private void GerarMoedas()
    {
        for (int i = 0; i <= 6; i++)
            Instantiate(preFabs[0], new Vector3(-3.8f, 4.4f, 0f) + new Vector3((float)i * 0.55f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 5; i++)
        {
            if (i == 2) Instantiate(preFabs[1], new Vector3(-3.8f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.53f, 0f), Quaternion.identity);
            else if (i != 0) Instantiate(preFabs[0], new Vector3(-3.8f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.53f, 0f), Quaternion.identity);
        }

        for (int i = 0; i <= 6; i++)
            Instantiate(preFabs[0], new Vector3(0.4f, 4.4f, 0f) + new Vector3((float)i * 0.55f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 5; i++)
        {
            if (i == 2) Instantiate(preFabs[1], new Vector3(3.7f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.53f, 0f), Quaternion.identity);
            else if (i != 0) Instantiate(preFabs[0], new Vector3(3.7f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.53f, 0f), Quaternion.identity);
        }

        for (int i = 0; i <= 15; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-2.15f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.51f, 0f), Quaternion.identity);

        for (int i = 0; i <= 15; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(2.05f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.51f, 0f), Quaternion.identity);

        for (int i = 0; i <= 13; i++)
            if (i != 0 && i != 3 && i != 11) if (i != 0) Instantiate(preFabs[0], new Vector3(-3.8f, 3.131f, 0f) + new Vector3((float)i * 0.55f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-3.8f, 1.75f, 0f) + new Vector3((float)i * 0.55f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(3.7f, 1.75f, 0f) + new Vector3((float)-i * 0.55f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-0.4999998f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(0.4f, 4.4f, 0f) + new Vector3(0f, (float)-i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(1.27f, 3.131f, 0f) + new Vector3(0f, (float)-i * 0.45f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-1.301f, 3.131f, 0f) + new Vector3(0f, (float)-i * 0.45f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-1.301f, 2.231f, 0f) + new Vector3((float)i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(1.27f, 2.231f, 0f) + new Vector3((float)-i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 8; i++)
            if (i != 4) Instantiate(preFabs[0], new Vector3(-3.901f, -1.514f, 0f) + new Vector3((float)i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 8; i++)
            if (i != 4) Instantiate(preFabs[0], new Vector3(3.901f, -1.514f, 0f) + new Vector3((float)-i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
        {
            if (i == 1) Instantiate(preFabs[1], new Vector3(-3.901f, -1.514f, 0f) + new Vector3(0f, (float)-i * 0.45f, 0f), Quaternion.identity);
            else if (i != 0) Instantiate(preFabs[0], new Vector3(-3.901f, -1.514f, 0f) + new Vector3(0f, (float)-i * 0.45f, 0f), Quaternion.identity);
        }

        for (int i = 0; i <= 2; i++)
        {
            if (i == 1) Instantiate(preFabs[1], new Vector3(3.901f, -1.514f, 0f) + new Vector3(0f, (float)-i * 0.45f, 0f), Quaternion.identity);
            else if (i != 0) Instantiate(preFabs[0], new Vector3(3.901f, -1.514f, 0f) + new Vector3(0f, (float)-i * 0.45f, 0f), Quaternion.identity);
        }

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-3.901f, -2.414f, 0f) + new Vector3((float)i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(3.901f, -2.414f, 0f) + new Vector3((float)-i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-3.001f, -2.414f, 0f) + new Vector3(0f, (float)-i * 0.42f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(3.001f, -2.414f, 0f) + new Vector3(0f, (float)-i * 0.42f, 0f), Quaternion.identity);

        for (int i = 0; i <= 4; i++)
            if (i != 0 && i != 2) Instantiate(preFabs[0], new Vector3(-2.15f, -3.25f, 0f) + new Vector3((float)-i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 4; i++)
            if (i != 0 && i != 2) Instantiate(preFabs[0], new Vector3(2.05f, -3.25f, 0f) + new Vector3((float)i * 0.45f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 3; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-3.95f, -3.25f, 0f) + new Vector3(0f, (float)-i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 18; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-3.95f, -4.54f, 0f) + new Vector3((float)i * 0.43f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(3.79f, -4.54f, 0f) + new Vector3(0f, (float)i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 3; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-0.51f, -4.54f, 0f) + new Vector3(0f, (float)i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 3; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(0.3500001f, -4.54f, 0f) + new Vector3(0f, (float)i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-0.51f, -3.25f, 0f) + new Vector3((float)-i * 0.43f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(0.3500001f, -3.25f, 0f) + new Vector3((float)i * 0.43f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(-1.37f, -3.25f, 0f) + new Vector3(0f, (float)i * 0.43f, 0f), Quaternion.identity);

        for (int i = 0; i <= 2; i++)
            if (i != 0) Instantiate(preFabs[0], new Vector3(1.21f, -3.25f, 0f) + new Vector3(0f, (float)i * 0.43f, 0f), Quaternion.identity);
    }
}