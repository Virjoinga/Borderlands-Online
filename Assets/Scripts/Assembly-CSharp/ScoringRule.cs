using XsdSettings;

public interface ScoringRule
{
	void ccc9d3a38966dc10fedb531ea17d24611();

	void OnDamagedPreStat(DamageContext context);

	void OnDamagedPostStat(DamageContext context);

	void OnEntityKillPreStat(KillContext context);

	void OnEntityKillPostStat(KillContext context);

	int c1cf78bc79484f63267d4766d6776b199(ScoringActionType c861de212c63da4e42109937e3cac1a44);

	void cb61f0369d09ada426256a3f4b80236fa(int c8a7f3986726d4793d7b3f3bbcc750943);

	void c79b0bc249fb8e76dcf6d1941f8abaee5(Entity cf7ee7f254a35f9c53a393957e2758a0a);

	void OnUpdateMatch();

	void OnEndMatch();

	void c8016e12695c9b13b19ba1bba03f30c6f(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b);
}
