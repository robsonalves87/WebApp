﻿using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var usuario = BaseUsuarios
                .Usuarios()
                .FirstOrDefault(x => x.Nome == context.UserName &&
                                     x.Senha == context.Password);

            if(usuario == null)
            {
                context.SetError("invalid_grant", "Usuário não encontranho ou senha incorreta");
            }
            else
            {
                var identidadeUsuario = new ClaimsIdentity(context.Options.AuthenticationType);
                context.Validated(identidadeUsuario);
            }


        }
    }
}