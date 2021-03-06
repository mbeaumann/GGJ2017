// Patrol.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class Patrol_wait : MonoBehaviour {

   public Transform[] points;
   private int destPoint = 0;
   private NavMeshAgent agent;
   private Vector3 lastAgentVelocity;
   private NavMeshPath lastAgentPath;
   public float timeToPause = 2;
   private float curTime = 0;
   void Start () {
	   agent = GetComponent<NavMeshAgent>();

	   // Disabling auto-braking allows for continuous movement
	   // between points (ie, the agent doesn't slow down as it
	   // approaches a destination point).
	   agent.autoBraking = false;

	   GotoNextPoint();
   }


   void GotoNextPoint() {
	   // Returns if no points have been set up
	   if (points.Length == 0)
		   return;

	   // Set the agent to go to the currently selected destination.
	   agent.destination = points[destPoint].position;

	   // Choose the next point in the array as the destination,
	   // cycling to the start if necessary.
	   destPoint = (destPoint + 1) % points.Length;

   }


   void Update () {
	   // Choose the next destination point when the agent gets
	   // close to the current one.
	   if (agent.remainingDistance < 0.5f) {
		   if(curTime == 0) {
			   agent.Stop();
			   curTime = Time.time;
		   }
		   if(Time.time - curTime >= timeToPause) {
			   agent.Resume();
			   curTime = 0;
			   GotoNextPoint();
		   }
	   }
   }

	public IEnumerator sleep(int seconds) {
		yield return new WaitForSeconds(seconds);
	}

   void pause() {
         lastAgentVelocity = agent.velocity;
         lastAgentPath = agent.path;
         agent.velocity = Vector3.zero;
         agent.ResetPath();
     }

     void resume() {
         agent.velocity = lastAgentVelocity;
         agent.SetPath(lastAgentPath);
     }
}
