using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChangerOnBehaviour : MonoBehaviour
{
	[SerializeField] private Text textField;
	[SerializeField] private string textNPC;
	[SerializeField] private string textEnemy;

	private void Start()
    {
		textField.text = "";
    }

  	private void ChangeTextNPC()
	{
		textField.text = textNPC;
		StartCoroutine(RemoveText());
	}

	private void ChangeTextEnemy()
	{
		textField.text = textEnemy;
		StartCoroutine(RemoveText());
	}

	IEnumerator RemoveText()
	{
		yield return new WaitForSeconds(1f);
		textField.text = "";
	}

	private void OnEnable()
	{
		EnemyBehaviour.EnemyDeadEvent += ChangeTextEnemy;
		NPCBehaviour.NPCHitEvent += ChangeTextNPC;
		NPCFemaleBehaviour.FemaleHitEvent += ChangeTextNPC;
	}

	private void OnDisable()
	{
		EnemyBehaviour.EnemyDeadEvent -= ChangeTextEnemy;
		NPCBehaviour.NPCHitEvent += ChangeTextNPC;
		NPCFemaleBehaviour.FemaleHitEvent -= ChangeTextNPC;
	}
}