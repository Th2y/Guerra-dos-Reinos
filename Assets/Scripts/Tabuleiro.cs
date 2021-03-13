using UnityEngine;
using TMPro;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField]
    private GameObject painelVencedor;
    [SerializeField]
    private TextMeshProUGUI vencedor;

    public int jogadas = 0;

    // Lista de combinações possíveis para ganhar o jogo
    [SerializeField]
    private Combinacoes[] combinacoes;

    public void Update()
    {
        TipoJogador jogadorVencedor = ObterVencedor();
        if (jogadorVencedor != TipoJogador.Nenhum)
        {
            painelVencedor.SetActive(true);

            if(jogadorVencedor == TipoJogador.Bola)
                vencedor.text = "O reino das " + jogadorVencedor.ToString() + " venceu a partida!";
            else if(jogadorVencedor == TipoJogador.Xis)
                vencedor.text = "O reino dos " + jogadorVencedor.ToString() + " venceu a partida!";
            else if(jogadas == 9)
                vencedor.text = "O reino das Bolas e dos Xis chegaram a um acordo e empataram a partida!";

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
