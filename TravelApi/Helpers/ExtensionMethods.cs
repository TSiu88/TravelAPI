using System.Collections.Generic;
using System.Linq;
using TravelApi.Entities;

namespace TravelApi.Helpers
{
  public static class ExtensionMethods
  {
    public static IEnumerable<TokenRequest> WithoutPasswords(this IEnumerable<TokenRequest> tokenRequests)
    {
     return tokenRequests.Select(x => x.WithoutPassword());
    }

    public static TokenRequest WithoutPassword(this TokenRequest tokenRequest)
    {
      tokenRequest.Password = null;
      return tokenRequest;
    }
  }
  
}