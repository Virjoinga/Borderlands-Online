public interface IDamageListener
{
	void OnDamaged(DamageContext context);

	void OnEntityKill(KillContext context);
}
