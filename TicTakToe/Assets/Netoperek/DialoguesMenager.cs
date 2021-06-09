using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesMenager : MonoBehaviour
{
    [SerializeReference] GameObject bunnyWinnerDialogue;
    [SerializeReference] GameObject batWinnerDialogue;
    [SerializeReference] GameObject tieDialogue;

    public void Show(IEnumPlayer.Player player)
    {
        switch (player)
        {
            case IEnumPlayer.Player.Bat:
                batWinnerDialogue.SetActive(true);
                break;
            case IEnumPlayer.Player.Bunny:
                bunnyWinnerDialogue.SetActive(true);
                break;
            case IEnumPlayer.Player.Empty:
                tieDialogue.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void OnClick(int player)
    {
        switch ((IEnumPlayer.Player)player)
        {
            case IEnumPlayer.Player.Bat:
                Events.RestartBorad.Invoke();
                batWinnerDialogue.SetActive(false);
                break;
            case IEnumPlayer.Player.Bunny:
                Events.RestartBorad.Invoke();
                bunnyWinnerDialogue.SetActive(false);
                break;
            case IEnumPlayer.Player.Empty:
                Events.RestartBorad.Invoke();
                tieDialogue.SetActive(false);
                break;
            default:
                break;
        }
    }
    private void OnEnable()
    {
        Events.ShowDialogue += Show;
    }
    private void OnDisable()
    {
        Events.ShowDialogue -= Show;
    }
}
