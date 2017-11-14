using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 smoothSpeed;
	public Vector3 offset;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		float dis = (transform.position - desiredPosition).magnitude;
		//float speed = smoothSpeed * (1 + dis * dis);
		float smoothX = Mathf.Lerp(transform.position.x, desiredPosition.x, smoothSpeed.x);
		float smoothY = Mathf.Lerp(transform.position.y, desiredPosition.y, smoothSpeed.y);
		float smoothZ = Mathf.Lerp(transform.position.z, desiredPosition.z, smoothSpeed.z);
		Vector3 smoothedPosition = new Vector3(smoothX, smoothY, smoothZ);
		//Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
		transform.LookAt(target);

		//Vector3 realTargetPos = new Vector3(smoothX, smoothY, smoothZ);
		//Vector3 realTargetPos = new Vector3(smoothX, transform.position.y, smoothZ);
		//transform.LookAt(realTargetPos);
	}
}
