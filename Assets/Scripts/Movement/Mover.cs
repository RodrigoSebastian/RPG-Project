using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
  public class Mover : MonoBehaviour
  {
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Start()
    {
      navMeshAgent = GetComponent<NavMeshAgent>();
      animator = GetComponent<Animator>();
    }

    private void Update()
    {
      UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
      navMeshAgent.destination = destination;
    }

    private void UpdateAnimator()
    {
      Vector3 velocity = navMeshAgent.velocity;
      Vector3 localVelocity = transform.InverseTransformDirection(velocity);
      float speed = localVelocity.z;

      animator.SetFloat("speed", speed);
    }
  }

}