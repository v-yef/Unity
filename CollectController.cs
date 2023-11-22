using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    public enum CollectibleTypes {NoType, SilverCoin, GoldCoin, Gem};
	public CollectibleTypes CollectibleType;

	public bool IsRotating = false;
	public int TurnRate = 100;

    public static int SilverCoinCount = 0;
    public static int GoldCoinCount = 0;
    public static int GemCount = 0;

	// Start is called before the first frame update
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (IsRotating)
        {
	        transform.Rotate (0, TurnRate * Time.deltaTime, 0);
        }
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
        {
			Collect ();
		}
	}

	private void Collect()
	{
		if (CollectibleType == CollectibleTypes.SilverCoin)
        {
			SilverCoinCount++;
            Debug.Log("Silver coin was collected");
		}
		else if (CollectibleType == CollectibleTypes.GoldCoin)
        {
			GoldCoinCount++;
            Debug.Log("Gold coin was collected");
		}
		else if (CollectibleType == CollectibleTypes.Gem)
        {
			GemCount++;
            Debug.Log("Gem was collected");
		}
        else
        {
            Debug.Log("Unknown item was collected");
        }

		Destroy(gameObject);
	}
}