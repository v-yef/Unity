using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
	private enum CollectibleBehaviour
	{
		Undefined,
		Additive,
		Subtractive
	};

	private enum CollectibleColor
	{
		Undefined,
		Silver,
		Gold,
		Diamond
	}

	[SerializeField] private CollectibleBehaviour _collectibleBehaviour;
	[SerializeField] private CollectibleColor _collectibleColor;
	[SerializeField] private GameObject _collectedEffect;
	[SerializeField] private AudioClip _collectedSound;
	[SerializeField] private bool _isDestructible;

	private CollectibleCounter _collectibleCounter;

	private void Start()
	{

	}

	private void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		switch (_collectibleColor)
		{
			case CollectibleColor.Silver:
				getSilverCounterFromObject(other);
				break;
			case CollectibleColor.Gold:
				getGoldCounterFromObject(other);
				break;
			case CollectibleColor.Diamond:
				getDiamondCounterFromObject(other);
				break;
			case CollectibleColor.Undefined: // Undefined type must be avoided in the game!!!
			default:
				logWarningMessage();
				break;
		}

		if (null == _collectibleCounter)
		{
			logErrorMessage();
			return;
		}

		switch (_collectibleBehaviour)
		{
			case CollectibleBehaviour.Additive:
				processAdditiveBehaviour();
				break;
			case CollectibleBehaviour.Subtractive:
				processSubtractiveBehaviour();
				break;
			case CollectibleBehaviour.Undefined: // Undefined type must be avoided in the game!!!
			default:
				logWarningMessage();
				break;
		}

		if (null != _collectedEffect)
		{
			Instantiate(_collectedEffect, transform.position, Quaternion.identity);
		}

		if (null != _collectedSound)
		{
			AudioSource.PlayClipAtPoint(_collectedSound, transform.position);
		}

		if (_isDestructible)
		{
			Destroy(gameObject);
		}
	}

	private void getSilverCounterFromObject(Collider objectCollider)
	{
		_collectibleCounter = objectCollider.GetComponent<SilverCounter>();

		Debug.Log("Silver item was collected!");
	}

	private void getGoldCounterFromObject(Collider objectCollider)
	{
		_collectibleCounter = objectCollider.GetComponent<GoldCounter>();

		Debug.Log("Gold item was collected!");
	}

	private void getDiamondCounterFromObject(Collider objectCollider)
	{
		_collectibleCounter = objectCollider.GetComponent<DiamondCounter>();

		Debug.Log("Diamond item was collected!");
	}

	private void processAdditiveBehaviour() =>
		_collectibleCounter.IncrementCounter();

	private void processSubtractiveBehaviour() =>
		_collectibleCounter.DecrementCounter();

	private void logWarningMessage()
	{
		Debug.LogWarning(
		   "WARNING!!! Undefined item was collected!!! Must never happen!!!");
	}

	private void logErrorMessage()
	{
		Debug.LogError(
		   "ERROR!!! No counter was detected!!! Can't process the collectible object!!!");
	}
}