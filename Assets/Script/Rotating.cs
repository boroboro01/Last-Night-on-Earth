using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public iTween.EaseType easeType;
    public iTween.LoopType loopType;
    bool flag = true;
    void Update()
    {
         Rotate();
    }

    private void Rotate()
    {
        if (flag)
        {
            flag = false;
            iTween.RotateTo(this.gameObject, iTween.Hash("y", 180, "time", 1.5f, "easetype", easeType, "looptype", loopType));
            StartCoroutine(RotateOrigin());
        }
    }
    IEnumerator RotateOrigin()
            {
                yield return new WaitForSeconds(1.51f);
                iTween.RotateTo(this.gameObject, iTween.Hash("y", 360, "time", 1.5f, "easetype", easeType, "looptype", loopType));
                yield return new WaitForSeconds(1.5f);
                flag = true;
            }
}
