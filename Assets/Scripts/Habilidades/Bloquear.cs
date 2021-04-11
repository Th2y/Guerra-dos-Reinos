using UnityEngine;

public class Bloquear : MonoBehaviour
{
    [SerializeField]
    private Habilidades habilidades;

    public void JogadorBloqueia()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "bloquear";
    }
}
