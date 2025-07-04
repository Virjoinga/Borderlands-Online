namespace ExitGames.Client.Photon
{
	public class TrafficStatsGameLevel
	{
		private int timeOfLastDispatchCall;

		private int timeOfLastSendCall;

		public int OperationByteCount { get; internal set; }

		public int OperationCount { get; internal set; }

		public int ResultByteCount { get; internal set; }

		public int ResultCount { get; internal set; }

		public int EventByteCount { get; internal set; }

		public int EventCount { get; internal set; }

		public int LongestOpResponseCallback { get; internal set; }

		public byte LongestOpResponseCallbackOpCode { get; internal set; }

		public int LongestEventCallback { get; internal set; }

		public byte LongestEventCallbackCode { get; internal set; }

		public int LongestDeltaBetweenDispatching { get; internal set; }

		public int LongestDeltaBetweenSending { get; internal set; }

		public int DispatchCalls { get; internal set; }

		public int SendOutgoingCommandsCalls { get; internal set; }

		public int TotalByteCount
		{
			get
			{
				return OperationByteCount + ResultByteCount + EventByteCount;
			}
		}

		public int TotalMessageCount
		{
			get
			{
				return OperationCount + ResultCount + EventCount;
			}
		}

		public int TotalIncomingByteCount
		{
			get
			{
				return ResultByteCount + EventByteCount;
			}
		}

		public int TotalIncomingMessageCount
		{
			get
			{
				return ResultCount + EventCount;
			}
		}

		public int TotalOutgoingByteCount
		{
			get
			{
				return OperationByteCount;
			}
		}

		public int TotalOutgoingMessageCount
		{
			get
			{
				return OperationCount;
			}
		}

		internal void CountOperation(int operationBytes)
		{
			OperationByteCount += operationBytes;
			OperationCount++;
		}

		internal void CountResult(int resultBytes)
		{
			ResultByteCount += resultBytes;
			ResultCount++;
		}

		internal void CountEvent(int eventBytes)
		{
			EventByteCount += eventBytes;
			EventCount++;
		}

		internal void TimeForResponseCallback(byte code, int time)
		{
			if (time > LongestOpResponseCallback)
			{
				LongestOpResponseCallback = time;
				LongestOpResponseCallbackOpCode = code;
			}
		}

		internal void TimeForEventCallback(byte code, int time)
		{
			if (time > LongestOpResponseCallback)
			{
				LongestEventCallback = time;
				LongestEventCallbackCode = code;
			}
		}

		internal void DispatchIncomingCommandsCalled()
		{
			if (timeOfLastDispatchCall != 0)
			{
				int num = SupportClass.GetTickCount() - timeOfLastDispatchCall;
				if (num > LongestDeltaBetweenDispatching)
				{
					LongestDeltaBetweenDispatching = num;
				}
			}
			DispatchCalls++;
			timeOfLastDispatchCall = SupportClass.GetTickCount();
		}

		internal void SendOutgoingCommandsCalled()
		{
			if (timeOfLastSendCall != 0)
			{
				int num = SupportClass.GetTickCount() - timeOfLastSendCall;
				if (num > LongestDeltaBetweenSending)
				{
					LongestDeltaBetweenSending = num;
				}
			}
			SendOutgoingCommandsCalls++;
			timeOfLastSendCall = SupportClass.GetTickCount();
		}

		public override string ToString()
		{
			return string.Format("OperationByteCount: {0} ResultByteCount: {1} EventByteCount: {2}", OperationByteCount, ResultByteCount, EventByteCount);
		}

		public string ToStringVitalStats()
		{
			return string.Format("Longest delta between Send: {0}ms Dispatch: {1}ms. Longest callback OnEv: {3}={2}ms OnResp: {5}={4}ms. Calls of Send: {6} Dispatch: {7}.", LongestDeltaBetweenSending, LongestDeltaBetweenDispatching, LongestEventCallback, LongestEventCallbackCode, LongestOpResponseCallback, LongestOpResponseCallbackOpCode, SendOutgoingCommandsCalls, DispatchCalls);
		}
	}
}
