using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sortear : MonoBehaviour
{
    //Botões
    public Button[] sortear;
    public Button[] habJogador;
    [SerializeField]
    private Button[] habIA;
    [SerializeField]
    private GameObject[] vez;

    public Tabuleiro tabuleiro;
    [SerializeField]
    private Interagir interagir;
    [SerializeField]
    private Inimigo inimigo;
    [SerializeField]
    private Animator btnSorteioIA;

    private int i = 100;
    private int chanceNadaJogador = 0;
    private int chanceNadaIA = 2;
    [SerializeField]
    private int dificuldade = 1;
    public bool vezJogador = true;
    public bool esperarSorteio = false;

    private void Start()
    {
        chanceNadaIA += dificuldade;
        chanceNadaJogador += dificuldade;

        switch (dificuldade)
        {
            case 1:
                tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.facil;
                break;
            case 2:
                tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.media;
                break;
            case 3:
                tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.dificil;
                break;
            default:
                tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.superdificil;
                break;
        }
    }

    public void DiminuirJogadas()
    {
        tabuleiro.jogadas--;
    }

    public void PassarVez()
    {
        PassouVez();
    }

    private void PassouVez()
    {
        tabuleiro.jogadas++;

        if (vezJogador)
        {
            vez[1].gameObject.SetActive(true);
            vez[0].gameObject.SetActive(false);
            vezJogador = false;

            for(int i = 0; i < habJogador.Length; i++)
            {
                habJogador[i].interactable = false;
                habJogador[i].gameObject.SetActive(false);
            }
        }
        else
        {
            vez[0].gameObject.SetActive(true);
            vez[1].gameObject.SetActive(false);
            vezJogador = true;

            for (int i = 0; i < habIA.Length; i++)
            {
                habIA[i].interactable = false;
            }
        }
    }

    public void SortearNum()
    {
        esperarSorteio = true;

        if (!vezJogador)
        {
            i = Random.Range(0, habIA.Length + chanceNadaIA);
            btnSorteioIA.Play("Sortear");
        }
        else
            i = Random.Range(0, habJogador.Length + chanceNadaJogador);
    }

    public void Sorteio()
    {
        esperarSorteio = false;
        interagir.Bloquear(true);

        if (i == 0)
        {
            if ((tabuleiro.jogadorDeX && tabuleiro.jogadas < 9) || (!tabuleiro.jogadorDeX && tabuleiro.jogadas < 8))
            {
                habJogador[0].interactable = true;
                habJogador[0].gameObject.SetActive(true);
            }
        }
        else if (i == 1)
        {
            habJogador[1].interactable = true;
            habJogador[1].gameObject.SetActive(true);
        }
        else if (i == 2)
        {
            habJogador[2].interactable = true;
            habJogador[2].gameObject.SetActive(true);
        }

        sortear[0].interactable = false;
        sortear[0].gameObject.SetActive(false);
    }

    public void SorteioIA()
    {
        esperarSorteio = false;

        if (i == 0)
        {
            if((tabuleiro.jogadorDeX && tabuleiro.jogadas < 8) || (!tabuleiro.jogadorDeX && tabuleiro.jogadas < 9))
                habIA[0].interactable = true;
        }
        else if (i == 1)
            habIA[1].interactable = true;
        else if (i == 2)
            habIA[2].interactable = true;

        sortear[1].interactable = false;
        inimigo.Jogar();
    }
}