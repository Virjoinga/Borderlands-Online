using System;
using UnityEngine;

public class ldlt
{
	public static void c5d25e45542123ec3a2d0619791ab3221(ref float[,] c8afd0d53d6687bf18e0654bc7cf43a65, int cf5d861c74bc5f76089eaa0e6f21526c0, bool ca905981cbcc3924d81f44343b316da0d, float[] c0cff27f286007e407710e3a742bca5fd)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		float num17 = 0f;
		float num18 = 0f;
		float num19 = 0f;
		float num20 = 0f;
		float num21 = 0f;
		int num22 = 0;
		float num23 = 0f;
		int num24 = 0;
		num10 = (1f + Mathf.Sqrt(17f)) / 8f;
		if (ca905981cbcc3924d81f44343b316da0d)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					for (num5 = cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num5 >= 0; num5 -= num8)
					{
						num8 = 1;
						num9 = Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num5, num5]);
						if (num5 > 0)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
							num2 = 1;
							for (num22 = 2; num22 <= num5; num22++)
							{
								if (Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num22 - 1, num5]) > Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num5]))
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											continue;
										}
										break;
									}
									num2 = num22;
								}
							}
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							num11 = Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num5]);
						}
						else
						{
							num11 = 0f;
						}
						if (Math.Max(num9, num11) == 0f)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
							num7 = num5;
						}
						else
						{
							if (num9 >= num10 * num11)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								num7 = num5;
							}
							else
							{
								num4 = num2 + 1;
								for (num22 = num2 + 2; num22 <= num5 + 1; num22++)
								{
									if (Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num22 - 1]) > Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num4 - 1]))
									{
										while (true)
										{
											switch (4)
											{
											case 0:
												continue;
											}
											break;
										}
										num4 = num22;
									}
								}
								while (true)
								{
									switch (2)
									{
									case 0:
										continue;
									}
									break;
								}
								num17 = Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num4 - 1]);
								if (num2 > 1)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											continue;
										}
										break;
									}
									num4 = 1;
									for (num22 = 2; num22 <= num2 - 1; num22++)
									{
										if (Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num22 - 1, num2 - 1]) > Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num4 - 1, num2 - 1]))
										{
											while (true)
											{
												switch (7)
												{
												case 0:
													continue;
												}
												break;
											}
											num4 = num22;
										}
									}
									while (true)
									{
										switch (2)
										{
										case 0:
											continue;
										}
										break;
									}
									num17 = Math.Max(num17, Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num4 - 1, num2 - 1]));
								}
								num23 = num11 / num17;
								if (num9 >= num10 * num11 * num23)
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
									num7 = num5;
								}
								else if (Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num2 - 1]) >= num10 * num17)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											continue;
										}
										break;
									}
									num7 = num2 - 1;
								}
								else
								{
									num7 = num2 - 1;
									num8 = 2;
								}
							}
							num6 = num5 + 1 - num8;
							if (num7 + 1 != num6 + 1)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = 0; num24 <= num7 - 1; num24++)
								{
									c0cff27f286007e407710e3a742bca5fd[num24] = c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6];
								}
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = 0; num24 <= num7 - 1; num24++)
								{
									c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6] = c8afd0d53d6687bf18e0654bc7cf43a65[num24, num7];
								}
								while (true)
								{
									switch (3)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = 0; num24 <= num7 - 1; num24++)
								{
									c8afd0d53d6687bf18e0654bc7cf43a65[num24, num7] = c0cff27f286007e407710e3a742bca5fd[num24];
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = num7 + 1; num24 <= num6 - 1; num24++)
								{
									c0cff27f286007e407710e3a742bca5fd[num24] = c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6];
								}
								while (true)
								{
									switch (4)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = num7 + 1; num24 <= num6 - 1; num24++)
								{
									c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6] = c8afd0d53d6687bf18e0654bc7cf43a65[num7, num24];
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = num7 + 1; num24 <= num6 - 1; num24++)
								{
									c8afd0d53d6687bf18e0654bc7cf43a65[num7, num24] = c0cff27f286007e407710e3a742bca5fd[num24];
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								num18 = c8afd0d53d6687bf18e0654bc7cf43a65[num6, num6];
								c8afd0d53d6687bf18e0654bc7cf43a65[num6, num6] = c8afd0d53d6687bf18e0654bc7cf43a65[num7, num7];
								c8afd0d53d6687bf18e0654bc7cf43a65[num7, num7] = num18;
								if (num8 == 2)
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											continue;
										}
										break;
									}
									num18 = c8afd0d53d6687bf18e0654bc7cf43a65[num5 - 1, num5];
									c8afd0d53d6687bf18e0654bc7cf43a65[num5 - 1, num5] = c8afd0d53d6687bf18e0654bc7cf43a65[num7, num5];
									c8afd0d53d6687bf18e0654bc7cf43a65[num7, num5] = num18;
								}
							}
							if (num8 == 1)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								num16 = 1f / c8afd0d53d6687bf18e0654bc7cf43a65[num5, num5];
								for (num = 0; num <= num5 - 1; num++)
								{
									num23 = 0f - num16 * c8afd0d53d6687bf18e0654bc7cf43a65[num, num5];
									for (num24 = num; num24 <= num5 - 1; num24++)
									{
										c8afd0d53d6687bf18e0654bc7cf43a65[num, num24] += num23 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5];
									}
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											goto end_IL_0531;
										}
										continue;
										end_IL_0531:
										break;
									}
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								for (num24 = 0; num24 <= num5 - 1; num24++)
								{
									c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5] = num16 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5];
								}
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
							}
							else if (num5 > 1)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										continue;
									}
									break;
								}
								num13 = c8afd0d53d6687bf18e0654bc7cf43a65[num5 - 1, num5];
								num15 = c8afd0d53d6687bf18e0654bc7cf43a65[num5 - 1, num5 - 1] / num13;
								num12 = c8afd0d53d6687bf18e0654bc7cf43a65[num5, num5] / num13;
								num18 = 1f / (num12 * num15 - 1f);
								num13 = num18 / num13;
								num3 = num5 - 2;
								while (num3 >= 0)
								{
									num20 = num13 * (num12 * c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5 - 1] - c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5]);
									num19 = num13 * (num15 * c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5] - c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5 - 1]);
									for (num24 = 0; num24 <= num3; num24++)
									{
										c8afd0d53d6687bf18e0654bc7cf43a65[num24, num3] -= num19 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5];
									}
									while (true)
									{
										switch (2)
										{
										case 0:
											break;
										default:
											for (num24 = 0; num24 <= num3; num24++)
											{
												c8afd0d53d6687bf18e0654bc7cf43a65[num24, num3] -= num20 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5 - 1];
											}
											while (true)
											{
												switch (2)
												{
												case 0:
													break;
												default:
													goto end_IL_06bc;
												}
												continue;
												end_IL_06bc:
												break;
											}
											c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5] = num19;
											c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5 - 1] = num20;
											num3--;
											goto end_IL_0679;
										}
										continue;
										end_IL_0679:
										break;
									}
								}
								while (true)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									break;
								}
							}
						}
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}
		for (num5 = 0; num5 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num5 += num8)
		{
			num8 = 1;
			num9 = Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num5, num5]);
			if (num5 < cf5d861c74bc5f76089eaa0e6f21526c0 - 1)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				num2 = num5 + 1 + 1;
				for (num22 = num5 + 1 + 2; num22 <= cf5d861c74bc5f76089eaa0e6f21526c0; num22++)
				{
					if (!(Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num22 - 1, num5]) > Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num5])))
					{
						continue;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					num2 = num22;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				num11 = Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num5]);
			}
			else
			{
				num11 = 0f;
			}
			if (Math.Max(num9, num11) == 0f)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				num7 = num5;
				continue;
			}
			if (num9 >= num10 * num11)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				num7 = num5;
			}
			else
			{
				num4 = num5 + 1;
				for (num22 = num5 + 1 + 1; num22 <= num2 - 1; num22++)
				{
					if (!(Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num22 - 1]) > Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num4 - 1])))
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					num4 = num22;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				num17 = Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num4 - 1]);
				if (num2 < cf5d861c74bc5f76089eaa0e6f21526c0)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					num4 = num2 + 1;
					for (num22 = num2 + 2; num22 <= cf5d861c74bc5f76089eaa0e6f21526c0; num22++)
					{
						if (!(Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num22 - 1, num2 - 1]) > Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num4 - 1, num2 - 1])))
						{
							continue;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						num4 = num22;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					num17 = Math.Max(num17, Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num4 - 1, num2 - 1]));
				}
				num23 = num11 / num17;
				if (num9 >= num10 * num11 * num23)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					num7 = num5;
				}
				else if (Math.Abs(c8afd0d53d6687bf18e0654bc7cf43a65[num2 - 1, num2 - 1]) >= num10 * num17)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					num7 = num2 - 1;
				}
				else
				{
					num7 = num2 - 1;
					num8 = 2;
				}
			}
			num6 = num5 + num8 - 1;
			if (num7 != num6)
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
				if (num7 + 1 < cf5d861c74bc5f76089eaa0e6f21526c0)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					for (num24 = num7 + 1; num24 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num24++)
					{
						c0cff27f286007e407710e3a742bca5fd[num24] = c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6];
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					for (num24 = num7 + 1; num24 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num24++)
					{
						c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6] = c8afd0d53d6687bf18e0654bc7cf43a65[num24, num7];
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					for (num24 = num7 + 1; num24 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num24++)
					{
						c8afd0d53d6687bf18e0654bc7cf43a65[num24, num7] = c0cff27f286007e407710e3a742bca5fd[num24];
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				for (num24 = num6 + 1; num24 <= num7 - 1; num24++)
				{
					c0cff27f286007e407710e3a742bca5fd[num24] = c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6];
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				for (num24 = num6 + 1; num24 <= num7 - 1; num24++)
				{
					c8afd0d53d6687bf18e0654bc7cf43a65[num24, num6] = c8afd0d53d6687bf18e0654bc7cf43a65[num7, num24];
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				for (num24 = num6 + 1; num24 <= num7 - 1; num24++)
				{
					c8afd0d53d6687bf18e0654bc7cf43a65[num7, num24] = c0cff27f286007e407710e3a742bca5fd[num24];
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				num18 = c8afd0d53d6687bf18e0654bc7cf43a65[num6, num6];
				c8afd0d53d6687bf18e0654bc7cf43a65[num6, num6] = c8afd0d53d6687bf18e0654bc7cf43a65[num7, num7];
				c8afd0d53d6687bf18e0654bc7cf43a65[num7, num7] = num18;
				if (num8 == 2)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					num18 = c8afd0d53d6687bf18e0654bc7cf43a65[num5 + 1, num5];
					c8afd0d53d6687bf18e0654bc7cf43a65[num5 + 1, num5] = c8afd0d53d6687bf18e0654bc7cf43a65[num7, num5];
					c8afd0d53d6687bf18e0654bc7cf43a65[num7, num5] = num18;
				}
			}
			if (num8 == 1)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (num5 + 1 >= cf5d861c74bc5f76089eaa0e6f21526c0)
				{
					continue;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				num12 = 1f / c8afd0d53d6687bf18e0654bc7cf43a65[num5 + 1 - 1, num5 + 1 - 1];
				for (num22 = num5 + 1; num22 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num22++)
				{
					num23 = 0f - num12 * c8afd0d53d6687bf18e0654bc7cf43a65[num22, num5];
					for (num24 = num5 + 1; num24 <= num22; num24++)
					{
						c8afd0d53d6687bf18e0654bc7cf43a65[num22, num24] += num23 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5];
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_0bdd;
						}
						continue;
						end_IL_0bdd:
						break;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				for (num24 = num5 + 1; num24 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num24++)
				{
					c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5] = num12 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5];
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			else
			{
				if (num5 >= cf5d861c74bc5f76089eaa0e6f21526c0 - 2)
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				num14 = c8afd0d53d6687bf18e0654bc7cf43a65[num5 + 1, num5];
				num12 = c8afd0d53d6687bf18e0654bc7cf43a65[num5 + 1, num5 + 1] / num14;
				num15 = c8afd0d53d6687bf18e0654bc7cf43a65[num5, num5] / num14;
				num18 = 1f / (num12 * num15 - 1f);
				num14 = num18 / num14;
				num3 = num5 + 2;
				while (num3 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1)
				{
					num19 = num14 * (num12 * c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5] - c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5 + 1]);
					num21 = num14 * (num15 * c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5 + 1] - c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5]);
					for (num24 = num3; num24 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num24++)
					{
						c8afd0d53d6687bf18e0654bc7cf43a65[num24, num3] -= num19 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5];
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						for (num24 = num3; num24 <= cf5d861c74bc5f76089eaa0e6f21526c0 - 1; num24++)
						{
							c8afd0d53d6687bf18e0654bc7cf43a65[num24, num3] -= num21 * c8afd0d53d6687bf18e0654bc7cf43a65[num24, num5 + 1];
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								goto end_IL_0d72;
							}
							continue;
							end_IL_0d72:
							break;
						}
						c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5] = num19;
						c8afd0d53d6687bf18e0654bc7cf43a65[num3, num5 + 1] = num21;
						num3++;
						break;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
