//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMenager : MonoBehaviour
{
    [SerializeReference] List<Sprite> XImage;
    [SerializeReference] List<Sprite> OImage;
    public Sprite GetImageX(int index)
    {
        return XImage[index];
    }
    public Sprite GetImageY(int index)
    {
        return OImage[index];
    }
}
