﻿using UnityEngine;
using UnityEngine.UI;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    private Button[] casas;

    public static Interagir instancia;

    private void Start()
    {
        instancia = this;
    }

    public void Bloquear(bool bloqueio)
    {
        for (int i = 0; i < casas.Length; i++)
        {
            casas[i].interactable = bloqueio;
        }
    }
}