// Patrol.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class Patrol_random : MonoBehaviour {

   public Transform[] points;
   private Transform player;
   private int destPoint = 0;
   private NavMeshAgent agent;
   private Vector3 lastAgentVelocity;
   private NavMeshPath lastAgentPath;
   public float timeToPause = 2;
   private float curTime = 0;
  
	void Awake () {
	   agent = GetComponent<NavMeshAgent>();
       player = GameObject.Find("Joueur").transform;

	   // Disabling auto-braking allows for continuous movement
	   // between points (ie, the agent doesn't slow down as it
	   // approaches a destination point).
		agent.autoBraking = false;
		destPoint = (int)Random.Range (0, points.Length);
		GameObject[] tmps = GameObject.FindGameObjectsWithTag ("Finish");
		int i = 0;
		foreach(GameObject tmp in tmps){
			points[i] = tmp.transform;
			i++;
		}
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

	   destPoint = (int)Random.Range(0, points.Length);

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

     public void Alert() {
		Debug.Log (player.position);
        agent.Resume();
		agent.SetDestination(player.position);
     }
}
