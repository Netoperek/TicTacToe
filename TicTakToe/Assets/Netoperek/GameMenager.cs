using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour, IEnumPlayer
{
    IEnumPlayer.Player activePlayer = IEnumPlayer.Player.Empty;
    [SerializeReference] BoardMenager _board;
    [SerializeReference] ImageMenager _spriteMenager;
    [SerializeReference] Sprite _empty;
    Sprite playerX;
    Sprite playerO;

    private void Awake()
    {
        activePlayer = IEnumPlayer.Player.X;
        playerX = _spriteMenager.GetImageX(0);
        playerO = _spriteMenager.GetImageY(0);
    }

    public void OnClick(int index)
    {
        _board.GetButtonDate(index).Player = activePlayer;
        _board.GetButtonDate(index).Sprite = GetSpriteActivePlayer();
        _board.Check();
        ChangePlayer();
    }
    public Sprite GetSpriteActivePlayer()
    {
        switch (activePlayer)
        {
            case IEnumPlayer.Player.X:
                return playerX;
            case IEnumPlayer.Player.O:
                return playerO;
            case IEnumPlayer.Player.Empty:
                return _empty;
            default:
                return _empty;
        }
    }
    private void OnEnable()
    {
        _board.ShowWiner += ShwoWiner;
    }
    private void OnDisable()
    {
        _board.ShowWiner -= ShwoWiner;
    }
    void ShwoWiner(IEnumPlayer.Player player)
    {
        Debug.Log(player);
    }
    void ChangePlayer()
    {
        if (activePlayer == IEnumPlayer.Player.X)
        {
            activePlayer = IEnumPlayer.Player.O;
        }
        else
        {
            activePlayer = IEnumPlayer.Player.X;
        }
    }
}
