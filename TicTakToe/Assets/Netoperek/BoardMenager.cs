using System;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMenager : MonoBehaviour, IEnumPlayer
{
    public event Action<IEnumPlayer.Player> ShowWiner;
    Dictionary<int, ButtonDate> filds;
    [SerializeField] List<int> Index;
    [SerializeReference] List<ButtonDate> buttonDates;
    private void OnEnable()
    {
        filds = new Dictionary<int, ButtonDate>();
        for (int i = 0; i < Index.Count; i++)
        {
            filds.Add(Index[i], buttonDates[i]);
        }
    }
    private void OnDisable()
    {
        filds = null;
    }

    public ButtonDate GetButtonDate(int index)
    {
        return filds[index];
    }
    public void Check()
    {
        #region Poziomo
        if (filds[11].Player != IEnumPlayer.Player.Empty && filds[11].Player == filds[12].Player && filds[11].Player == filds[13].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[11].Player);
            }
        }
        else if (filds[21].Player != IEnumPlayer.Player.Empty && filds[21].Player == filds[22].Player && filds[21].Player == filds[23].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[21].Player);
            }
        }
        else if (filds[31].Player != IEnumPlayer.Player.Empty && filds[31].Player == filds[32].Player && filds[31].Player == filds[33].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[31].Player);
            }
        }
        #endregion
        #region Pionowo
        else if (filds[11].Player != IEnumPlayer.Player.Empty && filds[11].Player == filds[21].Player && filds[11].Player == filds[31].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[11].Player);
            }
        }
        else if (filds[12].Player != IEnumPlayer.Player.Empty && filds[12].Player == filds[22].Player && filds[12].Player == filds[32].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[12].Player);
            }
        }
        else if (filds[13].Player != IEnumPlayer.Player.Empty && filds[13].Player == filds[23].Player && filds[13].Player == filds[33].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[13].Player);
            }
        }
        #endregion
        #region Skos
        else if (filds[11].Player != IEnumPlayer.Player.Empty && filds[11].Player == filds[22].Player && filds[11].Player == filds[33].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[11].Player);
            }
        }
        else if (filds[13].Player != IEnumPlayer.Player.Empty && filds[13].Player == filds[22].Player && filds[13].Player == filds[31].Player)
        {
            if (ShowWiner != null)
            {
                ShowWiner(filds[13].Player);
            }
        }
        #endregion
    }
}
