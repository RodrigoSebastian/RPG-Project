using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField]
  GameObject target;

  void LateUpdate()
  {
    transform.position = target.transform.position;
  }
}