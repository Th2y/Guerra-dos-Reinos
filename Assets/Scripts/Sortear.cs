using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sortear : MonoBehaviour
{
    private int i = 0;

    //Botões
    [SerializeField]
    private Button[] sortear;
    [SerializeField]
    private Button[] bloquear;
    [SerializeField]
    private Button[] mudar;
    [SerializeField]
    private Button[] retirar;
    [SerializeField]
    private Button[] casas;
    [SerializeField]
    private TextMeshProUGUI[] vez;

    public bool vezJogador = true;
    public static Sortear instancia;

    private void Start()
    {
        instancia = this;
    }

    public void PassarVez()
    {
        PassouVez();
    }

    private void PassouVez()
    {
        if (vezJogador)
        {
            vez[1].gameObject.SetActive(true);
            vez[0].gameObject.SetActive(false);
            vezJogador = false;
            Debug.Log("Vez do inimigo");
        }
        else
        {
            vez[0].gameObject.SetActive(true);
            vez[1].gameObject.SetActive(false);
            vezJogador = true;
            Debug.Log("Vez do jogador");
        }
    }

    public void Sorteio()
    {
        i = Random.Range(1, 6);
        for (int a = 0; a < 9; a++)
        {
            //Conferir se a casa não está ocupada, caso sim, verificar se pelo jogador ou pelo inimigo
            casas[a].interactable = true;
        }

        if (i == 2)
        {
            Debug.Log(i + " bloquear");
            bloquear[0].interactable = true;
        }
        else if (i == 4)
        {
            Debug.Log(i + " mudar");
            mudar[0].interactable = true;
        }
        else if (i == 6)
        {
            Debug.Log(i + " retirar");
            retirar[0].interactable = true;
        }
        else
            Debug.Log(i + " nada");


        sortear[0].interactable = false;
    }

    public void SorteioIA()
    {
        i = Random.Range(1, 6);

        if (i == 2)
        {
            Debug.Log(i + " bloquear");
            bloquear[1].interactable = true;
        }
        else if (i == 4)
        {
            Debug.Log(i + " mudar");
            mudar[1].interactable = true;
        }
        else if (i == 6)
        {
            Debug.Log(i + " retirar");
            retirar[1].interactable = true;
        }
        else
            Debug.Log(i + " nada");


        sortear[1].interactable = false;
        Inimigo.instancia.Jogada();
    }
}
