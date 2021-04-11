using UnityEngine;
using TMPro;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField]
    private GameObject painelVencedor;
    [SerializeField]
    private TextMeshProUGUI vencedor;

    public int jogadas = 0;
    private bool jaTerminou = false;

    // Lista de combinações possíveis para ganhar o jogo
    [SerializeField]
    private Combinacoes[] combinacoes;
    [SerializeField]
    private Vidas vidas;

    public void Update()
    {
        TipoJogador jogadorVencedor = ObterVencedor();
        if (jogadorVencedor != TipoJogador.Nenhum)
        {
            painelVencedor.SetActive(true);

            if(jogadorVencedor == TipoJogador.Bola && !jaTerminou)
            {
                vencedor.text = "O reino das " + jogadorVencedor.ToString() + " venceu a partida!";
                vidas.PerderVida();
                jaTerminou = true;
            }
            else if(jogadorVencedor == TipoJogador.Xis && !jaTerminou)
            {
                vencedor.text = "O reino dos " + jogadorVencedor.ToString() + " venceu a partida!";
                jaTerminou = true;
            }
            else if(jogadas == 9 && !jaTerminou)
            {
                vencedor.text = "O reino das Bolas e dos Xis chegaram a um acordo e empataram a partida!";
                jaTerminou = true;
            }

            Time.timeScale = 0f;
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
