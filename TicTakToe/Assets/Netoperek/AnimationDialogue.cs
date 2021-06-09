using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDialogue : MonoBehaviour
{
    [SerializeReference] RectTransform puchar;
    [SerializeReference] RectTransform[] tr;
    [SerializeField] float speedRotation;
    [SerializeField] float speedScale;
    float axisZ = 0f;
    [SerializeField] float maxDegrees = 0f;
    bool change = false;
    private void OnEnable()
    {
        puchar.localScale = Vector3.zero;
        StartCoroutine(ScaleAnimation());
    }
    private void OnDisable()
    {
        puchar.localScale = Vector3.zero;
        StopAllCoroutines();
    }
    private void Update()
    {
        if (!change)
        {

            axisZ += speedRotation * Time.deltaTime;
            if (axisZ >= maxDegrees - 1f)
            {
                change = true;
            }
        }
        else
        {
            axisZ -= speedRotation * Time.deltaTime;

            if (axisZ <= -maxDegrees + 1f)
            {

                change = false;
            }
        }


        for (int i = 0; i < tr.Length; i += 3)
        {

            tr[i].localRotation = Quaternion.Euler(0f, 0f, axisZ);
            tr[i + 1].localRotation = Quaternion.Euler(0f, 0f, -axisZ);
            tr[i + 2].localRotation = Quaternion.Euler(0f, 0f, axisZ);
        }
    }
    IEnumerator ScaleAnimation()
    {
        while (true)
        {
          
            puchar.localScale = Vector3.Lerp(puchar.localScale, Vector3.one*1.5f, speedScale * Time.deltaTime);
            if (puchar.localScale.x >= Vector3.one.x)
            {
                yield break;
            }
            yield return null;
        }
        
       
    }
    

}
