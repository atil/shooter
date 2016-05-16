using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipView : ShipView
	{
	    protected override void Awake()
        {
            base.Awake();
            InputDispatcher = gameObject.AddComponent<PlayerInputDispatcher>();

	        StartCoroutine(ImmunityCoroutine());
        }

	    private IEnumerator ImmunityCoroutine()
	    {
            // Make the sprite a bit more transparent
	        var col = Sprite.GetComponent<SpriteRenderer>().color;
	        col.a = 0.2f;
	        Sprite.GetComponent<SpriteRenderer>().color = col;

            GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(1.5f);
	        GetComponent<BoxCollider2D>().enabled = true;

            // And restore it
            col = Sprite.GetComponent<SpriteRenderer>().color;
            col.a = 1f;
            Sprite.GetComponent<SpriteRenderer>().color = col;

        }
    }
}