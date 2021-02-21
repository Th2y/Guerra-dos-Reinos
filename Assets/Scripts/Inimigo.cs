using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private GameObject[] vez;

    public void PassarVez()
    {
        vez[0].SetActive(true);
        vez[1].SetActive(false);
        Debug.Log("Vez do jogador");
    }
}
