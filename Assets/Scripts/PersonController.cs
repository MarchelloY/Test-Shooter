using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PersonController : MonoBehaviour
{
	
	[SerializeField] private Transform player1;
	[SerializeField] private Transform player2;
	[SerializeField] private Camera playerCamera1;
	[SerializeField] private Camera playerCamera2;
	[SerializeField] private float speed = 5f;

	private void FixedUpdate ()
	{
		MoveCheck();
		ZoomCheck();
	}

	private void MoveCheck()
	{
		if (Input.GetKey(KeyCode.A)) Movement(player1, -player1.right);
		if (Input.GetKey(KeyCode.D)) Movement(player1, player1.right);
		if (Input.GetKey(KeyCode.W)) Movement(player1, player1.forward);
		if (Input.GetKey(KeyCode.S)) Movement(player1, -player1.forward);
		if (Input.GetKey(KeyCode.LeftArrow)) Movement(player2, -player2.right);
		if (Input.GetKey(KeyCode.RightArrow)) Movement(player2, player2.right);
		if (Input.GetKey(KeyCode.UpArrow)) Movement(player2, player2.forward);
		if (Input.GetKey(KeyCode.DownArrow)) Movement(player2, -player2.forward);
	}

	private void ZoomCheck()
	{
		var fow = playerCamera1.fieldOfView;
		if (Input.GetMouseButton(1))
		{
			if (!(fow > 40)) return;
			playerCamera1.fieldOfView -= 1f;
			playerCamera2.fieldOfView -= 1f;
		}
		else
		{
			if (!(fow < 60)) return;
			playerCamera1.fieldOfView += 1f;
			playerCamera2.fieldOfView += 1f;
		}
	}

	private void Movement(Transform player, Vector3 dir)
	{
		player.position += dir * (speed * Time.fixedDeltaTime);
	}
}
