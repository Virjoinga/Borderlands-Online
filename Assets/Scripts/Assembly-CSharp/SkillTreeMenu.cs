using System.Collections.Generic;
using A;
using UnityEngine;

public class SkillTreeMenu : MonoBehaviour
{
	public class GUITreeLayout
	{
		public List<GUILineLayout> m_lines = new List<GUILineLayout>();

		public PlayerSkillTreeManage m_skillTreeManager;

		private GUIButton_Slowdown m_btn_slowdown;

		public GUITreeLayout()
		{
			m_skillTreeManager = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<PlayerSkillTreeManage>();
			m_btn_slowdown = new GUIButton_Slowdown();
		}

		public void cb9e248e6a2f292fd596c387da112a63f(SkillItem[] c6fa07d5aecb8430ead41e7df2488f010, float c32ba65fdbfd4d12a4f584f8f2c471167, float ca374026bc7554a5423518083d838cbd6)
		{
			m_lines.Add(new GUILineLayout(c6fa07d5aecb8430ead41e7df2488f010, c32ba65fdbfd4d12a4f584f8f2c471167, ca374026bc7554a5423518083d838cbd6, this));
		}

		public void cb302806e463df4de9a1767da2d7d7ebf()
		{
			int num = 800;
			int num2 = 800;
			GUILayout.BeginArea(new Rect((Screen.width - num) / 2, 20f, num, num2));
			using (List<GUILineLayout>.Enumerator enumerator = m_lines.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GUILineLayout current = enumerator.Current;
					current.cb302806e463df4de9a1767da2d7d7ebf();
					GUILayout.Space(10f);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					break;
				}
			}
			m_btn_slowdown.cb302806e463df4de9a1767da2d7d7ebf();
			GUILayout.EndArea();
		}
	}

	public class GUIButton_Slowdown
	{
		private MarkManager.ESlowdownType m_type;

		private Dictionary<MarkManager.ESlowdownType, string> m_dict = new Dictionary<MarkManager.ESlowdownType, string>
		{
			{
				MarkManager.ESlowdownType.BeingMarking,
				"slow down when being marking"
			},
			{
				MarkManager.ESlowdownType.InMarkState,
				"slow down when in mark state"
			}
		};

		public void cb302806e463df4de9a1767da2d7d7ebf()
		{
			GUILayout.Space(12f);
			string text = m_dict[m_type];
			GUILayoutOption[] array = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = GUILayout.Width(200f);
			if (!GUILayout.Button(text, array))
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				int type;
				if (m_type == MarkManager.ESlowdownType.BeingMarking)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					type = 1;
				}
				else
				{
					type = 0;
				}
				m_type = (MarkManager.ESlowdownType)type;
				c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<PlayerSkillTreeManage>().c2f727c8b0dc503a67b7afc4dc8fad0f3(m_type);
				return;
			}
		}
	}

	public class GUILineLayout
	{
		public float m_pad = 10f;

		public float m_left;

		private List<SkillItem> m_items = new List<SkillItem>();

		private GUITreeLayout m_owner;

		public GUILineLayout(SkillItem[] c5dcfef59aa123921648b5081470b3706, float c32ba65fdbfd4d12a4f584f8f2c471167, float ca374026bc7554a5423518083d838cbd6, GUITreeLayout cf811c0d5de19d7fe22be8d61350b722d)
		{
			m_items.AddRange(c5dcfef59aa123921648b5081470b3706);
			m_left = c32ba65fdbfd4d12a4f584f8f2c471167;
			m_pad = ca374026bc7554a5423518083d838cbd6;
			m_owner = cf811c0d5de19d7fe22be8d61350b722d;
		}

		public void cb302806e463df4de9a1767da2d7d7ebf()
		{
			GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.Space(m_left);
			using (List<SkillItem>.Enumerator enumerator = m_items.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SkillItem current = enumerator.Current;
					if (GUILayout.Button(string.Format("{0} {1}", current.c2835e119bf53e3745d16fb1b15f9a690(), current.c1b5726f54c8d3b91eb210c6161ede742), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0)))
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (current.m_type == ESkillType.None)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
							continue;
						}
						current.OnClick();
						m_owner.m_skillTreeManager.c1dbff9b95a2e82e43a33a24cd7557719(current);
					}
					GUILayout.Space(m_pad);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00be;
					}
					continue;
					end_IL_00be:
					break;
				}
			}
			GUILayout.EndHorizontal();
		}
	}

	private GUITreeLayout m_treeLayout;

	private void Awake()
	{
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
		float c32ba65fdbfd4d12a4f584f8f2c = 10f;
		float ca374026bc7554a5423518083d838cbd = 10f;
		int cb192723869bc48ea5d2017bac40dcbab = 5;
		m_treeLayout = new GUITreeLayout();
		EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is FirebirdManage)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					GUITreeLayout treeLayout = m_treeLayout;
					SkillItem[] array = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
					array[0] = new SkillItem(ESkillType.FirebirdFirstAction, 1);
					treeLayout.cb9e248e6a2f292fd596c387da112a63f(array, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout2 = m_treeLayout;
					SkillItem[] array2 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
					array2[0] = new SkillItem(ESkillType.FirebirdSecondAction, 1);
					treeLayout2.cb9e248e6a2f292fd596c387da112a63f(array2, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout3 = m_treeLayout;
					SkillItem[] array3 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(6);
					array3[0] = new SkillItem(ESkillType.FireHeart, cb192723869bc48ea5d2017bac40dcbab);
					array3[1] = new SkillItem(ESkillType.FireEater, cb192723869bc48ea5d2017bac40dcbab);
					array3[2] = new SkillItem(ESkillType.Detonation, cb192723869bc48ea5d2017bac40dcbab);
					array3[3] = new SkillItem(ESkillType.Sparkle, cb192723869bc48ea5d2017bac40dcbab);
					array3[4] = new SkillItem(ESkillType.Resurrection);
					array3[5] = new SkillItem(ESkillType.Glare, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout3.cb9e248e6a2f292fd596c387da112a63f(array3, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout4 = m_treeLayout;
					SkillItem[] array4 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array4[0] = new SkillItem(ESkillType.FireWings, cb192723869bc48ea5d2017bac40dcbab);
					array4[1] = new SkillItem(ESkillType.Absorption, cb192723869bc48ea5d2017bac40dcbab);
					array4[2] = new SkillItem(ESkillType.Retaliation);
					treeLayout4.cb9e248e6a2f292fd596c387da112a63f(array4, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout5 = m_treeLayout;
					SkillItem[] array5 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array5[0] = new SkillItem(ESkillType.Ignition, cb192723869bc48ea5d2017bac40dcbab);
					array5[1] = new SkillItem(ESkillType.UndyingFlames, cb192723869bc48ea5d2017bac40dcbab);
					array5[2] = new SkillItem(ESkillType.DazzlingShots);
					treeLayout5.cb9e248e6a2f292fd596c387da112a63f(array5, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout6 = m_treeLayout;
					SkillItem[] array6 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array6[0] = new SkillItem(ESkillType.Gifted, cb192723869bc48ea5d2017bac40dcbab);
					array6[1] = new SkillItem(ESkillType.Ablaze, cb192723869bc48ea5d2017bac40dcbab);
					array6[2] = new SkillItem(ESkillType.Energize);
					treeLayout6.cb9e248e6a2f292fd596c387da112a63f(array6, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout7 = m_treeLayout;
					SkillItem[] array7 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array7[0] = new SkillItem(ESkillType.Ethereal, cb192723869bc48ea5d2017bac40dcbab);
					array7[1] = new SkillItem(ESkillType.Astute, cb192723869bc48ea5d2017bac40dcbab);
					array7[2] = new SkillItem(ESkillType.Deception);
					treeLayout7.cb9e248e6a2f292fd596c387da112a63f(array7, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					return;
				}
				}
			}
		}
		if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is BerserkManage)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					GUITreeLayout treeLayout8 = m_treeLayout;
					SkillItem[] array8 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
					array8[0] = new SkillItem(ESkillType.BerserkFirstAction, 1);
					treeLayout8.cb9e248e6a2f292fd596c387da112a63f(array8, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout9 = m_treeLayout;
					SkillItem[] array9 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
					array9[0] = new SkillItem(ESkillType.BerserkSecondAction, 1);
					treeLayout9.cb9e248e6a2f292fd596c387da112a63f(array9, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout10 = m_treeLayout;
					SkillItem[] array10 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(6);
					array10[0] = new SkillItem(ESkillType.BigPockets, cb192723869bc48ea5d2017bac40dcbab);
					array10[1] = new SkillItem(ESkillType.BamBam, cb192723869bc48ea5d2017bac40dcbab);
					array10[2] = new SkillItem(ESkillType.BerserkOverweight, cb192723869bc48ea5d2017bac40dcbab);
					array10[3] = new SkillItem(ESkillType.BadTemper, cb192723869bc48ea5d2017bac40dcbab);
					array10[4] = new SkillItem(ESkillType.PhantomShot, cb192723869bc48ea5d2017bac40dcbab);
					array10[5] = new SkillItem(ESkillType.MagicBullet, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout10.cb9e248e6a2f292fd596c387da112a63f(array10, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout11 = m_treeLayout;
					SkillItem[] array11 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array11[0] = new SkillItem(ESkillType.CombatReload, cb192723869bc48ea5d2017bac40dcbab);
					array11[1] = new SkillItem(ESkillType.Bloodlust, cb192723869bc48ea5d2017bac40dcbab);
					array11[2] = new SkillItem(ESkillType.Retribution, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout11.cb9e248e6a2f292fd596c387da112a63f(array11, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout12 = m_treeLayout;
					SkillItem[] array12 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array12[0] = new SkillItem(ESkillType.RedFury, cb192723869bc48ea5d2017bac40dcbab);
					array12[1] = new SkillItem(ESkillType.BURP, cb192723869bc48ea5d2017bac40dcbab);
					array12[2] = new SkillItem(ESkillType.Discharge, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout12.cb9e248e6a2f292fd596c387da112a63f(array12, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout13 = m_treeLayout;
					SkillItem[] array13 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array13[0] = new SkillItem(ESkillType.Boxer, cb192723869bc48ea5d2017bac40dcbab);
					array13[1] = new SkillItem(ESkillType.Adrenaline, cb192723869bc48ea5d2017bac40dcbab);
					array13[2] = new SkillItem(ESkillType.Desperation, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout13.cb9e248e6a2f292fd596c387da112a63f(array13, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout14 = m_treeLayout;
					SkillItem[] array14 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array14[0] = new SkillItem(ESkillType.Tenacity, cb192723869bc48ea5d2017bac40dcbab);
					array14[1] = new SkillItem(ESkillType.Relentless, cb192723869bc48ea5d2017bac40dcbab);
					array14[2] = new SkillItem(ESkillType.Fortitude, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout14.cb9e248e6a2f292fd596c387da112a63f(array14, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					return;
				}
				}
			}
		}
		if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is TurretManage)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					GUITreeLayout treeLayout15 = m_treeLayout;
					SkillItem[] array15 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
					array15[0] = new SkillItem(ESkillType.TurretFirstAction, 1);
					treeLayout15.cb9e248e6a2f292fd596c387da112a63f(array15, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout16 = m_treeLayout;
					SkillItem[] array16 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
					array16[0] = new SkillItem(ESkillType.TurretSecondAction, 1);
					treeLayout16.cb9e248e6a2f292fd596c387da112a63f(array16, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout17 = m_treeLayout;
					SkillItem[] array17 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(6);
					array17[0] = new SkillItem(ESkillType.SpeedyHands, cb192723869bc48ea5d2017bac40dcbab);
					array17[1] = new SkillItem(ESkillType.SecretPouch, cb192723869bc48ea5d2017bac40dcbab);
					array17[2] = new SkillItem(ESkillType.BionicLink, cb192723869bc48ea5d2017bac40dcbab);
					array17[3] = new SkillItem(ESkillType.SupplyPack, cb192723869bc48ea5d2017bac40dcbab);
					array17[4] = new SkillItem(ESkillType.Unison, cb192723869bc48ea5d2017bac40dcbab);
					array17[5] = new SkillItem(ESkillType.Conservation, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout17.cb9e248e6a2f292fd596c387da112a63f(array17, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout18 = m_treeLayout;
					SkillItem[] array18 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array18[0] = new SkillItem(ESkillType.ShotPut, cb192723869bc48ea5d2017bac40dcbab);
					array18[1] = new SkillItem(ESkillType.Bunker, cb192723869bc48ea5d2017bac40dcbab);
					array18[2] = new SkillItem(ESkillType.Decompress, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout18.cb9e248e6a2f292fd596c387da112a63f(array18, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout19 = m_treeLayout;
					SkillItem[] array19 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array19[0] = new SkillItem(ESkillType.Rocker, cb192723869bc48ea5d2017bac40dcbab);
					array19[1] = new SkillItem(ESkillType.ShortCircuit, cb192723869bc48ea5d2017bac40dcbab);
					array19[2] = new SkillItem(ESkillType.Aftershock, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout19.cb9e248e6a2f292fd596c387da112a63f(array19, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout20 = m_treeLayout;
					SkillItem[] array20 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array20[0] = new SkillItem(ESkillType.FirePowder, cb192723869bc48ea5d2017bac40dcbab);
					array20[1] = new SkillItem(ESkillType.ShieldBomb, cb192723869bc48ea5d2017bac40dcbab);
					array20[2] = new SkillItem(ESkillType.Battery, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout20.cb9e248e6a2f292fd596c387da112a63f(array20, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					GUITreeLayout treeLayout21 = m_treeLayout;
					SkillItem[] array21 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
					array21[0] = new SkillItem(ESkillType.Repulsor, cb192723869bc48ea5d2017bac40dcbab);
					array21[1] = new SkillItem(ESkillType.Electrocute, cb192723869bc48ea5d2017bac40dcbab);
					array21[2] = new SkillItem(ESkillType.Readiness, cb192723869bc48ea5d2017bac40dcbab);
					treeLayout21.cb9e248e6a2f292fd596c387da112a63f(array21, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
					return;
				}
				}
			}
		}
		if (!(entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is HunterManage))
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			GUITreeLayout treeLayout22 = m_treeLayout;
			SkillItem[] array22 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
			array22[0] = new SkillItem(ESkillType.HunterFirstAction, 1);
			treeLayout22.cb9e248e6a2f292fd596c387da112a63f(array22, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			GUITreeLayout treeLayout23 = m_treeLayout;
			SkillItem[] array23 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(1);
			array23[0] = new SkillItem(ESkillType.HunterSecondAction, 1);
			treeLayout23.cb9e248e6a2f292fd596c387da112a63f(array23, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			GUITreeLayout treeLayout24 = m_treeLayout;
			SkillItem[] array24 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(6);
			array24[0] = new SkillItem(ESkillType.Swift, cb192723869bc48ea5d2017bac40dcbab);
			array24[1] = new SkillItem(ESkillType.Intangible, cb192723869bc48ea5d2017bac40dcbab);
			array24[2] = new SkillItem(ESkillType.VitalPoint, cb192723869bc48ea5d2017bac40dcbab);
			array24[3] = new SkillItem(ESkillType.Exploit, cb192723869bc48ea5d2017bac40dcbab);
			array24[4] = new SkillItem(ESkillType.Precision, cb192723869bc48ea5d2017bac40dcbab);
			array24[5] = new SkillItem(ESkillType.Balanced, cb192723869bc48ea5d2017bac40dcbab);
			treeLayout24.cb9e248e6a2f292fd596c387da112a63f(array24, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			GUITreeLayout treeLayout25 = m_treeLayout;
			SkillItem[] array25 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
			array25[0] = new SkillItem(ESkillType.Shift, cb192723869bc48ea5d2017bac40dcbab);
			array25[1] = new SkillItem(ESkillType.Volatile, cb192723869bc48ea5d2017bac40dcbab);
			array25[2] = new SkillItem(ESkillType.Booster, cb192723869bc48ea5d2017bac40dcbab);
			treeLayout25.cb9e248e6a2f292fd596c387da112a63f(array25, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			GUITreeLayout treeLayout26 = m_treeLayout;
			SkillItem[] array26 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
			array26[0] = new SkillItem(ESkillType.Siphon, cb192723869bc48ea5d2017bac40dcbab);
			array26[1] = new SkillItem(ESkillType.Bounty, cb192723869bc48ea5d2017bac40dcbab);
			array26[2] = new SkillItem(ESkillType.Disorientate, cb192723869bc48ea5d2017bac40dcbab);
			treeLayout26.cb9e248e6a2f292fd596c387da112a63f(array26, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			GUITreeLayout treeLayout27 = m_treeLayout;
			SkillItem[] array27 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
			array27[0] = new SkillItem(ESkillType.Continuity, cb192723869bc48ea5d2017bac40dcbab);
			array27[1] = new SkillItem(ESkillType.ChargedShot, cb192723869bc48ea5d2017bac40dcbab);
			array27[2] = new SkillItem(ESkillType.Redirect, cb192723869bc48ea5d2017bac40dcbab);
			treeLayout27.cb9e248e6a2f292fd596c387da112a63f(array27, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			GUITreeLayout treeLayout28 = m_treeLayout;
			SkillItem[] array28 = c33e33eb4a6cdb53bb5c40b305f47c1a1.c0a0cdf4a196914163f7334d9b0781a04(3);
			array28[0] = new SkillItem(ESkillType.Vigilance, cb192723869bc48ea5d2017bac40dcbab);
			array28[1] = new SkillItem(ESkillType.Impedance, cb192723869bc48ea5d2017bac40dcbab);
			array28[2] = new SkillItem(ESkillType.Scan, cb192723869bc48ea5d2017bac40dcbab);
			treeLayout28.cb9e248e6a2f292fd596c387da112a63f(array28, c32ba65fdbfd4d12a4f584f8f2c, ca374026bc7554a5423518083d838cbd);
			return;
		}
	}

	public void ce7ae451e46fa21f3e8f2e60314307ec6()
	{
		if (!(c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
			return;
		}
	}
}
