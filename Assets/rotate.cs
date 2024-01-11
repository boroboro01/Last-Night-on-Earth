using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    public iTween.EaseType easeType;
    public iTween.LoopType loopType;
    [SerializeField] float time = 3f;
    void Start() {
iTween.RotateTo(this.gameObject, iTween.Hash("y", 180, "time", time, "easetype", easeType, "looptype", loopType));
    }
}
