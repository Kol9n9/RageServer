using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
namespace RageServer.AccountSystem
{
    class AuthorizationEvents : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "ShowAuthorizationCommon");
            if (AccountSystem.CheckIsSocialAccountExist(player.SocialClubId))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "ShowAuthorizationLogin");
            }
            else
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "ShowAuthorizationRegister");
            }

        }
        [RemoteEvent("AuthorizationLogin")]
        private void OnAuthorizationFormLogin(Player player, string login, string password)
        {
            if (AccountSystem.Login(player, login, password))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "AuthorizationSuccess");
                player.SendChatMessage("Вы успешно авторизовались");
            }
            else
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "AuthorizationFormError", "Логин или пароль не верный.");
            }
        }
        [RemoteEvent("AuthorizationRegister")]
        private void OnAuthorizationFormRegister(Player player, string login, string password)
        {
            if (AccountSystem.CheckIsAccountExist(login))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "AuthorizationFormError", "Данный аккаунт уже зарегистрирован");
                return;
            }
            if (AccountSystem.Register(player, player.SocialClubId, login, password))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "AuthorizationSuccess");
                player.SendChatMessage("Вы успешно зарегистрировались");
            }
            else
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "AuthorizationFormError", "Во время регистрации произошла ошибка");
            }
        }
    }
}
