using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;


public class DoRotateToFace : MonoBehaviour {
    public GameObject ResultPanel;
    public Text ResultText;
    public string resultstring;
    public GameObject[] BtsToHide;

    // Use this for initialization
    public bool CanSpin = true;
    public AudioSource CoinSound;


    public void HideResults()
    {
        ResultPanel.SetActive(false);
    }
    public void ShowResultPanel()
    {
        ResultText.text = resultstring;
        ResultPanel.SetActive(true);
        Invoke("ReactivateBT", 3);
    }


    public void ReactivateBT()
    {
        CoinSound.volume = 1;
        HideORShow(false);
    }
    // Par Défaut FACE !!!

    public float angle = 0;

    public void DoPile()
    {
        HideResults();
        resultstring = "Pile";
        angle =    (Random.Range(12, 20)*360) + 180;
        LancePiece();
    }
    public void DoFace()
    {
        HideResults();
        resultstring = "Face";
        angle =(Random.Range(12, 20) * 360);
        LancePiece();


    }

    public void HideORShow(bool b)
    {
        if (b)
        {
            foreach (GameObject Go in BtsToHide)
            {
                Go.gameObject.SetActive(false);

            }
        }else
        {
            foreach (GameObject Go in BtsToHide)
            {
                Go.gameObject.SetActive(true);

            }
        }

    }

    public void LancePiece()
    {
        if (CanSpin)
        {
            CoinSound.DOFade(0, 3);
            //this.transform.Rotate(new Vector3(0, 0, 0));
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            HideORShow(true);
            CoinSound.Play();
            CanSpin = false;
            this.transform.DORotate(new Vector3(0, angle, 0), 7.8f, RotateMode.WorldAxisAdd).OnComplete(() => { Invoke("ShowResultPanel", 0.75f); CanSpin = true; }).SetEase(Ease.OutQuint);

        }
    }

 }
