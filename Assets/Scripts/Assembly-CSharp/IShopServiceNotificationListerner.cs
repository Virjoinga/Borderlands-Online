public interface IShopServiceNotificationListerner
{
	void OnBuyItem(ItemDNA itemDna);

	void OnGetShop(Shop shop);

	void OnGetSoldItems(Shop soldItems);

	void OnSellItem(int newBondCurrency);

	void OnRedeemItem(ItemDNA item);
}
