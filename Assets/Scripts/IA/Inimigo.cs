using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int casaJogar;
    public bool iniciarJogada = false;

    [SerializeField]
    private CasasInimigo[] casas;
    [SerializeField]
    private Casas[] casasJogador;

    [SerializeField]
    private Tabuleiro tabuleiro;

    public void Jogar()
    {
        if (tabuleiro.jogadas != 9)
        {
            casaJogar = Random.Range(0, 8);

            if (casasJogador[casaJogar].tipoJogador == TipoJogador.Nenhum)
                casas[casaJogar].Jogar();
            else
                Jogar();
        }
        iniciarJogada = false;
    }

    public void Jogada()
    {
        iniciarJogada = true;
    }
}
