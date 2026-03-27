using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ZadanieRekrutacyjneKONSOLA
{
    internal class CatFactResponse
    {
        // JsonPropertName przypisuje odrazu odpowiednie pola z odebranych danych do pól obiektu
        // Czyli jeśli w odpowiedzi jest obiekt "fact" to zostanie od przypisany do pola `Fact`
        [JsonPropertyName("fact")]
        public string? Fact { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
