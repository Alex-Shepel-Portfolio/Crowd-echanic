using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score SetScore { get; set; }
    public TextMeshProUGUI scoreText;
    Camera m_camera;
    public Transform PlayerPos;

   public  int count { get;  set; }

    private void Awake()
    {
        SetScore = this;
    }
    private void Start()
    {
        m_camera = Camera.main;
    }

    void Update()
    {
        if (count > 100)
        { count = 100; }
        if (count < 0) { count = 0; }
        scoreText.text = count.ToString();
        Vector3 pos = PlayerPos.position + new Vector3(0f, 1f, 0f);
        pos = m_camera.WorldToScreenPoint(pos);
        pos.z = 0f;
        scoreText.transform.position = pos;

    }


}
