using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaliczenie_nap.Consolei.CurrencyAPI
{

    public interface ICurrencyClient
    {
        [Get]
        Task<CurrencyApi> GetCurrencyByQuery();
    }
}
