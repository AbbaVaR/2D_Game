using UnityEngine;

public class Fight : Enemy
{

/*	// функция возвращает ближайший объект из массива, относительно указанной позиции
	static GameObject NearTarget(Vector3 position, Collider2D[] array)
	{
		Collider2D current = null;
		float dist = Mathf.Infinity;

		foreach (Collider2D coll in array)
		{
			float curDist = Vector3.Distance(position, coll.transform.position);

			if (curDist < dist)
			{
				current = coll;
				dist = curDist;
			}
		}

		return (current != null) ? current.gameObject : null;
	}*/

	// point - точка контакта
	// radius - радиус поражения
	// layerMask - номер слоя, с которым будет взаимодействие
	// damage - наносимый урон
	public static void Action(Vector2 point, float radius, int layerMask, float damage, bool flag)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

		foreach (Collider2D hit in colliders)
		{
			
			if (flag)
            {
				if (hit.GetComponent<Player>())
				{
					hit.GetComponent<Player>().PlayerDamage(damage);
				}
			}

			else
            {
				if (hit.GetComponent<Patrol>())
				{
					hit.GetComponent<Patrol>().TakeDamage(damage);
				}
            }
			
			

			
		}
	}
}