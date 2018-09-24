using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	public string stringTag;
    public string tag1, tag2;

    void OnTriggerEnter2D(Collider2D hit)
	{
        if (hit.CompareTag(stringTag) && hit.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            GameManager.IncreaseScore(10);
            AudioSource.PlayClipAtPoint(Sounds.Instance.explosion, Vector3.zero);
            //CtrlUI.score = CtrlUI.score + 10f + (CtrlUI.combo * 1.5f);
            //CtrlUI.combo++;

            Destroy(hit.gameObject);
            Destroy(gameObject);
        }

        if (hit.tag.Equals(tag1) || hit.tag.Equals(tag2))
        {
            GameManager.ResetCombo();
            Destroy(hit.gameObject);
            //CtrlUI.combo = 0;
        }

        if (hit.tag == "Player")
        {
            ShakeScreen.shake = 1;
            print(ShakeScreen.shake);
        }
    }

}
