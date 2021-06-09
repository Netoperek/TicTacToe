using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour, IEnumPlayer
{

    IEnumPlayer.Player playerWin = IEnumPlayer.Player.Empty;
    public static Action<int> PlayerClick;
    IEnumPlayer.Player playerStart = IEnumPlayer.Player.Empty;
    IEnumPlayer.Player activePlayer = IEnumPlayer.Player.Empty;
    [SerializeReference] BoardMenager _board;
    [SerializeReference] ImageMenager _spriteMenager;
    [SerializeReference] Sprite _empty;
    [SerializeReference] Line line;
    Sprite playerX;
    Sprite playerO;

    private void Awake()
    {

        activePlayer = IEnumPlayer.Player.Bat;
        playerStart = activePlayer;
        playerX = _spriteMenager.GetImageX(0);
        playerO = _spriteMenager.GetImageY(0);
        if (Events.ChangePlayer != null)
        {
            Events.ChangePlayer.Invoke(activePlayer);
        }
    }

    public void OnClick(int index)
    {
        _board.GetButtonDate(index).ImageVisible = true;
        _board.GetButtonDate(index).Player = activePlayer;
        _board.GetButtonDate(index).Sprite = GetSpriteActivePlayer();
        PlayerClick(index);
        _board.Check();
        // ChangePlayer();
    }
    public Sprite GetSpriteActivePlayer()
    {
        switch (activePlayer)
        {
            case IEnumPlayer.Player.Bat:
                return playerX;
            case IEnumPlayer.Player.Bunny:
                return playerO;
            case IEnumPlayer.Player.Empty:
                return _empty;
            default:
                return _empty;
        }
    }
    private void OnEnable()
    {
        //events.Win += Win;
        //Line.GameWin += GameWin;
        Events.GameWin += GameWin;
        BoardMenager.ActiveLineComponent += line.Enable;
        Events.WhoWin += SetWiner;
        Events.PlayerMoved += ChangePlayer;
        Events.RestartBorad += Reset;
        Events.RestartGame += Reset;

    }
    private void OnDisable()
    {
        //events.Win -= Win;
        // Line.GameWin -= GameWin;
        Events.GameWin -= GameWin;
        BoardMenager.ActiveLineComponent -= line.Enable;
        Events.WhoWin -= SetWiner;
        Events.PlayerMoved -= ChangePlayer;
        Events.RestartBorad -= Reset;
        Events.RestartGame -= Reset;

    }
    void SetWiner(IEnumPlayer.Player player)
    {
        playerWin = player;
    }
    void GameWin()
    {
        if (Events.ShowDialogue != null)
        {
            Events.ShowDialogue.Invoke(playerWin);
        }
        if (Events.AddPoint != null)
        {
            Events.AddPoint(playerWin);
        }
        
    }
    void ChangePlayer()
    {
        if (activePlayer == IEnumPlayer.Player.Bat)
        {
            activePlayer = IEnumPlayer.Player.Bunny;
        }
        else
        {
            activePlayer = IEnumPlayer.Player.Bat;
        }
        if (Events.ChangePlayer != null)
        {
            Events.ChangePlayer.Invoke(activePlayer);
        }
    }
    private void Reset()
    {
        playerWin = IEnumPlayer.Player.Empty;
        #region Change Player On Start
        if (playerStart != IEnumPlayer.Player.Bat)
        {
            activePlayer = IEnumPlayer.Player.Bat;
            playerStart = activePlayer;
        }
        else
        {
            activePlayer = IEnumPlayer.Player.Bunny;
            playerStart = activePlayer;
        }
        if (Events.ChangePlayer != null)
        {
            Events.ChangePlayer.Invoke(activePlayer);
        }
        #endregion
    }
}
