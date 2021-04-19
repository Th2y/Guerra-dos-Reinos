using UnityEngine;
using TMPro;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField]
    private GameObject painelVencedor;
    [SerializeField]
    private TextMeshProUGUI vencedor;

    public int maxJogadas = 9;
    public bool jogadorDeX = true;
    public int jogadas = 0;
    private bool jaTerminou = false;

    // Lista de combinações possíveis para ganhar o jogo
    public Combinacoes[] combinacoes;
    [SerializeField]
    private Vidas vidas;

    private void Update()
    {
        if (!jaTerminou)
        {
            TipoJogador jogadorVencedor = ObterVencedor();

            if (jogadorVencedor != TipoJogador.Nenhum)
            {
                painelVencedor.SetActive(true);

                if (jogadorVencedor == TipoJogador.Bola)
                {
                    vencedor.text = "O reino das Bolas venceu a partida!";
                    vidas.PerderVida();
                }
                else if (jogadorVencedor == TipoJogador.Xis)
                    vencedor.text = "O reino dos Xis venceu a partida!";

                jaTerminou = true;
                Time.timeScale = 0f;
            }
            else if (jogadas == 9)
            {
                painelVencedor.SetActive(true);
                vencedor.text = "O reino das Bolas e dos Xis chegaram a um acordo e empataram a partida!";
                jaTerminou = true;
                Time.timeScale = 0f;
            }
        }
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
