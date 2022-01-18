using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{
    public bool analog;
    // �ð�� 360�� �̰� �ð��� ���� 12, �а� �ʴ� 60 ���� ����
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    // �������� �����Ұű⿡ Transform�� �����Ѵ�.
    public Transform hours, minutes, seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // ���� �ð� �ҷ��� ȸ��.
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
            // ���� �ð� �ҷ�����.
            DateTime time = DateTime.Now;
            // Z���� �����ٺ��� �ְ� Unity�� �޼� ��ǥ�踦 ����ϹǷ� Z���� �߽����� ȸ���� �������� ��.
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
        }
        
    }
}
