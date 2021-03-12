using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    //[SerializeField]
    //private Text textoSimbolo;

    private TipoJogador tipoJogador;

    private void Awake()
    {
        this.tipoJogador = TipoJogador.Nenhum;
    }

    public void OnClick()
    {
        this.tipoJogador = TipoJogador.Xis;
        Sortear.instancia.PassarVez();
        Interagir.instancia.Bloquear(false);

        /*
        if (this.tipoJogador == TipoJogador.Nenhum)
        {
            this.tipoJogador = TipoJogador.Xis;
            this.textoSimbolo.text = "X";
        }
        else if (this.tipoJogador == TipoJogador.Xis)
        {
            this.tipoJogador = TipoJogador.Bola;
            this.textoSimbolo.text = "O";
        }
        else if (this.tipoJogador == TipoJogador.Bola)
        {
            this.tipoJogador = TipoJogador.Nenhum;
            this.textoSimbolo.text = "";
        }*/
    }

    public TipoJogador TipoJogador
    {
        get
        {
            return this.tipoJogador;
        }
        set
        {
            this.tipoJogador = value;
        }
    }
}
