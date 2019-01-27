using UnityEngine;

public class Turret : MonoBehaviour
{
	public Projectile ProjectilePrefab;

	public bool Enabled
	{
		get { return gameObject.activeInHierarchy; }
		set { gameObject.SetActive(value); }
	}

	public bool Alternating;
	private int AlternatingCurrent = 0;
	public float FireRate;
	public float FireSpeedBonusMultiplier = 0;
	public int Ammo;

	[Header("Game State")]
	public float Cooldown;

	public void Update()
	{
		Cooldown -= Time.deltaTime * (1 + FireSpeedBonusMultiplier);
		if (Cooldown < 0) { Cooldown = 0; }
	}
	public virtual void FireAt (Vector3 position)
	{
		if(Ammo == 0) return;
		if(Ammo != -1) Ammo--;
		if (Cooldown > 0 || !Enabled)
		{
			return;
		}
		else
		{
			Cooldown = FireRate;
		}

		var direction = position - transform.position;
		if(!this.transform.gameObject.CompareTag("Satelite"))
		{
			this.transform.up = direction;
		}
		else direction = this.transform.up;

		Component[] Guns = GetComponentsInChildren<Gun>();

		if (!Alternating)
		{
			foreach(var gun in Guns)
			{
				Projectile.Fire
				(
					from: gun.transform.position,
					dir: direction,
					prefab: ProjectilePrefab
				);
			}
		}
		else
		{
			Projectile.Fire
			(
				from: Guns[AlternatingCurrent].transform.position,
				dir: direction,
				prefab: ProjectilePrefab
			);

			AlternatingCurrent = (AlternatingCurrent + 1) % Guns.Length;
		}
	}
}