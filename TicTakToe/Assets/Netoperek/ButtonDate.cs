//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDate : MonoBehaviour, IEnumPlayer
{
    IEnumPlayer.Player player = IEnumPlayer.Player.Empty;
    //[SerializeReference] Button button;
    [SerializeField] int index;
    [SerializeReference] Image image;
    public Sprite Sprite { get { return image.sprite; } set { image.sprite = value; } }
    public int GetIndex => index;
    public IEnumPlayer.Player Player { get { return player; } set { player = value; } }
}
public interface IEnumPlayer
{
    enum Player { X = 0, O = 1, Empty = 3 }
}