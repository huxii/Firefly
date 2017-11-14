using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour
{

	public GameObject Player;
	public Vector3 offset;
	private Vector3 _endPoint;
	private Vector3 _desiredPoint;

	private const float DISTANCE_THRESHOLD = 6.0f;

	void Start()
	{
		if (this.Player != null)
		{
			this._endPoint = this.Player.transform.position + offset;
		}
		this.transform.position = this._endPoint;
	}

	void Update()
	{
		_desiredPoint = this.Player.transform.position + offset;
		if (this.Player != null)
		{
			//Check if the distance between the player and the ball is big enough
			//to start moving
			if (Vector3.Distance(_desiredPoint,
				    this.transform.position) > DISTANCE_THRESHOLD)
			{
				//Start moving towards the player
				this.transform.position = Vector3.Slerp(
					this.transform.position, this._endPoint, Time.deltaTime);
			}
			//Check if the tracker has finally reached its end point.
			//If it hasn't, keep on moving.
			if (this.transform.position != this._endPoint)
			{
				this.transform.position = Vector3.Slerp(
					this.transform.position, this._endPoint, Time.deltaTime);
			}
			//Update the last frame's player position
			this._endPoint = _desiredPoint;
		}
	}
}
   