/*
 Copyright (c) 2024 HigginsSoft, Alexander Higgins - https://github.com/alexhiggins732/ 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code and license this software can be found 

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
*/

using IdentityServer8.Models;

namespace IdentityServer8.EntityFramework.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for clients.
    /// </summary>
    public static class ClientMappers
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.Client ToModel(this Entities.Client entity)
        {
            if (entity == null) return null;

            return new Models.Client
            {
                Enabled = entity.Enabled,
                ClientId = entity.ClientId,
                ProtocolType = entity.ProtocolType,
                ClientSecrets = entity.ClientSecrets?.Select(s => new Secret
                {
                    Description = s.Description,
                    Value = s.Value,
                    Expiration = s.Expiration,
                    Type = s.Type
                }).ToHashSet() ?? new HashSet<Secret>(),
                RequireClientSecret = entity.RequireClientSecret,
                ClientName = entity.ClientName,
                Description = entity.Description,
                ClientUri = entity.ClientUri,
                LogoUri = entity.LogoUri,
                RequireConsent = entity.RequireConsent,
                AllowRememberConsent = entity.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = entity.AlwaysIncludeUserClaimsInIdToken,
                AllowedGrantTypes = entity.AllowedGrantTypes?.Select(g => g.GrantType).ToList() ?? new List<string>(),
                RequirePkce = entity.RequirePkce,
                AllowPlainTextPkce = entity.AllowPlainTextPkce,
                RequireRequestObject = entity.RequireRequestObject,
                AllowAccessTokensViaBrowser = entity.AllowAccessTokensViaBrowser,
                RedirectUris = entity.RedirectUris?.Select(r => r.RedirectUri).ToHashSet() ?? new HashSet<string>(),
                PostLogoutRedirectUris = entity.PostLogoutRedirectUris?.Select(r => r.PostLogoutRedirectUri).ToHashSet() ?? new HashSet<string>(),
                FrontChannelLogoutUri = entity.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = entity.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = entity.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = entity.BackChannelLogoutSessionRequired,
                AllowOfflineAccess = entity.AllowOfflineAccess,
                AllowedScopes = entity.AllowedScopes?.Select(s => s.Scope).ToHashSet() ?? new HashSet<string>(),
                IdentityTokenLifetime = entity.IdentityTokenLifetime,
                AllowedIdentityTokenSigningAlgorithms = ApiResourceMappers.StringToSigningAlgorithms(entity.AllowedIdentityTokenSigningAlgorithms),
                AccessTokenLifetime = entity.AccessTokenLifetime,
                AuthorizationCodeLifetime = entity.AuthorizationCodeLifetime,
                ConsentLifetime = entity.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = entity.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = entity.SlidingRefreshTokenLifetime,
                RefreshTokenUsage = (TokenUsage)entity.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = entity.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = (TokenExpiration)entity.RefreshTokenExpiration,
                AccessTokenType = (AccessTokenType)entity.AccessTokenType,
                EnableLocalLogin = entity.EnableLocalLogin,
                IdentityProviderRestrictions = entity.IdentityProviderRestrictions?.Select(r => r.Provider).ToHashSet() ?? new HashSet<string>(),
                IncludeJwtId = entity.IncludeJwtId,
                Claims = entity.Claims?.Select(c => new ClientClaim(c.Type, c.Value, ClaimValueTypes.String)).ToHashSet() ?? new HashSet<ClientClaim>(),
                AlwaysSendClientClaims = entity.AlwaysSendClientClaims,
                ClientClaimsPrefix = entity.ClientClaimsPrefix,
                PairWiseSubjectSalt = entity.PairWiseSubjectSalt,
                AllowedCorsOrigins = entity.AllowedCorsOrigins?.Select(o => o.Origin).ToHashSet() ?? new HashSet<string>(),
                Properties = entity.Properties?.ToDictionary(p => p.Key, p => p.Value) ?? new Dictionary<string, string>(),
                UserSsoLifetime = entity.UserSsoLifetime,
                UserCodeType = entity.UserCodeType,
                DeviceCodeLifetime = entity.DeviceCodeLifetime
            };
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.Client ToEntity(this Models.Client model)
        {
            if (model == null) return null;

            return new Entities.Client
            {
                Enabled = model.Enabled,
                ClientId = model.ClientId,
                ProtocolType = model.ProtocolType,
                ClientSecrets = model.ClientSecrets?.Select(s => new Entities.ClientSecret
                {
                    Description = s.Description,
                    Value = s.Value,
                    Expiration = s.Expiration,
                    Type = s.Type
                }).ToList() ?? new List<Entities.ClientSecret>(),
                RequireClientSecret = model.RequireClientSecret,
                ClientName = model.ClientName,
                Description = model.Description,
                ClientUri = model.ClientUri,
                LogoUri = model.LogoUri,
                RequireConsent = model.RequireConsent,
                AllowRememberConsent = model.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
                AllowedGrantTypes = model.AllowedGrantTypes?.Select(g => new Entities.ClientGrantType { GrantType = g }).ToList() ?? new List<Entities.ClientGrantType>(),
                RequirePkce = model.RequirePkce,
                AllowPlainTextPkce = model.AllowPlainTextPkce,
                RequireRequestObject = model.RequireRequestObject,
                AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
                RedirectUris = model.RedirectUris?.Select(r => new Entities.ClientRedirectUri { RedirectUri = r }).ToList() ?? new List<Entities.ClientRedirectUri>(),
                PostLogoutRedirectUris = model.PostLogoutRedirectUris?.Select(r => new Entities.ClientPostLogoutRedirectUri { PostLogoutRedirectUri = r }).ToList() ?? new List<Entities.ClientPostLogoutRedirectUri>(),
                FrontChannelLogoutUri = model.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = model.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
                AllowOfflineAccess = model.AllowOfflineAccess,
                AllowedScopes = model.AllowedScopes?.Select(s => new Entities.ClientScope { Scope = s }).ToList() ?? new List<Entities.ClientScope>(),
                IdentityTokenLifetime = model.IdentityTokenLifetime,
                AllowedIdentityTokenSigningAlgorithms = ApiResourceMappers.SigningAlgorithmsToString(model.AllowedIdentityTokenSigningAlgorithms),
                AccessTokenLifetime = model.AccessTokenLifetime,
                AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
                ConsentLifetime = model.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
                RefreshTokenUsage = (int)model.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = (int)model.RefreshTokenExpiration,
                AccessTokenType = (int)model.AccessTokenType,
                EnableLocalLogin = model.EnableLocalLogin,
                IdentityProviderRestrictions = model.IdentityProviderRestrictions?.Select(r => new Entities.ClientIdPRestriction { Provider = r }).ToList() ?? new List<Entities.ClientIdPRestriction>(),
                IncludeJwtId = model.IncludeJwtId,
                Claims = model.Claims?.Select(c => new Entities.ClientClaim { Type = c.Type, Value = c.Value }).ToList() ?? new List<Entities.ClientClaim>(),
                AlwaysSendClientClaims = model.AlwaysSendClientClaims,
                ClientClaimsPrefix = model.ClientClaimsPrefix,
                PairWiseSubjectSalt = model.PairWiseSubjectSalt,
                AllowedCorsOrigins = model.AllowedCorsOrigins?.Select(o => new Entities.ClientCorsOrigin { Origin = o }).ToList() ?? new List<Entities.ClientCorsOrigin>(),
                Properties = model.Properties?.Select(p => new Entities.ClientProperty { Key = p.Key, Value = p.Value }).ToList() ?? new List<Entities.ClientProperty>(),
                UserSsoLifetime = model.UserSsoLifetime,
                UserCodeType = model.UserCodeType,
                DeviceCodeLifetime = model.DeviceCodeLifetime
            };
        }
    }
}
