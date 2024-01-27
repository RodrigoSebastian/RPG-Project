using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
  private NavMeshAgent navMeshAgent;
  private Animator animator;

  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      MoveToCursor();
    }

    UpdateAnimator();
  }

  private void MoveToCursor()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    bool hasHit = Physics.Raycast(ray, out hit);
    if (hasHit)
    {
      navMeshAgent.destination = hit.point;
    }
  }

  private void UpdateAnimator()
  {
    Vector3 velocity = navMeshAgent.velocity;
    Vector3 localVelocity = transform.InverseTransformDirection(velocity);
    float speed = localVelocity.z;

    animator.SetFloat("speed", speed);
  }
}
