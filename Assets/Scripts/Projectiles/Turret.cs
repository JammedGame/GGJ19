using UnityEngine;

public class Turret : MonoBehaviour
{
	public Projectile ProjectilePrefab;
	public bool Enabled = true;
	public bool Alternating;
	private int AlternatingCurrent = 0;
	public float FireRate;
	public float FireSpeedBonusMultiplier = 0;

	[Header("Game State")]
	public float Cooldown;

	public void Update()
	{
		Cooldown -= Time.deltaTime * (1 + FireSpeedBonusMultiplier);
		if (Cooldown < 0) { Cooldown = 0; }
	}

	public virtual void FireAt (Vector3 position)
	{
		if (Cooldown > 0 || !Enabled)
		{
			return;
		}
		else
		{
			Cooldown = FireRate;
		}

		var direction = position - transform.position;
		this.transform.up = direction;

<<<<<<< HEAD
		if(!this.Alternating || this.AlternatingCurrent == 0)
		{
			Projectile.Fire
			(
				from: Guns[0].transform.position,
				dir: transform.up,
				prefab: ProjectilePrefab
			);

			if (this.Alternating)
				this.AlternatingCurrent = 1;
		}
		else if(this.AlternatingCurrent == 1)
		{
			Projectile.Fire
			(
				from: Guns[1].transform.position,
				dir: transform.up,
				prefab: ProjectilePrefab
			);
			this.AlternatingCurrent = 0;
=======
		Component[] Guns = GetComponentsInChildren<Gun>();

		if (!Alternating)
		{
			foreach(var gun in Guns)
			{
				Projectile.Fire
				(
					from: gun.transform.position,
					dir: position - transform.position,
					prefab: ProjectilePrefab
				);
			}
>>>>>>> ac5638e6dd4c2056d40e4f6a08ca228fef875412
		}
		else
		{
			Projectile.Fire
			(
				from: Guns[AlternatingCurrent].transform.position,
				dir: position - transform.position,
				prefab: ProjectilePrefab
			);

			AlternatingCurrent = (AlternatingCurrent + 1) % Guns.Length;
		}
	}
}