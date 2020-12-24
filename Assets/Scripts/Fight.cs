using UnityEngine;

public class Fight : MonoBehaviour
{
	// point - точка контакта
	// radius - радиус поражения
	// layerMask - номер слоя, с которым будет взаимодействие
	// damage - наносимый урон
	public static void Action(Vector2 point, float radius, int layerMask, float damage, bool flag)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

		foreach (Collider2D hit in colliders)
		{
			if (hit.GetComponent<AbsEnemyControl>())
			{
				hit.GetComponent<AbsEnemyControl>().TakeDamage(damage);
			}
		}
	}
}