using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
namespace RageServer.AccountSystem
{
    class AccountEvents : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            if (AccountSystem.CheckIsAccountExist(player.Name))
            {
                player.SendChatMessage("Вы зарегистрированы. Введите /login password");
            }
            else
            {
                player.SendChatMessage("Вы не зарегистрированы. Введите /register password");
            }
        }
        [Command("login")]
        private void OnLoginCommand(Player player, string password)
        {
            if (AccountSystem.CheckIsAccountLogged(player))
            {
                player.SendChatMessage("Вы уже авторизованы");
                return;
            }
            if (AccountSystem.Login(player, player.Name, password))
            {
                player.SendChatMessage("Вы успешно авторизовались");
            } 
            else
            {
                player.SendChatMessage("Логин или пароль не верный. Попробуйте снова");
            }
        }
        [Command("register")]
        private void OnRegisterCommand(Player player, string password)
        {
            if (AccountSystem.CheckIsAccountLogged(player))
            {
                player.SendChatMessage("Вы уже авторизованы");
                return;
            }
            if (AccountSystem.CheckIsAccountExist(player.Name))
            {
                player.SendChatMessage("Данный аккаунт уже зарегистрирован");
                return;
            }
            if (AccountSystem.Register(player, player.Name, password))
            {
                player.SendChatMessage("Вы успешно зарегистрировались и авторизовались");
            }
            else
            {
                player.SendChatMessage("Во время регистрации произошла ошибка");
            }
        }
    }
}
