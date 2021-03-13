using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int casaJogar;

    [SerializeField]
    private CasasInimigo[] casas;
    [SerializeField]
    private Casas[] casasJogador;

    [SerializeField]
    private Tabuleiro tabuleiro;

    public void Jogada()
    {
        if(tabuleiro.jogadas != 9)
        {
            casaJogar = Random.Range(0, 8);

            if (casasJogador[casaJogar].tipoJogador == TipoJogador.Nenhum)
                casas[casaJogar].Jogar();
            else
                Jogada();
        }
    }
}
