using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	#region Variables (private)

	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceUp;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;
	private Vector3 targetPosition;

	#endregion

	#region Properties (public)

	#endregion

	#region Unity event functions

	// Use this for initialization
	void Start () 
	{
		follow = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate ()
	{
		//setting the target position to be the correct offset from the hovercraft
		targetPosition = follow.position + follow.up * distanceUp - follow.forward* distanceAway;
		Debug.DrawRay (follow.position, Vector3.up * distanceUp, Color.red);
		Debug.DrawRay (follow.position, -1f  * follow.forward * distanceAway, Color.blue);
		Debug.DrawLine (follow.position, targetPosition, Color.magenta);

		//making a smooth transition between it's current position and the position it vants to be in
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);

		// make sure the camera is looking the right way
		transform.LookAt(follow);
	}
	#endregion
}
