//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDate : MonoBehaviour, IEnumPlayer
{
    [SerializeReference] Rigidbody2D rg;
    [SerializeField] Button button;
    IEnumPlayer.Player player = IEnumPlayer.Player.Empty;
    //[SerializeReference] Button button;
    [SerializeField] int index;
    [SerializeReference] Image image;
    public Sprite Sprite { get { return image.sprite; } set { image.sprite = value; } }
    public int GetIndex => index;
    public IEnumPlayer.Player Player { get { return player; } set { player = value; } }

    private void Restart()
    {
        player = IEnumPlayer.Player.Empty;
        ImageVisible = false;
        rg.simulated = false;
        image.color = Color.clear;
        image.sprite = null;
        EnableInteraction();
        LineChackDisable();
    }
    public void LineChackEnable(int indexButton)
    {
        if (index == indexButton)
        {

            rg.simulated = true;

            if (this.gameObject.TryGetComponent<LineChack>(out LineChack lineChack))
            {
                lineChack.enabled = true;
            }
        }
    }
    public void LineChackDisable()
    {
        Debug.Log("Button disable " + this.name);
        rg.simulated = false;
        if (this.gameObject.TryGetComponent<LineChack>(out LineChack lineChack))
        {
            lineChack.enabled = false;
        }
    }
    public void EnableInteraction()
    {
        button.interactable = true;
    }
    public void DisableInteraction()
    {
        button.interactable = false;
    }
    public void DisableInteraction(int IndexButton)
    {
        if (index == IndexButton)
        {
            button.interactable = false;
        }
    }
    public bool ImageVisible
    {
        set
        {
            if (value)
            {
                image.color = Color.white;
            }
            else
            {
                image.color = Color.clear;
            }
        }
        get
        {
            if (image.color == Color.clear)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
    private void Awake()
    {
        ImageVisible = false;
        rg.simulated = false;
    }
    private void OnEnable()
    {
        Events.RestartBorad += Restart;
        Events.RestartGame += Restart;
        GameMenager.PlayerClick += DisableInteraction;
        BoardMenager.EnableChackButton += LineChackEnable;
        BoardMenager.DisableButton += DisableInteraction;
    }
    private void OnDisable()
    {
        Events.RestartBorad -= Restart;
        Events.RestartGame -= Restart;
        GameMenager.PlayerClick -= DisableInteraction;
        BoardMenager.EnableChackButton -= LineChackEnable;
        BoardMenager.DisableButton -= DisableInteraction;
    }
}
public interface IEnumPlayer
{
    enum Player { Bat = 0, Bunny = 1, Empty = 2 }
}