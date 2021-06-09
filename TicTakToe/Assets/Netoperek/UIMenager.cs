using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenager : MonoBehaviour
{
    [SerializeReference] GameObject mainMenu;
    public void UISetActiveMainMenu(bool Open)
    {
        mainMenu.SetActive(Open);
        if (Events.RestartGame != null)
        {
            Events.RestartGame.Invoke();
        }
    }
    public void PlayerVsPlayer()
    {
        UISetActiveMainMenu(false);
    }
}
