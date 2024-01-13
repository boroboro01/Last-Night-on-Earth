using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator2 : MonoBehaviour
{
    public iTween.EaseType easeType;
    public iTween.LoopType loopType;
    void Update()
    {
        //  Rotate();
        iTween.RotateTo(this.gameObject, iTween.Hash("z", 180, "time", 4.0f, "easetype", easeType, "looptype", loopType));
    }

    // private void Rotate()
    // {
    //     if (flag)
    //     {
    //         flag = false;
    //         iTween.RotateTo(this.gameObject, iTween.Hash("x", 180, "time", 3.0f, "easetype", easeType, "looptype", loopType));
    //         StartCoroutine(RotateOrigin());
    //     }
    // }
    // IEnumerator RotateOrigin()
    //         {
    //             yield return new WaitForSeconds(3.01f);
    //             iTween.RotateTo(this.gameObject, iTween.Hash("x", 360, "time", 3.0f, "easetype", easeType, "looptype", loopType));
    //             yield return new WaitForSeconds(3.0f);
    //             flag = true;
    //         }
}
