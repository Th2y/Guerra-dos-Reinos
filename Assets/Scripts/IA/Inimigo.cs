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
        if (tabuleiro.jogadas != tabuleiro.maxJogadas)
        {
            if (tabuleiro.jogadorDeX)
            {
                //Verificar se existe alguma possibilidade de vencer
                if (Verificar(TipoJogador.Bola))
                {
                    casas[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Verificar se existe alguma possibilidade de perder
                else if (Verificar(TipoJogador.Xis))
                {
                    casas[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Fazer uma jogada aleatória em qualquer casa vazia
                else
                    JogadaAleatoria();
            }
            else
            {
                //Verificar se existe alguma possibilidade de vencer
                if (Verificar(TipoJogador.Xis))
                {
                    casas[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Verificar se existe alguma possibilidade de perder
                else if (Verificar(TipoJogador.Bola))
                {
                    casas[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Fazer uma jogada aleatória em qualquer casa vazia
                else
                    JogadaAleatoria();
            }
        }
    }

    private void JogadaAleatoria()
    {
        casaJogar = Random.Range(0, 8);

        if (casasJogador[casaJogar].tipoJogador == TipoJogador.Nenhum)
        {
            casas[casaJogar].Jogar();
            iniciarJogada = false;
        }
        else
            JogadaAleatoria();
    }

    private bool Verificar(TipoJogador tipo)
    {
        for (int i = 0; i < 8; i++)
        {
            if (tabuleiro.combinacoes[i].casas[0].tipoJogador == TipoJogador.Nenhum)
            {
                if (tabuleiro.combinacoes[i].casas[1].tipoJogador == tipo && tabuleiro.combinacoes[i].casas[2].tipoJogador == tipo)
                {
                    casaJogar = tabuleiro.combinacoes[i].casas[0].numCasa;
                    return true;
                }
            }
            else if (tabuleiro.combinacoes[i].casas[1].tipoJogador == TipoJogador.Nenhum)
            {
                if (tabuleiro.combinacoes[i].casas[0].tipoJogador == tipo && tabuleiro.combinacoes[i].casas[2].tipoJogador == tipo)
                {
                    casaJogar = tabuleiro.combinacoes[i].casas[1].numCasa;
                    return true;
                }
            }
            else if (tabuleiro.combinacoes[i].casas[2].tipoJogador == TipoJogador.Nenhum)
            {
                if (tabuleiro.combinacoes[i].casas[0].tipoJogador == tipo && tabuleiro.combinacoes[i].casas[1].tipoJogador == tipo)
                {
                    casaJogar = tabuleiro.combinacoes[i].casas[2].numCasa;
                    return true;
                }
            }
        }

        return false;
    }

    public void Jogada()
    {
        iniciarJogada = true;
    }
}