﻿using Newtonsoft.Json;

namespace MeetingRoomObserver.Handler.DTOs
{
    public class CaseEventRoomDTO : EventDTO
    {
        [JsonProperty("paatosehdotus")]
        public string PropositionFI { get; set; } = string.Empty;

        [JsonProperty("paatosehdotus_sv")]
        public string PropositionSV { get; set; } = string.Empty;

        [JsonProperty("asianumero")]
        public string CaseNumber { get; set; } = string.Empty;

        [JsonProperty("kohtanumero")]
        public string ItemNumber { get; set; } = string.Empty;

        [JsonProperty("asiateksti")]
        public string TextFI { get; set; } = string.Empty;

        [JsonProperty("asiateksti_sv")]
        public string TextSV { get; set; } = string.Empty;

        [JsonProperty("tunniste")]
        public string Id { get; set; } = string.Empty;
    }
}
