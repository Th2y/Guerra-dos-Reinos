using UnityEngine;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    float volumeMax, volumeEfeitos, volumeMusicas;
    public Slider sliderMax, sliderEfeitos, sliderMusicas;

    void Start()
    {
        //Tudo
        if (!PlayerPrefs.HasKey("Maximo"))
            sliderMax.value = 1;
        else
            sliderMax.value = PlayerPrefs.GetFloat("Maximo");

        //Efeitos
        if (!PlayerPrefs.HasKey("Efeitos"))
            sliderEfeitos.value = 1;
        else
            sliderEfeitos.value = PlayerPrefs.GetFloat("Efeitos");

        //Musicas
        if (!PlayerPrefs.HasKey("Musicas"))
            sliderMusicas.value = 1;
        else
            sliderMusicas.value = PlayerPrefs.GetFloat("Musicas");
    }

    public void VolumeMaximo(float volume)
    {
        volumeMax = volume;
        AudioListener.volume = volumeMax;

        PlayerPrefs.SetFloat("Maximo", volumeMax);
    }

    public void VolumeEfeitos(float volume)
    {
        volumeEfeitos = volume;
        GameObject[] efeito = GameObject.FindGameObjectsWithTag("Efeitos");
        if (efeito.Length > 0)
        {
            for (int i = 0; i < efeito.Length; i++)
            {
                efeito[i].GetComponent<AudioSource>().volume = volumeEfeitos;
            }
        }

        PlayerPrefs.SetFloat("Efeitos", volumeEfeitos);
    }

    public void VolumeMusicas(float volume)
    {
        volumeMusicas = volume;
        /*GameObject[] musica = GameObject.FindGameObjectsWithTag("Musicas");
        if (musica.Length > 0)
        {
            for (int i = 0; i < musica.Length; i++)
            {
                musica[i].GetComponent<AudioSource>().volume = volumeMusicas;
            }
        }*/

        PlayerPrefs.SetFloat("Musicas", volumeMusicas);
    }
}