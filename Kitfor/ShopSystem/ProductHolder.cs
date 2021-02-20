using System;
using UnityEngine;
using UnityEngine.UI;

public class ProductHolder : MonoBehaviour
{
    public int m_cost = 1;
    public CostType m_costType = CostType.Coins;
    public RewardType m_rewardType;
    private readonly IShopTransactions _shopTransactions = new ShopTransactionsHolder(  );
    private Button _button;

    private void Awake( )
    {
        _button = GetComponentInChildren<Button>( );
        _button.onClick.AddListener(StartTransaction);
    }

    private void StartTransaction( )
    {
        _shopTransactions.StartTransaction(this);
    }
}
