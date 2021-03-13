using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sortear : MonoBehaviour
{
    private int i = 0;

    //Botões
    public Button[] sortear;
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
        }
        else
        {
            vez[0].gameObject.SetActive(true);
            vez[1].gameObject.SetActive(false);
            vezJogador = true;
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
            Debug.Log(i + " bloquear jogador");
            bloquear[0].interactable = true;
        }
        else if (i == 4)
        {
            Debug.Log(i + " mudar jogador");
            mudar[0].interactable = true;
        }
        else if (i == 6)
        {
            Debug.Log(i + " retirar jogador");
            retirar[0].interactable = true;
        }
        else
            Debug.Log(i + " nada jogador");


        sortear[0].interactable = false;
    }

    public void SorteioIA()
    {
        i = Random.Range(1, 6);

        if (i == 2)
        {
            Debug.Log(i + " bloquear inimigo");
            bloquear[1].interactable = true;
        }
        else if (i == 4)
        {
            Debug.Log(i + " mudar inimigo");
            mudar[1].interactable = true;
        }
        else if (i == 6)
        {
            Debug.Log(i + " retirar inimigo");
            retirar[1].interactable = true;
        }
        else
            Debug.Log(i + " nada inimigo");


        sortear[1].interactable = false;
        Inimigo.instancia.Jogada();
    }
}
