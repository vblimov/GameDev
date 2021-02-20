    using System;
    using UnityEngine;
    //TODO Check values in ENUM and actions in switch if u change smth
    public static class RewardEnumExtension
    {
        public static Action CallBack( this RewardType rewardEnum)
        {
            switch ( rewardEnum )
            {
                case RewardType.Nothing:
                    break;
                case RewardType.Everything:
                    break;
                case RewardType.Coins500:
                    return ( ) => GameStats.GetInstance().ChangeCoins(500);
                case RewardType.Coins1000:
                    return ( ) => GameStats.GetInstance().ChangeCoins(1000);
                case RewardType.Coins2500:
                    return ( ) => GameStats.GetInstance().ChangeCoins(2500);
                case RewardType.Coins5000:
                    return ( ) => GameStats.GetInstance().ChangeCoins(5000);
                case RewardType.Coins10000:
                    return ( ) => GameStats.GetInstance().ChangeCoins(10000);
                case RewardType.Gems500:
                    return ( ) => GameStats.GetInstance().ChangeGems(500);
                case RewardType.Gems1000:
                    return ( ) => GameStats.GetInstance().ChangeGems(1000);
                case RewardType.Gems2500:
                    return ( ) => GameStats.GetInstance().ChangeGems(2500);
                case RewardType.Gems5000:
                    return ( ) => GameStats.GetInstance().ChangeGems(5000);
                case RewardType.Gems10000:
                    return ( ) => GameStats.GetInstance().ChangeGems(10000);
                case RewardType.EnergyMax:
                    return ( ) => GameStats.GetInstance().ChangeEnergy(
                        GameStats.GetInstance().m_gameData.GetMaxEnergy()
                        -GameStats.GetInstance().m_gameData.GetStat(StatType.Energy)
                        );
                case RewardType.LegendaryWeapon:
                    return ( ) => Inventory.GetInstance().AddItem(ItemGenerator.GenerateAssetItem( ItemType.Weapon, ItemRarity.Legendary ));
                case RewardType.LegendaryArmor:
                    return ( ) => Inventory.GetInstance().AddItem(ItemGenerator.GenerateAssetItem( ItemType.Armor, ItemRarity.Legendary ));
                default:
                    throw new ArgumentOutOfRangeException( nameof(rewardEnum), rewardEnum, null );
            }
            return null;
        }
    }
    [Flags]
    public enum RewardType 
    {
        Nothing = 0,
        Everything = ~0,
        Coins500= 1 << 0,
        Coins1000 = 1 << 1,
        Coins2500 = 1 << 2,
        Coins5000 = 1 << 3,
        Coins10000 = 1 << 4,
        Gems500 = 1 << 5,
        Gems1000 = 1 << 6,
        Gems2500 = 1 << 7,
        Gems5000 = 1 << 8,
        Gems10000 = 1 << 9,
        EnergyMax = 1 << 10,
        LegendaryWeapon = 1 << 11,
        LegendaryArmor = 1 << 12
            
    }
    
    
    
