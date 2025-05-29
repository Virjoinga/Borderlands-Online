using pumpkin.display;
using pumpkin.text;

namespace A
{
	public class c6ae57b6b0eaf6c226a8fff792fb808df : c9f62278a5e2341872ad7373d9bb65f26
	{
		private MovieClip cff49a55edc4cb8bf48585bbb35002a3c;

		private MovieClip cdef482a78ba178bbdf1094643de75ddb;

		private MovieClip cc55b9f74cc416303501c6320672eeaca;

		private TextField c8085d49b92aea7a0479dadf522d55edd;

		private TextField c232660b102124d66343c5c24528e9806;

		private TextField ce99f408be8259ae3ff9d5f45d0b44399;

		private TextField c37f9fa7417b098dc92d5ce646a73ec56;

		private TextField c6f8e853f5111ba8cce0c02d83932f9df;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			cff49a55edc4cb8bf48585bbb35002a3c = movieClip.getChildByName<MovieClip>("mc_title");
			cdef482a78ba178bbdf1094643de75ddb = movieClip.getChildByName<MovieClip>("mc_detail1");
			cc55b9f74cc416303501c6320672eeaca = movieClip.getChildByName<MovieClip>("mc_detail2");
			cdef482a78ba178bbdf1094643de75ddb.visible = false;
			c8085d49b92aea7a0479dadf522d55edd = cff49a55edc4cb8bf48585bbb35002a3c.getChildByName<TextField>("tf_title");
			c232660b102124d66343c5c24528e9806 = cc55b9f74cc416303501c6320672eeaca.getChildByName<TextField>("tf_prefix2");
			ce99f408be8259ae3ff9d5f45d0b44399 = cc55b9f74cc416303501c6320672eeaca.getChildByName<TextField>("tf_data2");
			c37f9fa7417b098dc92d5ce646a73ec56 = cdef482a78ba178bbdf1094643de75ddb.getChildByName<TextField>("tf_prefix1");
			c6f8e853f5111ba8cce0c02d83932f9df = cdef482a78ba178bbdf1094643de75ddb.getChildByName<TextField>("tf_data1");
			c37f9fa7417b098dc92d5ce646a73ec56.text = string.Empty;
			c6f8e853f5111ba8cce0c02d83932f9df.text = string.Empty;
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
		}

		public void c2786f1425a63a64bd01b4ba445fb8ba9(string c682d9c5b8f0b6928c6d5849c0aaf023a, string cddbba325e886c08ed7783a87d1552c17, bool c77bc86b28abe877379b369fb277f2f36 = false)
		{
			if (c77bc86b28abe877379b369fb277f2f36)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						cff49a55edc4cb8bf48585bbb35002a3c.visible = true;
						cc55b9f74cc416303501c6320672eeaca.visible = false;
						cdef482a78ba178bbdf1094643de75ddb.visible = false;
						c8085d49b92aea7a0479dadf522d55edd.text = c682d9c5b8f0b6928c6d5849c0aaf023a;
						c232660b102124d66343c5c24528e9806.text = string.Empty;
						ce99f408be8259ae3ff9d5f45d0b44399.text = string.Empty;
						return;
					}
				}
			}
			cff49a55edc4cb8bf48585bbb35002a3c.visible = false;
			cc55b9f74cc416303501c6320672eeaca.visible = true;
			cdef482a78ba178bbdf1094643de75ddb.visible = false;
			c8085d49b92aea7a0479dadf522d55edd.text = string.Empty;
			c232660b102124d66343c5c24528e9806.text = c682d9c5b8f0b6928c6d5849c0aaf023a;
			ce99f408be8259ae3ff9d5f45d0b44399.text = cddbba325e886c08ed7783a87d1552c17;
		}
	}
}
