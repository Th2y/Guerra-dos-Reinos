using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumEstrelasMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] estrelas;

    public void ExibirEstrelas(int num)
    {
        for (int i = 0; i < num; i++){
            estrelas[i].SetActive(true);
        }
    }
}
