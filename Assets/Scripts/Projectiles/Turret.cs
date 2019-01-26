using UnityEngine;

public class Turret : MonoBehaviour
{
	public Projectile ProjectilePrefab;
	public bool Enabled = true;
	public float FireRate;
	public float FireSpeedBonusMultiplier = 0;

	[Header("Game State")]
	public float Cooldown;

	public void Update()
	{
		Cooldown -= Time.deltaTime * (1 + FireSpeedBonusMultiplier);
		if (Cooldown < 0) { Cooldown = 0; }
	}

	public virtual Projectile FireAt (Vector3 position)
	{
		if (Cooldown > 0 || !Enabled)
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
			dir: Game.MousePosition - transform.position,
			prefab: ProjectilePrefab
		);
	}
}