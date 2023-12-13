using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretController : MonoBehaviour
{
  [SerializeField]
  private Transform head;
  [SerializeField]
  private Transform body;
  [SerializeField]
  private Transform filter;

  private Vector3 initialHeadPosition;
  private Vector3 initialFilterPosition;
  private float initialBodyLength;

  void Start()
  {
    // 初期位置を保存
    initialHeadPosition = head.localPosition;
    initialFilterPosition = filter.localPosition;
    initialBodyLength = body.localScale.y;
  }
  void Update()
  {
    // Bodyの長さに合わせてHeadとFilterの位置を変更
    float ratio = body.localScale.y / initialBodyLength;
    head.localPosition = initialHeadPosition * ratio;
    filter.localPosition = initialFilterPosition * ratio;
  }
}
