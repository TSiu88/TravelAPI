using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelApi.Entities;
using TravelApi.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace TravelApi.Services
{
  public interface IAuthenticateService
  {
    bool IsAuthenticated(TokenRequest request, out string token);
    bool UserIsValid(string username, string password);
  }

  public class TokenAuthenticationService : IAuthenticateService
  {
    private readonly IUserManagementService _userManagementService;
    private readonly TokenManagement _tokenManagement;
        
    public TokenAuthenticationService(IUserManagementService service, IOptions<TokenManagement> tokenManagement)
    {
        _userManagementService = service;
        _tokenManagement = tokenManagement.Value;
    }

    public bool IsAuthenticated(TokenRequest request, out string token)
    {
      token = string.Empty;
      if (!_userManagementService.IsValidUser(request.Username, request.Password)) return false;
      var claim = new[]
      {
        new Claim (ClaimTypes.Name, request.Username)
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var jwtToken = new JwtSecurityToken(
        issuer: _tokenManagement.Issuer,
        audience: _tokenManagement.Audience,
        claims: claim,
        expires:DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
        signingCredentials: credentials
      );
      token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
      HttpClient client = new HttpClient();
      // client.BaseAddress = new Uri(_tokenManagement.Issuer);
      // var contentType = new MediaTypeWithQualityHeaderValue
      // ("application/json");
      // client.DefaultRequestHeaders.Accept.Add(contentType);
      //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      //Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("bearer", token));
      return true;
    }

    public bool UserIsValid (string username, string password)
    {
      return _userManagementService.IsValidUser(username, password);
    }
  }
}