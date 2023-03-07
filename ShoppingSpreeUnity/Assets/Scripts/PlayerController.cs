using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

	//Player Stats
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	public static int count;

	//Player Movement Variables
	public CharacterController controller;
	public Transform cam;

	public float speed = 6f;

	public float turnSmoothTime = 0.1f;
	private float turnSmoothVelocity;

	public float gravity = -9.81f;
	private Vector3 velocity;
	private bool isGrounded;
	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;


	public Item itemUp;
	public ItemPick ip;


	// At the start of the game..
	void Start()
	{
		// Set the count to zero 
		count = 0;
		SetCountText();

		// Win display message as inactive
		winTextObject.SetActive(false);
	}

	void Update()
	{
		float horiz = Input.GetAxisRaw("Horizontal");
		float vert = Input.GetAxisRaw("Vertical");
		Vector3 direct = new Vector3(horiz, 0f, vert).normalized;

		if (direct.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direct.x, direct.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);
			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(speed * Time.deltaTime * moveDir.normalized);
		}

		//GRAVITY
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			ip = other.transform.GetComponent<ItemPick>();
			InventoryManager.Instance.Add(ip.Item);
			Destroy(other.gameObject);

			// if (count < 2) 
			// {
				// other.gameObject.SetActive (false);


				// Add one to the score variable 'count'
				// count = count + 1;

				// other.gameObject.GetComponent<Item>()

				// Run the 'SetCountText()' function (see below)	
			// } else {
			// 	SetCountText ();
			// }
			
			
		}
	}
	

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 6) 
		{
			// Set the text value of your 'winText'
            winTextObject.SetActive(true);
		}
	}
}