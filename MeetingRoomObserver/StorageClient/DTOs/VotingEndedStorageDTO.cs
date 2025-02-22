﻿namespace MeetingRoomObserver.StorageClient.DTOs
{
    public class VotingEndedStorageDTO : StorageEventDTO
    {
        public VotingEndedStorageDTO()
        {
            EventType = StorageClient.StorageEventType.VotingStarted;
        }

        public int VotingType { get; set; }

        public string? VotingTypeText { get; set; }

        public string? ForText { get; set; }

        public string? ForTitle { get; set; }

        public string? AgainstText { get; set; }

        public string? AgainstTitle { get; set; }

        public int? VotesFor { get; set; }

        public int? VotesAgainst { get; set; }

        public int? VotesEmpty { get; set; }

        public int? VotesAbsent { get; set; }

        public List<VoteStorageDTO>? Votes { get; set; }


    }
}
