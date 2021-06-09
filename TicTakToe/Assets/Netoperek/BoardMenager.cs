using System;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMenager : MonoBehaviour, IEnumPlayer
{
    //public event Action<IEnumPlayer.Player> ShowPlayerWiner;
    public static event Action DisableButton;
    public static event Action<int> EnableChackButton;
    public static event Action ActiveLineComponent;
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
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[11].Player);

            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[11].GetIndex);
                EnableChackButton(filds[12].GetIndex);
                EnableChackButton(filds[13].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }

        }
        else if (filds[21].Player != IEnumPlayer.Player.Empty && filds[21].Player == filds[22].Player && filds[21].Player == filds[23].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[21].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[21].GetIndex);
                EnableChackButton(filds[22].GetIndex);
                EnableChackButton(filds[23].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        else if (filds[31].Player != IEnumPlayer.Player.Empty && filds[31].Player == filds[32].Player && filds[31].Player == filds[33].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[31].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[31].GetIndex);
                EnableChackButton(filds[32].GetIndex);
                EnableChackButton(filds[33].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        #endregion
        #region Pionowo
        else if (filds[11].Player != IEnumPlayer.Player.Empty && filds[11].Player == filds[21].Player && filds[11].Player == filds[31].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[11].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[11].GetIndex);
                EnableChackButton(filds[21].GetIndex);
                EnableChackButton(filds[31].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        else if (filds[12].Player != IEnumPlayer.Player.Empty && filds[12].Player == filds[22].Player && filds[12].Player == filds[32].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[12].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[12].GetIndex);
                EnableChackButton(filds[22].GetIndex);
                EnableChackButton(filds[32].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        else if (filds[13].Player != IEnumPlayer.Player.Empty && filds[13].Player == filds[23].Player && filds[13].Player == filds[33].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[13].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[13].GetIndex);
                EnableChackButton(filds[23].GetIndex);
                EnableChackButton(filds[33].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        #endregion
        #region Skos
        else if (filds[11].Player != IEnumPlayer.Player.Empty && filds[11].Player == filds[22].Player && filds[11].Player == filds[33].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[11].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[11].GetIndex);
                EnableChackButton(filds[22].GetIndex);
                EnableChackButton(filds[33].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        else if (filds[13].Player != IEnumPlayer.Player.Empty && filds[13].Player == filds[22].Player && filds[13].Player == filds[31].Player)
        {
            if (Events.WhoWin != null)
            {
                Events.WhoWin.Invoke(filds[13].Player);
            }
            if (EnableChackButton != null)
            {
                EnableChackButton(filds[13].GetIndex);
                EnableChackButton(filds[22].GetIndex);
                EnableChackButton(filds[31].GetIndex);
            }
            if (ActiveLineComponent != null)
            {
                ActiveLineComponent();
            }
            if (DisableButton != null)
            {
                DisableButton();
            }
        }
        #endregion
        #region Daraw
        else
        {
            int conter = 0;
            foreach (var item in filds)
            {
                if (item.Value.ImageVisible)
                {
                    conter++;
                }
            }
            if (conter == 9)
            {
                if (Events.WhoWin != null)
                {
                    Events.WhoWin.Invoke(IEnumPlayer.Player.Empty);
                }
                if (Events.ShowDialogue != null)
                {
                    Events.ShowDialogue.Invoke(IEnumPlayer.Player.Empty);
                }
                if (Events.AddPoint != null)
                {
                    Events.AddPoint.Invoke(IEnumPlayer.Player.Empty);
                }
               
                return;
            }
            if (Events.PlayerMoved != null)
            {
                Events.PlayerMoved.Invoke();
            }

        }
        #endregion
    }

}
