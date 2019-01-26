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
		
		this.transform.up = Game.MousePosition - transform.position;
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

		Component[] Guns = this.GetGuns();

		transform.up = position - transform.position;

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
		}
	}

	private Component[] GetGuns()
	{
		return GetComponentsInChildren<Gun>();
	}
}