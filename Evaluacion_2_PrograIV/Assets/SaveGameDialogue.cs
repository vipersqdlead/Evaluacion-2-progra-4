using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameDialogue : MonoBehaviour
{
    public GameObject savegamePanel;
    public PjLoader loader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            savegamePanel.SetActive(true);
            loader.Load();
        }
    }
}
