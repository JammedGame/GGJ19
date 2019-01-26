using UnityEngine;

public class Turret : MonoBehaviour
{
	public Projectile ProjectilePrefab;
	public float FireRate;
	public float FireSpeedBonusMultiplier = 0;

	[Header("Game State")]
	public float Cooldown;

	public void Update()
	{
		Cooldown -= Time.deltaTime * (1 + FireSpeedBonusMultiplier);
		if (Cooldown < 0) { Cooldown = 0; }
	}

	public Projectile FireAt (Vector3 position)
	{
		if (Cooldown > 0)
		{
			return null;
		}
		else
		{
			Cooldown = FireRate;
		}

		return Projectile.Fire
		(
			from: transform.position,
			to: Game.MousePosition,
			prefab: ProjectilePrefab
		);
	}
}