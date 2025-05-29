namespace XsdSettings
{
	public class KeyBindingItem
	{
		private ControlAction mControlActionField;

		private KeyboardCode mPrimaryKeyField;

		private KeyboardCode mSecondaryKeyField;

		public ControlAction mControlAction { get; set; }

		public KeyboardCode mPrimaryKey { get; set; }

		public KeyboardCode mSecondaryKey { get; set; }
	}
}
