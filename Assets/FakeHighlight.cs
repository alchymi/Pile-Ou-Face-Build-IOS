using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class FakeHighlight : MonoBehaviour {

    public Image ThisPic;
    public Color BaseColor;
    public Color HighlightColor;

    public void DoHighlight()
    {
        Debug.Log("Clicked");
        ThisPic.DOColor(HighlightColor, 0.55f).OnComplete(() => { ThisPic.DOColor(BaseColor, 0.15f); });
    }
	 
}
