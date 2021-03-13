using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    [SerializeField]
    private Button casa;

    [SerializeField]
    private Interagir interagir;
    [SerializeField]
    private Sortear sortear;

    public TipoJogador tipoJogador;
    public static TipoJogador tipos;

    private void Awake()
    {
        this.tipoJogador = TipoJogador.Nenhum;
        tipos = tipoJogador;
    }

    public void OnClick()
    {
        if (this.tipoJogador == TipoJogador.Nenhum)
        {
            this.tipoJogador = TipoJogador.Xis;
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SorteioIA();
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
