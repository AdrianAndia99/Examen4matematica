using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class JugadorController : MonoBehaviour
{
	[Header("DoTween")]
	[SerializeField] private Ease EaseValue = Ease.Linear;
	[SerializeField] private float duration;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Piso")
		{	
		    Time.timeScale = 0;
			StartCoroutine(ScalePlayerAndLoadGameOver());	
		}
	}
	private IEnumerator ScalePlayerAndLoadGameOver()
	{
		transform.DOScale(Vector3.zero, duration).SetEase(EaseValue).SetUpdate(true);

		yield return new WaitForSecondsRealtime(duration + 0.2f);

		SceneManager.LoadScene("Derrota");
		Time.timeScale = 1;
	}
}