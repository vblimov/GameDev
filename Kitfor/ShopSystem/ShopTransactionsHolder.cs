using System;
using System.Collections.Generic;
using System.Linq;

public class ShopTransactionsHolder : IShopTransactions
{
    void IShopTransactions.StartTransaction( ProductHolder product )
    {
        if ( !CalculateTransactionPossibility( product ) )
        {
            return;
        }
        CalculateTransaction(product);
        GiveReward( product );
    }

    private static bool CalculateTransactionPossibility( ProductHolder product )
    {
        switch ( product.m_costType )
        {
            case CostType.Coins:
                return 
                    GameStats.GetInstance()
                    .m_gameData
                    .GetStat( StatType.Coins )
                           .CompareTo( product.m_cost ) > 0;
            case CostType.Gems:
                return GameStats.GetInstance()
                    .m_gameData
                    .GetStat( StatType.Gems )
                    .CompareTo( product.m_cost ) > 0;
            case CostType.Ad:
                return true;
                //TODO if we have AD to show - return true
            case CostType.Money:
                //TODO here will be real money transactions
                return false;
            default:
                throw new ArgumentOutOfRangeException( );
        }
    }

    private static void CalculateTransaction( ProductHolder product)
    {
        switch ( product.m_costType )
        {
            case CostType.Coins:
                GameStats.GetInstance().ChangeCoins(-product.m_cost);
                break;
            case CostType.Gems:
                GameStats.GetInstance().ChangeGems(-product.m_cost);
                break;
            case CostType.Ad:
                break;
                //TODO if we have AD to show - show
            case CostType.Money:
                break;
                //TODO here will be real money transactions
            default:
                throw new ArgumentOutOfRangeException( );
        }
    }

    private static void GiveReward( ProductHolder product )
    {
        var rewards = GetFlags( product.m_rewardType );
        foreach ( var reward in rewards )
        {
            reward.CallBack( )?.Invoke();
        }
    }
    private static IEnumerable<RewardType> GetFlags(Enum e)
    {
        return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag).Cast<RewardType>();
    }


}
