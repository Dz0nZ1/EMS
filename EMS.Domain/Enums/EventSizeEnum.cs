using Ardalis.SmartEnum;

namespace EMS.Domain.Enums;

public abstract class EventSizeEnum : SmartEnum<EventSizeEnum>
{
    
    public abstract int MaxNumberOfPeople { get; }
    public abstract string Description { get; }

    public abstract List<EventSizeEnum> SubEvents { get; }
    
    
    protected EventSizeEnum(string name, int value) : base(name, value)
    {
    }

    #region Main

    public static EventSizeEnum Small = new SmallEventSizeEnum();
    public static EventSizeEnum Medium = new MediumEventSizeEnum();
    public static EventSizeEnum Big = new BigEventSizeEnum();
    
    private sealed class SmallEventSizeEnum : EventSizeEnum
    {
        public SmallEventSizeEnum() : base(nameof(Small), 1)
        {
        }

        public override int MaxNumberOfPeople => 25;

        public override string Description => "Small event";
        public override List<EventSizeEnum> SubEvents => [Networking, Discussion, Workshop];
    }
    
    
    private sealed class MediumEventSizeEnum : EventSizeEnum
    {
        public MediumEventSizeEnum() : base(nameof(Medium), 2)
        {
        }

        public override int MaxNumberOfPeople => 50;

        public override string Description => "Medium event";
        public override List<EventSizeEnum> SubEvents => [Speech, Debate, Demonstration];
    }
    
    
    private sealed class BigEventSizeEnum : EventSizeEnum
    {
        public BigEventSizeEnum() : base(nameof(Big), 3)
        {
        }

        public override int MaxNumberOfPeople => 100;

        public override string Description => "Big event";
        public override List<EventSizeEnum> SubEvents => [Hackathon, Auction, Celebration];
    }
    
    
    
    
    
    

    #endregion

    #region SmallEvent

    public static EventSizeEnum Networking = new NetworkingEventSizeEnum();
    public static EventSizeEnum Discussion = new DiscussionEventSizeEnum();
    public static EventSizeEnum Workshop = new WorkshopEventSizeEnum();
    
    private sealed class NetworkingEventSizeEnum : EventSizeEnum
    {
        public NetworkingEventSizeEnum() : base(nameof(Networking), 11)
        {
        }

        public override int MaxNumberOfPeople => 25;
        public override string Description => "Networking event";
        public override List<EventSizeEnum> SubEvents => [Small];
    }
    
    
    private sealed class DiscussionEventSizeEnum : EventSizeEnum
    {
        public DiscussionEventSizeEnum() : base(nameof(Discussion), 12)
        {
        }

        public override int MaxNumberOfPeople => 25;
        public override string Description => "Discussion event";
        public override List<EventSizeEnum> SubEvents => [Small];
    }
    
    
    private sealed class WorkshopEventSizeEnum : EventSizeEnum
    {
        public WorkshopEventSizeEnum() : base(nameof(Workshop), 13)
        {
        }

        public override int MaxNumberOfPeople => 25;
        public override string Description => "Workshop event";
        public override List<EventSizeEnum> SubEvents => [Small];
    }
    
    

    #endregion

    #region MediumEvents
    
    
    #region MediumEvent
    
    public static EventSizeEnum Speech = new SpeechEventSizeEnum();
    public static EventSizeEnum Debate = new DebateEventSizeEnum();
    public static EventSizeEnum Demonstration = new DemonstrationEventSizeEnum();
    
    #endregion

    private sealed class SpeechEventSizeEnum : EventSizeEnum
    {
        public SpeechEventSizeEnum() : base(nameof(Speech), 21)
        {
        }

        public override int MaxNumberOfPeople => 50;
        public override string Description => "Speech event";
        public override List<EventSizeEnum> SubEvents => [Medium];
    }
    
    private sealed class DebateEventSizeEnum : EventSizeEnum
    {
        public DebateEventSizeEnum() : base(nameof(Debate), 22)
        {
        }

        public override int MaxNumberOfPeople => 50;
        public override string Description => "Debate event";
        public override List<EventSizeEnum> SubEvents => [Medium];
    }
    
    private sealed class DemonstrationEventSizeEnum : EventSizeEnum
    {
        public DemonstrationEventSizeEnum() : base(nameof(Demonstration), 23)
        {
        }

        public override int MaxNumberOfPeople => 50;
        public override string Description => "Demonstration event";
        public override List<EventSizeEnum> SubEvents => [Medium];
    }

    #endregion

    #region BigEvents
    
    public static EventSizeEnum Hackathon = new HackathonEventSizeEnum();
    public static EventSizeEnum Auction = new AuctionEventSizeEnum();
    public static EventSizeEnum Celebration = new CelebrationEventSizeEnum();
    
    private sealed class HackathonEventSizeEnum : EventSizeEnum
    {
        public HackathonEventSizeEnum() : base(nameof(Hackathon), 31)
        {
        }

        public override int MaxNumberOfPeople => 100;
        public override string Description => "Hackathon event";
        public override List<EventSizeEnum> SubEvents => [Big];
    }
    
    private sealed class AuctionEventSizeEnum : EventSizeEnum
    {
        public AuctionEventSizeEnum() : base(nameof(Auction), 32)
        {
        }

        public override int MaxNumberOfPeople => 100;
        public override string Description => "Auction event";
        public override List<EventSizeEnum> SubEvents => [Big];
    }
    
    private sealed class CelebrationEventSizeEnum : EventSizeEnum
    {
        public CelebrationEventSizeEnum() : base(nameof(Celebration), 33)
        {
        }

        public override int MaxNumberOfPeople => 100;
        public override string Description => "Celebration event";
        public override List<EventSizeEnum> SubEvents => [Big];
    }


    #endregion
    
}