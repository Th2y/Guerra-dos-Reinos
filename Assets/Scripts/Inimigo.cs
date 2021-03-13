using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int casaJogar;

    private TipoJogador tipoJogador;
    public static Inimigo instancia;
    [SerializeField]
    private CasasInimigo[] casas;
    [SerializeField]
    private Casas[] casasJogador;

    private void Awake()
    {
        this.tipoJogador = TipoJogador.Nenhum;
    }

    private void Start()
    {
        instancia = this;
    }

    public void Jogada()
    {
        casaJogar = Random.Range(0, 8);

        if (casasJogador[casaJogar].tipoJogador == TipoJogador.Nenhum)
            casas[casaJogar].Jogar();
        else
            Jogada();
    }
}
