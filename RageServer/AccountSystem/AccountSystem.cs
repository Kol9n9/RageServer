using GTANetworkAPI;
using RageServer.Data.Models;
using RageServer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageServer.AccountSystem
{
    public static class AccountSystem
    {
        public static List<Account> AccountList { get; } = new List<Account>();
        private static AccountRepository accountRepository = new AccountRepository();
        private static SocialAccountRepository socialAccountRepository = new SocialAccountRepository();
        public static bool CheckIsAccountExist(string Nickname)
        {
            return accountRepository.IsExist(x => x.Nickname == Nickname);
        }
        public static bool CheckIsAccountLogged(Player GamePlayer)
        {
            return GamePlayer.GetOwnSharedData<int?>("ID").HasValue;
        }
        public static Account GetAccount(Player GamePlayer)
        {
            int ID = GamePlayer.GetOwnSharedData<int?>("ID").Value;
            return AccountList.Find(x => x.Id == ID);
        }
        public static bool Login(Player GamePlayer, string Nickname, string Password)
        {
            var account = accountRepository.Get(x => x.Nickname == Nickname && x.Password == Password);
            if (account == null) return false;
            GamePlayer.SetOwnSharedData("ID", account.AccountId);
            AccountList.Add(new Account(account.AccountId, -1, GamePlayer)
            {
                Nickname = account.Nickname,
                Money = account.Money
            });
            return true;
        }
        public static bool Register(Player GamePlayer, ulong SocialId,  string Nickname, string Password)
        {
            var socialAccount = new SocialAccountModel
            {
                SocialId = SocialId
            };
            socialAccountRepository.Add(socialAccount);
            var account = new AccountModel
            {
                Nickname = Nickname,
                Password = Password,
                SocialAccountId = socialAccount.SocialAccountId
            };
            accountRepository.Add(account);
            return Login(GamePlayer, Nickname, Password);
        }
        public static bool CheckIsSocialAccountExist(ulong socialId)
        {
            return socialAccountRepository.IsExist(x => x.SocialId == socialId);
        }
    }
}
