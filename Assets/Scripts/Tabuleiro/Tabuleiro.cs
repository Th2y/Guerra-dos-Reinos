using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tabuleiro : MonoBehaviour
{
    [Header("Músicas")]
    [SerializeField]
    private AudioSource musicaEmJogo;
    [SerializeField]
    private AudioSource musicaFimDeJogo;

    [Header ("Final de jogo")]

    [SerializeField]
    private GameObject painelVencedor;
    [SerializeField]
    private TextMeshProUGUI vencedor;
    public Estrelas_e_Moedas estrelas_E_Moedas;

    [Header ("Variaveis")]

    public int maxJogadas = 9;
    public int jogadas = 0;
    public bool jogadorDeX = true;
    private bool jogadorVenceu = false;

    private TipoJogador jogadorAtual;
    private bool jaTerminou = false;
    private bool jaPegouRecompensas = false;
    private float tempoDecorrido = 0f;
    private string nomeDaCena;
    private int numDaCena;
    private int numEstrelas = 0;

    // Lista de combinações possíveis para ganhar o jogo
    [Header ("Classes")]

    public Combinacoes[] combinacoes;
    [SerializeField]
    private Vidas vidas;
    [SerializeField]
    private Sortear sortear;

    private void Start()
    {
        nomeDaCena = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;

        if (jogadorDeX)
            jogadorAtual = TipoJogador.Xis;
        else
            jogadorAtual = TipoJogador.Bola;
    }

    private void Update()
    {
        if (sortear.vezJogador && !jaTerminou)
            tempoDecorrido += Time.deltaTime;

        TipoJogador jogadorVencedor = ObterVencedor();

        if (!jaTerminou)
            AindaJogando(jogadorVencedor);

        else if (!jaPegouRecompensas)
        {
            PegarRecompensas(jogadorVencedor);
            jaPegouRecompensas = true;
            Time.timeScale = 0f;
        }
    }

    private void AindaJogando(TipoJogador jogadorVencedor)
    {
        if (jogadorVencedor != TipoJogador.Nenhum)
        {
            musicaEmJogo.Pause();
            musicaFimDeJogo.Play();
            painelVencedor.SetActive(true);

            if (jogadorVencedor == TipoJogador.Bola)
            {
                vencedor.text = "O reino das Bolas venceu a partida!";
                if (jogadorDeX)
                {
                    vidas.PerderVida();
                }
            }
            else if (jogadorVencedor == TipoJogador.Xis)
            {
                vencedor.text = "O reino dos Xis venceu a partida!";
                if (!jogadorDeX)
                {
                    vidas.PerderVida();
                }
            }            

            jaTerminou = true;
        }
        else if (jogadas == 9)
        {
            painelVencedor.SetActive(true);
            vencedor.text = "O reino das Bolas e dos Xis chegaram a um acordo e empataram a partida!";
            jaTerminou = true;
        }
    }

    private void PegarRecompensas(TipoJogador jogadorVencedor)
    {
        if (jogadorVencedor == jogadorAtual)
        {
            jogadorVenceu = true;

            if (estrelas_E_Moedas.dificuldade == EnumDificuldade.facil)
            {
                if (tempoDecorrido <= 140f)
                    numEstrelas = 3;
                else if (tempoDecorrido <= 240f)
                    numEstrelas = 2;
                else
                    numEstrelas = 1;
            }
            else if (estrelas_E_Moedas.dificuldade == EnumDificuldade.media)
            {
                if (tempoDecorrido <= 150f)
                    numEstrelas = 3;
                else if (tempoDecorrido <= 245f)
                    numEstrelas = 2;
                else
                    numEstrelas = 1;
            }
            else if (estrelas_E_Moedas.dificuldade == EnumDificuldade.dificil)
            {
                if (tempoDecorrido <= 160f)
                    numEstrelas = 3;
                else if (tempoDecorrido <= 255f)
                    numEstrelas = 2;
                else
                    numEstrelas = 1;
            }
            else
            {
                if (tempoDecorrido <= 170f)
                    numEstrelas = 3;
                else if (tempoDecorrido <= 260f)
                    numEstrelas = 2;
                else
                    numEstrelas = 1;
            }
        }
        else if (jogadorVencedor == TipoJogador.Nenhum)
        {
            if (estrelas_E_Moedas.dificuldade == EnumDificuldade.facil || estrelas_E_Moedas.dificuldade == EnumDificuldade.media)
                numEstrelas = 2;
            else
                numEstrelas = 1;
        }
        else
        {
            numEstrelas = 0;
            estrelas_E_Moedas.MoedaAoPerder();
        }

        if (numEstrelas > PlayerPrefs.GetInt("Estrelas" + nomeDaCena))
            PlayerPrefs.SetInt("Estrelas" + nomeDaCena, numEstrelas);

        estrelas_E_Moedas.DefinirEstrelasEMoedas(numEstrelas, jogadorVenceu);
    }

    public TipoJogador ObterVencedor()
    {
        foreach (Combinacoes combinacao in this.combinacoes)
        {
            if (combinacao.EstaCompleta())
            {
                return combinacao.ObterTipoJogadorVencedor();
            }
        }
        return TipoJogador.Nenhum;
    }
}
