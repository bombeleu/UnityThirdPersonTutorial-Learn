using UnityEngine;
using System.Collections;

/// <summary>
/// #DESCRIPTION OF CLASS#
/// </summary>

public class CharacterControllerLogic : MonoBehaviour 
{
	#region Variables (private)

	[SerializeField]
	private Animator animator;
	[SerializeField]
	private float directionDampTime = .25f;

	private float speed = 0.0f;
	private float status = 0.0f;
	private float h = 0.0f;
	private float v = 0.0f;
	#endregion

	#region Properties (public)

	#endregion

	#region Unity event functions

	/// <summary> 
	/// Use this for initialization
	/// </summary>
	void Start () 
	{
		animator = GetComponent<Animator> ();

		if (animator.layerCount >= 2) 
		{
			animator.SetLayerWeight(1,1);		
		}
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update () 
	{
		if (animator) 
		{
			// Pull values from controller/keyboard
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");

			speed = new Vector2(h, v).sqrMagnitude;

			animator.SetFloat("Speed", speed);
			animator.SetFloat("Status", h, directionDampTime, Time.deltaTime);
			Debug.Log(speed);
			

		}
	}

	/// <summary>
	/// Debugging information should be put here/
	/// </summary>

	void OnDrawGizmos ()
	{


	}

	#endregion

	#region Methods

	#endregion Methods

}
