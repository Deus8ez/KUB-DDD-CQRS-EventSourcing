using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KUB.SharedKernel.Interfaces;

namespace KUB.Core.Models
{
    public class Participant : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassicGameRank { get; set; }
        public int? BlitzGameRank { get; set; }
        public bool CanBeAJury { get; set; }
        public ParticipantInSchool ParticipantInSchool { get; set; }
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }

        public void AddToSchool(Guid? schoolId)
        {
            if(schoolId != null)
            {
                ParticipantInSchool = new ParticipantInSchool
                {
                    SchoolId = schoolId,
                    Id = Guid.NewGuid(),
                    ParticipantId = this.Id
                };
            }
        }

        public void RemoveFromTournament(ParticipantInTournament participantInTournament)
        {
            foreach (var participant in ParticipantInTournaments)
            {
                if (participant.ParticipantId == participantInTournament.ParticipantId)
                {
                    ParticipantInTournaments.Remove(participant);
                    break;
                }
            }

            Console.WriteLine(ParticipantInTournaments.Count);
        }
    }
}
