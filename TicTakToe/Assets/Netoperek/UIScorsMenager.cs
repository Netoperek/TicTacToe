using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScorsMenager : MonoBehaviour
{
    [SerializeField] Color inactiveColor;
    [SerializeReference] Text scoreBat;
    [SerializeReference] Text scoreBunny;
    [SerializeReference] Image imageBat;
    [SerializeReference] Image imageBunny;
    [SerializeReference] Image imageBackBat;
    [SerializeReference] Image imageBackBunny;
    uint conterScoreBat;
    uint conterScoreBunny;
    private void Awake()
    {
        scoreBat.text = "0";
        scoreBunny.text = "0";
        conterScoreBat = 0;
        conterScoreBunny = 0;
    }
    private void OnEnable()
    {
        Events.AddPoint += AddPoint;
        Events.ChangePlayer += ShowActivePlayer;
        Events.RestartGame += Reset;
    }
    private void OnDisable()
    {
        Events.AddPoint -= AddPoint;
        Events.ChangePlayer -= ShowActivePlayer;
        Events.RestartGame -= Reset;
    }
    private void Reset()
    {
        scoreBat.text = "0";
        scoreBunny.text = "0";
        conterScoreBat = 0;
        conterScoreBunny = 0;
    }
    private void ChangeColor(IEnumPlayer.Player activePlayer, Color active, Color inactive)
    {
        switch (activePlayer)
        {
            case IEnumPlayer.Player.Bat:
                imageBackBat.color = active;
                imageBat.color = active;
                imageBackBunny.color = inactive;
                imageBunny.color = inactive;
                break;
            case IEnumPlayer.Player.Bunny:
                imageBackBat.color = inactive;
                imageBat.color = inactive;
                imageBackBunny.color = active;
                imageBunny.color = active;
                break;
            default:
                imageBackBat.color = inactive;
                imageBat.color = inactive;
                imageBackBunny.color = inactive;
                imageBunny.color = inactive;
                break;
        }

    }
    private void ShowActivePlayer(IEnumPlayer.Player player)
    {
        switch (player)
        {
            case IEnumPlayer.Player.Bat:
                ChangeColor(player, Color.white, inactiveColor);
                break;
            case IEnumPlayer.Player.Bunny:
                ChangeColor(player, Color.white, inactiveColor);
                break;
            default:
                ChangeColor(player, Color.white, inactiveColor);
                break;
        }
    }

    private void AddPoint(IEnumPlayer.Player player)
    {
        switch (player)
        {
            case IEnumPlayer.Player.Bat:
                conterScoreBat++;
                scoreBat.text = conterScoreBat.ToString();
                break;
            case IEnumPlayer.Player.Bunny:
                conterScoreBunny++;
                scoreBunny.text = conterScoreBat.ToString();
                break;
            case IEnumPlayer.Player.Empty:
                conterScoreBat++;
                conterScoreBunny++;
                scoreBunny.text = conterScoreBat.ToString();
                scoreBat.text = conterScoreBat.ToString();
                break;
            default:
                break;
        }
    }
}
