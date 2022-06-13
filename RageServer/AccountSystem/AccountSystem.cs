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
        private static AccountRepository repository = new AccountRepository();
        public static bool CheckIsAccountExist(string Nickname)
        {
            return repository.IsExist(x => x.Nickname.Equals(Nickname));
        }
        public static bool CheckIsAccountLogged(Player GamePlayer)
        {
            return GamePlayer.GetOwnSharedData<int?>("ID").HasValue;
        }
        public static bool Login(Player GamePlayer, string Nickname, string Password)
        {
            var account = repository.Get(x => x.Nickname.Equals(Nickname) && x.Password.Equals(Password));
            if (account == null) return false;
            GamePlayer.SetOwnSharedData("ID", account.Id);
            AccountList.Add(new Account(account.Id, -1, GamePlayer)
            {
                Nickname = account.Nickname,
                Money = account.Money
            });
            return true;
        }
        public static bool Register(Player GamePlayer, string Nickname, string Password)
        {
            var account = new AccountModel
            {
                Nickname = Nickname,
                Password = Password
            };
            repository.Add(account);
            return Login(GamePlayer, Nickname, Password);
        }
    }
}
