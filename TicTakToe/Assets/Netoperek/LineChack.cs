using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChack : MonoBehaviour
{
    int index = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Line")
        {
            index = collision.gameObject.GetComponent<Line>().Present(true, index, this.gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Line")
        {
            index = collision.gameObject.GetComponent<Line>().Present(false,index, this.gameObject.name);
        }
    }
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }

}
