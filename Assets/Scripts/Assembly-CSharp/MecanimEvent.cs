using System;
using System.Collections.Generic;

[Serializable]
public class MecanimEvent
{
	public string functionName;

	public float normalizedTime;

	public MecanimEventParamTypes paramType;

	private BaseEventEnumList eventEnumList;

	public int intParam;

	public float floatParam;

	public string stringParam;

	public bool boolParam;

	public string enumParam;

	public static string[] enumParamList;

	public EventCondition condition;

	public bool critical;

	public bool isEnable = true;

	private EventContext context;

	public static EventContext Context { get; protected set; }

	public object parameter
	{
		get
		{
			switch (paramType)
			{
			case MecanimEventParamTypes.Int32:
				return intParam;
			case MecanimEventParamTypes.Float:
				return floatParam;
			case MecanimEventParamTypes.String:
				return stringParam;
			case MecanimEventParamTypes.Boolean:
				return boolParam;
			case MecanimEventParamTypes.EnumList:
				return enumParam;
			default:
				return null;
			}
		}
	}

	public MecanimEvent()
	{
		condition = new EventCondition();
		eventEnumList = new BaseEventEnumList();
		List<string> list = new List<string>();
		using (Dictionary<int, string>.Enumerator enumerator = eventEnumList.DicData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				list.Add(enumerator.Current.Value);
			}
			while (true)
			{
				switch (7)
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
		enumParamList = list.ToArray();
	}

	public MecanimEvent(MecanimEvent c6ab743f31b30bfca58e451188f2c9421)
	{
		normalizedTime = c6ab743f31b30bfca58e451188f2c9421.normalizedTime;
		functionName = c6ab743f31b30bfca58e451188f2c9421.functionName;
		paramType = c6ab743f31b30bfca58e451188f2c9421.paramType;
		switch (paramType)
		{
		case MecanimEventParamTypes.Int32:
			intParam = c6ab743f31b30bfca58e451188f2c9421.intParam;
			break;
		case MecanimEventParamTypes.Float:
			floatParam = c6ab743f31b30bfca58e451188f2c9421.floatParam;
			break;
		case MecanimEventParamTypes.String:
			stringParam = c6ab743f31b30bfca58e451188f2c9421.stringParam;
			break;
		case MecanimEventParamTypes.Boolean:
			boolParam = c6ab743f31b30bfca58e451188f2c9421.boolParam;
			break;
		case MecanimEventParamTypes.EnumList:
			enumParam = c6ab743f31b30bfca58e451188f2c9421.enumParam;
			break;
		}
		condition = new EventCondition();
		condition.conditions = new List<EventConditionEntry>(c6ab743f31b30bfca58e451188f2c9421.condition.conditions);
		critical = c6ab743f31b30bfca58e451188f2c9421.critical;
		isEnable = c6ab743f31b30bfca58e451188f2c9421.isEnable;
	}

	public int c99db88c3f9a2113da34e571081db7f7b()
	{
		for (int i = 0; i < enumParamList.Length; i++)
		{
			if (!(enumParamList[i] == enumParam))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return i;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return 0;
		}
	}

	public void c2eaf6d5580516e9c0af5f66d826e18cb(int cae80adcd816940694e39ede2c2d356ee)
	{
		enumParam = enumParamList[cae80adcd816940694e39ede2c2d356ee];
	}

	public void c076011a8a4a8a431f020df4195346d03(EventContext c2970555c0fc69d9442a248a8e3fc971c)
	{
		context = c2970555c0fc69d9442a248a8e3fc971c;
		context.current = this;
	}

	public static void c3094946243c26396f504b818c6388458(MecanimEvent c05f6b47f5e84359168dfe9aaf57b8a79)
	{
		Context = c05f6b47f5e84359168dfe9aaf57b8a79.context;
	}
}
