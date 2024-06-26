﻿using CMMTS.Domain.Enums;

namespace CMMTS.Application.Messaging.Requests
{
    public class CadastrarRotaRequest
    {
        public string PlaceIdOrigem { get; set; }
        public string PlaceIdDestino { get; set; }
        public string TipoRota { get; set; }
        public DateTime DataRota { get; set; }
    }
}
