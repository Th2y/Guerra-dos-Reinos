using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogadas : MonoBehaviour
{
    [SerializeField]
    private Button[] casas;
    [SerializeField]
    private Button[] habilidades;

    public void Jogou(int i)
    {
        for (int a = 0; a < 9; a++)
        {
            casas[a].interactable = false;
        }
        for (int a = 0; a < 3; a++)
        {
            habilidades[a].interactable = false;
        }

        //Determina em qual casa o jogador clicou, fazer os valores serem salvos
        switch (i)
        {
            case 0:
                Debug.Log("Casa 1");
                break;
            case 1:
                Debug.Log("Casa 2");
                break;
            case 2:
                Debug.Log("Casa 3");
                break;
            case 3:
                Debug.Log("Casa 4");
                break;
            case 4:
                Debug.Log("Casa 5");
                break;
            case 5:
                Debug.Log("Casa 6");
                break;
            case 6:
                Debug.Log("Casa 7");
                break;
            case 7:
                Debug.Log("Casa 8");
                break;
            case 8:
                Debug.Log("Casa 9");
                break;
        }
        Sortear.instancia.PassarVez();
    }
}