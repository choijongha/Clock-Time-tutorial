using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{
    public bool analog;
    // 시계는 360도 이고 시간은 그중 12, 분과 초는 60 으로 나눔
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    // 움직임을 조절할거기에 Transform을 참조한다.
    public Transform hours, minutes, seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 현재 시간 불러와 회전.
    void Update()
    {
        if (analog)
        {
            TimeSpan timespan  = DateTime.Now.TimeOfDay;
            hours.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);
        }
        else
        {
            // 현재 시간 불러오기.
            DateTime time = DateTime.Now;
            // Z축을 내려다보고 있고 Unity는 왼손 좌표계를 사용하므로 Z축을 중심으로 회전이 음수여야 함.
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
        }
        
    }
}
