using System;
using System.Collections.Generic;
using System.Text;

namespace ZadanieRekrutacyjneKONSOLA
{
    internal interface ICatFactFetcher
    {
        Task<CatFactResponse> ConnectAsync();
    }
}
