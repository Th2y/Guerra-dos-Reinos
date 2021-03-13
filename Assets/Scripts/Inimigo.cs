using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int casaJogar;

    private TipoJogador tipoJogador;
    public static Inimigo instancia;
    [SerializeField]
    private CasasInimigo[] casas;

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
        Debug.Log(casas[casaJogar]);
        casas[casaJogar].Jogar();
    }
}
