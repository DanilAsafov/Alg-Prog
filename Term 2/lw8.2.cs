using System;
using System.Collections.Generic;
using System.Linq;

public class Participant(string name, double currentSpeed) {
    public string name = name;
    public double currentSpeed = currentSpeed;
    public double distanceCovered = 0;
    private bool hasFinished = false;

    public void UpdateSpeed(Random random) {
        currentSpeed = random.Next(1, 51);
    }

    public void Move(double timeInterval, double finishLine) {
        if (!hasFinished) {
            distanceCovered += currentSpeed * timeInterval;
            if (distanceCovered >= finishLine) {
                hasFinished = true;
                Finished?.Invoke(this);
            }
        }
    }

    public delegate void FinishHandler(Participant participant);
    public event FinishHandler Finished;
}


public class Race(double finishLine, double timeInterval) {
    public double finishLine = finishLine;
    public double timeInterval = timeInterval;
    public List<Participant> participants = [];
    
    private List<Participant> winners = [];

    public void AddParticipant(Participant participant) {
        participant.Finished += OnParticipantFinished;
        participants.Add(participant);
    }

    private void OnParticipantFinished(Participant participant) {
        if (!winners.Contains(participant)) {
            winners.Add(participant);
        }
    }

    public void Run() {
        Random random = new();
        bool raceFinished = false;

        while (!raceFinished) {
            winners.Clear();
            
            foreach (var participant in participants) {
                participant.Move(timeInterval, finishLine);
            }

            if (winners.Count > 0) {
                raceFinished = true;
                Console.WriteLine("Гонка завершена. Победители:");
                foreach (var winner in winners.OrderBy(i => i.name)) {
                    Console.WriteLine($"{winner.name} - пройдено: {winner.distanceCovered}");
                }
            } else {
                foreach (var participant in participants) {
                    participant.UpdateSpeed(random);
                }
            }
        }
    }
}


class Program {
    static void Main() {
        Race race = new(200, 2);
        
        Participant p1 = new("Участник 1", 10);
        Participant p2 = new("Участник 2", 12);
        Participant p3 = new("Участник 3", 15);

        race.AddParticipant(p1);
        race.AddParticipant(p2);
        race.AddParticipant(p3);

        race.Run();
    }
}