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
    private Button[] casas;
    [SerializeField]
    private GameObject[] vez;

    public Tabuleiro tabuleiro;
    [SerializeField]
    private Interagir interagir;
    [SerializeField]
    private Inimigo inimigo;
    [SerializeField]
    private Animator btnSorteioIA;

    private int i = 0;
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

        if (dificuldade == 1)
            tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.facil;
        else if (dificuldade == 2)
            tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.media;
        else if (dificuldade == 3)
            tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.dificil;
        else if (dificuldade == 4)
            tabuleiro.estrelas_E_Moedas.dificuldade = EnumDificuldade.superdificil;
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
                habJogador[0].interactable = true;
        }
        else if (i == 1)
            habJogador[1].interactable = true;
        else if (i == 2)
            habJogador[2].interactable = true;

        sortear[0].interactable = false;
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