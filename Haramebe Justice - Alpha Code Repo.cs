using UnityEngine;
using System.Collections;

public class KillPlsyer : MonoBehaviour {

	public Transform RespawnLocation;

	//public Transform PlayerTransform;
	void Update(){
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Collider2D>().tag == "Player") {
			Debug.Log ("IsPlayer");
			other.transform.position = RespawnLocation.position ;
		}
	}
	/*
	void OnCollissionEnter2D(Collider2D other){
		Debug.Log ("Collision");

	}*/
	/*
	function OnTriggerEnter(other : Collider){   //this function checks for the collision of the local Collider which is Trigger (i.e. field-like, and not rigid, objects can pass through the field, but will trigger the function)
		if(other.gameObject.name == "Player"){ //the function took an argument "other", it refers to a collider that is passing through the trigger field
			GameObject.Destory(other.gameObject); //using our keyword that refers to that external collider, it picks  the whole gameObject that somehow relates to that collider, that is, holds it.  We than destroy that gameObject
			for(var child : Transform in transform.gameObject){ //
				GameObject.Destroy(child.gameObject);  //those three lines are only needed if you have children of the player objet that have to be removed
			}                                                                            //otherwise, you can remove those 3 lines
			Debug.Log("Player was brutalized"); //write a message in a console that the player has r.i.p'ed
		}
	}*/
}



public class PlayerStats 	{
	public float Health = 100f;
	}

	public PlayerStats playerStats = new PlayerStats();


	public void 


using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);


            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}


using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public class PlayerStats 	{
		public int  Health = 100f;
	}

	public PlayerStats playerStats = new PlayerStats();


	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			GameMaster.KillPlayer (this);
		}
			
	}

}
`

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public class PlayerStats 	{
		public int  Health = 100f;
	}

	public PlayerStats playerStats = new PlayerStats();


	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			GameMaster.KillPlayer (this);
		}
			
	}

}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour {

	public static int score;

	Text text;

	void Start()
	{

		text = GetComponent<Text> ();

		score = 0;

	}

	void Update()
	{

		if (score < 0)
			score = 0;

		text.text = "" + score;
	}

	public static void AddPoints (int pointsToAdd)
	{
		score += pointsToAdd;



	}
}


using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;



	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {

			ScoreCounter.AddPoints (pointsToAdd);

			Destroy (gameObject);
		}

	}
}
