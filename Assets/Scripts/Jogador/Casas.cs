using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    [SerializeField]
    private Image xisImage;

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

    public void Clicou()
    {
        xisImage.gameObject.SetActive(true);
        this.tipoJogador = TipoJogador.Xis;
        sortear.PassarVez();
        interagir.Bloquear(false);
        sortear.SorteioIA();
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
