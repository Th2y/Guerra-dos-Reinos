using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    [SerializeField]
    private Button casa;

    public TipoJogador tipoJogador;
    public static TipoJogador tipos;
    public static Casas instancia;

    private void Awake()
    {
        instancia = this;

        this.tipoJogador = TipoJogador.Nenhum;
        tipos = tipoJogador;
    }

    public void OnClick()
    {
        if (this.tipoJogador == TipoJogador.Nenhum)
        {
            this.tipoJogador = TipoJogador.Xis;
            Sortear.instancia.PassarVez();
            Interagir.instancia.Bloquear(false);
            Sortear.instancia.SorteioIA();
        }
        else if (this.tipoJogador == TipoJogador.Xis)
        {
            casa.interactable = false;
        }
        else if (this.tipoJogador == TipoJogador.Bola)
        {
            casa.interactable = false;
        }
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
