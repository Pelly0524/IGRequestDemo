using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Models.Responses
{
    public class LoginResponse
    {
        // 登入需要token
        public string cst { get; set; } = string.Empty;
        public string xSecurityToken { get; set; } = string.Empty;

        public string AccountType { get; set; } = string.Empty;
        public AccountInfo? AccountInfo { get; set; }
        public string CurrencyIsoCode { get; set; } = string.Empty;
        public string CurrencySymbol { get; set; } = string.Empty;
        public string CurrentAccountId { get; set; } = string.Empty;
        public string LightstreamerEndpoint { get; set; } = string.Empty;
        public List<Account> Accounts { get; set; } = new List<Account>();
        public string ClientId { get; set; } = string.Empty;
        public int TimezoneOffset { get; set; }
        public bool HasActiveDemoAccounts { get; set; }
        public bool HasActiveLiveAccounts { get; set; }
        public bool TrailingStopsEnabled { get; set; }
        public object? ReroutingEnvironment { get; set; }
        public bool DealingEnabled { get; set; }
    }

    public class AccountInfo
    {
        public double Balance { get; set; }
        public double Deposit { get; set; }
        public double ProfitLoss { get; set; }
        public double Available { get; set; }
    }

    public class Account
    {
        public string AccountId { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public bool Preferred { get; set; }
        public string AccountType { get; set; } = string.Empty;
    }

}
