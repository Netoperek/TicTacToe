using System;
using UnityEngine;
public static class Events
{
    public static Action RestartGame;
    public static Action RestartBorad;
    public static Action<IEnumPlayer.Player> ShowDialogue;
    public static Action<IEnumPlayer.Player> WhoWin;
    public static Action GameWin;
    public static Action<IEnumPlayer.Player> ChangePlayer;
    public static Action PlayerMoved;
    public static Action<IEnumPlayer.Player> AddPoint;
    
}
