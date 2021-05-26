using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public static event Action GameWin;
    public bool[] ListPresents = new bool[3];
    [SerializeField] bool isPC = false;
    Vector2[] linePos;
    [SerializeReference] LineRenderer line;
    [SerializeReference] EdgeCollider2D edgeCollider;
    [SerializeReference] Rigidbody2D rg;
    private void OnEnable()
    {
        rg.simulated = false;
        for (int i = 0; i < ListPresents.Length; i++)
        {
            ListPresents[i] = false;
        }
        // GameMenager.gameMenager.events.ChackCrossedBox += AddPresent;
        linePos = new Vector2[2];
        line.positionCount = 2;
    }
    private void OnDisable()
    {
        rg.simulated = false;
        for (int i = 0; i < ListPresents.Length; i++)
        {
            ListPresents[i] = false;
        }
        // GameMenager.gameMenager.events.ChackCrossedBox -= AddPresent;
        edgeCollider.enabled = false;
       // line.enabled = false;
        linePos[0] = Vector2.zero;
        linePos[1] = Vector2.zero;
       // line.SetPosition(0, Vector3.zero);
       // line.SetPosition(1, Vector3.zero);
    }
    
    private void Update()
    {
        
        if (!isPC)
        {
            if (Input.touches.Length > 0)
            {
                switch (Input.touches[0].phase)
                {
                    case TouchPhase.Began:
                        line.SetPosition(0, new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 1f));
                        break;
                    case TouchPhase.Moved:
                        line.SetPosition(1, new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 1f));
                        break;
                    case TouchPhase.Ended:
                        line.SetPosition(1, new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 1f));

                        break;
                    default:
                        break;
                }
            }
        }
        else if (isPC)
        {

            if (Input.GetMouseButtonDown(0))
            {

                linePos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(0, new Vector3(linePos[0].x, linePos[0].y, 1f));
                line.SetPosition(1, new Vector3(linePos[0].x, linePos[0].y, 1f));
                linePos[0] = transform.InverseTransformPoint(linePos[0]);
                edgeCollider.points = linePos;
                line.enabled = true;
                edgeCollider.enabled = true;
                rg.simulated = true;
                

            }
            else if (Input.GetMouseButton(0))
            {
                linePos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(1, new Vector3(linePos[1].x, linePos[1].y, 1f));
                linePos[1] = transform.InverseTransformPoint(linePos[1]);
                edgeCollider.points = linePos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // Events.InvokeChackCrossedBox();
                ChackListPresents();
                rg.simulated = false;
            }
        }
    }
    public void Reset()
    {
        rg.simulated = false;
        for (int i = 0; i < ListPresents.Length; i++)
        {
            ListPresents[i] = false;
        }
        line.enabled = false;
        edgeCollider.enabled = false;
        linePos[0] = Vector2.zero;
        linePos[1] = Vector2.zero;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
    }
    public int Present(bool isPresent, int index, string name)
    {
        for (int i = 0; i < ListPresents.Length; i++)
        {
            if (isPresent)
            {
                if (index == 10)
                {
                    if (ListPresents[i] == false)
                    {
                        ListPresents[i] = isPresent;
                        return i;
                    }
                   
                }
                
            }
            else if (isPresent == false)
            {
                if (i == index)
                {
                    ListPresents[i] = isPresent;
                    return 10;
                }
                
            }
        }
        // "10" defoult value for not present button 
        Debug.Log("aaaaaaaaaaaaaaaaa "+ isPresent+name);
        return 10;
       
    }
    public void Enable()
    {
        this.enabled = true;
    }
    public void ChackListPresents()
    {
        if (ListPresents[0] == true && ListPresents[1] == true && ListPresents[2] == true)
        {
            if (GameWin != null)
            {
                GameWin();
            }
            
            this.enabled = false;
        }
        else
        {
           
            Reset();
        }
       
    }


}
