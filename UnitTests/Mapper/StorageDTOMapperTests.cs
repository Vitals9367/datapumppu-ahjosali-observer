﻿using MeetingRoomObserver.Handler.DTOs;
using MeetingRoomObserver.Mapper;
using MeetingRoomObserver.Models;
using MeetingRoomObserver.StorageClient.DTOs;
using Moq;
using Xunit;

namespace UnitTests.Mapper
{
    public class StorageDTOMapperTests
    {

        [Fact]
        public void CaseEvent()
        {
            var eventTypeMapper = new Mock<IMeetingEventTypeMapper>();
            var voteTypeMapper = new Mock<IVoteTypeMapper>();
            var votingTypeMapper = new Mock<IVotingTypeMapper>();
            var speechTypeMapper = new Mock<ISpeechTypeMapper>();
            var storageMapper = new StorageDTOMapper(
                eventTypeMapper.Object, voteTypeMapper.Object, votingTypeMapper.Object, speechTypeMapper.Object);

            var meetingEventList = new MeetingEventList
            {
                State = new StateQueryDTO
                {
                    MeetingTitleFI = "Fin Title",
                    MeetingTitleSV = "Sv Title",
                    CaseNumber = "64",
                    ItemNumber = "2"
                },
                Events = new List<EventDTO>
                {
                    new CaseRoomEventDTO
                    {
                        EventType = EventTypeDTOConstants.Case,
                        SequenceNumber = 1,
                        Timestamp= DateTime.Now,
                        PropositionFI = "Prop FI",
                        PropositionSV = "Prop SV",
                        Id = "1",
                        TextFI = "Text FI",
                        TextSV = "Text SV",
                    }
                },
                MeetingID = "2015/21 2019-12-11 15:56:19.358",
            };

            var result = storageMapper.MapToStorageDTOs(meetingEventList);

            Assert.Single(result);

            var resultEvent = result[0] as StorageCaseEventDTO;
            Assert.NotNull(resultEvent);
            Assert.Equal("Prop FI", resultEvent.PropositionFI);
            Assert.Equal("Prop SV", resultEvent.PropositionSV);
            Assert.Equal("64", resultEvent.CaseNumber);
            Assert.Equal("2", resultEvent.ItemNumber);
            Assert.Equal("02900201521", resultEvent.MeetingID);
        }

        [Fact]
        public void MeetingStartEvent()
        {
            var eventTypeMapper = new Mock<IMeetingEventTypeMapper>();
            var voteTypeMapper = new Mock<IVoteTypeMapper>();
            var votingTypeMapper = new Mock<IVotingTypeMapper>();
            var speechTypeMapper = new Mock<ISpeechTypeMapper>();
            var storageMapper = new StorageDTOMapper(
                eventTypeMapper.Object, voteTypeMapper.Object, votingTypeMapper.Object, speechTypeMapper.Object);

            var meetingEventList = new MeetingEventList
            {
                State = new StateQueryDTO
                {
                    MeetingTitleFI = "Fin Title",
                    MeetingTitleSV = "Sv Title",
                    CaseNumber = "2",
                    ItemNumber = "3",
                    SequenceNumber = 43423423

                },
                Events = new List<EventDTO>
                {
                    new MeetingStartsRoomEventDTO
                    {
                        EventType = EventTypeDTOConstants.MeetingStarts,
                        SequenceNumber = 1,
                        Timestamp= DateTime.Now,
                    }
                },
                MeetingID = "2015/21 2019-12-11 15:56:19.358",
            };

            var result = storageMapper.MapToStorageDTOs(meetingEventList);

            Assert.Single(result);

            var resultEvent = result[0] as StorageMeetingStartedEventDTO;
            Assert.NotNull(resultEvent);
            Assert.Equal("Fin Title", resultEvent.MeetingTitleFI);
            Assert.Equal("Sv Title", resultEvent.MeetingTitleSV);
            Assert.Equal("02900201521", resultEvent.MeetingID);
        }

        [Fact]
        public void FloorReservationEvent()
        {
            var eventTypeMapper = new Mock<IMeetingEventTypeMapper>();
            var voteTypeMapper = new Mock<IVoteTypeMapper>();
            var votingTypeMapper = new Mock<IVotingTypeMapper>();
            var speechTypeMapper = new Mock<ISpeechTypeMapper>();
            var storageMapper = new StorageDTOMapper(
                eventTypeMapper.Object, voteTypeMapper.Object, votingTypeMapper.Object, speechTypeMapper.Object);

            var meetingEventList = new MeetingEventList
            {
                State = new StateQueryDTO
                {
                    MeetingTitleFI = "Fin Title",
                    MeetingTitleSV = "Sv Title"
                },
                Events = new List<EventDTO>
                {
                    new FloorReservationRoomEventDTO
                    {
                        EventType = EventTypeDTOConstants.FloorReservation,
                        SequenceNumber = 1,
                        Timestamp= DateTime.Now,
                        Ordinal = 64,
                        PersonFI = "Kalle /SDP",
                        PersonSV = "Kalle (pormestari)"
                    }
                },
                MeetingID = "2015/21 2019-12-11 15:56:19.358",
            };

            var result = storageMapper.MapToStorageDTOs(meetingEventList);

            var resultEvent = result[0] as StorageSpeakingTurnReservationEventDTO;
            Assert.NotNull(resultEvent);
            Assert.Equal("02900201521", resultEvent.MeetingID);
            //Assert.Equal("Kalle", resultEvent.Person);
            //Assert.Equal("SDP", resultEvent.AdditionalInfoFI);
            //Assert.Equal("pormestari", resultEvent.AdditionalInfoSV);
            Assert.Equal(64, resultEvent.Ordinal);
        }
    }
}
